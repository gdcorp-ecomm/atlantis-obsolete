﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atlantis.Framework.Interface;
using Atlantis.Framework.ClearBasket.Interface;

namespace Atlantis.Framework.ClearBasket.Impl
{
    public class ClearBasketRequest:IRequest
    {
        #region IRequest Members

        public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
        {
            ClearBasketResponseData oResponseData = null;
            string sResponseXML = "";

            try
            {
                ClearBasketRequestData oClearBasketRequestData = (ClearBasketRequestData)oRequestData;
                WSCgdBasket.WscgdBasketService oBasketWS = new WSCgdBasket.WscgdBasketService();
                oBasketWS.Url = ((WsConfigElement)oConfig).WSURL;

                sResponseXML = string.Empty;
                sResponseXML = oBasketWS.ClearByType(oClearBasketRequestData.ShopperID,oClearBasketRequestData.BasketType);
                if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                                         "ClearBasketRequest.RequestHandler",
                                                                         sResponseXML,
                                                                         oRequestData.ToXML());

                    oResponseData = new ClearBasketResponseData(sResponseXML, exAtlantis);
                }
                else
                    oResponseData = new ClearBasketResponseData(sResponseXML);
            }
            catch (AtlantisException exAtlantis)
            {
                oResponseData = new ClearBasketResponseData(sResponseXML, exAtlantis);
            }
            catch (Exception ex)
            {
                oResponseData = new ClearBasketResponseData(sResponseXML, oRequestData, ex);
            }

            return oResponseData;
        }

        #endregion
    }
}
