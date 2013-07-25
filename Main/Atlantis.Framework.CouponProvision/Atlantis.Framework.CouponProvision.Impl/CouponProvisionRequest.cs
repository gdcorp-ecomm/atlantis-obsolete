using System;
using Atlantis.Framework.CouponProvision.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CouponProvision.Impl
{
  public class CouponProvisionRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      CouponProvisionResponseData responseData;
      try
      {
        CouponProvisionRequestData couponProvisionRequestData = (CouponProvisionRequestData)requestData;
        GDAdWordCoupons.WSCgdAdWordCouponsService adWordWS = new GDAdWordCoupons.WSCgdAdWordCouponsService();
        adWordWS.Url = ((WsConfigElement)config).WSURL;
        adWordWS.Timeout = (int)couponProvisionRequestData.RequestTimeout.TotalMilliseconds;

        string result = adWordWS.ProvisionCoupon(couponProvisionRequestData.ShopperID, couponProvisionRequestData.CouponKey);

        responseData = new CouponProvisionResponseData(result);
      }
      catch (AtlantisException atlantisException)
      {
        responseData = new CouponProvisionResponseData(atlantisException);
      }
      catch (Exception ex)
      {
        responseData = new CouponProvisionResponseData(requestData, ex);
      }

      return responseData;
    }
  }
}
