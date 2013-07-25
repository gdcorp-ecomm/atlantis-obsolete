using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYARenewalDomains.Interface
{
  public class MYARenewalDomainsRequestData : RequestData
  {
    public enum SortColumnType
    {
      ExpirationDate,
      Domain,
    }

    public enum SortDirectionType
    {
      Ascending,
      Descending
    }

    public TimeSpan RequestTimeout { get; set; }

    public int DaysToExpiration { get; set; }

    public int DomainsToReturn { get; set; }

    public string Contains { get; set; }

    public int PageNumber { get; set; }

    /// <summary>
    /// Default of Expiration Date
    /// </summary>
    public SortColumnType SortColumn { get; set; }

    /// <summary>
    /// Default of Ascending
    /// </summary>
    public SortDirectionType SortDirection { get; set; }

    public MYARenewalDomainsRequestData(
      string shopperID,
      string sourceURL,
      string orderID,
      string pathway,
      int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      DaysToExpiration = 90;
      DomainsToReturn = 20;
      Contains = string.Empty;
      PageNumber = 1;
      SortColumn = SortColumnType.ExpirationDate;
      SortDirection = SortDirectionType.Ascending;
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      return string.Empty;
    }

    #endregion
  }
}
