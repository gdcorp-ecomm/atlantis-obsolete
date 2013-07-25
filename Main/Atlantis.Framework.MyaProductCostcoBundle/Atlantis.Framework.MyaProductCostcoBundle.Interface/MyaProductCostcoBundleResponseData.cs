using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductCostcoBundle.Interface
{
  public class MyaProductCostcoBundleResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<CostcoBundleProduct> CostcoBundleProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductCostcoBundleResponseData(IList<CostcoBundleProduct> costcoBundleProducts, int totalRecords, int totalPages)
    {
      CostcoBundleProducts = costcoBundleProducts;
      PagingResult = new CostcoBundlePagingResult(totalRecords, totalPages);
    }

    public MyaProductCostcoBundleResponseData(AtlantisException atlantisException)
    {
      CostcoBundleProducts = new List<CostcoBundleProduct>(1);
      PagingResult = new CostcoBundlePagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductCostcoBundleResponseData(RequestData requestData, Exception ex)
    {
      CostcoBundleProducts = new List<CostcoBundleProduct>(1);
      PagingResult = new CostcoBundlePagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaCostcoBundle Error: {0}", ex.Message)
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
