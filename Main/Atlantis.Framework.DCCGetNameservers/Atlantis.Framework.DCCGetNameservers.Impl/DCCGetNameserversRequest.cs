using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCGetNameservers.Interface;

namespace Atlantis.Framework.DCCGetNameservers.Impl
{
  public class DCCGetNameserversRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCGetNameserversResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        DsWeb.RegCheckDomainStatusWebSvcService oDsWeb = new DsWeb.RegCheckDomainStatusWebSvcService();
        DCCGetNameserversRequestData oRequest = (DCCGetNameserversRequestData)oRequestData;
        oDsWeb.Url = ((WsConfigElement)oConfig).WSURL;
        oDsWeb.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
        responseXml = oDsWeb.GetNameserverInfoByDomainNameAndShopperId(oRequest.ToXML());
        responseData = new DCCGetNameserversResponseData(responseXml);
        
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCGetNameserversResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCGetNameserversResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
