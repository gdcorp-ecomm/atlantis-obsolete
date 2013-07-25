using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommInstoreBalance.Interface
{
  public class EcommInstoreBalanceRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; private set; }

    public EcommInstoreBalanceRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }
  }
}