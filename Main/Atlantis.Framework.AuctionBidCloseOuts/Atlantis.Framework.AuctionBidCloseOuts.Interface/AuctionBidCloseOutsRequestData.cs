using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuctionBidCloseOuts.Interface
{
  public class AuctionBidCloseOutsRequestData : RequestData
  {
    #region Properties

    private string _domainName = String.Empty;
    public string DomainName
    {
      get { return _domainName; }
      set { _domainName = value; }
    }

    private bool _isShopperAuth = false;
    public bool IsShopperAuth
    {
      get { return _isShopperAuth; }
      set { _isShopperAuth = value; }
    }

    TimeSpan _requestTimeout = TimeSpan.FromMilliseconds(2500);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    #endregion Properties

    #region Constructors

    public AuctionBidCloseOutsRequestData(string sShopperID, string sSourceURL, 
      string sOrderID, string sPathway, int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
    }

    public AuctionBidCloseOutsRequestData(string sShopperID, string sSourceURL, 
      string sOrderID, string sPathway, int iPageCount, string domainName, bool isShopperAuth)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._domainName = domainName;
      this._isShopperAuth = isShopperAuth;
    }

    #endregion Constructors

    #region Public Methods

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }

    #endregion Public Methods

    #region Private Methods
    #endregion
  }
}
