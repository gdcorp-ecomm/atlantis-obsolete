using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetMiniCart.Interface
{
  public class GetMiniCartRequestData : RequestData
  {
    private string _basketType = string.Empty;
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(3);

    public GetMiniCartRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount)
                                  : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
    }

    public string BasketType
    {
      get { return _basketType; }
      set { _basketType = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      throw new Exception("GetMiniCart is not a cacheable request.");
    }

    #endregion
  }
}
