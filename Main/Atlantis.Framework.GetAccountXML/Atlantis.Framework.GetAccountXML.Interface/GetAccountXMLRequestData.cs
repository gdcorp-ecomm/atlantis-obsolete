using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using System.Xml.Serialization;
using System.IO;

namespace Atlantis.Framework.GetAccountXML.Interface
{
  [Serializable]
  public class GetAccountXMLRequestData : RequestData
  {
    private GetAccountXMLRequestData()
      : base("", "", "", "", 0)
    {}

    public GetAccountXMLRequestData(string shopperID, string sourceURL, string orderID, 
                                    string pathway, int pageCount, string resourceID,
                                    string resourceType, string idType, int treeID,
                                    int privateLabelID)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      ResourceID = resourceID;
      ResourceType = resourceType;
      IDType = idType;
      TreeID = treeID;
      PrivateLabelID = privateLabelID;
    }

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

    public string ResourceID { get; set; }
    public string ResourceType { get; set; }
    public string IDType { get; set; }
    public int TreeID { get; set; }
    public int PrivateLabelID { get; set; }
  }
}
