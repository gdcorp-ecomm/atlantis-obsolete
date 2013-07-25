using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.PrivacyAppGetEmailByHash.Interface
{
  public class PrivacyAppGetEmailByHashResponseData : IResponseData
  {
    private string _responseXml = string.Empty;
    private string _emailAddress = string.Empty;
    private bool _isValid = false;
    private AtlantisException _ex;

    public PrivacyAppGetEmailByHashResponseData(string responseXML, string emailAddress)
    {
      _responseXml = responseXML;
      _emailAddress = emailAddress;
      _isValid = true;

    }

    public bool IsValid
    {
      get { return _isValid; }
    }

    public string ResponseXML
    {
      get { return _responseXml; }
    }

    public string EmailAddress
    {
      get { return _emailAddress; }
    }

    public PrivacyAppGetEmailByHashResponseData(string responseXml, string emailAddress, AtlantisException ex)
    {
      _responseXml = responseXml;
      _emailAddress = emailAddress;
      _isValid = false;
      _ex = ex;
    }

    public PrivacyAppGetEmailByHashResponseData(string responseXml, string emailAddress, RequestData oRequestData, Exception ex)
    {
      _responseXml = responseXml;
      _emailAddress = emailAddress;
      _isValid = false;
      _ex = new AtlantisException(oRequestData, "PrivacyAppGetEmailByHashResponseData", ex.Message, oRequestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      return _responseXml;
    }
    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion
  }


}
