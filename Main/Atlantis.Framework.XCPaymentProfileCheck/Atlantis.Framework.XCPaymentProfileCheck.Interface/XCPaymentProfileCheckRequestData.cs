using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.XCPaymentProfileCheck.Interface
{
  public class XCPaymentProfileCheckRequestData : RequestData
  {
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public XCPaymentProfileCheckRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    { }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in XCPaymentProfileCheckRequestData");     
    }


  }
}
