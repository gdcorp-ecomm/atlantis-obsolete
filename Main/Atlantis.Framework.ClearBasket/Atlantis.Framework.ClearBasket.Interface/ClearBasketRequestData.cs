using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ClearBasket.Interface
{
    public class ClearBasketRequestData : RequestData
    {
        public ClearBasketRequestData(string shopperID,
                                string sourceURL,
                                string orderID,
                                string pathway,
                                int pageCount)
            : base(shopperID, sourceURL, orderID, pathway, pageCount)
        {

        }

        public override string GetCacheMD5()
        {
            throw new Exception("ClearBasket is not a cacheable request.");
        }
        string _basketType = "gdshop";
        public string BasketType
        {
          get { return _basketType; }
          set { _basketType = value; }
        }
    }
}
