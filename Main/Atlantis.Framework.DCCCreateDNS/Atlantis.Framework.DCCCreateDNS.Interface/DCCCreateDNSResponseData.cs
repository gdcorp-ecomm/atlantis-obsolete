using System;
using System.Xml;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCCreateDNS.Interface
{
  public class DCCCreateDNSResponseData  : IResponseData
  {
    bool _isSuccess = false;
    string _responseXml;
    AtlantisException _exception;
    List<string> _errorList;

    public DCCCreateDNSResponseData(bool result)
    {
      _isSuccess = result;
    }

    public DCCCreateDNSResponseData(List<string> errorList)
    {
      _errorList = errorList;
    }

    public DCCCreateDNSResponseData(string responseXML, AtlantisException exAtlantis)
    {
      _responseXml = responseXML;
      _exception = exAtlantis;
    }

    public DCCCreateDNSResponseData(string responseXML, RequestData oRequestData, Exception ex)
    {
      _responseXml = responseXML;
      _exception = new AtlantisException(oRequestData,
                                   "DCCCreateDNSResponseData", 
                                   ex.Message, 
                                   oRequestData.ToXML());
    }

    public bool IsSuccess
    {
      get { return (_exception == null && _isSuccess); }
    }

    public List<string> ErrorList
    {
      get { return _errorList; }
    }

    #region IResponseData Members

    public AtlantisException GetException()
    {
      return _exception;
    }

    public string ToXML()
    {
      return _responseXml;
    }

    #endregion
  }
}
