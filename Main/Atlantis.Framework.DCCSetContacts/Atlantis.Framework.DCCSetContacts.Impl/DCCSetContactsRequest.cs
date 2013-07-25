using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCSetContacts.Interface;

namespace Atlantis.Framework.DCCSetContacts.Impl
{
  public class DCCSetContactsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCSetContactsResponseData responseData = null;
      string responseXml = string.Empty;
      string verifyResponseXml = string.Empty;
      try
      {
        DCCSetContactsRequestData oRequest = (DCCSetContactsRequestData)oRequestData;

        string verifyAction = "";
        string verifyDomains = "";
        oRequest.XmlToVerify(out verifyAction, out verifyDomains);

        DsWebValidate.RegDCCValidateWebSvc oDsWebValidate = new DsWebValidate.RegDCCValidateWebSvc();
        string sValidateUrl = ((WsConfigElement)oConfig).WSURL.Replace("RegDCCRequestWebSvc/RegDCCRequestWebSvc.dll", "RegDCCValidateWebSvc/RegDCCValidateWebSvc.asmx");
        oDsWebValidate.Url = sValidateUrl;
        oDsWebValidate.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
        string validateResponseXml = oDsWebValidate.ValidateContactUpdate(verifyAction, verifyDomains);

        if (validateResponseXml.Contains("<ACTIONRESULTS></ACTIONRESULTS>"))
        {
          DsWebVerify.RegDCCVerifyWebSvcService oDsWebVerify = new DsWebVerify.RegDCCVerifyWebSvcService();
          oDsWebVerify.Url = ((WsConfigElement)oConfig).WSURL.Replace("RegDCCRequestWebSvc/RegDCCRequestWebSvc.dll", "RegDCCVerifyWebSvc/RegDCCVerifyWebSvc.dll");
          oDsWebVerify.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
          verifyResponseXml = oDsWebVerify.VerifyContactUpdate(verifyAction, verifyDomains);

          if (verifyResponseXml.Contains("ActionResultID=\"0\""))
          {
            DsWebSubmit.RegDCCRequestWebSvcService oDsWeb = new DsWebSubmit.RegDCCRequestWebSvcService();
            oDsWeb.Url = ((WsConfigElement)oConfig).WSURL;
            oDsWeb.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;

            responseXml = oDsWeb.SubmitRequestStandard(oRequest.XmlToSubmit());
            responseData = new DCCSetContactsResponseData(responseXml);
          }
          else
          {            
            responseData = new DCCSetContactsResponseData(verifyResponseXml,oRequestData);
          }
        }
        else
        {
          responseData = new DCCSetContactsResponseData(validateResponseXml, false);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCSetContactsResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCSetContactsResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
