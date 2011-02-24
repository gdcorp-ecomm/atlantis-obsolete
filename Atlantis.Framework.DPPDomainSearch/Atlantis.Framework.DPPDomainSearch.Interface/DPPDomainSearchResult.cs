using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.DPPDomainSearch.Interface
{
  public class DPPDomainNameMatch
  {
    public DPPDomainSearchVendor VendorId { get; set; }
    public int AuctionId { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int CommissionPct { get; set; }
    public string AuctionType { get; set; }
    public DateTime AuctionEndTime { get; set; }

    public DPPDomainNameMatch()
    {
    }

    public DPPDomainNameMatch(DPPDomainSearchVendor vendorId, int id, string name, int price, int pct, string auctionType, string auctionEndTime)
    {
      VendorId = vendorId;
      AuctionId = id;
      Name = name;
      Price = price;
      CommissionPct = pct;
      AuctionType = auctionType;
      DateTime endTime = DateTime.Now;
      DateTime.TryParse(auctionEndTime, out endTime);
      AuctionEndTime = endTime;
    }
  }

  public class DPPDomainSearchResult
  {
    public string Server { get; set; }
    public string DateTime { get; set; }

    public DPPDomainNameMatch ExactMatch { get; private set; }

    public List<DPPDomainNameMatch> PremiumMatch { get; private set; }

    public void AddExactMatch(DPPDomainSearchVendor vendorId, int id, string name, int price, int pct, string auctionType, string auctionEndTime)
    {
      ExactMatch = new DPPDomainNameMatch(vendorId, id, name, price, pct, auctionType, auctionEndTime);
    }

    public void AddPremiumMatch(DPPDomainSearchVendor vendorId, int id, string name, int price, int pct, string auctionType, string auctionEndTime)
    {
      if (PremiumMatch == null)
        PremiumMatch = new List<DPPDomainNameMatch>();

      PremiumMatch.Add(new DPPDomainNameMatch(vendorId, id, name, price, pct, auctionType, auctionEndTime));
    }

    public void AddExactMatch(DPPDomainNameMatch match)
    {
      ExactMatch = match;
    }

    public void AddPremiumMatch(DPPDomainNameMatch match)
    {
      if (PremiumMatch == null)
        PremiumMatch = new List<DPPDomainNameMatch>();

      PremiumMatch.Add(match);
    }

  }
}
