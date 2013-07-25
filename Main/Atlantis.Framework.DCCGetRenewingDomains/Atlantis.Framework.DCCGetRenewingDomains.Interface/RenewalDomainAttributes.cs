using System;
using System.Xml;

namespace Atlantis.Framework.DCCGetRenewingDomains.Interface
{
  public class RenewalDomainAttributes
  {
    public int Id { get; private set; }
    public string DomainName { get; private set; }
    public int TldId { get; private set; }
    public int ParentBundleId { get; private set; }
    public int BillingResouceId { get; private set; }
    public DateTime ExpirationDate { get; private set; }
    public bool IsLocked { get; private set; }
    public bool IsProxied { get; private set; }
    public bool IsBusinessRegistration { get; private set; }
    public bool IsExpirationProtected { get; private set; }
    public bool IsTransferProtected { get; private set; }
    public bool IsSmartDomain { get; private set; }
    public bool AutoRenewFlag { get; private set; }
    public int RenewPeriod { get; private set; }
    public string Xml { get; private set; }

    internal int Status { get; private set; }

    internal RenewalDomainAttributes(XmlNode domainElement)
    {
      if (domainElement != null)
      {
        Id = ParseInt(domainElement.Attributes["id"]);
        DomainName = ParseString(domainElement.Attributes["domainname"]).ToUpperInvariant();
        TldId = ParseInt(domainElement.Attributes["tldid"]);
        ParentBundleId = ParseInt(domainElement.Attributes["parent_bundle_id"]);
        BillingResouceId = ParseInt(domainElement.Attributes["billingresourceid"]);
        ExpirationDate = ParseDate(domainElement.Attributes["expirationdate"]);
        IsLocked = ParseBool(domainElement.Attributes["islocked"]);
        IsProxied = ParseBool(domainElement.Attributes["isproxied"]);
        // The GUID attribute maps to Business Registration
        IsBusinessRegistration = ParseGuid(domainElement.Attributes["guid"]) != Guid.Empty ? true : false;
        IsExpirationProtected = ParseBool(domainElement.Attributes["isexpirationprotected"]);
        IsTransferProtected = ParseBool(domainElement.Attributes["istransferprotected"]);
        IsSmartDomain = ParseBool(domainElement.Attributes["issmartdomain"]);
        AutoRenewFlag = ParseBool(domainElement.Attributes["autorenewflag"]);
        RenewPeriod = ParseInt(domainElement.Attributes["renewperiod"]);
        Status = ParseInt(domainElement.Attributes["status"]);
        Xml = domainElement.OuterXml;
      }
    }

    public RenewalDomainAttributes(string renewalDomainXml)
      : this(GetXmlNode(renewalDomainXml))
    {

    }

    private static XmlNode GetXmlNode(string xmlNode)
    {
      XmlDocument xmlDocument = new XmlDocument();
      XmlNode renewalDomainNode;

      try
      {
        xmlDocument.LoadXml(xmlNode);
        renewalDomainNode = xmlDocument.SelectSingleNode("/domain");
      }
      catch
      {
        renewalDomainNode = null;
      }

      return renewalDomainNode;
    }

    private static string ParseString(XmlAttribute attribute)
    {
      string result = string.Empty;
      if (attribute != null)
      {
        result = attribute.Value;
      }
      return result;
    }

    private static int ParseInt(XmlAttribute attribute)
    {
      int result = 0;
      if (attribute != null)
      {
        int.TryParse(attribute.Value, out result);
      }
      return result;
    }

    private static DateTime ParseDate(XmlAttribute attribute)
    {
      DateTime result = DateTime.MaxValue;
      if (attribute != null)
      {
        DateTime.TryParse(attribute.Value, out result);
      }
      return result;
    }

    private static bool ParseBool(XmlAttribute attribute)
    {
      bool result = false;
      if (ParseInt(attribute) == 1)
      {
        result = true;
      }
      return result;
    }

    private static Guid ParseGuid(XmlAttribute attribute)
    {
      Guid result = Guid.Empty;
      if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
      {
        try
        {
          result = new Guid(attribute.Value);
        }
        catch
        {
          result = Guid.Empty;
        }
      }
      return result;
    }
  }
}
