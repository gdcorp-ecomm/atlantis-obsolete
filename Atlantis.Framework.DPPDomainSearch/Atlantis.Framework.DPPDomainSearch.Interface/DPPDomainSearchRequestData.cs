using System.IO;
using System.Xml;
using Atlantis.Framework.Interface;
using System;

namespace Atlantis.Framework.DPPDomainSearch.Interface
{
  public class DPPDomainSearchRequestData : RequestData
  {
    private DPPDomainSearchVendorList _vendorList;
    private string _domainName;
    private string _requestingServer;
    private string _customerIp;
    private int _privateLabelID;
    private string _sourceCode;
    private string _visitingId;
    private int _maxDomainsPerVendor;
    private string _tlds;
    public TimeSpan _requestTimeout = TimeSpan.FromMilliseconds(2500);


    public DPPDomainSearchRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount,
        DPPDomainSearchVendorList vendorList, string domainName, string requestingServer, string customerIp,
        int privateLabelID, string sourceCode, int maxDomainsPerVendor, string tlds)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      _vendorList = vendorList;
      _domainName = domainName;
      _requestingServer = requestingServer;
      _customerIp = customerIp;
      _privateLabelID = privateLabelID;
      _sourceCode = sourceCode;
      _visitingId = pathway;
      _maxDomainsPerVendor = maxDomainsPerVendor;
      _tlds = tlds;
    }

    public override string GetCacheMD5()
    {
      throw new System.NotImplementedException();
    }

    public override string ToXML()
    {
      using (StringWriter sw = new StringWriter())
      {
        using (XmlTextWriter writer = new XmlTextWriter(sw))
        {
          writer.WriteStartElement("dppdomainsearch");
          writer.WriteAttributeString("vendorid", GetVendorList());
          writer.WriteAttributeString("domainname", _domainName);
          writer.WriteAttributeString("requestingserver", _requestingServer);
          writer.WriteAttributeString("customerip", _customerIp);
          writer.WriteAttributeString("privatelabel", _privateLabelID.ToString());
          writer.WriteAttributeString("sourcecode", _sourceCode);
          writer.WriteAttributeString("visitingid", _visitingId);
          writer.WriteAttributeString("maxdomainspervendor", _maxDomainsPerVendor.ToString());
          writer.WriteAttributeString("tlds", _tlds);
          writer.WriteEndElement();
        }

        return sw.ToString();
      }
    }

    private string GetVendorList()
    {
      string vendorList = string.Empty;

      foreach (DPPDomainSearchVendor vendorId in _vendorList)
        vendorList += ((int)vendorId).ToString() + ",";

      return vendorList.TrimEnd(new char[] { ',' });
    }
  }
}
