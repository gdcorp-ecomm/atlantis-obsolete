using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;

namespace Atlantis.Framework.MyaProductServerHosting.Interface
{
  public class MyaProductServerHostingRequestData : RequestData
  {
    #region Properties
    public enum SortColumnType
    {
      AccountExpirationDate,
      CommonName,
    }

    public int PrivateLabelId { get; set; }

    /// <summary>
    /// Default of Expiration Date
    /// </summary>
    public SortColumnType SortColumn { get; set; }

    /// <summary>
    /// Default of Ascending
    /// </summary>
    public SortDirectionType SortDirection { get; set; }

    public IPagingInfo PagingInfo { get; set; }

    /// <summary>
    /// Default of 5 seconds
    /// </summary>
    public TimeSpan RequestTimeout { get; set; }

    public bool IncludePendingSetupAccounts { get; set; }

    public ServerType Type { get; set; }

    #endregion

    public MyaProductServerHostingRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount
      , int privateLabelId
      , bool includePendingSetupAccounts
      , ServerType type)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      PrivateLabelId = privateLabelId;
      SortColumn = SortColumnType.AccountExpirationDate;
      SortDirection = SortDirectionType.Ascending;
      RequestTimeout = TimeSpan.FromSeconds(5);
      PagingInfo = new ServerHostingPagingInfo();
      IncludePendingSetupAccounts = includePendingSetupAccounts;
      Type = type;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MyaProductServerHostingRequestData");
    }

    public enum ServerType
    {
      DedHosting,
      VDedHosting,
      Ded_And_VDedHosting
    }

  }
}
