using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DPPDomainSearch.Interface;
using Atlantis.Framework.DPPDomainSearch.Impl.gdDPPSearch;

namespace Atlantis.Framework.DPPDomainSearch.Impl
{
  public class DPPDomainSearchRequest : IRequest
  {
    private const int _MAX_SERVICETIMEOUT_MILLISECONDS = 300000;// in miliseconds

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DPPDomainSearchResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        gdDppSearchWS service = new gdDppSearchWS();
        DPPDomainSearchRequestData request = (DPPDomainSearchRequestData)oRequestData;

        if (request._requestTimeout.TotalMilliseconds > _MAX_SERVICETIMEOUT_MILLISECONDS)
          service.Timeout = _MAX_SERVICETIMEOUT_MILLISECONDS;
        else
          service.Timeout = (int)request._requestTimeout.TotalMilliseconds;

        service.Url = ((WsConfigElement)oConfig).WSURL;
        responseXml = service.dppDomainSearch(oRequestData.ToXML());

        responseData = new DPPDomainSearchResponseData(responseXml);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DPPDomainSearchResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DPPDomainSearchResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }
  }
}
