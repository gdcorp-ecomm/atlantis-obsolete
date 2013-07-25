using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SearchShoppers.Interface;

namespace Atlantis.Framework.SearchShoppers.Impl
{
  public class SearchShoppersRequest : IRequest
  {
    // **************************************************************** //

    #region IRequest Members

    // **************************************************************** //

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      SearchShoppersResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        SearchShoppersRequestData oSearchRequestData = (SearchShoppersRequestData)oRequestData;
        WSCgdShopper.WSCgdShopperService shopperWS = new WSCgdShopper.WSCgdShopperService();
        shopperWS.Url = ((WsConfigElement)oConfig).WSURL;
        sResponseXML = shopperWS.SearchShoppers(oSearchRequestData.ToXML());

        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "ShopperRequest.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new SearchShoppersResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new SearchShoppersResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new SearchShoppersResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new SearchShoppersResponseData(sResponseXML, 
                                                       oRequestData, 
                                                       ex);
      }

      return oResponseData;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
