using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSEV.Interface
{
  public class MyaProductSEVResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<SEVProduct> SEVProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductSEVResponseData(IList<SEVProduct> sevProducts, int totalRecords, int totalPages)
    {
      SEVProducts = sevProducts;
      PagingResult = new SEVPagingResult(totalRecords, totalPages);
    }

     public MyaProductSEVResponseData(AtlantisException atlantisException)
    {
      SEVProducts = new List<SEVProduct>(1);
      PagingResult = new SEVPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductSEVResponseData(RequestData requestData, Exception ex)
    {
      SEVProducts = new List<SEVProduct>(1);
      PagingResult = new SEVPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductSEV Error: {0}", ex.Message)
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
