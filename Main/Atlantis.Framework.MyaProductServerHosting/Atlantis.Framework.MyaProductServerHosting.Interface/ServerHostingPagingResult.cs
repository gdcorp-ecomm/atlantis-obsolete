using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductServerHosting.Interface
{
  public class ServerHostingPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal ServerHostingPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
