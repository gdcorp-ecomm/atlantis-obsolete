using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;

namespace Atlantis.Framework.MyaProductPhotoAlbum.Interface
{
  public class MyaProductPhotoAlbumRequestData : RequestData
  {
    public enum SortColumnType
    {
      ExpirationDate,
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
    /// Default of 4 seconds
    /// </summary>
    public TimeSpan RequestTimeout { get; set; }

    public MyaProductPhotoAlbumRequestData(string sShopperID,
                                              int privateLabelId,
                                              string sSourceURL,
                                              string sOrderID,
                                              string sPathway,
                                              int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      PrivateLabelId = privateLabelId;
      SortColumn = SortColumnType.ExpirationDate;
      SortDirection = SortDirectionType.Ascending;
      RequestTimeout = TimeSpan.FromSeconds(4);
      PagingInfo = new PhotoAlbumPagingInfo();
    }

    public override string GetCacheMD5()
    {
      throw new Exception("MyaProductPhotoAlbum is not a cacheable request");
    }
  }
}
