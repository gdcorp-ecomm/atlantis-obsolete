using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductFaxThruEmail.Interface
{
  public class MyaProductFaxThruEmailResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;

    public IList<FaxThruEmailProduct> FaxThruEmailProducts { get; private set; }

    public IPagingResult PagingResult { get; private set; }

    public bool IsSuccess
    {
      get
      {
        return _atlantisException == null;
      }
    }

    public MyaProductFaxThruEmailResponseData(IList<FaxThruEmailProduct> fteProducts, int totalRecord, int totalPages)
    {
      FaxThruEmailProducts = fteProducts;
      PagingResult = new FaxThruEmailPagingResult(totalRecord, totalPages);
    }

    public MyaProductFaxThruEmailResponseData(MyaProductFaxThruEmailRequestData requestData, Exception ex)
    {
      FaxThruEmailProducts = new List<FaxThruEmailProduct>(1);
      PagingResult = new FaxThruEmailPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData,
                                                 MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                 string.Format("MyaProductFaxThruEmailRequest Error: {0}", ex.Message),
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
