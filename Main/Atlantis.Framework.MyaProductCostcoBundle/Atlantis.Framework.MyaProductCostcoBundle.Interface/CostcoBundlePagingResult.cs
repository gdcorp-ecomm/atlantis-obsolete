using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductCostcoBundle.Interface
{
  public class CostcoBundlePagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal CostcoBundlePagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
