using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BonzaiApplyAddOn.Interface
{
  public class BonzaiApplyAddOnResponseData : IResponseData
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

    public BonzaiApplyAddOnResponseData()
    {
      _success = true;
    }

     public BonzaiApplyAddOnResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public BonzaiApplyAddOnResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "BonzaiApplyAddOnResponseData",
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
