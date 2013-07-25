using System;
using System.Text;
using System.Xml.Linq;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OrionGetAccountTransition.Impl.AccountQueriesService;
using Atlantis.Framework.OrionGetAccountTransition.Interface;
using Atlantis.Framework.OrionSecurityAuth.Interface;

namespace Atlantis.Framework.OrionGetAccountTransition.Impl
{
  public class OrionGetAccountTransitionRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      AccountQueriesService.AccountTransition[] accountTransitionList = { };
      string[] errors = { };
      int wsResult = -1;
      OrionGetAccountTransitionResponseData responseData = null;

      try
      {
        OrionSecurityAuthResponseData responseSecurityData = GetOrionAuthToken(requestData);

        OrionGetAccountTransitionRequestData orionRequestData = (OrionGetAccountTransitionRequestData)requestData;

        if (responseSecurityData.IsSuccess && !string.IsNullOrEmpty(responseSecurityData.AuthToken))
        {
          AccountQueriesService.AccountQueries accountServices = new AccountQueriesService.AccountQueries();
          accountServices.Url = ((WsConfigElement)config).WSURL;
          accountServices.SecureHeaderValue = new SecureHeader();
          accountServices.SecureHeaderValue.Token = responseSecurityData.AuthToken;

          wsResult = accountServices.GetAccountTransitionList(orionRequestData.MessageId
            , orionRequestData.AccountUid
            , orionRequestData.TransitionUid
            , orionRequestData.StatusList
            , out accountTransitionList
            , out errors);
        }

        if (wsResult.Equals(0) && accountTransitionList.Length > 0)
        {
          XElement accountTransitionResponse = CreateOrionResponseXml(accountTransitionList[0]);
          responseData = new OrionGetAccountTransitionResponseData(requestData, accountTransitionResponse.ToString());
        }
        else
        {
          StringBuilder sb = new StringBuilder();
          if (errors != null && errors.Length > 0)
          {
            foreach (string err in errors)
            {
              sb.Append(err);
            }
          }

          AtlantisException aex = new AtlantisException(requestData
            , "OrionGetAccountTransitionRequest::RequestHandler"
            , "Error calling AccountQueries.GetAccountTransitionList"
            , sb.ToString());

          responseData = new OrionGetAccountTransitionResponseData(aex);
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new OrionGetAccountTransitionResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new OrionGetAccountTransitionResponseData(requestData, ex);
      }

      return responseData;
    }

    #region XML Creation
    private XElement CreateOrionResponseXml(AccountTransition accountTransition)
    {
      XElement accountTransitionData = new XElement("accounttransition");
      accountTransitionData.Add(new XElement("id", accountTransition.AccountTransitionId));
      accountTransitionData.Add(new XElement("status", accountTransition.AccountTransitionStatus));
      accountTransitionData.Add(new XElement("uid", accountTransition.AccountTransitionUid));
      accountTransitionData.Add(new XElement("accountuid", accountTransition.AccountUid));
      accountTransitionData.Add(new XElement("archiveattributeuid", accountTransition.ArchiveAttributeUid));
      accountTransitionData.Add(new XElement("datecreated", accountTransition.DateCreated));
      accountTransitionData.Add(new XElement("typeinternalname", accountTransition.TypeInternalName));

      return accountTransitionData;
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
        "OrionGetAccountTransition");

      OrionSecurityAuthResponseData responseSecurityData =
        (OrionSecurityAuthResponseData)DataCache.DataCache.GetProcessRequest(
          securityRequestData, securityRequestData.OrionSecurityAuthRequestType);

      return responseSecurityData;
    }
    #endregion
  }
}
