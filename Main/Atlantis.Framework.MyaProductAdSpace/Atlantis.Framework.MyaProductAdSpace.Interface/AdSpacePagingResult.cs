using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductAdSpace.Interface
{
  public class AdSpacePagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal AdSpacePagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
