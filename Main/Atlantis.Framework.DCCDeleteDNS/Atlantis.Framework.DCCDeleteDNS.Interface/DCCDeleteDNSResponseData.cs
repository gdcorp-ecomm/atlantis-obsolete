using System;
using System.Xml;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCDeleteDNS.Interface
{
  public class DCCDeleteDNSResponseData : IResponseData
  {
    bool _isSuccess = false;
    string _responseXml;
    AtlantisException _exception;
    List<string> _errorList;

    public DCCDeleteDNSResponseData(bool result)
    {
      _isSuccess = result;
    }

    public DCCDeleteDNSResponseData(List<string> errorList)
    {
      _errorList = errorList;
    }

    public DCCDeleteDNSResponseData(string responseXML, AtlantisException exAtlantis)
    {
      _responseXml = responseXML;
      _exception = exAtlantis;
    }

    public DCCDeleteDNSResponseData(string responseXML, RequestData oRequestData, Exception ex)
    {
      _responseXml = responseXML;
      _exception = new AtlantisException(oRequestData,
                                   "DCCDeleteDNSResponseData", 
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
