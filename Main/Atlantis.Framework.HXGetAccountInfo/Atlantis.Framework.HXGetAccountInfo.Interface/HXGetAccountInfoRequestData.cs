using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.HXGetAccountInfo.Interface
{
  public class HXGetAccountInfoRequestData : RequestData
  {

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 5);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public string AccountUid { get; set; }

    public HXGetAccountInfoRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  string accountUid)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      if (string.IsNullOrEmpty(accountUid)) { throw new AtlantisException(this, "HXGetAccountInfoRequestData", "accountUid cannot be null or empty", string.Empty); }
      AccountUid = accountUid;
    }

    public override string GetCacheMD5()
    {
      // It is not expected that this request will use Session or Data cache
      throw new NotImplementedException("GetCacheMD5 not implemented in HxGetAccountInfo");
    }

    public override string ToXML()
    {
      return string.Format(@"<HXGetAccountInfoRequestData><ShopperId>{0}</ShopperId><AccountUid>{1}</AccountUid></HXGetAccountInfoRequestData>", ShopperID, AccountUid);
    }
  }
}
