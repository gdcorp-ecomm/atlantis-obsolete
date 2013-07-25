using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using System.Xml.Serialization;
using System.IO;

namespace Atlantis.Framework.GetTransitionsAndRank.Interface
{
  public class GetTransitionsAndRankRequestData : RequestData
  {
    private GetTransitionsAndRankRequestData()
      : base("", "", "", "", 0)
    { }

    public GetTransitionsAndRankRequestData(string shopperID, string sourceURL, string orderID, string pathway,
      int pageCount, string resourceID, string resourceType, string idType, int unifiedProductID)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      ResourceID = resourceID;
      ResourceType = resourceType;
      IDType = idType;
      UnifiedProductID = unifiedProductID;
    }

    public string ResourceID { get; set; }
    public string ResourceType { get; set; }
    public string IDType { get; set; }
    public int UnifiedProductID { get; set; }

    public override string GetCacheMD5()
    {
      return string.Empty;
    }

    public override string ToXML()
    {
      StringBuilder objectXML = new StringBuilder();
      XmlSerializer serializer = new XmlSerializer(this.GetType());
      serializer.Serialize(new StringWriter(objectXML), this);
      return objectXML.ToString();
    }
  }
}
