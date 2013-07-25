using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAResourceStatus.Interface
{
  public class MYAResourceStatusRequestData : RequestData
  {
    #region Properties
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 5);

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public int BillingResourceId { get; set; }

    #endregion

    public MYAResourceStatusRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  int billingResourceId )
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      BillingResourceId = billingResourceId;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MYAResourceStatusRequestData");     
    }
  }
}
