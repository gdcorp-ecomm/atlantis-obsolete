using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ShopperPrefGetModDate.Interface
{
  public class ShopperPrefGetModDateRequestData : RequestData
  {

    public ShopperPrefGetModDateRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
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
      throw new NotImplementedException("GetCacheMD5 not implemented in ShopperPrefGetModDateRequestData");     
    }


  }
}
