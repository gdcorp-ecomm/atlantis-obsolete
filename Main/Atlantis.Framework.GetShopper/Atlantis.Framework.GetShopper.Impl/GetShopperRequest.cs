using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetShopper.Interface;

namespace Atlantis.Framework.GetShopper.Impl
{
  public class GetShopperRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetShopperResponseData oResponseData = null;
      string sResultXML = "";

      try
      {
        GetShopperRequestData oShopperData = (GetShopperRequestData)oRequestData;
        WSCgdShopper.WSCgdShopperService oShopperWS = new WSCgdShopper.WSCgdShopperService();
        oShopperWS.Url = ((WsConfigElement)oConfig).WSURL;
        oShopperWS.Timeout = (int)oShopperData.RequestTimeout.TotalMilliseconds;
        string sRequestXML = oShopperData.ToXML();
        sResultXML = oShopperWS.GetShopper(sRequestXML);

        if (sResultXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException((RequestData)oRequestData,
                                                               "GetShopperRequest.RequestHandler",
                                                               sResultXML,
                                                               oRequestData.ToXML());

          oResponseData = new GetShopperResponseData(sResultXML, exAtlantis);
        }
        else
          oResponseData = new GetShopperResponseData(sResultXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetShopperResponseData(sResultXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetShopperResponseData(sResultXML, (GetShopperRequestData)oRequestData, ex);
      }
 
      return oResponseData;
    }

    #endregion

  }
}
