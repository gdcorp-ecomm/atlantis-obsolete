using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommDelayedPayment.Interface
{
  public class EcommDelayedPaymentResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private Dictionary<string, string> _formValues;
    private string _resultXML = string.Empty;
    private bool _success = false;

    public string RedirectURL { get; set; }
    public string ErrorOccured { get; set; }
    public string InvoiceID { get; set; }
    public Dictionary<string, string> FormValues
    {
      get
      {
        return _formValues;
      }
      set
      {
        _formValues = value;
      }
    }

    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public EcommDelayedPaymentResponseData(RequestData requestData,string redirectXML,string errorXML,string invoiceID)
    {
      try
      {
        _formValues = new Dictionary<string, string>();
        ErrorOccured = string.Empty;
        RedirectURL = string.Empty;
        InvoiceID = string.Empty;
        if (!string.IsNullOrEmpty(redirectXML))
        {
          XmlDocument redirectDoc = new XmlDocument();
          redirectDoc.LoadXml(redirectXML);
          XmlNode redirectURL = redirectDoc.SelectSingleNode("//Redirect/URL");
          XmlNode formNode = redirectDoc.SelectSingleNode("//Redirect/Form");
          PopulateFormValues(formNode);
          RedirectURL = redirectURL.InnerText;
        }
        else if (!string.IsNullOrEmpty(errorXML))
        {
          XmlDocument errorsDoc = new XmlDocument();
          errorsDoc.LoadXml(errorXML);
          XmlNode errorNode = errorsDoc.SelectSingleNode("//ERRORS/ERROR");
          ErrorOccured = errorNode.InnerText;
        }
        if (!string.IsNullOrEmpty(invoiceID))
        {
          InvoiceID = invoiceID;
        }
        _success = true;
      }
      catch (System.Exception ex)
      {
        this._exception = new AtlantisException(requestData,
                                    "EcommDelayedPaymentResponseData",
                                    ex.Message,
                                    requestData.ToXML());
        _success = false;
      }
    }

     public EcommDelayedPaymentResponseData(AtlantisException atlantisException)
    {
      _formValues = new Dictionary<string, string>();
      this._exception = atlantisException;
    }

    public EcommDelayedPaymentResponseData(RequestData requestData, Exception exception)
    {
      _formValues = new Dictionary<string, string>();
      this._exception = new AtlantisException(requestData,
                                   "EcommDelayedPaymentResponseData",
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

    private void PopulateFormValues(XmlNode formNode)
    {
      if (formNode != null)
      {
        foreach (XmlNode node in formNode.ChildNodes)
        {
          _formValues[node.Attributes["name"].Value] = node.InnerText;
        }
      }

    }
  }
}
