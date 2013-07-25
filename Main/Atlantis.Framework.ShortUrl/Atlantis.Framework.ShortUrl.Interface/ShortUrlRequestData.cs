using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ShortUrl.Interface
{
  public class ShortUrlRequestData : RequestData
  {
    public string Url { get; set; }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(10);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public ShortUrlRequestData(string url, string shopperId, string sourceURL, string orderId, string pathway, int pageCount) : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      Url = url;
    }

    public override string GetCacheMD5()
    {
      throw new Exception("ShortUrl is not a cacheable request.");
    }
  }
}
