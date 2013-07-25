using System;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.RenewalsGetRenewingDomains.Interface
{
  public class RenewalsGetRenewingDomainsRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }

    private int _daystoexpiration = 90;
    public int DaysToExpiration
    {
      get
      {
        return _daystoexpiration;
      }
      set
      {
        if (value > 0)
        {
          _daystoexpiration = value;
        }
      }
    }

    private int _domainstoreturn = 20;
    public int DomainsToReturn
    {
      get
      {
        return _domainstoreturn;
      }
      set
      {
        if (value > 0)
        {
          _domainstoreturn = value;
        }
      }
    }

    public RenewalsGetRenewingDomainsRequestData(
      string shopperID,
      string sourceURL,
      string orderID,
      string pathway,
      int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
    }

    public RenewalsGetRenewingDomainsRequestData(
      string shopperID,
      string sourceURL,
      string orderID,
      string pathway,
      int pageCount, int daysToExpiration, int domainsToReturn)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      DaysToExpiration = daysToExpiration;
      DomainsToReturn = domainsToReturn;
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      return string.Empty;
    }

    #endregion
  }
}
