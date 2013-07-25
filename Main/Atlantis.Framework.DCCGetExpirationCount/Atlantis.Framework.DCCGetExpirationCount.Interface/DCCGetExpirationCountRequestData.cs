using System;
using System.Text;
using Atlantis.Framework.Interface;
using System.Xml;
using System.IO;

namespace Atlantis.Framework.DCCGetExpirationCount.Interface
{
  public class DCCGetExpirationCountRequestData : RequestData
  {
    private int _daysFromExpiration = 91;
    private string _applicationName = string.Empty;
    public TimeSpan RequestTimeout { get; set; }

    public DCCGetExpirationCountRequestData(string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, string applicationName, int daysFromExpiration)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _applicationName = applicationName;
      _daysFromExpiration = daysFromExpiration;
      RequestTimeout = TimeSpan.FromSeconds(4);
    }

    [Obsolete("Please use RequestTimeout instead.")]
    public TimeSpan ServiceTimeout
    {
      get { return RequestTimeout; }
      set { RequestTimeout = value; }
    }

    public int DaysFromExpiration
    {
      get { return _daysFromExpiration; }
    }

    public string ApplicationName
    {
      get { return _applicationName; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("DomainGetExpirationCount is not a cacheable request.");
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("getexpirationdomaincountsbyshopperid");
      xtwRequest.WriteElementString("username", ApplicationName);
      xtwRequest.WriteStartElement("shopper");
      xtwRequest.WriteAttributeString("shopperid", ShopperID);
      xtwRequest.WriteAttributeString("daysfromexpiration", DaysFromExpiration.ToString());
      xtwRequest.WriteEndElement(); // shopper
      xtwRequest.WriteEndElement(); // getexpirationdomaincountsbyshopperid

      return sbRequest.ToString();
    }
  }
}
