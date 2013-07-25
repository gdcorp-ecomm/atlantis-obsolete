using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductOFF.Interface
{
  public class MyaProductOFFResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;

    public IList<OFFProduct> OFFProducts { get; private set; }

    public IPagingResult PagingResult { get; private set; }

    public bool IsSuccess
    {
      get
      {
        return _atlantisException == null;
      }
    }

    public MyaProductOFFResponseData(IList<OFFProduct> offProducts, int totalRecord, int totalPages)
    {
      OFFProducts = offProducts;
      PagingResult = new OFFPagingResult(totalRecord, totalPages);
    }

    public MyaProductOFFResponseData(MyaProductOFFRequestData requestData, Exception ex)
    {
      OFFProducts = new List<OFFProduct>(1);
      PagingResult = new OFFPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData,
                                                 MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                 string.Format("MyaProductOFFRequest Error: {0}", ex.Message),
                                                 ex.Data.ToString(),
                                                 ex);
    }

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _atlantisException;
    }
  }
}
