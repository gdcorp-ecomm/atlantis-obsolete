using System;
using System.Xml.Linq;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService;
using Atlantis.Framework.OrionGetAccountsByUID.Interface;
using Atlantis.Framework.OrionSecurityAuth.Interface;

namespace Atlantis.Framework.OrionGetAccountsByUID.Impl
{
  public class OrionGetAccountsByUIDRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData accountRequestData, ConfigElement config)
    {
      string[] _errors = { };
      int _resultCode = -1;
      string error = string.Empty;
      string authToken = string.Empty;
      Account[] _accountList = { };
      OrionGetAccountsByUIDResponseData responseData = null;

      try
      {
        OrionSecurityAuthResponseData responseSecurityData = GetOrionAuthToken(accountRequestData);

        OrionGetAccountsByUIDRequestData orionRequestData = (OrionGetAccountsByUIDRequestData)accountRequestData;

        if (responseSecurityData.IsSuccess && !string.IsNullOrEmpty(responseSecurityData.AuthToken))
        {
          AccountQueriesService.AccountQueries accountServices = new AccountQueriesService.AccountQueries();
          accountServices.Url = ((WsConfigElement)config).WSURL;
          accountServices.SecureHeaderValue = new SecureHeader();
          accountServices.SecureHeaderValue.Token = responseSecurityData.AuthToken;

          _resultCode = accountServices.GetAccountListByAccountUid(orionRequestData.MessageId
            , orionRequestData.AccountUid
            , orionRequestData.ReturnAttributeList
            , out _accountList
            , out _errors);
        }

        XElement GetAccountListByAccountUidResponse = CreateOrionResponseXml(_resultCode, _accountList, _errors);

        responseData = new OrionGetAccountsByUIDResponseData(GetAccountListByAccountUidResponse.ToString(), accountRequestData);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new OrionGetAccountsByUIDResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new OrionGetAccountsByUIDResponseData(accountRequestData, ex);
      }

      return responseData;
    }

    #region XML Creation
    private XElement CreateOrionResponseXml(int resultCode, Account[] accountList, string[] errors)
    {
      XElement GetAccountListByAccountUidResponse = new XElement("GetAccountListByAccountUidResponse");
      GetAccountListByAccountUidResponse.Add(new XElement("GetAccountListByAccountUidResult", resultCode));
      XElement xAccountList = new XElement("AccountList");

      if (resultCode == 0)
      {
        foreach (Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService.Account acct in accountList)
        {
          XElement xAcctAttributes = new XElement("AccountAttributes");
          foreach (Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService.AccountAttribute attr in acct.AccountAttributes)
          {
            XElement xAcctAttr = new XElement("AccountAttribute");
            xAcctAttr.Add(new XElement("AttributeId", attr.AttributeId));
            xAcctAttr.Add(new XElement("AttributeUid", attr.AttributeUid));
            xAcctAttr.Add(new XElement("DisplayStatus", attr.DisplayStatus));
            xAcctAttr.Add(new XElement("IsTemplateAttribute", attr.IsTemplateAttribute));
            xAcctAttr.Add(new XElement("Name", attr.Name));
            xAcctAttr.Add(new XElement("ProductAttributeUid", attr.ProductAttributeUid));
            xAcctAttr.Add(new XElement("Status", attr.Status));
            xAcctAttr.Add(new XElement("TemplateInternalName", attr.TemplateInternalName ?? string.Empty));


            XElement xAcctElements = new XElement("AccountElements");
            foreach (Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService.AccountElement acctElem in attr.AccountElements)
            {
              XElement xAcctElement = new XElement("AccountElement");
              xAcctElement.Add(new XElement("DisplayStatus", acctElem.DisplayStatus));
              xAcctElement.Add(new XElement("ElementId", acctElem.ElementId));
              xAcctElement.Add(new XElement("ElementUid", acctElem.ElementUid));
              xAcctElement.Add(new XElement("Name", acctElem.Name));
              xAcctElement.Add(new XElement("ProductAttributeElementUid", acctElem.ProductAttributeElementUid));
              xAcctElement.Add(new XElement("Status", acctElem.Status));
              xAcctElement.Add(new XElement("Value", acctElem.Value));
              xAcctElements.Add(xAcctElement);
            }
            xAcctAttr.Add(xAcctElements);
            xAcctAttributes.Add(xAcctAttr);
          }

          XElement xQuotas = new XElement("Quotas");
          if (acct.Quotas != null)
          {
            foreach (Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService.AccountQuota quota in acct.Quotas)
            {
              XElement xQuota = new XElement("AccountQuota");
              xQuota.Add(new XAttribute("ObjectUid", quota.ObjectUid));
              xQuota.Add(new XAttribute("objType", quota.objType.ToString()));
              xQuota.Add(new XAttribute("QuotaBeginPeriod", quota.QuotaBeginPeriod));
              xQuota.Add(new XAttribute("QuotaEndPeriod", quota.QuotaEndPeriod));
              xQuota.Add(new XAttribute("QuotaType", quota.QuotaType));

              XElement xDetails = new XElement("Details");
              foreach (Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService.AccountQuotaDetail elem in quota.Details)
              {
                xDetails.Add("AccountAttributeName", elem.AccountAttributeName);
                xDetails.Add("QuotaBeginPeriod", elem.QuotaBeginPeriod);
                xDetails.Add("QuotaEndPeriod", elem.QuotaEndPeriod);
                xDetails.Add("QuotaType", elem.QuotaType);
                xDetails.Add("ProductAttributeElementUid", elem.QuotaUsage);
              }
              xQuota.Add(xDetails);
            }
          }

          XElement xData = new XElement("data");
          if (acct.data != null)
          {
            foreach (Atlantis.Framework.OrionGetAccountsByUID.Impl.AccountQueriesService.AccountInternalData data in acct.data)
            {
              XElement xDatum = new XElement("AccountInternalData");
              xDatum.Add(new XAttribute("ItemName", data.ItemName));
              xDatum.Add(new XAttribute("ItemValue", data.ItemValue));
              xData.Add(xDatum);
            }
          }

          xAccountList.Add(
            new XElement("Account",
              new XElement("SystemNamespace", acct.SystemNamespace),
              new XElement("ResellerId", acct.ResellerId),
              new XElement("CustomerNum", acct.CustomerNum),
              new XElement("ProductName", acct.ProductName),
              new XElement("ProductTemplateId", acct.ProductTemplateId),
              new XElement("ProductTemplateName", acct.ProductTemplateName),
              new XElement("ProductUid", acct.ProductUid),
              new XElement("OrionCustomerId", acct.OrionCustomerId),
              new XElement("AccountId", acct.AccountId),
              new XElement("AccountUid", acct.AccountUid),
              new XElement("DisplayStatus", acct.DisplayStatus),
              new XElement("Status", acct.Status),
              new XElement("ExpireDate", acct.ExpireDate),
              new XElement("CanBeModified", acct.CanBeModified),
              new XElement("IsActive", acct.IsActive),
              new XElement("IsRemoved", acct.IsRemoved),
              new XElement(xAcctAttributes),
              new XElement(xQuotas),
              new XElement(xData)
            )
          );
        }
      }

      XElement xError = new XElement("errors");
      if (errors != null && errors.Length > 0)
      {
        foreach (string err in errors)
        {
          xError.Add(new XElement("error", err));
        }
      }
      GetAccountListByAccountUidResponse.Add(xAccountList);
      GetAccountListByAccountUidResponse.Add(xError);
      return GetAccountListByAccountUidResponse;
    }
    #endregion

    #region OrionSecurity
    private OrionSecurityAuthResponseData GetOrionAuthToken(RequestData accountRequestData)
    {
      OrionSecurityAuthRequestData securityRequestData = null;

      securityRequestData = new OrionSecurityAuthRequestData(accountRequestData.ShopperID,
        accountRequestData.SourceURL,
        accountRequestData.OrderID,
        accountRequestData.Pathway,
        accountRequestData.PageCount,
        "OrionGetAccountsByUID");

      OrionSecurityAuthResponseData responseSecurityData =
        (OrionSecurityAuthResponseData)DataCache.DataCache.GetProcessRequest(
          securityRequestData, securityRequestData.OrionSecurityAuthRequestType);

      return responseSecurityData;
    }
    #endregion
  }
}
