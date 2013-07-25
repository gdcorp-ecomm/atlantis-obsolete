using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ResourceSslBillingInfo.Interface
{
  public class ResourceSslBillingInfoRequestData : RequestData
  {
    #region Properties
    public TimeSpan RequestTimeout { get; set; }
    public int BillingResourceId { get; private set; }
    #endregion

    public ResourceSslBillingInfoRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount
      , int billingResourceId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = new TimeSpan(0, 0, 5);
      BillingResourceId = billingResourceId;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in ResourceSslBillingInfoRequestData");     
    }
  }
}
