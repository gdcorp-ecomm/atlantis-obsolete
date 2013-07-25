using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSiteAnalytics.Interface
{
  public class SiteAnalyticsPagingResult : IPagingResult
  {
    public int TotalNumberOfRecords { get; private set; }

    public int TotalNumberOfPages { get; private set; }

    internal SiteAnalyticsPagingResult(int totalNumberOfRecords, int totalNumberOfPages)
    {
      TotalNumberOfRecords = totalNumberOfRecords;
      TotalNumberOfPages = totalNumberOfPages;
    }
  }
}
