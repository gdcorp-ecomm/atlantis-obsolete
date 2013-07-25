using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;

namespace Atlantis.Framework.MyaProductQBC.Interface
{
  public class MyaProductQBCRequestData : RequestData
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

    #endregion
    public MyaProductQBCRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount
      , int privateLabelId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      PrivateLabelId = privateLabelId;
      SortColumn = SortColumnType.AccountExpirationDate;
      SortDirection = SortDirectionType.Ascending;
      RequestTimeout = TimeSpan.FromSeconds(5);
      PagingInfo = new QBCPagingInfo();
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MyaProductQBCRequestData");     
    }
  }
}
