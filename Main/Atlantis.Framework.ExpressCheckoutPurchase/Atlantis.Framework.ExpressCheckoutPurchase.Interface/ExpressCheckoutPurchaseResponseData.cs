using System;
using System.Xml.Linq;
using Atlantis.Framework.Interface;
using System.Text;

namespace Atlantis.Framework.ExpressCheckoutPurchase.Interface
{
  public class ExpressCheckoutPurchaseResponseData : IResponseData
  {
    #region Properties
    public struct ErrorStruct
    {
      public string ErrorCode { get; set; }
      public string Description { get; set; }
      public string ServerName { get; set; }
    }

    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private string _orderXML = string.Empty;
    private bool _success = false;
    private ErrorStruct _error = new ErrorStruct();

    public bool IsSuccess
    {
      get { return _success; }
    }

    public ErrorStruct Error
    {
      get { return _error; }
      private set { _error = value; }
    }

    public string OrderXml
    {
      get { return _orderXML; }
    }
    #endregion

    public ExpressCheckoutPurchaseResponseData(string xml, string orderXml)
    {
      _resultXML = xml;
      _orderXML = orderXml;
      _success = _resultXML.IndexOf("Success", StringComparison.OrdinalIgnoreCase) > -1;

      if (!_success)
      {
        XDocument xDoc = XDocument.Parse(xml);
        XElement root = xDoc.Element("Status");

        ErrorStruct err = new ErrorStruct();
        err.ErrorCode = root.Element("Error").Value;
        err.Description = root.Element("Description").Value;
        err.ServerName = root.Element("Server").Value;
        Error = err;
      }
      else
      {
        int errorCount = 0;
        StringBuilder sb = new StringBuilder();
        XDocument xDoc = XDocument.Parse(_orderXML);
        XElement root = xDoc.Element("ORDER");
        XElement basketErrors = root.Element("BASKETERRORS");
        XElement purchaseErrors = root.Element("PURCHASEERRORS");

        if (basketErrors.HasElements || purchaseErrors.HasElements)
        {
          _success = false;
          ErrorStruct err = new ErrorStruct();
          err.ErrorCode = "N/A";
          err.ServerName = "N/A";
          
          if (basketErrors.HasElements)
          {
            sb.Append("BasketError: ");
            sb.Append(basketErrors.Element("ERROR").Attribute("description").Value);
            errorCount++;
          }
          if (purchaseErrors.HasElements)
          {
            if (errorCount > 0)
            {
              sb.Append(" | PurchaseError: ");
              sb.Append(purchaseErrors.Element("ERROR").Attribute("description").Value);
            }
            else
            {
              sb.Append("PurchaseError: ");
              sb.Append(purchaseErrors.Element("ERROR").Attribute("description").Value);
            }
          }
          err.Description = sb.ToString();
          Error = err;
        }
      }
    }

     public ExpressCheckoutPurchaseResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public ExpressCheckoutPurchaseResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "ExpressCheckoutPurchaseResponseData",
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
