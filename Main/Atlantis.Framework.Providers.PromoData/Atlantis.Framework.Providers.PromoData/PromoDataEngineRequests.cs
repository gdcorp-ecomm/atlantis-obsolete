using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.Providers.PromoData
{
  public static class PromoDataEngineRequests
  {
    private static int _getPromoDataRequest = 365;
    public static int GetPromoDataRequest
    {
      get { return _getPromoDataRequest; }
      set { _getPromoDataRequest = value; }
    }
  }
}
