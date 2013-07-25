using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductEasyDB.Interface
{
  public class MyaProductEasyDBResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<EasyDBProduct> EasyDBProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductEasyDBResponseData(IList<EasyDBProduct> easyDBProducts, int totalRecords, int totalPages)
    {
      EasyDBProducts = easyDBProducts;
      PagingResult = new EasyDBPagingResult(totalRecords, totalPages);
    }

    public MyaProductEasyDBResponseData(AtlantisException atlantisException)
    {
      EasyDBProducts = new List<EasyDBProduct>(1);
      PagingResult = new EasyDBPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductEasyDBResponseData(RequestData requestData, Exception ex)
    {
      EasyDBProducts = new List<EasyDBProduct>(1);
      PagingResult = new EasyDBPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductEasyDB Error: {0}", ex.Message)
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
