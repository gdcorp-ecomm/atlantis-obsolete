using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductEEM.Interface
{
  public class EEMPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal EEMPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
