using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCGetExpirationCount.Interface;
using Atlantis.Framework.DCCGetExpirationCount.Impl.DomainStatusWS;

namespace Atlantis.Framework.DCCGetExpirationCount.Impl
{
  public class DCCGetExpirationCountRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;
      string responseXml = null;

      try
      {
        DCCGetExpirationCountRequestData request = (DCCGetExpirationCountRequestData)oRequestData;

        RegCheckDomainStatusWebSvcService service = new RegCheckDomainStatusWebSvcService();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)request.ServiceTimeout.TotalMilliseconds;

        responseXml = service.GetExpirationDomainCountsByShopperId(request.ToXML());
        result = new DCCGetExpirationCountResponseData(responseXml, oRequestData);
      }
      catch (Exception ex)
      {
        result = new DCCGetExpirationCountResponseData(responseXml, oRequestData, ex);
      }

      return result;
    }

    #endregion
  }
}
