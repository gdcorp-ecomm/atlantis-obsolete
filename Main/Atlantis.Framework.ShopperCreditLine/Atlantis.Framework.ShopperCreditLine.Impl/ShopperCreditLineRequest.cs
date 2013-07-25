using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.ShopperCreditLine.Interface;

namespace Atlantis.Framework.ShopperCreditLine.Impl
{

  public class ShopperCreditLineRequest : IRequest
  {

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      ShopperCreditLineResponseData oResponseData = null;
      string sResponseXML = "";
      try
      {
        ShopperCreditLineRequestData oShopperCreditRequest = (ShopperCreditLineRequestData)oRequestData;
        gdLoc.Service oSvc = new Atlantis.Framework.ShopperCreditLine.Impl.gdLoc.Service();
        oSvc.Url = ((WsConfigElement)oConfig).WSURL;
        oSvc.Timeout = (int)oShopperCreditRequest.TimeOut.TotalMilliseconds;
        bool shopperLOC = false;
        sResponseXML = oSvc.ShopperHasLOC(oShopperCreditRequest.ShopperID, out shopperLOC);
        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "ShopperCreditLine.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new ShopperCreditLineResponseData(sResponseXML, exAtlantis);
        }
        else
        {
          oResponseData = new ShopperCreditLineResponseData(sResponseXML, shopperLOC);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new ShopperCreditLineResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new ShopperCreditLineResponseData(sResponseXML, oRequestData, ex);
      }
      return oResponseData;
    }

    #endregion

  }
}
