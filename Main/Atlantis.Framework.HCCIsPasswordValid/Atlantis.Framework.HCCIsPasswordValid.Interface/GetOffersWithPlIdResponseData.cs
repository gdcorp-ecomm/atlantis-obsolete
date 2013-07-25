using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.HCCIsPasswordValid.Interface;
using Atlantis.Framework.HCC.Interface;

namespace Atlantis.Framework.HCCIsPasswordValid.Interface
{
  public class HCCIsPasswordValidResponseData : IResponseData
  {
    HCCIsPasswordValidResponse _hccResponse;
    AtlantisException _exception = null;
    string _resultXml = string.Empty;

    bool _success = false;

    public bool IsSuccess { get { return _success; } }

    public HCCIsPasswordValidResponseData(HCCIsPasswordValidResponse hccResponse)
    {
      _hccResponse = hccResponse;
      _success = true;
    }

    public HCCIsPasswordValidResponseData(AtlantisException exception)
    {
      _exception = exception;
    }

    public HCCIsPasswordValidResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
        "HCCIsPasswordValidResponseData",
        exception.Message,
        string.Empty);
    }

    public string ToXML()
    {
      if (_hccResponse != null)
      {
        _resultXml = _hccResponse.ToXML();
      }

      return _resultXml;
    }

    public HCCIsPasswordValidResponse Response { get { return _hccResponse; } }

    public AtlantisException GetException()
    {
      return _exception;
    }
  }
}
