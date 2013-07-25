﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Xml;
using Atlantis.Framework.MessagingProcess.Interface;
using Atlantis.Framework.PurchaseEmail.Interface.Providers;
using Atlantis.Framework.Providers.Interface.Links;
using Atlantis.Framework.Providers.ProviderContainer.Impl;
using Atlantis.Framework.GetPaymentProfileAlternate.Interface;
using Atlantis.Framework.GetPaymentProfiles.Interface;
using Atlantis.Framework.Interface;
using System.IO;

namespace Atlantis.Framework.PurchaseEmail.Interface.Emails
{
  internal class GDConfirmationEmail : PurchaseConfirmationEmailBase
  {
    private int engineGetPaymentProfileAlternateId = 381;
    private int engineGetPaymentProfiles = 59;

    private bool _isAZHumane;
    private bool _isDevServer;
    private RequestData _requestData;

    public GDConfirmationEmail(OrderData orderData, EmailRequired emailRequired, bool isAZHumane, bool isDevServer, RequestData rd, ObjectProviderContainer objectContainer)
      : base(orderData, emailRequired,objectContainer)
    {
      _isAZHumane = isAZHumane;
      _isDevServer = isDevServer;
      _requestData = rd;
    }

    protected override void SetParams()
    {
      SetParam(EmailTokenNames.OrderId, Order.OrderId);

      if (EmailTemplate.Id == EmailTemplateType.OrderConfirmation || EmailTemplate.Id == EmailTemplateType.GDWelcome)
      {
        string xmlParam;
        using (var ms = new MemoryStream())
        {
          Order.OrderXmlDoc.Save(ms);
          xmlParam = String.Concat("<?xml version=\"1.0\" encoding=\"utf-16\"?>", Encoding.Default.GetString(ms.ToArray()) );
          ms.Close();
        }

        SetParam(EmailTokenNames.CartXml, xmlParam, AttributeValueWriteMethod.CDataBlock);

        SetParam(EmailTokenNames.ItemsText, GetEulaBlock());
      }
      else
      {
        SetParam(EmailTokenNames.ItemsText, GetItemsText());
      }
      SetParam(EmailTokenNames.ShopperId, ShopperContext.ShopperId);
      SetParam(EmailTokenNames.OrderTotal, TotalPrice);
      SetParam(EmailTokenNames.ServerName, _isDevServer ? "www.dev.godaddy.com" : "www.godaddy.com");
      SetParam(EmailTokenNames.LoginName, LoginName);
      SetParam(EmailTokenNames.CC_Address, string.Empty);
      SetParam(EmailTokenNames.OrderTime, OrderTime);
      SetParam(EmailTokenNames.CrossSellItems, GetCrossSellItems());
      SetParam(EmailTokenNames.VATId, VATId);
      SetParam(EmailTokenNames.VideoMeHTMLLink, GetVideoLink("html"));
      SetParam(EmailTokenNames.VideoMeTextLink, GetVideoLink("text"));
      SetParam(EmailTokenNames.HostingConciergeBanner, HostingConciergeBannerHtmlGet());
      SetParam(EmailTokenNames.HostingConciergeText, HostingConciergeTextGet((IsHTMLEmail? true : false), true));
      SetParam(EmailTokenNames.AlipayRenewalText, AliPayRenewalNotice());
    }

    private const string aliPayRenewalMessageOnError = aliPayRenewalMessage;
    private const string aliPayRenewalMessage = "<span style='color:red; font-weight:bold'>Payment Alert</span>: Alipay does not support automatic renewal of GoDaddy products. You will receive an email notification with manual renewal instructions in advance of the expiration date of any of your products.";

    private string AliPayRenewalNotice()
    {
      string notice = String.Empty;
      switch (EmailTemplate.Id)
      {
        case EmailTemplateType.OrderConfirmation_WelcomeTellAFriend:
        case EmailTemplateType.GDWelcome:
        case EmailTemplateType.OrderConfirmation:
          var xmlPaymentMethod = Order.OrderXmlDoc.SelectSingleNode("/ORDER/ORDERDETAIL[@cc_type='AliPay']");
          if (xmlPaymentMethod == null)
          {
            break;
          }

          // See if there are any domains purchased w/autorenew enabled
          int itemsWithAutoRenewal = Order.OrderXmlDoc.SelectNodes("/ORDER/ITEMS/ITEM/CUSTOMXML/domainBulkRegistration/domain[@autorenewflag=1]").Count;
          if (itemsWithAutoRenewal == 0)
          {
            break;
          }

          try
          {
            // Customer has no non-Alipay backup payment method available
            var reqAltPaymentProfile = new GetPaymentProfileAlternateRequestData(ShopperContext.ShopperId, _requestData.SourceURL, Order.OrderId, Order.Pathway, Order.PageCount);
            var rspAltPaymentProfile = (GetPaymentProfileAlternateResponseData)Engine.Engine.ProcessRequest(reqAltPaymentProfile, engineGetPaymentProfileAlternateId);
            if (!rspAltPaymentProfile.IsSuccess)
            {
              AtlantisException aex = new AtlantisException(_requestData, "GDConfirmationEmail.AliPayRenewalNotice", "GetPaymentProfileAlternateResponseData.IsSuccess<>true", String.Empty);
              Engine.Engine.LogAtlantisException(aex); 
              notice = aliPayRenewalMessageOnError;
              break;
            }

            if (rspAltPaymentProfile.PaymentProfileId <= 0)
            {
              // no backup payment method... so the renewal will fail
              notice = aliPayRenewalMessage;
              break;
            }

            // get all of our payment profiles
            var reqPaymentProfiles = new GetPaymentProfilesRequestData(ShopperContext.ShopperId, _requestData.SourceURL, Order.OrderId, Order.Pathway, Order.PageCount);
            var rspPaymentProfiles = (GetPaymentProfilesResponseData)Engine.Engine.ProcessRequest(reqPaymentProfiles, engineGetPaymentProfiles);
            if (!rspPaymentProfiles.IsSuccess)
            {
              AtlantisException aex = new AtlantisException(_requestData, "GDConfirmationEmail.AliPayRenewalNotice", "GetPaymentProfilesResponseData.IsSuccess<>true", String.Empty);
              Engine.Engine.LogAtlantisException(aex);
              notice = aliPayRenewalMessageOnError;
              break;
            }

            // See if the Alternate Payment Profile is not alipay... otherwise send the message
            string strAltPaymentProfileId = rspAltPaymentProfile.PaymentProfileId.ToString();
            PaymentProfile altPaymentProfile = rspPaymentProfiles.Profiles.Find(pp => pp.ProfileID.Equals(strAltPaymentProfileId));
            if (altPaymentProfile.ProfileType.Equals("alipay", StringComparison.OrdinalIgnoreCase))
            {
              // backup payment method is also alipay... so renewal will fail
              notice = aliPayRenewalMessage;
              break;
            }
          }
          catch (Exception ex)
          {
            AtlantisException aex = new AtlantisException(_requestData, "GDConfirmationEmail.AliPayRenewalNotice", "Exception caught. ", String.Empty, ex);
            Engine.Engine.LogAtlantisException(aex);
            notice = aliPayRenewalMessageOnError;
          }
          break;

        default:
          break;
      }
      return notice;
    }

    private string HostingConciergeBannerHtmlGet()
    {
        string hostPhoneUsa;
        string hostPhoneIntl;
        HostPhoneUsaIntlGet(out hostPhoneUsa, out hostPhoneIntl);
        StringBuilder banner = new StringBuilder();
            
        if (HostingConciergeEnabled && !String.IsNullOrEmpty(hostPhoneIntl) && !String.IsNullOrEmpty(hostPhoneUsa))
        {

            int hostingHeight = 104;
            int hostingWidth = 196;
            string hostingImage = String.Empty;
            switch (EmailTemplate.Id)
            {
                case EmailTemplateType.OrderConfirmation_WelcomeTellAFriend:
                case EmailTemplateType.GDWelcome:
                    hostingImage = Links.GetUrl(LinkTypes.Image, "promos/htmlemails/bbtemplate/52345_hosting_01c.jpg",
                                               QueryParamMode.ExplicitParameters, false);
                    hostingHeight = 106;
                    hostingWidth = 182;
                    break;
                default:
                    hostingImage = Links.GetUrl(LinkTypes.Image, "promos/htmlemails/bbtemplate/52345_hosting_01b.jpg",
                                               QueryParamMode.ExplicitParameters, false);
                    break;
            }
            banner.Append(
                "<table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" bgcolor=\"white\" width=\"" + hostingWidth + "\" style=\"border: 1px solid black;\">");
            banner.Append(
                "<tbody><tr> <td><table cellspacing=\"0\" cellpadding=\"0\" border=\"0\" width=\"100%\"> <tbody><tr> ");
            banner.Append("<td align=\"center\"><img height=\"" + hostingHeight);
            banner.Append("\" border=\"0\" width=\"" + hostingWidth + "\" src=\"");
            banner.Append(hostingImage + "\" alt=\"GoDaddy Hosting Concierge\"></a>");
            banner.Append("</td> </tr> <tr> <td align=\"left\" style=\"padding:3px 5px 5px 5px;\">");
            banner.Append(
                "<font style=\"font-size: 11px; color: black; font-family: arial,sans serif;\">");
            banner.Append(
                "Call <span style='font-size: 12px; font-weight:bold'>" + hostPhoneUsa + "</span> (US only) or <span style='font-size: 12px; font-weight:bold'>" + hostPhoneIntl + "</span> for the next 30 days.</font></td> </tr> </tbody></table>");
            string transparentImage = Links.GetUrl(LinkTypes.Image, "promos/std/spc_trans.gif", QueryParamMode.CommonParameters, false);
            banner.Append("</td> </tr> </tbody></table><img height=\"12\" border=\"0\" src=\"" + transparentImage +
                          "\"><br>");
        }
        return banner.ToString();
    }

    
    private EmailTemplate _emailTemplate;
    protected override EmailTemplate EmailTemplate
    {
      get
      {
        return _emailTemplate;
      }
    }

    private EmailTemplate DetermineFirstEmailTemplate()
    {
      EmailTemplate temp = null;

      if (Order.IsRefund)
      {
        if (IsFraudRefund())
        {
          temp = EmailTemplates[EmailTemplateType.CustomerAccountLocked];
        }
        else
        {
          temp = EmailTemplates[EmailTemplateType.RefundConfirmation];
        }
      }
      else
      {
        if (DoRecurringHostingExists())
        {
          temp = EmailTemplates[EmailTemplateType.RecurringHostingConfirmation];
        }
        else
        {
          if (EmailRequired.ProcessFee && EmailRequired.OtherProductIdsExist)
          {
            if (HttpContext.Current != null && HttpContext.Current.Session != null &&
              HttpContext.Current.Session["CreateShopperReferredByFriend"] != null)
            {
              temp = EmailTemplates[EmailTemplateType.OrderConfirmation_WelcomeTellAFriend];
            }
            else
            {
              if (IsNewShopper)
              {
                temp = EmailTemplates[EmailTemplateType.GDWelcome];
              }
              else
              {
                temp = EmailTemplates[EmailTemplateType.OrderConfirmation];
              }
            }
          }
          else
          {
            if (EmailRequired.ProcessFee && !EmailRequired.OtherProductIdsExist)
            {
              temp = EmailTemplates[EmailTemplateType.MiscFeesConfirmation];
            }
            else
            {
              if (HttpContext.Current != null && HttpContext.Current.Session != null &&
              HttpContext.Current.Session["CreateShopperReferredByFriend"] != null)
              {
                temp = EmailTemplates[EmailTemplateType.OrderConfirmation_WelcomeTellAFriend];
              }
              else
              {
                if (IsNewShopper)
                {
                  temp = EmailTemplates[EmailTemplateType.GDWelcome];
                }
                else
                {
                  temp = EmailTemplates[EmailTemplateType.OrderConfirmation];
                }
              }
            }
          }
        }

      }

      return temp;
    }

    public override List<MessagingProcessRequestData> GetMessageRequests()
    {
      List<MessagingProcessRequestData> result = new List<MessagingProcessRequestData>(2);
      if (Order.PrivateLabelId == 1)
      {
        _emailTemplate = DetermineFirstEmailTemplate();
        result.AddRange(base.GetMessageRequests());

        if (_isAZHumane)
        {
          _emailTemplate = EmailTemplates[EmailTemplateType.ArizonaHumaneSociety];
          result.AddRange(base.GetMessageRequests());
        }
      }

      return result;
    }

  }

    internal class HostingGodaddy
    {
    }
}
