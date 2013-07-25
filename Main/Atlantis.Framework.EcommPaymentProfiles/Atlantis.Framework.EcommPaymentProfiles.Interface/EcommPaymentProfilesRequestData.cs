using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommPaymentProfiles.Interface
{
  public class EcommPaymentProfilesRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }

    public EcommPaymentProfilesRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = new TimeSpan(0, 0, 5);
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in EcommPaymentProfilesRequestData");     
    }
  }
}
