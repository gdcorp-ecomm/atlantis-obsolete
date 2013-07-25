using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductServerHosting.Interface
{
  public class MyaProductServerHostingResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<ServerHostingProduct> ServerHostingProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductServerHostingResponseData(IList<ServerHostingProduct> serverHostingProducts, int totalRecord, int totalPages)
    {
      ServerHostingProducts = serverHostingProducts;
      PagingResult = new ServerHostingPagingResult(totalRecord, totalPages);
    }

    public MyaProductServerHostingResponseData(AtlantisException atlantisException)
    {
      ServerHostingProducts = new List<ServerHostingProduct>(1);
      PagingResult = new ServerHostingPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductServerHostingResponseData(RequestData requestData, Exception ex)
    {
      ServerHostingProducts = new List<ServerHostingProduct>(1);
      PagingResult = new ServerHostingPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductServerHosting Error: {0}", ex.Message)
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
