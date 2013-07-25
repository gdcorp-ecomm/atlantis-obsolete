using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.XCPaymentProfileCheck.Impl.PaymentProfile;
using Atlantis.Framework.XCPaymentProfileCheck.Interface;

namespace Atlantis.Framework.XCPaymentProfileCheck.Impl
{
  public class XCPaymentProfileCheckRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      XCPaymentProfileCheckResponseData responseData = null;
      string wsResponse = string.Empty;
      bool hasInstantPurchasePayment = false;

      try
      {
        XCPaymentProfileCheckRequestData paymentProfileRequest = (XCPaymentProfileCheckRequestData)requestData;
        PaymentProfile.Service ppWS = new Service();
        ppWS.Url = ((WsConfigElement)config).WSURL;
        ppWS.Timeout = (int)paymentProfileRequest.RequestTimeout.TotalMilliseconds;
        wsResponse = ppWS.ShopperHasInstantPurchasePayment(paymentProfileRequest.ShopperID, out hasInstantPurchasePayment);

        responseData = new XCPaymentProfileCheckResponseData(wsResponse, hasInstantPurchasePayment);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new XCPaymentProfileCheckResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new XCPaymentProfileCheckResponseData(requestData, ex);
      }

      return responseData;
    }
  }
}
