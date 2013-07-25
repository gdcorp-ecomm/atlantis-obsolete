using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atlantis.Framework.Interface;
using Atlantis.Framework.GetBasketItemCounts.Interface;

namespace Atlantis.Framework.GetBasketItemCounts.Impl
{
  public class GetBasketItemCountsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetBasketItemCountsResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        GetBasketItemCountsRequestData oGetBasketItemCountsRequestData = (GetBasketItemCountsRequestData)oRequestData;
        WSCgdBasket.WscgdBasketService oBasketWS = new WSCgdBasket.WscgdBasketService();
        oBasketWS.Url = ((WsConfigElement)oConfig).WSURL;
        sResponseXML = string.Empty;
        sResponseXML = oBasketWS.GetItemCounts(oGetBasketItemCountsRequestData.ShopperID);
        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "GetBasketItemCountsRequest.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new GetBasketItemCountsResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new GetBasketItemCountsResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetBasketItemCountsResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetBasketItemCountsResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
