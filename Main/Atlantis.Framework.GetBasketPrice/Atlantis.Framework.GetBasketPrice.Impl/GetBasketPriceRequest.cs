﻿using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetBasketPrice.Interface;

namespace Atlantis.Framework.GetBasketPrice.Impl
{
  public class GetBasketPriceRequest : IRequest
  {
    // **************************************************************** //

    #region IRequest Members

    // **************************************************************** //

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        GetBasketPriceRequestData oBasketPriceRequestData = (GetBasketPriceRequestData)oRequestData;
        WscgdBasket.WscgdBasketService oBasketWS = new WscgdBasket.WscgdBasketService();
        oBasketWS.Url = ((WsConfigElement)oConfig).WSURL;
        oBasketWS.Timeout = (int)oBasketPriceRequestData.RequestTimeout.TotalMilliseconds;

        if (!string.IsNullOrEmpty(oBasketPriceRequestData.BasketType))
        {
          sResponseXML = oBasketWS.GetBasketPriceXMLByType(
            oBasketPriceRequestData.ShopperID,
            oBasketPriceRequestData.PaymentType,
            (short)(oBasketPriceRequestData.DeleteRefund ? -1 : 0),
            oBasketPriceRequestData.BasketType);
        }
        else
        {
          sResponseXML = oBasketWS.GetBasketPriceXML(
            oBasketPriceRequestData.ShopperID,
            oBasketPriceRequestData.PaymentType,
            (short)(oBasketPriceRequestData.DeleteRefund ? -1 : 0));
        }

        oResponseData = new GetBasketPriceResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetBasketPriceResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetBasketPriceResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
