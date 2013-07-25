using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductReseller.Interface
{
  public class ResellerPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal ResellerPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
