using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.PremiumDNS.Interface
{
  public class GetPremiumDNSStatusRequestData : RequestData
  {
    public int PrivateLabelId { get; set; }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(3);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public GetPremiumDNSStatusRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount, int privateLabelId) : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      PrivateLabelId = privateLabelId;
    }

    public override string GetCacheMD5()
    {
      throw new Exception("GetPremiumDNSStatus is not a cacheable request.");
    }
  }
}
