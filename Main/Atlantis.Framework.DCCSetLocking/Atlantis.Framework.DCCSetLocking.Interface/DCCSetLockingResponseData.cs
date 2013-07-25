using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCSetLocking.Interface
{
  public class DCCSetLockingResponseData: IResponseData
  {
    string _responseXml;
    AtlantisException _exception;
    bool _isSuccess = false;

    private string _validationMsg;
    public string ValidationMsg
    {
      get { return _validationMsg; }
    }

    public DCCSetLockingResponseData(string responseXML)
    {
      _responseXml = responseXML;
      PopulateFromXML(responseXML);      
    }

    public DCCSetLockingResponseData(string responseXML, AtlantisException exAtlantis)
    {
      _responseXml = responseXML;
      _exception = exAtlantis;      
    }

    public DCCSetLockingResponseData(string validationXML, bool isSuccess)
    {
      _responseXml = validationXML;
      _isSuccess = isSuccess;
      _validationMsg = parseVerificationDesc(validationXML);
    }

    string parseVerificationDesc(string verificaitonDoc)
    {
      XmlDocument oDoc = new XmlDocument();
      oDoc.LoadXml(verificaitonDoc);

      XmlElement oEle = (XmlElement)oDoc.SelectSingleNode("/VERIFICATION/ACTIONRESULTS/ACTIONRESULT");
      return (oEle != null) ? oEle.Attributes["Description"].Value : "";
    }

    public DCCSetLockingResponseData(string responseXML, RequestData oRequestData, Exception ex)
    {
      _responseXml = responseXML;
      _exception = new AtlantisException(oRequestData,
                                   "DCCSetLockingResponseData",
                                   ex.Message,
                                   oRequestData.ToXML());
    }

    void PopulateFromXML(string resultXML)
    {
      //ResultID52 == "Already in specified Status"
      if (resultXML.Contains("<success") )
      {
        _isSuccess = true;
      }
        /*
      else if (resultXML.Contains("<error"))
      {
        XmlDocument responseDoc = new XmlDocument();
        responseDoc.LoadXml(resultXML);
        responseDoc.Attributes["desc"].Value

      }
         * */
    }

    public bool IsSuccess
    {
      get { return (_exception == null && _isSuccess); }
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
