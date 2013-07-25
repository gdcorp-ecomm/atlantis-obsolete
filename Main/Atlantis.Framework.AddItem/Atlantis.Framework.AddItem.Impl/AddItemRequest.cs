using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.AddItem.Interface;

namespace Atlantis.Framework.AddItem.Impl
{
  public class AddItemRequest : IRequest
  {
    public static string version = "";
    // **************************************************************** //

    #region IRequest Members

    // **************************************************************** //

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      AddItemResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        AddItemRequestData oAddItemRequestData = (AddItemRequestData)oRequestData;
        WSCgdBasket.WscgdBasketService oBasketWS = new WSCgdBasket.WscgdBasketService();
        oBasketWS.Url = ((WsConfigElement)oConfig).WSURL;
        sResponseXML = oBasketWS.AddItem(oAddItemRequestData.ShopperID, 
                                         oAddItemRequestData.ToXML());

        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "AddItemRequest.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new AddItemResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new AddItemResponseData(sResponseXML);
      }
      catch(AtlantisException exAtlantis)
      {
        oResponseData = new AddItemResponseData(sResponseXML, exAtlantis);
      }
      catch(Exception ex)
      {
        oResponseData = new AddItemResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
