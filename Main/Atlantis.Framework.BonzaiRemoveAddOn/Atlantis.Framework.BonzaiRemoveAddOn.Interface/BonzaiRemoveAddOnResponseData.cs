using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BonzaiRemoveAddOn.Interface
{
  public class BonzaiRemoveAddOnResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;

    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public BonzaiRemoveAddOnResponseData()
    {
      _success = true;
    }

     public BonzaiRemoveAddOnResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public BonzaiRemoveAddOnResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "BonzaiRemoveAddOnResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      return _resultXML;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
