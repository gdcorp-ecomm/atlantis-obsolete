using System;
using System.Collections.Generic;
using System.Text;

using Atlantis.Framework.Interface;
using Atlantis.Framework.Backorder.Interface;

namespace Atlantis.Framework.Backorder.Impl
{
  public class BackorderAsyncRequest : IAsyncRequest
  {

    #region IAsyncRequest Members

    public IAsyncResult BeginHandleRequest(RequestData oRequestData, ConfigElement oConfig, AsyncCallback oCallback, object oState)
    {
      BackorderRequestData oBackOrderRequestData = (BackorderRequestData)oRequestData;

      RegChkIsBackorder.RegChkIsBackorderService oRequest 
        = new Atlantis.Framework.Backorder.Impl.RegChkIsBackorder.RegChkIsBackorderService();
      oRequest.Url = ((WsConfigElement)oConfig).WSURL;

      AsyncState oAsyncState = new AsyncState(oRequestData, oConfig, oRequest, oState);

      IAsyncResult oAsyncResult = oRequest.BeginIsMultipleDomainBackorderAllowed(oBackOrderRequestData.ToXML(),
                                                                          oCallback,
                                                                          oAsyncState);
      return oAsyncResult;
    }

    public IResponseData EndHandleRequest(IAsyncResult oAsyncResult)
    {
      IResponseData oResponseData = null;
      string sResponseXML = "";
      AsyncState oAsyncState = (AsyncState)oAsyncResult.AsyncState;

      try
      {
        RegChkIsBackorder.RegChkIsBackorderService oRequest 
          = (RegChkIsBackorder.RegChkIsBackorderService)oAsyncState.Request;

        sResponseXML = oRequest.EndIsMultipleDomainBackorderAllowed(oAsyncResult);

        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oAsyncState.RequestData,
                                                               "BackorderAsyncRequest.EndHandleRequest",
                                                               sResponseXML,
                                                               oAsyncState.RequestData.ToXML());

          oResponseData = new BackorderResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new BackorderResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new BackorderResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new BackorderResponseData(sResponseXML, oAsyncState.RequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
