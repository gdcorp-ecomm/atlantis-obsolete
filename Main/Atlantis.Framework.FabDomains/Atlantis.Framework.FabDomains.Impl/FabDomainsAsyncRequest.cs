using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

using Atlantis.Framework.Interface;
using Atlantis.Framework.FabDomains.Interface;

namespace Atlantis.Framework.FabDomains.Impl
{
  public class FabDomainsAsyncRequest : IAsyncRequest
  {
    /******************************************************************************/

    #region IAsyncRequest Members

    /******************************************************************************/

    public IAsyncResult BeginHandleRequest(RequestData oRequestData, ConfigElement oConfig, AsyncCallback oCallback, object oState)
    {
      FabDomainsRequestData oFabDomainsRequestData = (FabDomainsRequestData)oRequestData;

      string oRequestURL = ((WsConfigElement)oConfig).WSURL + oFabDomainsRequestData.GetQuery;

      HttpWebRequest oRequest = (HttpWebRequest)HttpWebRequest.Create(oRequestURL);

      AsyncState oAsyncState = new AsyncState(oRequestData, oConfig, oRequest, oState);

      IAsyncResult oAsyncResult = oRequest.BeginGetResponse(oCallback, oAsyncState);

      return oAsyncResult;
    }

    /******************************************************************************/

    public IResponseData EndHandleRequest(IAsyncResult oAsyncResult)
    {
      IResponseData oResponseData = null;
      string sResponseXML = "";
      AsyncState oAsyncState = (AsyncState)oAsyncResult.AsyncState;

      try
      {
        HttpWebRequest oRequest = (HttpWebRequest)oAsyncState.Request;
        HttpWebResponse oResponse = (HttpWebResponse)oRequest.EndGetResponse(oAsyncResult);
        StreamReader srResponse = new StreamReader(oResponse.GetResponseStream());
        sResponseXML = srResponse.ReadToEnd();

        oResponseData = new FabDomainsResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new FabDomainsResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new FabDomainsResponseData(sResponseXML, oAsyncState.RequestData, ex);
      }

      return oResponseData;
    }

    /******************************************************************************/

    #endregion

    /******************************************************************************/
  }
}
