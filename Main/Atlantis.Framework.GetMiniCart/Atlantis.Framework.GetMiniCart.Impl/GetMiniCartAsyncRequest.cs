using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetMiniCart.Interface;

namespace Atlantis.Framework.GetMiniCart.Impl
{
  public class GetMiniCartAsyncRequest : IAsyncRequest
  {
    #region IAsyncRequest Members

    public IAsyncResult BeginHandleRequest(RequestData oRequestData, ConfigElement oConfig, AsyncCallback oCallback, object oState)
    {
      GetMiniCartRequestData miniCartRequestData = (GetMiniCartRequestData)oRequestData;
      WSCgdBasket.WscgdBasketService basketWS = new WSCgdBasket.WscgdBasketService();
      basketWS.Url = ((WsConfigElement)oConfig).WSURL;
      basketWS.Timeout = (int)miniCartRequestData.RequestTimeout.TotalMilliseconds;

      oState = miniCartRequestData.BasketType;
      AsyncState oAsyncState = new AsyncState(oRequestData, oConfig, basketWS, oState);

      IAsyncResult result;
      if (!string.IsNullOrEmpty(miniCartRequestData.BasketType))
      {
        result = basketWS.BeginGetMiniCartXMLByType(miniCartRequestData.ShopperID, miniCartRequestData.BasketType, oCallback, oAsyncState);
      }
      else
      {
        result = basketWS.BeginGetMiniCartXML(miniCartRequestData.ShopperID, oCallback, oAsyncState);
      }
      return result;
      
    }

    public IResponseData EndHandleRequest(IAsyncResult oAsyncResult)
    {
      IResponseData _responseData = null;
      string _responseXml = string.Empty;

      AsyncState oAsyncState = (AsyncState)oAsyncResult.AsyncState;
      string basketType = oAsyncState.State.ToString();

      try
      { 
        WSCgdBasket.WscgdBasketService basketWS = ( WSCgdBasket.WscgdBasketService)oAsyncState.Request;
        if (!string.IsNullOrEmpty(basketType))
        {
          _responseData = new GetMiniCartResponseData(basketWS.EndGetMiniCartXMLByType(oAsyncResult));
        }
        else
        {
          _responseData = new GetMiniCartResponseData(basketWS.EndGetMiniCartXML(oAsyncResult));
        }
      }
      catch (AtlantisException exAtlantis)
      {
        _responseData = new GetMiniCartResponseData(_responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        _responseData = new GetMiniCartResponseData(_responseXml, oAsyncState.RequestData, ex);
      }

      return _responseData;
    }

    #endregion
  }
}
