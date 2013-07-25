using System;
using System.Xml;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCModifyDNS.Interface
{
  public class DCCModifyDNSResponseData : IResponseData
  {
    bool _isSuccess = false;
    string _responseXml;
    AtlantisException _exception;
    List<string> _errorList;

    public DCCModifyDNSResponseData(bool result)
    {
      _isSuccess = result;
    }

    public DCCModifyDNSResponseData(List<string> errorList)
    {
      _errorList = errorList;
    }

    public DCCModifyDNSResponseData(string responseXML, AtlantisException exAtlantis)
    {
      _responseXml = responseXML;
      _exception = exAtlantis;
    }

    public DCCModifyDNSResponseData(string responseXML, RequestData oRequestData, Exception ex)
    {
      _responseXml = responseXML;
      _exception = new AtlantisException(oRequestData,
                                   "DCCModifyDNSResponseData", 
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
