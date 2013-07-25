using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using System.Reflection;

namespace Atlantis.Framework.MyaProductGetByRid.Interface
{
  public partial class MyaProductGetByRidResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public MyaProductAccount ProductAccount { get; set; }

    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductGetByRidResponseData(MyaProductAccount product)
    {
      ProductAccount = product;
    }

    public MyaProductGetByRidResponseData(AtlantisException atlantisException)
    {
      _atlantisException = atlantisException;
    }

    public MyaProductGetByRidResponseData(RequestData requestData, Exception ex)
    {
      ProductAccount = null;
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
