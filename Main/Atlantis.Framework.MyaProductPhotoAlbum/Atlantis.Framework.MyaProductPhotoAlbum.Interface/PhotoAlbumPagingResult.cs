using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductPhotoAlbum.Interface
{
  public class PhotoAlbumPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal PhotoAlbumPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
