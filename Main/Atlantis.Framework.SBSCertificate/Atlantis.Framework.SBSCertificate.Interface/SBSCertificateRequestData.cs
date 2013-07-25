using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SBSCertificate.Interface
{
  public class SBSCertificateRequestData : RequestData
  {
    public SBSCertificateRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string domain) :
      base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      Domain = domain;
      RequestType = "request_certificate";
    }

    public TimeSpan RequestTimeout { get; set; }
    public string Domain { get; set; }
    public string RequestType { get; set; }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("SBSCerficate is not a cacheable request.");
    }

  }
}
