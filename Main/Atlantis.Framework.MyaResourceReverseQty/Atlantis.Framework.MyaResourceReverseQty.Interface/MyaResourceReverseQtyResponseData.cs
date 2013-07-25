using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MyaResourceReverseQty.Interface
{
  public partial class MyaResourceReverseQtyResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public List<ResourceReverseQty> ResourceReverseQtyList { get; set; }

    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaResourceReverseQtyResponseData(List<ResourceReverseQty> list)
    {
      ResourceReverseQtyList = list;
    }

    public MyaResourceReverseQtyResponseData(AtlantisException atlantisException)
    {
      _atlantisException = atlantisException;
    }

    public MyaResourceReverseQtyResponseData(RequestData requestData, Exception ex)
    {
      ResourceReverseQtyList = null;
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
