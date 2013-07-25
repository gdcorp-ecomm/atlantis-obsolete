using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atlantis.Framework.Interface;
namespace Atlantis.Framework.GetBasketItemCounts.Interface
{
  public class GetBasketItemCountsRequestData : RequestData
  {
    public GetBasketItemCountsRequestData(string shopperID,
                            string sourceURL,
                            string orderID,
                            string pathway,
                            int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {

    }

    public override string GetCacheMD5()
    {
      throw new Exception("GetBasketItemCounts is not a cacheable request.");
    }
  }
}
