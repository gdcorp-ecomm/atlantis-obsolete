using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SBSDomainRegistrar.Interface
{
  public class SBSDomainRegistrarRequestData : RequestData
  {
    public SBSDomainRegistrarRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string domain) :
      base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      Domain = domain;
    }

    public TimeSpan RequestTimeout { get; set; }
    public string Domain { get; set; }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("SBSDomainRegistrar is not a cacheable request.");
    }
  }
}
