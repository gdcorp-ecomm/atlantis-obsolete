using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.EcommPaymentProfile.Interface;

namespace Atlantis.Framework.EcommPaymentProfile.Impl
{
  public class EcommPaymentProfileRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      EcommPaymentProfileResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        EcommPaymentProfileRequestData oEcommPaymentProfileRequestData = (EcommPaymentProfileRequestData)oRequestData;
        WsgdCPPSvc.PPWebSvcService oSvc = new WsgdCPPSvc.PPWebSvcService();
        oSvc.Url = ((WsConfigElement)oConfig).WSURL;
        sResponseXML = string.Empty;
        sResponseXML = oSvc.GetInfoByProfileID(string.Empty, oEcommPaymentProfileRequestData.ProfileID, oRequestData.ShopperID);
        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "EcommPaymentProfileRequest.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new EcommPaymentProfileResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new EcommPaymentProfileResponseData(oRequestData, sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new EcommPaymentProfileResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new EcommPaymentProfileResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
