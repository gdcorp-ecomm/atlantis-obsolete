using System;
using System.Collections.Generic;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainContactCheck.Interface;

namespace Atlantis.Framework.AddItem.Interface
{
  public class AddItemRequestData : RequestData
  {
    XmlDocument m_xdRequest = new XmlDocument();
    XmlElement m_xlItemRequest = null;

    public AddItemRequestData(string sShopperID,
                  string sSourceURL,
                  string sOrderID,
                  string sPathway,
                  int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_xlItemRequest = m_xdRequest.CreateElement("itemRequest");
      m_xdRequest.AppendChild(m_xlItemRequest);
    }

    public AddItemRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount, string initialItemRequestXml)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      m_xdRequest = new XmlDocument();
      m_xdRequest.LoadXml(initialItemRequestXml);

      m_xlItemRequest = m_xdRequest.SelectSingleNode("//itemRequest") as XmlElement;
    }

    public void SetItemRequestAttribute(string sName, string sValue)
    {
      m_xlItemRequest.SetAttribute(sName, sValue);
    }

    public void AddContactInfo(DomainContactGroup oContactGroup)
    {
      if (!oContactGroup.IsValid)
        throw new ArgumentException("Domain contact group has not been validated.");

      string xmlContactInfo = oContactGroup.GetContactXml();
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.LoadXml(xmlContactInfo);
      XmlNode m_ContactInfoNode = xmlDoc.SelectSingleNode("//" + DomainContactGroup.ContactInfoElementName);
      m_ContactInfoNode = m_xdRequest.ImportNode(m_ContactInfoNode, true);
      m_xlItemRequest.AppendChild(m_ContactInfoNode);
    }

    // **************************************************************** //

    public void AddItem(IEnumerable<KeyValuePair<string, string>> oAttributes)
    {
      AddItem(oAttributes, "");
    }

    // **************************************************************** //

    public void AddItem(IEnumerable<KeyValuePair<string, string>> oAttributes, string sCustomXML)
    {
      XmlElement xlItem = m_xdRequest.CreateElement("item");
      foreach (KeyValuePair<string, string> attr in oAttributes)
        xlItem.SetAttribute(attr.Key, attr.Value);

      if (sCustomXML.Length > 0)
        xlItem.InnerXml = sCustomXML;

      m_xlItemRequest.AppendChild(xlItem);
    }

    // **************************************************************** //

    public void AddItem(string sUnifiedProductID, string sQuantity)
    {
      AddItem(sUnifiedProductID, sQuantity, null, "");
    }

    // **************************************************************** //

    public void AddItem(string sUnifiedProductID, string sQuantity, string sCustomXML)
    {
      AddItem(sUnifiedProductID, sQuantity, null, sCustomXML);
    }

    // **************************************************************** //

    public void AddItem(string sUnifiedProductID, string sQuantity, IEnumerable<KeyValuePair<string, string>> oAttributes, string sCustomXML)
    {
      List<KeyValuePair<string, string>> lstAttributes = new List<KeyValuePair<string, string>>();

      lstAttributes.Add(new KeyValuePair<string, string>("unifiedProductID", sUnifiedProductID));
      lstAttributes.Add(new KeyValuePair<string, string>("quantity", sQuantity));

      if (oAttributes != null)
        lstAttributes.AddRange(oAttributes);

      AddItem(lstAttributes, sCustomXML);
    }

    // **************************************************************** //

    #region RequestData Members

    // **************************************************************** //

    public override string GetCacheMD5()
    {
      throw new Exception("AddItem is not a cacheable request.");
    }

    // **************************************************************** //

    public override string ToXML()
    {
      return m_xdRequest.InnerXml;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
