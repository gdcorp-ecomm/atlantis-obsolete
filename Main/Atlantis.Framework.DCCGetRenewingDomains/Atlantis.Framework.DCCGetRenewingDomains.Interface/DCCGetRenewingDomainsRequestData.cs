using System;
using System.Xml;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.DCCGetRenewingDomains.Interface
{
  [Obsolete("Use Atlantis.Framework.DCCGetDomainByShopper instead, using expiration sorting")]
  public class DCCGetRenewingDomainsRequestData : RequestData
  {
    internal enum RequestType
    {
      TimeSpan,
      Count,
      DomainName
    }

    private const string ORDER_BY = "expirationDate";
    private const string SORT_ORDER = "ASC";

    private static string SortOrder { get { return SORT_ORDER; } }
    private static string OrderBy { get { return ORDER_BY; } }
    private string DccDomainUser { get; set; }

    internal RequestType Type { get; private set;}

    internal TimeSpan TimeSpanFromExpiration { get; private set; }
    
    internal uint DomainCount { get; set; }

    internal string SearchDomainName { get; set; }

    internal DateTime? BoundryExpirationDate { get; set; }
    
    /// <summary>
    /// Default of 30 seconds.
    /// </summary>
    public TimeSpan RequestTimeout { get; set; }

    public DCCGetRenewingDomainsRequestData(string shopperId, 
                                            TimeSpan timeSpanFromExpiration, 
                                            string sourceUrl, 
                                            string orderId, 
                                            string pathway,
                                            int pageCount,
                                            string dccDomainUser) : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      TimeSpanFromExpiration = timeSpanFromExpiration;
      Type = RequestType.TimeSpan;
      RequestTimeout = new TimeSpan(0, 0, 30);
      DccDomainUser = dccDomainUser;
    }

    public DCCGetRenewingDomainsRequestData(string shopperId, 
                                            uint domainCount, 
                                            string sourceUrl, 
                                            string orderId, 
                                            string pathway,
                                            int pageCount,
                                            string dccDomainUser) : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      DomainCount = domainCount;
      Type = RequestType.Count;
      RequestTimeout = new TimeSpan(0, 0, 30);
      DccDomainUser = dccDomainUser;
    }

    public DCCGetRenewingDomainsRequestData(string shopperId,
                                            string searchDomainName,
                                            string sourceUrl,
                                            string orderId,
                                            string pathway,
                                            int pageCount,
                                            string dccDomainUser): base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      SearchDomainName = searchDomainName.ToUpperInvariant();
      Type = RequestType.DomainName;
      RequestTimeout = new TimeSpan(0, 0, 30);
      DccDomainUser = dccDomainUser;
    }

    public override string ToXML()
    {
      XmlDocument requestDoc = new XmlDocument();
      requestDoc.LoadXml("<getdccdomainlist/>");

      XmlElement oRoot = requestDoc.DocumentElement;

      XmlElement oUserName = AddElement(oRoot, "username");
      oUserName.InnerText = DccDomainUser;

      XmlElement oSort = AddElement(oRoot, "sort");
      AddAttribute(oSort, "column", OrderBy);
      AddAttribute(oSort, "direction", SortOrder);

      XmlElement oShopper = AddElement(oRoot, "shopper");
      AddAttribute(oShopper, "shopperid", ShopperID);
      AddAttribute(oShopper, "search", !string.IsNullOrEmpty(SearchDomainName) ? SearchDomainName : string.Empty);
      AddAttribute(oShopper, "quantity", DomainCount.ToString());

      if (BoundryExpirationDate != null)
      {
        XmlElement oPaging = AddElement(oRoot, "paging");
        AddAttribute(oPaging, "boundaryExpirationDate", BoundryExpirationDate.Value.ToString("MM/dd/yyyy HH:mm:ss"));
        AddAttribute(oPaging, "direction", "forward");
      }

      return requestDoc.InnerXml;
    }

    private static XmlElement AddElement(XmlNode parentNode, string sChildNodeName)
    {
      XmlElement childNode = parentNode.OwnerDocument.CreateElement(sChildNodeName);
      parentNode.AppendChild(childNode);
      return childNode;
    }

    private static void AddAttribute(XmlNode node, string attributeName, string attributeValue)
    {
      XmlAttribute attribute = node.OwnerDocument.CreateAttribute(attributeName);
      node.Attributes.Append(attribute);
      attribute.Value = attributeValue;
    }

    #region RequestData Members
    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}-{2}", ShopperID, DccDomainUser, Type.ToString()));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
    #endregion
  }
}
