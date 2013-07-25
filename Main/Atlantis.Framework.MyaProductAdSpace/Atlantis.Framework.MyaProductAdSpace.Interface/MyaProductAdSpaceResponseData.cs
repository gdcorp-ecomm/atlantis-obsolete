using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductAdSpace.Interface
{
  public class MyaProductAdSpaceResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;

    public IList<AdSpaceProduct> AdSpaceProducts { get; private set; }

    public IPagingResult PagingResult { get; private set; }

    public bool IsSuccess
    {
      get
      {
        return _atlantisException == null;
      }
    }

    public MyaProductAdSpaceResponseData(IList<AdSpaceProduct> adSpaceProducts, int totalRecord, int totalPages)
    {
      AdSpaceProducts = adSpaceProducts;
      PagingResult = new AdSpacePagingResult(totalRecord, totalPages);
    }

    public MyaProductAdSpaceResponseData(MyaProductAdSpaceRequestData requestData, Exception ex)
    {
      AdSpaceProducts = new List<AdSpaceProduct>(1);
      PagingResult = new AdSpacePagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData,
                                                 MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                 string.Format("MyaProductAdSpaceRequest Error: {0}", ex.Message),
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
