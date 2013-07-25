using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DBSSellerNotInterested.Interface
{
  public class DBSSellerNotInterestedRequestData : RequestData
  {
    private int _resourceId;
    private TimeSpan _requestTimeout;
    
    public DBSSellerNotInterestedRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount, 
    int resourceId)
      : base (shopperId, sourceURL, orderId, pathway, pageCount)
    {
      _resourceId = resourceId;
      _requestTimeout = TimeSpan.FromSeconds(4);
    }

    public int ResourceId
    {
      get { return _resourceId; }
      set { _resourceId = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new Exception("DBSSellerNotInterested is not a cacheable request.");
    }

  }
}
