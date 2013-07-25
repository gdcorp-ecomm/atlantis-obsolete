using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MktgSetShopperCommDoubleOpt.Interface
{
  public class MktgSetShopperCommDoubleOptRequestData: RequestData
  {
    public TimeSpan RequestTimeout { get; set; }
    public int CommPreferenceTypeId { get; set; }

    public MktgSetShopperCommDoubleOptRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      int comPreferenceTypeId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      CommPreferenceTypeId=comPreferenceTypeId;
      RequestTimeout = TimeSpan.FromSeconds(4);
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("MktgSetShopperCommDoubleOptRequestData is not a cacheable request.");
    }
  }
}
