using System;
using Atlantis.Framework.Interface;
using System.Xml.Linq;

namespace Atlantis.Framework.MyaCurrentProductGroups.Interface
{
  public class MyaCurrentProductGroupsRequestData : RequestData
  {
    public MyaCurrentProductGroupsRequestData(string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, int privateLabelId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(3);
      PrivateLabelId = privateLabelId;
    }

    public TimeSpan RequestTimeout { get; set; }
    public int PrivateLabelId { get; set; }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("MyaCurrentProductGroups is not a cacheable request.");
    }

    public override string ToXML()
    {
      XDocument xmlDoc = new XDocument(new XElement("MyaIsMirageCurrentRequestData", new XElement("ShopperId", ShopperID), new XElement("PrivateLabelId", PrivateLabelId.ToString())));
      return xmlDoc.ToString();
    }
  }
}
