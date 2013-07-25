using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductEEM.Interface
{
  public class MyaProductEEMResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<EEMProduct> EEMProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductEEMResponseData(IList<EEMProduct> eemProducts, int totalRecords, int totalPages)
    {
      EEMProducts = eemProducts;
      PagingResult = new EEMPagingResult(totalRecords, totalPages);
    }

     public MyaProductEEMResponseData(AtlantisException atlantisException)
    {
      EEMProducts = new List<EEMProduct>(1);
      PagingResult = new EEMPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductEEMResponseData(RequestData requestData, Exception ex)
    {
      EEMProducts = new List<EEMProduct>(1);
      PagingResult = new EEMPagingResult(0, 0);
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
