using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCSetContacts.Interface
{
  public class DCCSetContactsResponseData : IResponseData
  {
    string _responseXml;
    string _validationMsg = "";
    AtlantisException _exception;
    bool _isSuccess = false;

    public DCCSetContactsResponseData(string responseXML)
    {
      _responseXml = responseXML;
      PopulateFromXML(responseXML);
    }

    public DCCSetContactsResponseData(string validationXML, bool isSuccess)
    {
      _responseXml = validationXML;
      _isSuccess = isSuccess;
      _validationMsg = parseValidationDesc(validationXML);
    }

    public DCCSetContactsResponseData(string responseXML, AtlantisException exAtlantis)
    {
      _responseXml = responseXML;
      _exception = exAtlantis;
    }

    public DCCSetContactsResponseData(string responseXML, RequestData oRequestData, Exception ex)
    {
      _validationMsg = parseVerificationDesc(responseXML);
      _responseXml = responseXML;
      _exception = new AtlantisException(oRequestData,
                                   "DCCSetContactsResponseData",
                                   ex.Message,
                                   oRequestData.ToXML());
    }


    public DCCSetContactsResponseData(string responseXML, RequestData oRequestData)
    {
      _validationMsg = parseVerificationDesc(responseXML);
      _responseXml = responseXML;      
    }


    string parseVerificationDesc(string inXML)
    {
      string sResult = "";
      XmlDocument oDoc = new XmlDocument();
      oDoc.LoadXml(inXML);

      XmlElement oEle = (XmlElement)oDoc.SelectSingleNode("/VERIFICATION/ACTIONRESULTS/ACTIONRESULT");
      sResult = oEle.Attributes["Description"].Value;
      return sResult;
    }

    string parseValidationDesc(string validationDoc)
    {
      string sResult = "";
      XmlDocument oDoc = new XmlDocument();
      oDoc.LoadXml(validationDoc);

      XmlElement oEle = (XmlElement)oDoc.SelectSingleNode("/VALIDATION/ACTIONRESULTS/ACTIONRESULT");
      sResult = oEle.Attributes["Description"].Value;
      return sResult;
    }

    void PopulateFromXML(string resultXML)
    {
      if (resultXML.Contains("<success"))
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

    public string ValidationMsg
    {
      get { return _validationMsg; }
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
