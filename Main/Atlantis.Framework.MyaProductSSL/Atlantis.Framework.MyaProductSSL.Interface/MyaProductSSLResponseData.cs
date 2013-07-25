using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSSL.Interface
{
  public class MyaProductSSLResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;

    public IList<SSLProduct> SSLProducts { get; private set; }

    public IPagingResult PagingResult { get; private set; }

    public bool IsSuccess
    {
      get
      {
        return _atlantisException == null;
      }
    }

    public MyaProductSSLResponseData(IList<SSLProduct> sslProducts, int totalRecord, int totalPages)
    {
      SSLProducts = sslProducts;
      PagingResult = new SSLPagingResult(totalRecord, totalPages);
    }

    public MyaProductSSLResponseData(MyaProductSSLRequestData requestData, Exception ex)
    {
      SSLProducts = new List<SSLProduct>(1);
      PagingResult = new SSLPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData,
                                                 MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                 string.Format("MyaProductSSLRequest Error: {0}", ex.Message),
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
