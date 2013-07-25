using System;
using System.Xml.Linq;
using Atlantis.Framework.AddItem.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine.Properties;

namespace Atlantis.Framework.ExpressCheckoutPurchase.Interface
{
  public class ExpressCheckoutPurchaseRequestData : RequestData
  {
    #region Properties
    private XDocument _xDoc = new XDocument();

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 5);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    public XDocument WebServiceRequestXml
    {
      get { return _xDoc; }
    }

    #endregion

    #region Constructors
    public ExpressCheckoutPurchaseRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  string requestingAppHost,
                                  string clientIP,
                                  bool sendConfirmEmail,
                                  string enteredBy,
                                  string orderSource,
                                  AddItemRequestData itemRequestData,
                                  string translationIP,
                                  string translationLanguage)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      
      _xDoc = new XDocument(
        new XElement("instantPurchase",
          new XAttribute("requestingApp", string.Empty),
          new XAttribute("requestingAppHost", requestingAppHost),
          new XAttribute("clientAddr", clientIP),
          new XAttribute("sendConfimEmail", Convert.ToInt32(sendConfirmEmail).ToString()),
          new XAttribute("entered_by", enteredBy),
          new XAttribute("order_source", orderSource)
        )
      );

      if (!string.IsNullOrEmpty(translationIP))
      {
        _xDoc.Element("instantPurchase").Add(new XAttribute("translationIP", translationIP));
        _xDoc.Element("instantPurchase").Add(new XAttribute("translationLanguage", translationLanguage));
      }

      try
      {
        XDocument itemRequestDoc = XDocument.Parse(itemRequestData.ToXML());
        _xDoc.Element("instantPurchase").Add(itemRequestDoc.Element("itemRequest"));
      }
      catch (Exception ex)
      {
        throw new AtlantisException(this, "ExpressCheckoutPurchaseRequestData::ExpressCheckoutPurchaseRequestData", ex.Message, ex.StackTrace);
      }
    }

    public ExpressCheckoutPurchaseRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  string requestingAppHost,
                                  string clientIP,
                                  bool sendConfirmEmail,
                                  string enteredBy,
                                  string orderSource,
                                  AddItemRequestData itemRequestData,
                                  string expectedTotalInPennies,
                                  bool estimateOnly,
                                  string transactionCurrency,
                                  string translationIP,
                                  string translationLanguage)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _xDoc = new XDocument(
        new XElement("instantPurchase",
          new XAttribute("requestingApp", string.Empty),
          new XAttribute("requestingAppHost", requestingAppHost),
          new XAttribute("clientAddr", clientIP),
          new XAttribute("sendConfimEmail", Convert.ToInt32(sendConfirmEmail).ToString()),
          new XAttribute("entered_by", enteredBy),
          new XAttribute("order_source", orderSource),
          new XAttribute("expectedTotal", expectedTotalInPennies),
          new XAttribute("estimateOnly", Convert.ToInt32(estimateOnly).ToString()),
          new XAttribute("transactionCurrency", transactionCurrency)
        )
      );

      if (!string.IsNullOrEmpty(translationIP))
      {
        _xDoc.Element("instantPurchase").Add(new XAttribute("translationIP", translationIP));
        _xDoc.Element("instantPurchase").Add(new XAttribute("translationLanguage", translationLanguage));
      }

      try
      {
        XDocument itemRequestDoc = XDocument.Parse(itemRequestData.ToXML());
        _xDoc.Element("instantPurchase").Add(itemRequestDoc.Element("itemRequest"));
      }
      catch (Exception ex)
      {
        throw new AtlantisException(this, "ExpressCheckoutPurchaseRequestData::ExpressCheckoutPurchaseRequestData", ex.Message, ex.StackTrace);
      }

    }
    #endregion


    #region RequestData Members

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in ExpressCheckoutPurchaseRequestData");     
    }

    public override string ToXML()
    {
      return _xDoc.ToString();
    }
    #endregion
  }
}
