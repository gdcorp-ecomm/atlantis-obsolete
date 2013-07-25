using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSafeSite.Interface
{
  public class MyaProductSafeSiteResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<SafeSiteProduct> SafeSiteProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductSafeSiteResponseData(IList<SafeSiteProduct> safeSiteProducts, int totalRecords, int totalPages)
    {
      SafeSiteProducts = safeSiteProducts;
      PagingResult = new SafeSitePagingResult(totalRecords, totalPages);
    }

     public MyaProductSafeSiteResponseData(AtlantisException atlantisException)
    {
      _atlantisException = atlantisException;
    }

    public MyaProductSafeSiteResponseData(RequestData requestData, Exception ex)
    {
      SafeSiteProducts = new List<SafeSiteProduct>(1);
      PagingResult = new SafeSitePagingResult(0, 0);
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
