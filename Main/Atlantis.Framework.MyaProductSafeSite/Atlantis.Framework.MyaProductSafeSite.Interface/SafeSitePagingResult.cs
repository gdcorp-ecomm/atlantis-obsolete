using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSafeSite.Interface
{
  public class SafeSitePagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal SafeSitePagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
