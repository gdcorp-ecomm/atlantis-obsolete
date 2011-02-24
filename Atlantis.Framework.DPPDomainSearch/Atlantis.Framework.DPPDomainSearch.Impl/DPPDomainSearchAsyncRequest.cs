using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DPPDomainSearch.Interface;
using Atlantis.Framework.DPPDomainSearch.Impl.gdDPPSearch;

namespace Atlantis.Framework.DPPDomainSearch.Impl
{
  class DPPDomainSearchAsyncRequest : IAsyncRequest
  {
    /******************************************************************************/

    #region IAsyncRequest Members

    /******************************************************************************/

    public IAsyncResult BeginHandleRequest(RequestData oRequestData, ConfigElement oConfig, AsyncCallback oCallback, object oState)
    {
      DPPDomainSearchRequestData requestData = (DPPDomainSearchRequestData)oRequestData;

      gdDppSearchWS oRequest = new gdDppSearchWS();
      oRequest.Url = ((WsConfigElement)oConfig).WSURL;

      AsyncState oAsyncState = new AsyncState(oRequestData, oConfig, oRequest, oState);

      IAsyncResult oAsyncResult = oRequest.BegindppDomainSearch(requestData.ToXML(), oCallback, oAsyncState);
      return oAsyncResult;
    }

    /******************************************************************************/

    public IResponseData EndHandleRequest(IAsyncResult oAsyncResult)
    {
      DPPDomainSearchResponseData responseData = null;
      AsyncState oAsyncState = (AsyncState)oAsyncResult.AsyncState;
      string responseXml = string.Empty;

      try
      {
        gdDppSearchWS request = (gdDppSearchWS)oAsyncState.Request;
        responseXml = request.EnddppDomainSearch(oAsyncResult);
        responseData = new DPPDomainSearchResponseData(responseXml);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DPPDomainSearchResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DPPDomainSearchResponseData(responseXml, oAsyncState.RequestData, ex);
      }

      return responseData;

    }
    
    /******************************************************************************/

    #endregion

  }
}
