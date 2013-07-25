using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ShopperPrefGet.Interface
{
  public class ShopperPrefGetRequestData : RequestData
  {

    public ShopperPrefGetRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount) 
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {

    }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("ShopperPrefGet is not a cacheable request.");
    }
  }
}
