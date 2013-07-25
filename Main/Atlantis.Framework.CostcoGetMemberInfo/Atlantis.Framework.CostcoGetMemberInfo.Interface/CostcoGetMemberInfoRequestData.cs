using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CostcoGetMemberInfo.Interface
{
  public class CostcoGetMemberInfoRequestData : RequestData
  {
    public CostcoGetMemberInfoRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount) 
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      if (string.IsNullOrEmpty(shopperId))
      {
        throw new ArgumentException("Must provide a value.", "shopperId");
      }
    }

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 10);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }
  }
}
