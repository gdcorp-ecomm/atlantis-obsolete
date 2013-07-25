using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ExpressCheckoutDelete.Interface
{
  public class ExpressCheckoutDeleteRequestData : RequestData
  {
    public ExpressCheckoutDeleteRequestData(
      string shopperId,      
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {      
    }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);
    

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