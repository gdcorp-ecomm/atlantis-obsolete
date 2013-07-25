using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCGetDomainInfoByID.Interface;

namespace Atlantis.Framework.DCCGetDomainInfoByID.Impl
{
  public class DCCGetDomainInfoByIDRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCGetDomainInfoByIDResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        DsWebGet.RegCheckDomainStatusWebSvcService oDsWeb = new DsWebGet.RegCheckDomainStatusWebSvcService();
        DCCGetDomainInfoByIDRequestData oRequest = (DCCGetDomainInfoByIDRequestData)oRequestData;
        oDsWeb.Url = ((WsConfigElement)oConfig).WSURL;
        oDsWeb.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
        responseXml = oDsWeb.GetDomainInfoByID(oRequest.ToXML());
        responseData = new DCCGetDomainInfoByIDResponseData(responseXml, oRequest);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCGetDomainInfoByIDResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCGetDomainInfoByIDResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    #endregion

  }
}
