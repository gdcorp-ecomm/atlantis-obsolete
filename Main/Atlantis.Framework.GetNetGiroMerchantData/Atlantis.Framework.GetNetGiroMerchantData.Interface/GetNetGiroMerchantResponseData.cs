using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetNetGiroMerchantData.Interface
{

  public class GetNetGiroMerchantResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;
    private string _merchantID = string.Empty;
    private string _merchantAccount = string.Empty;
    private string _merchantAccountID = string.Empty;
    private string _paymentUrl = string.Empty;
    private string _paymentPassword = string.Empty;
    private string _merchantDescription = string.Empty;

    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public string MerchantID
    {
      get
      {
        return _merchantID;
      }
    }

    public string MerchantAccount
    {
      get
      {
        return _merchantAccount;
      }
    }

    public string MerchantAccountID
    {
      get
      {
        return _merchantAccountID;
      }
    }

    public string MerchantDescription
    {
      get
      {
        return _merchantDescription;
      }
    }

    private void PopulateFields(string resultXML)
    {
      XmlDocument oDoc = new XmlDocument();
      oDoc.LoadXml(resultXML);
      XmlNode merchantNode = oDoc.SelectSingleNode("//MerchantData");
      if (merchantNode != null)
      {
        if (merchantNode.Attributes["merchantid"] != null)
        {
          _merchantID = merchantNode.Attributes["merchantid"].Value;
        }

        if (merchantNode.Attributes["account"] != null)
        {
          _merchantAccount = merchantNode.Attributes["account"].Value;
        }

        if (merchantNode.Attributes["gdmerchantaccountid"] != null)
        {
          _merchantAccountID = merchantNode.Attributes["gdmerchantaccountid"].Value;
        }

        if (merchantNode.Attributes["url"] != null)
        {
          _paymentUrl = merchantNode.Attributes["url"].Value;
        }

        if (merchantNode.Attributes["pwd"] != null)
        {
          _paymentPassword = merchantNode.Attributes["pwd"].Value;
        }

        if (merchantNode.Attributes["merchant_description"] != null)
        {
          _merchantDescription = merchantNode.Attributes["merchant_description"].Value;
        }
      }
    }

    public GetNetGiroMerchantResponseData(string resultXML)
    {
      PopulateFields(resultXML);
      _resultXML = resultXML;
      _success = true;
    }

    public GetNetGiroMerchantResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public GetNetGiroMerchantResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "GetNetGiroMerchantResponseData",
                                   exception.Message,
                                   string.Empty);
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
