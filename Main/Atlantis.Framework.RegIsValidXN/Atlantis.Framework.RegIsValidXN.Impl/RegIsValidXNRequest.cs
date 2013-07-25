using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.RegIsValidXN.Interface;
using Atlantis.Framework.RegIsValidXN.Impl.RegIDNCheckerWS;

namespace Atlantis.Framework.RegIsValidXN.Impl
{
  public class RegIsValidXNRequest : IRequest
  {

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;
      string responseXml = string.Empty;

      try
      {
        string serviceUrl = ((WsConfigElement)oConfig).WSURL;
        RegIsValidXNRequestData request = (RegIsValidXNRequestData)oRequestData;

        RegIDNCheckerWebSvc xnRequest = new RegIDNCheckerWebSvc();
        xnRequest.Url = serviceUrl;
        xnRequest.Timeout = (int)request.RequestTimeout.TotalMilliseconds;
        responseXml = xnRequest.IsValidXN(request.ToXML());
        result = new RegIsValidXNResponseData(responseXml);
      }
      catch (AtlantisException exAtlantis)
      {
        result = new RegIsValidXNResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        result = new RegIsValidXNResponseData(responseXml, oRequestData, ex);
      }

      return result;
    }

    #endregion

  }
}
