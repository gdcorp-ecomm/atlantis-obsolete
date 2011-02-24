using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.DPPDomainSearch.Interface
{
  public enum DPPDomainSearchVendor : int
  {
    Unknown = -1,
    Auctions = 0,
    FabulousDomains = 1,
    DomainsBot = 2,
    NameMedia = 3
  }
  public class DPPDomainSearchVendorList : List<DPPDomainSearchVendor>
  {
  }
}
