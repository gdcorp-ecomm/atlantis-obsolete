using System;
using Atlantis.Framework.DCCGetDomainRankInfo.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCGetDomainRankInfo.Impl
{
  public class DCCGetDomainRankInfoAsyncRequest : IAsyncRequest
  {
    public IAsyncResult BeginHandleRequest(RequestData requestData, ConfigElement config, AsyncCallback callback, object state)
    {
      DCCGetDomainRankInfoRequestData request = (DCCGetDomainRankInfoRequestData)requestData;

      WebScoreBossWebSvc.WebScoreBossWebSvc domainRankInfoWS = new WebScoreBossWebSvc.WebScoreBossWebSvc();
      domainRankInfoWS.Url = ((WsConfigElement)config).WSURL;
      domainRankInfoWS.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

      AsyncState asyncState = new AsyncState(requestData, config, domainRankInfoWS, state);
      IAsyncResult asyncResult = domainRankInfoWS.BeginGetRankInfoForDomainIds(request.ToXML(), callback, asyncState);

      return asyncResult;
    }

    public IResponseData EndHandleRequest(IAsyncResult asyncResult)
    {
      IResponseData responseData = null;
      string responseXml = string.Empty;
      AsyncState asyncState = (AsyncState)asyncResult.AsyncState;

      try
      {
        WebScoreBossWebSvc.WebScoreBossWebSvc domainRankInfoWS = (WebScoreBossWebSvc.WebScoreBossWebSvc)asyncState.Request;
        responseXml = domainRankInfoWS.EndGetRankInfoForDomainIds(asyncResult);

        if (!string.IsNullOrEmpty(responseXml) && responseXml.Contains("<success>1</success>"))
        {
          responseData = new DCCGetDomainRankInfoResponseData(responseXml);
        }
        else
        {
          DCCGetDomainRankInfoRequestData reqData = (DCCGetDomainRankInfoRequestData)asyncState.RequestData;
          responseData = new DCCGetDomainRankInfoResponseData(reqData, responseXml);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCGetDomainRankInfoResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new DCCGetDomainRankInfoResponseData(asyncState.RequestData, ex);
      }

      return responseData;
    }
  }
}
