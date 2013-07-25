using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommValidPaymentCurrencies.Interface
{
  public class EcommValidPaymentCurrenciesRequestData : RequestData
  {
    private static readonly TimeSpan _defaultRequestTimeout = TimeSpan.FromSeconds(20);

    public string BasketType { get; set; }

    public TimeSpan RequestTimeout { get; set; }

    public EcommValidPaymentCurrenciesRequestData(string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, string basketType) : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      BasketType = basketType;
      RequestTimeout = _defaultRequestTimeout;
    }

    public override string GetCacheMD5()
    {
      throw new Exception("EcommValidPaymentCurrenciesRequestData is not a cacheable request.");
    }
  }
}
