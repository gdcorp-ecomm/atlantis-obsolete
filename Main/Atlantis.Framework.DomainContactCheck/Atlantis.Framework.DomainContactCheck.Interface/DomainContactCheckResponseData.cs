using System;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DomainContactCheck.Interface
{
  public class DomainContactCheckResponseData : IResponseData
  {

    private Dictionary<string, string> _trusteeVendorIds = new Dictionary<string,string>();
    public Dictionary<string, string> TrusteeVendorIds
    {
      get
      {
        return _trusteeVendorIds;
      }
    }
    
    public string ContactXml
    {
      get
      {
        XmlDocument xdDoc = new XmlDocument();

        xdDoc.LoadXml(m_sResponseXML);

        XmlNode xmlContact = xdDoc.SelectSingleNode("//contact");

        return (xmlContact.InnerXml);
      }
      
    } 

    private List<DomainContactError> mDomainContactErrors = new List<DomainContactError>();
    public List<DomainContactError> Errors
    {
      get
      {
          return mDomainContactErrors;
      }
    }

    private XmlAttributeCollection _responseAttributes;
    public XmlAttributeCollection ResponseAttributes
    {
      get
      {
        return _responseAttributes;
      }
    }

    public DomainContactCheckResponseData(string sDomainXML)
    {
      m_sResponseXML = sDomainXML;
      PopulateFromXML();
    }

    public DomainContactCheckResponseData( AtlantisException exAtlantis)
    {
      m_sResponseXML = "";
      m_ex = exAtlantis;
      PopulateFromXML();
    }

    public DomainContactCheckResponseData(string sResponseXML, RequestData oRequestData, Exception ex)
    {
      m_sResponseXML = sResponseXML;
      m_ex = new AtlantisException(oRequestData,
                                       "DomainContactCheckResponseData",
                                       ex.Message,
                                       string.Empty);
    
      PopulateFromXML();
    }

    private void PopulateFromXML()
    {
      XmlDocument xdDoc = new XmlDocument();

      xdDoc.LoadXml(m_sResponseXML);

      XmlElement contactNode = xdDoc.SelectSingleNode("/contact") as XmlElement;
      string contactTypeValue = contactNode.GetAttribute(DomainContactAttributes.DomainContactType);
      int contactType = 0;
      Int32.TryParse(contactTypeValue, out contactType);
      _responseAttributes = contactNode.Attributes;

      XmlNodeList xnlErrors = xdDoc.SelectNodes("/contact/error");

      foreach (XmlElement xlError in xnlErrors)
      { 
        string sAttribute = xlError.GetAttribute("attribute");
        int iCode = 0;
        int.TryParse(xlError.GetAttribute("code"), out iCode);
        string sDescription = xlError.GetAttribute("desc");

        mDomainContactErrors.Add( new DomainContactError(sAttribute, iCode, sDescription, contactType));
      }

      XmlNodeList trusteeNodes = xdDoc.SelectNodes("/contact/trustee");

      foreach (XmlElement element in trusteeNodes)
      {
        string dotType = element.GetAttribute("tld");
        string vendorId = element.GetAttribute("vendorid");
        _trusteeVendorIds[dotType] = vendorId;
      }
    }

    public bool IsSuccess
    {
      get { return m_sResponseXML.IndexOf("success", StringComparison.OrdinalIgnoreCase) > -1; }
    }

    #region IResponseData Members

    private AtlantisException m_ex;
    public AtlantisException GetException()
    {
      return m_ex;
    }

    private string m_sResponseXML;
    public string ToXML()
    {
      return m_sResponseXML;
    }

    #endregion
  }
}
