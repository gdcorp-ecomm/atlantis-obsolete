﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ShopperPinSet.Interface
{
  public class ShopperPinSetRequestData : RequestData
  {
    public ShopperPinSetRequestData(string shopperID,
                            string sourceURL,
                            string orderID,
                            string pathway,
                            int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {

    }

    public override string GetCacheMD5()
    {
      throw new Exception("ShopperPinSet is not a cacheable request.");
    }
  }
}
