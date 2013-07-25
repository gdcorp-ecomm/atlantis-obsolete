using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MyaShopperDataUpdate.Interface
{
  public class MyaShopperDataUpdateRequestData : RequestData
  {
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public int Category { get; set; }
    public string Data { get; set; }

    public MyaShopperDataUpdateRequestData(string shopperID,
                                           string sourceUrl,
                                           string orderID,
                                           string pathway,
                                           int pageCount,
                                           int category,
                                           string data)
      : base(shopperID, sourceUrl, orderID, pathway, pageCount)
    {
      Category = category;
      Data = data;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("MyaShopperDataUpdateRequestData is not a cacheable request");
    }
  }
}
