using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ExpressCheckoutUpdate.Interface
{
  public class ExpressCheckoutUpdateRequestData : RequestData
  {
    public ExpressCheckoutUpdateRequestData(
      string shopperId,
      int paymentProfileId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      PaymentProfileId = paymentProfileId;
    }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    public int PaymentProfileId { get; set; }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }
  }
}