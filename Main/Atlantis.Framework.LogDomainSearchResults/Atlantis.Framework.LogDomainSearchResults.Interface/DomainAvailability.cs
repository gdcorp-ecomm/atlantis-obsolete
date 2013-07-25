using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.LogDomainSearchResults.Interface
{
  public static class DomainAvailability
  {
    public const int NotAvailable = 0;
    public const int Available = 1;
    public const int Backorder = 2;
    public const int Unknown = 99;
  }
}
