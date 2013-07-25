using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductFaxThruEmail.Interface
{
  public class FaxThruEmailPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal FaxThruEmailPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
