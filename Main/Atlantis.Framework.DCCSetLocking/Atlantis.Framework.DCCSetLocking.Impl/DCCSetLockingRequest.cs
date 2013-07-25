using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCSetLocking.Interface;

namespace Atlantis.Framework.DCCSetLocking.Impl
{
  public class DCCSetLockingRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCSetLockingResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        DCCSetLockingRequestData oRequest = (DCCSetLockingRequestData)oRequestData;
        
        string verifyAction = "";
        string verifyDomains = "";
        oRequest.XmlToVerify(out verifyAction, out verifyDomains);

        DsWebVerify.RegDCCVerifyWebSvcService oDsWebVerify = new DsWebVerify.RegDCCVerifyWebSvcService();
        oDsWebVerify.Url = ((WsConfigElement)oConfig).WSURL.Replace("RegDCCRequestWebSvc/RegDCCRequestWebSvc.dll", "RegDCCVerifyWebSvc/RegDCCVerifyWebSvc.dll");
        oDsWebVerify.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
        responseXml = oDsWebVerify.VerifyDomainSetLock(verifyAction, verifyDomains);

        if (responseXml.Contains("ActionResultID=\"0\""))
        {
          DsWebSubmit.RegDCCRequestWebSvcService oDsWeb = new DsWebSubmit.RegDCCRequestWebSvcService();
          oDsWeb.Url = ((WsConfigElement)oConfig).WSURL;
          oDsWeb.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;

          responseXml = oDsWeb.SubmitRequestStandard(oRequest.ToXML());
          responseData = new DCCSetLockingResponseData(responseXml);
        }
        else if (responseXml.Contains("ActionResultID=\"52\""))
        {
          //Already in the state requested
          responseData = new DCCSetLockingResponseData("<success");
        }
        else
        {
          responseData = new DCCSetLockingResponseData(responseXml, false);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCSetLockingResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCSetLockingResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
