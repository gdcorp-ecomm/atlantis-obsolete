using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CouponProvision.Interface
{
  public class CouponProvisionRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }
    public int CouponKey { get; set; }

    public CouponProvisionRequestData(string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount,
      int couponKey)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      this.CouponKey = couponKey;
      this.RequestTimeout = new TimeSpan(0, 0, 2);
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }

  }
}
