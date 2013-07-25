using System;
using Atlantis.Framework.EcommPaymentProfiles.Impl.WsgdCPPSvc;
using Atlantis.Framework.EcommPaymentProfiles.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommPaymentProfiles.Impl
{
  public class EcommPaymentProfilesRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      EcommPaymentProfilesResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        EcommPaymentProfilesRequestData request = (EcommPaymentProfilesRequestData)requestData;

        PPWebSvcService ppWs = new PPWebSvcService();
        ppWs.Url = ((WsConfigElement)config).WSURL;
        ppWs.Timeout = (int)request.RequestTimeout.TotalMilliseconds;
        responseXml = ppWs.GetInfoByShopperID(string.Empty, request.ShopperID);

        if (responseXml.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(requestData
            , "EcommPaymentProfilesRequest.RequestHandler"
            , responseXml
            , requestData.ToXML());

          responseData = new EcommPaymentProfilesResponseData(responseXml, exAtlantis);
        }
        else
        {
          responseData = new EcommPaymentProfilesResponseData(requestData, responseXml);
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new EcommPaymentProfilesResponseData(responseXml, exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new EcommPaymentProfilesResponseData(responseXml, requestData, ex);
      }

      return responseData;
    }
  }
}
