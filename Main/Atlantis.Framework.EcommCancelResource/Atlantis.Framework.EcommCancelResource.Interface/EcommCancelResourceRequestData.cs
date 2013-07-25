using System;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommCancelResource.Interface
{
  public class EcommCancelResourceRequestData : RequestData
  {
    #region Properties
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public int ResourceId { get; private set; }
    public string ResourceType { get; private set; }
    public string AutoRenewType { get; private set; }
    public string EnteredBy { get; private set; }
    public string IpAddress { get; private set; }
    public string RequestXml { get; private set; }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    #endregion

    public EcommCancelResourceRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  int resourceId,
                                  string resourceType,
                                  string autoRenewType,
                                  string enteredBy,
                                  string ipAddress)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      ResourceId = resourceId;
      ResourceType = resourceType;
      AutoRenewType = autoRenewType;
      EnteredBy = enteredBy;
      IpAddress = ipAddress;
      RequestXml = CreateWsRequestXML();
    }

    public EcommCancelResourceRequestData(string shopperId,
                              string sourceUrl,
                              string orderId,
                              string pathway,
                              int pageCount,
                              string xml)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestXml = xml;
    }


    private string CreateWsRequestXML()
    {
      XDocument xDoc = new XDocument(
        new XElement("cancellation",
          new XAttribute("shopperid", ShopperID),
          new XAttribute("cancel_by", EnteredBy),
          new XAttribute("UserIP", IpAddress),
        new XElement("cancel",
          new XAttribute("type", AutoRenewType),
          new XAttribute("id", string.Format("{0}:{1}", ResourceType, ResourceId))
        )));

      return xDoc.ToString();

    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in EcommCancelResourceRequestData");
    }
  }
}
