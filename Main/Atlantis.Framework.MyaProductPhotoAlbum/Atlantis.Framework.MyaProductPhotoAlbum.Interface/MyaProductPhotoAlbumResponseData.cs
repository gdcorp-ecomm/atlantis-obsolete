using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductPhotoAlbum.Interface
{
  public class MyaProductPhotoAlbumResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;

    public IList<PhotoAlbumProduct> PhotoAlbumProducts { get; private set; }

    public IPagingResult PagingResult { get; private set; }

    public bool IsSuccess
    {
      get
      {
        return _atlantisException == null;
      }
    }

    public MyaProductPhotoAlbumResponseData(IList<PhotoAlbumProduct> paProducts, int totalRecord, int totalPages)
    {
      PhotoAlbumProducts = paProducts;
      PagingResult = new PhotoAlbumPagingResult(totalRecord, totalPages);
    }

    public MyaProductPhotoAlbumResponseData(MyaProductPhotoAlbumRequestData requestData, Exception ex)
    {
      PhotoAlbumProducts = new List<PhotoAlbumProduct>(1);
      PagingResult = new PhotoAlbumPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData,
                                                 MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                 string.Format("MyaProductPhotoAlbumRequest Error: {0}", ex.Message),
                                                 ex.Data.ToString(),
                                                 ex);
    }

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _atlantisException;
    }
  }
}
