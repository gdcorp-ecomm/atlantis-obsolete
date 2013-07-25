using System;
using Atlantis.Framework.EcommValidPaymentCurrencies.Impl.WscgdPayment;
using Atlantis.Framework.EcommValidPaymentCurrencies.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommValidPaymentCurrencies.Impl
{
  public class EcommValidPaymentCurrenciesRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      EcommValidPaymentCurrenciesRequestData ecommValidPaymentTypeRequestData = (EcommValidPaymentCurrenciesRequestData)requestData;
      EcommValidPaymentCurrenciesResponseData responseData;

      WSCgdPaymentTypesService wscgdPaymentService = null;

      try
      {
        wscgdPaymentService = new WSCgdPaymentTypesService();
        wscgdPaymentService.Url = ((WsConfigElement)config).WSURL;
        wscgdPaymentService.Timeout = (int)ecommValidPaymentTypeRequestData.RequestTimeout.TotalMilliseconds;

        string responseXml;
        int resultCode = wscgdPaymentService.GetActivePaymentCurrencies(ecommValidPaymentTypeRequestData.BasketType, out responseXml);
        responseData = new EcommValidPaymentCurrenciesResponseData(requestData, responseXml, resultCode);
      }
      catch (Exception ex)
      {
        responseData = new EcommValidPaymentCurrenciesResponseData(requestData, ex);
      }
      finally
      {
        if(wscgdPaymentService != null)
        {
          wscgdPaymentService.Dispose();
        }
      }
      return responseData;
    }
  }
}
