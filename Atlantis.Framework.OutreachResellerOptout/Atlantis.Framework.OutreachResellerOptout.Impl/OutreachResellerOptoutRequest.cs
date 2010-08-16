using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OutreachResellerOptout.Interface;
using Atlantis.Framework.OutreachResellerOptout.Impl.OutReachWS;

namespace Atlantis.Framework.OutreachResellerOptout.Impl
{
  public class OutreachResellerOptoutRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;

      try
      {
        OutreachResellerOptoutRequestData request = (OutreachResellerOptoutRequestData)oRequestData;
        string serviceUrl = ((WsConfigElement)oConfig).WSURL;
        CampaignBlazer optoutRequest = new CampaignBlazer();
        optoutRequest.Url = serviceUrl;
        optoutRequest.Timeout = (int)request.RequestTimeout.TotalMilliseconds;
        optoutRequest.ResellerOptOut(request.ToXML());
        result = new OutreachResellerOptoutResponseData();
      }
      catch (AtlantisException aex)
      {
        result = new OutreachResellerOptoutResponseData(aex);
      }
      catch (Exception ex)
      {
        result = new OutreachResellerOptoutResponseData(oRequestData, ex);
      }

      return result;
    }

    #endregion
  }
}
