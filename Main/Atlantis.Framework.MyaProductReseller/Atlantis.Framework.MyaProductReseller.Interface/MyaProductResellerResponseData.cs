using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductReseller.Interface
{
  public class MyaProductResellerResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException = null;
    public IList<ResellerProduct> ResellerProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductResellerResponseData(IList<ResellerProduct> resellerProducts, int totalRecords, int totalPages)
    {
      ResellerProducts = resellerProducts;
      PagingResult = new ResellerPagingResult(totalRecords, totalPages);
    }

    public MyaProductResellerResponseData(AtlantisException atlantisException)
    {
      ResellerProducts = new List<ResellerProduct>(1);
      PagingResult = new ResellerPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductResellerResponseData(RequestData requestData, Exception ex)
    {
      ResellerProducts = new List<ResellerProduct>(1);
      PagingResult = new ResellerPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductReseller Error: {0}", ex.Message)
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
