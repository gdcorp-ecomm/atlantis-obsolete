using System;
using Atlantis.Framework.GetCoupons.Impl.WSCgdAdWordCouponService;
using Atlantis.Framework.GetCoupons.Interface;
using Atlantis.Framework.Interface;


namespace Atlantis.Framework.GetCoupons.Impl
{
  /// <summary>
  /// Get all Adword credits for a shopper
  /// </summary>
  public class GetCouponsRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      GetCouponsResponseData responseData = null;

      try
      {
        GetCouponsRequestData getCouponsRequestData = (GetCouponsRequestData)requestData;
        
        WSCgdAdWordCouponsService ws = new WSCgdAdWordCouponsService();

        ws.Url = (((WsConfigElement)config).WSURL);
        ws.Timeout = (int)getCouponsRequestData.RequestTimeOut.TotalMilliseconds;

        string responseXml = ws.GetCoupons(getCouponsRequestData.ShopperID);

        responseData = new GetCouponsResponseData(responseXml);
      }     

      catch (AtlantisException exAtlantis)
      {
        responseData = new GetCouponsResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new GetCouponsResponseData(requestData, ex);
      }
       
      return responseData;
    }
  }
}
