using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.CreateShopper.Interface;

namespace Atlantis.Framework.CreateShopper.Impl
{
  class CreateShopperRequest : IRequest
  {
    // **************************************************************** //

    #region IRequest Members

    // **************************************************************** //

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      CreateShopperResponseData oResponseData = null;
      string sResultXML = string.Empty;

      try
      {
        string sErrorMsg = string.Empty;
        CreateShopperRequestData oShopperData = (CreateShopperRequestData)oRequestData;

        if (oShopperData.PrivateLabelId >= 1)
        {
          WSCgdShopper.WSCgdShopperService oShopperWS = new WSCgdShopper.WSCgdShopperService();
          oShopperWS.Url = ((WsConfigElement)oConfig).WSURL;
          string sRequestXML = oShopperData.ToXML();
          sResultXML = oShopperWS.CreateShopper(sRequestXML);

          if (sResultXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
            sErrorMsg = sResultXML;
        }
        else
        {
          sErrorMsg = "Specified private label ID must be 1 or greater";
        }

        oResponseData = BuildResponse(oRequestData, sResultXML, sErrorMsg);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new CreateShopperResponseData(sResultXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new CreateShopperResponseData(sResultXML, (CreateShopperRequestData)oRequestData, ex);
      }

      return oResponseData;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //

    private CreateShopperResponseData BuildResponse(RequestData oRequestData, string sResultXML, string sErrorMsg)
    {
      AtlantisException exAtlantis = null;

      if (!string.IsNullOrEmpty(sErrorMsg))
      {
        exAtlantis = new AtlantisException((RequestData)oRequestData,
                                           "CreateShopperRequest.RequestHandler",
                                           sErrorMsg,
                                           oRequestData.ToXML());
      }

      return new CreateShopperResponseData(sResultXML, exAtlantis);
    }
  }
}
