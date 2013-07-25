using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSiteAnalytics.Interface
{
  public class MyaProductSiteAnalyticsResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<SiteAnalyticsProduct> SiteAnalyticsProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductSiteAnalyticsResponseData(IList<SiteAnalyticsProduct> siteAnalyticsProducts, int totalRecords, int totalPages)
    {
      SiteAnalyticsProducts = siteAnalyticsProducts;
      PagingResult = new SiteAnalyticsPagingResult(totalRecords, totalPages);
    }

     public MyaProductSiteAnalyticsResponseData(AtlantisException atlantisException)
    {
      SiteAnalyticsProducts = new List<SiteAnalyticsProduct>(1);
      PagingResult = new SiteAnalyticsPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductSiteAnalyticsResponseData(RequestData requestData, Exception ex)
    {
      SiteAnalyticsProducts = new List<SiteAnalyticsProduct>(1);
      PagingResult = new SiteAnalyticsPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductSafeSite Error: {0}", ex.Message)
        , ex.Data.ToString()
        , ex); 
    }

    #region IResponseData Members

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _atlantisException;
    }

    #endregion

  }
}
