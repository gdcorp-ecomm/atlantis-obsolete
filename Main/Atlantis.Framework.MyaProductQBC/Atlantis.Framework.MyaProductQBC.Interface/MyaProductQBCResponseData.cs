using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductQBC.Interface
{
  public class MyaProductQBCResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<QBCProduct> QBCProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductQBCResponseData(IList<QBCProduct> qbcProducts, int totalRecords, int totalPages)
    {
      QBCProducts = qbcProducts;
      PagingResult = new QBCPagingResult(totalRecords, totalPages);
    }

     public MyaProductQBCResponseData(AtlantisException atlantisException)
    {
      QBCProducts = new List<QBCProduct>(1);
      PagingResult = new QBCPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductQBCResponseData(RequestData requestData, Exception ex)
    {
      QBCProducts = new List<QBCProduct>(1);
      PagingResult = new QBCPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductQBC Error: {0}", ex.Message)
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
