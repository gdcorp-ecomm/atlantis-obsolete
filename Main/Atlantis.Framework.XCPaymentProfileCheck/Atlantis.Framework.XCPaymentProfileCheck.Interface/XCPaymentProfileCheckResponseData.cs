using System;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.XCPaymentProfileCheck.Interface
{
  public class XCPaymentProfileCheckResponseData : IResponseData
  {
    public struct ErrorStruct
    {
      public string ErrorCode {get; set;}
      public string Description { get; set; }
      public string ServerName { get; set; }
    }

    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;
    private bool _hasInstantPurchasePayment = false;
    private ErrorStruct _error = new ErrorStruct();

    public bool IsSuccess
    {
      get { return _success; }
    }
    public bool HasInstantPurchasePayment
    {
      get { return _hasInstantPurchasePayment; }
    }
    public ErrorStruct Error
    {
      get { return _error; }
      private set { _error = value; }
    }

    public XCPaymentProfileCheckResponseData(string xml, bool hasInstantPurchasePayment)
    {
      _resultXML = xml;
      _hasInstantPurchasePayment = hasInstantPurchasePayment;

      XDocument xDoc = XDocument.Parse(xml);
      XElement root = xDoc.Element("Status");

      if (root.HasElements)
      {
        ErrorStruct err = new ErrorStruct();
        err.ErrorCode = root.Element("Error").Value;
        err.Description = root.Element("Description").Value;
        err.ServerName = root.Element("Server").Value;
        Error = err;
      }
      else
      {
        _success = true;
      }
    }

     public XCPaymentProfileCheckResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public XCPaymentProfileCheckResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "XCPaymentProfileCheckResponseData",
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
