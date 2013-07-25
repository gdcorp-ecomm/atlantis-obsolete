using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCGetDomainContacts.Interface
{
  public class DCCGetDomainContactsRequestData : RequestData
  {
    string _domainName;
    string _dccDomainUser;

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(20);

    public DCCGetDomainContactsRequestData( string shopperId,
                                            string sourceUrl,
                                            string orderId,
                                            string pathway,
                                            int pageCount,
                                            string domainName,
                                            string dccDomainUser)
            : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _domainName = domainName;
      _dccDomainUser = dccDomainUser;
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    private XmlNode AddNode(XmlNode parentNode, string sChildNodeName)
    {
      XmlNode childNode = parentNode.OwnerDocument.CreateElement(sChildNodeName);
      parentNode.AppendChild(childNode);
      return childNode;
    }

    private void AddAttribute(XmlNode node, string sAttributeName, string sAttributeValue)
    {
      XmlAttribute attribute = node.OwnerDocument.CreateAttribute(sAttributeName);
      node.Attributes.Append(attribute);
      attribute.Value = sAttributeValue;
    }

    public override string ToXML()
    {
      XmlDocument requestDoc = new XmlDocument();
      requestDoc.LoadXml("<request/>");
      
      XmlElement oRoot = requestDoc.DocumentElement;

      XmlElement oUserName = (XmlElement)AddNode(oRoot, "username");
      oUserName.InnerText = _dccDomainUser;

      XmlElement oSort = (XmlElement)AddNode(oRoot, "domain");
      AddAttribute(oSort, "domainname", _domainName);
      AddAttribute(oSort, "shopperid", ShopperID);

      return requestDoc.InnerXml;
    }


    #region RequestData Members

    public override string GetCacheMD5()
    {
      throw new Exception("DCCGetDomainByShopper is not a cacheable request.");
    }

    #endregion
  }
}
