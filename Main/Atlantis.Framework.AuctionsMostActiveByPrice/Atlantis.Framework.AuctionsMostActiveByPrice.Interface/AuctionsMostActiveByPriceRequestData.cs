using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuctionsMostActiveByPrice.Interface
{
  public class AuctionsMostActiveByPriceRequestData : RequestData
  {
    private int _auctionCount;
    private TimeSpan _wsRequestTimeout;

    public AuctionsMostActiveByPriceRequestData( 
      string shopperID, string sourceURL, string orderID, string pathway,
      int pageCount, int auctionCount)
      : base (shopperID, sourceURL, orderID, pathway, pageCount)
    {
      _auctionCount = auctionCount;
      _wsRequestTimeout = new TimeSpan(0, 0, 2);
    }

    public int AuctionCount
    {
      get { return _auctionCount; }
      set { _auctionCount = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _wsRequestTimeout; }
      set { _wsRequestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new Exception("AuctionsByArea is not a cacheable request.");
    }
  }
}
