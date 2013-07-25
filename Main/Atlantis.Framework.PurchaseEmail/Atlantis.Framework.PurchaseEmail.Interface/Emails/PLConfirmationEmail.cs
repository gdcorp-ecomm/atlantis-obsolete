﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.PurchaseEmail.Interface.Providers;
using Atlantis.Framework.Providers.ProviderContainer.Impl;
using System.IO;
using Atlantis.Framework.MessagingProcess.Interface;

namespace Atlantis.Framework.PurchaseEmail.Interface.Emails
{
  internal class PLConfirmationEmail : PurchaseConfirmationEmailBase
  {
    private const int _DBPPRIVATELABELID = 1695;
    private const int _MEPRIVATELABELID = 435560;
    private const int _WWDPRIVATELABELID = 1387;
    private const int _SUPERRESELLERTYPE = 5;

    public PLConfirmationEmail(OrderData orderData, EmailRequired emailRequired, ObjectProviderContainer objectContainer)
      : base(orderData, emailRequired,objectContainer)
    {
    }

    private bool IsSuperReseller
    {
      get
      {
        int privateLabelType = DataCache.DataCache.GetPrivateLabelType(Order.PrivateLabelId);
        return (privateLabelType == _SUPERRESELLERTYPE);
      }
    }

    protected override void SetParams()
    {
      SetParam(EmailTokenNames.OrderId, Order.OrderId);
      if (EmailTemplate.Id == EmailTemplateType.OrderConfirmation)
      {
        string xmlParam;
        using (var ms = new MemoryStream())
        {
          Order.OrderXmlDoc.Save(ms);
          xmlParam = String.Concat("<?xml version=\"1.0\" encoding=\"utf-16\"?>", Encoding.Default.GetString(ms.ToArray()));
          ms.Close();
        }

        SetParam(EmailTokenNames.CartXml, xmlParam, AttributeValueWriteMethod.CDataBlock);

        SetParam(EmailTokenNames.ItemsText, GetEulaBlock());
      }
      else
      {
        SetParam(EmailTokenNames.ItemsText, GetItemsText());
      }
      SetParam(EmailTokenNames.OrderTotal, TotalPrice);
      SetParam(EmailTokenNames.LoginName, LoginName);
      SetParam(EmailTokenNames.ShopperId, ShopperContext.ShopperId);
      SetParam(EmailTokenNames.OrderTime, OrderTime);
      SetParam(EmailTokenNames.VATId, VATId);

      string accountInfoText = string.Empty;
      if (EmailTemplate.Id != EmailTemplateType.RefundConfirmation_ME)
      {
        if (Order.PrivateLabelId == _DBPPRIVATELABELID)
        {
          accountInfoText = string.Format("Your login name is {0}.\nYour account email is {1}.", LoginName, ShopperData.GetField("email"));
        }
        else
        {
          accountInfoText = string.Format("Your customer number is {0}.\nYour account email is {1}.", ShopperContext.ShopperId, ShopperData.GetField("email"));
        }
      }
      SetParam(EmailTokenNames.AccountInfo, accountInfoText);
    }

    protected override EmailTemplate EmailTemplate
    {
      get
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
            if (Order.PrivateLabelId == _MEPRIVATELABELID) //ME
            {
              temp = EmailTemplates[EmailTemplateType.RefundConfirmation_ME];
            }
            else if (SiteContext.PrivateLabelId == 1695) //DBP
            {
              temp = EmailTemplates[EmailTemplateType.RefundConfirmation_DBP];
            }
            else
            {
              temp = EmailTemplates[EmailTemplateType.RefundConfirmation];
            }
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
            if (SiteContext.PrivateLabelId == _WWDPRIVATELABELID) //WWD
            {
              temp = EmailTemplates[EmailTemplateType.OrderConfirmation_WWD];
            }
            else
            {
              if (IsSuperReseller)
              {
                temp = EmailTemplates[EmailTemplateType.OrderConfirmation_SuperReseller];
              }
              else
              {
                if (SiteContext.PrivateLabelId == _DBPPRIVATELABELID) // DBP
                {
                  temp = EmailTemplates[EmailTemplateType.OrderConfirmation_DBP];
                }
                else
                {
                  if (!Products.IsProductGroupOffered(ProductGroups.Domains))
                  {
                    temp = EmailTemplates[EmailTemplateType.OrderConfirmation_ProductOnlyReseller];
                  }
                  else
                  {
                    if (EmailRequired.ProcessFee && EmailRequired.OtherProductIdsExist)
                    {
                      temp = EmailTemplates[EmailTemplateType.OrderConfirmation];
                    }
                    else
                    {
                      if (EmailRequired.ProcessFee && !EmailRequired.OtherProductIdsExist)
                      {
                        temp = EmailTemplates[EmailTemplateType.MiscFeesConfirmation];
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
          }
        }

        return temp;
      }
    }

    public override List<Atlantis.Framework.MessagingProcess.Interface.MessagingProcessRequestData> GetMessageRequests()
    {
      if ((Order.PrivateLabelId == 1) || (Order.PrivateLabelId == 2))
      {
        return null;
      }
      else
      {
        return base.GetMessageRequests();
      }
    }

  }
}
