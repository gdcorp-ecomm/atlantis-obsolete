using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.IsShopperInOptoutList.Interface
{
  public class ShopperInOptoutListRequestData : RequestData 
  {
    private int _privateLabelId = 0;
    public int PrivateLabelId
    {
      get { return _privateLabelId; }
    }

    private string _isoptedout;
    public string IsOptedOut
    {
      get { return _isoptedout; }
      set { _isoptedout = value; }
    }

    public ShopperInOptoutListRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      int privateLabelId, string isoptedout)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _privateLabelId = privateLabelId;
      _isoptedout = isoptedout;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("Checking if the shopper is in Opt Out List is not a cacheable request.");
    }
  }
}
