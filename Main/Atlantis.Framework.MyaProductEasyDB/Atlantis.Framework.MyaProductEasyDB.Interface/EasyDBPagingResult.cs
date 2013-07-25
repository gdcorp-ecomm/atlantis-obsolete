using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductEasyDB.Interface
{
  public class EasyDBPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal EasyDBPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
