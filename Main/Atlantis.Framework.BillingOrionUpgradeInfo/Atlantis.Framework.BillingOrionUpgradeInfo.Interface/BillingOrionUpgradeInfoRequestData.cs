using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BillingOrionUpgradeInfo.Interface
{
  public class BillingOrionUpgradeInfoRequestData : RequestData
  {
    #region Properties
    private int _resourceId;
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public int ResourceId
    {
      get { return _resourceId; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    #endregion

    public BillingOrionUpgradeInfoRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  int resourceId)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _resourceId = resourceId;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in BillingOrionUpgradeInfoRequestData");     
    }


  }
}
