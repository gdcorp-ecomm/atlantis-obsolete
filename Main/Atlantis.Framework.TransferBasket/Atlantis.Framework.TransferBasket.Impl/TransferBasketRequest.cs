﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.TransferBasket.Interface;
using Atlantis.Framework.Interface;
namespace Atlantis.Framework.TransferBasket.Impl
{
  public class TransferBasketRequest: IRequest
  {
    #region IRequest Members

    private const int LOCKCUSTOMER = 1;
    private const int LOCKMANAGER = 2;

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      TransferBasketResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        TransferBasketRequestData oTransferBasketRequestData = (TransferBasketRequestData)oRequestData;
        WSCgdBasket.WscgdBasketService oBasketWS = new WSCgdBasket.WscgdBasketService();
        oBasketWS.Url = ((WsConfigElement)oConfig).WSURL;

        sResponseXML = string.Empty;

        sResponseXML = oBasketWS.TransferBasket(oTransferBasketRequestData.FromShopperId, oTransferBasketRequestData.ToShopperId);
        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "TransferBasketRequest.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new TransferBasketResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new TransferBasketResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new TransferBasketResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new TransferBasketResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
