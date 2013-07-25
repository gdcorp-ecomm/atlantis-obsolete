using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.RegDomainsDbsCheck.Interface;
using Atlantis.Framework.RegDomainsDbsCheck.Impl.DbsWebService;

namespace Atlantis.Framework.RegDomainsDbsCheck.Impl
{
  public class RegDomainsDbsCheckRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement configElement)
    {
      IResponseData responseData = null;
      string responseXML = String.Empty;

      try
      {
        RegDomainsDbsCheckRequestData request = (RegDomainsDbsCheckRequestData)requestData;
        DbsWebService.DomainServices ws = new DbsWebService.DomainServices();
        WsConfigElement ce = (WsConfigElement)configElement;
        string requestXml = request.ToXML();
        ws.Timeout = request.Timeout;
        ws.Url = ((WsConfigElement)ce).WSURL;
        responseXML = ws.IsDomainDbsCapableBulk(requestXml);

        if (!string.IsNullOrEmpty(responseXML))
        {
          responseData = new RegDomainsDbsCheckResponseData(responseXML);
        }
        else
        {
          throw new AtlantisException(requestData,
                                      "Framework: RegDomainsDbsCheckRequest.RequestHandler",
                                      "Invalid request, null or empty string returned",
                                      string.Empty);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new RegDomainsDbsCheckResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new RegDomainsDbsCheckResponseData(requestData, ex);
      }

      return responseData;
    }
  }
}
