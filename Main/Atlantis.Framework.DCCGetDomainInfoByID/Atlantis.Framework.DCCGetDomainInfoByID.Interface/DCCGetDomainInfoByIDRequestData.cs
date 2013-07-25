using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCGetDomainInfoByID.Interface
{
  public class DCCGetDomainInfoByIDRequestData : RequestData
  {
    int _domainID;
    string _dccDomainUser;
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(20);

    public DCCGetDomainInfoByIDRequestData(string shopperId,
                                            string sourceUrl,
                                            string orderId,
                                            string pathway,
                                            int pageCount,
                                            string dccDomainUser,
                                            int domainID)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _domainID = domainID;
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

      XmlElement oOptionDomainName = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionDomainName, "name", "include_domainname");
      AddAttribute(oOptionDomainName, "value", "1");

      XmlElement oOptionShopperId = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionShopperId, "name", "include_shopperid");
      AddAttribute(oOptionShopperId, "value", "1");

      XmlElement oOptionLocked = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionLocked, "name", "include_islocked");
      AddAttribute(oOptionLocked, "value", "1");

      XmlElement oOptionRenew = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionRenew, "name", "include_autorenewflag");
      AddAttribute(oOptionRenew, "value", "1");

      XmlElement oOptionProxied = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionProxied, "name", "include_isproxied");
      AddAttribute(oOptionProxied, "value", "1");

      XmlElement oOptionStatus = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionStatus, "name", "include_status");
      AddAttribute(oOptionStatus, "value", "1");

      XmlElement oOptionExpProtected = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionExpProtected, "name", "include_isexpirationprotected");
      AddAttribute(oOptionExpProtected, "value", "1");

      XmlElement oOptionTransferProtected = (XmlElement)AddNode(oRoot, "option");
      AddAttribute(oOptionTransferProtected, "name", "include_istransferprotected");
      AddAttribute(oOptionTransferProtected, "value", "1");
     
      XmlElement oDomain = (XmlElement)AddNode(oRoot, "domain");
      AddAttribute(oDomain, "id", _domainID.ToString());

      return requestDoc.InnerXml;
    }


    #region RequestData Members

    public override string GetCacheMD5()
    {
      throw new Exception("DCCGetDomainInfoByID is not a cacheable request.");
    }

    #endregion
  }
}
