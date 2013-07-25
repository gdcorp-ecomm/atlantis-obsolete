﻿using System;
using System.Text;
using System.Xml;
using System.IO;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DomainContactCheck.Interface
{
  public class DomainContactCheckRequestData : RequestData
  {

    public enum DomainCheckType
    {
      DomainTransfer,
      Other
    }
    private DomainContact m_oDomainContact;
    private DomainCheckType m_CheckType;
    private DomainContact.DomainContactType m_DomainContactType;
    private string m_sTlds;
    private int m_PrivateLabelId;

    private string GetContactTypeString(DomainContact.DomainContactType contactType)
    {
      string result = contactType.ToString();
      switch (contactType)
      {
        case DomainContact.DomainContactType.Registrant:
          result = "registrant";
          break;
        case DomainContact.DomainContactType.Technical:
          result = "technical";
          break;
        case DomainContact.DomainContactType.Administrative:
          result = "administrative";
          break;
        case DomainContact.DomainContactType.Billing:
          result = "billing";
          break;
      }
      return result;
    }

    /******************************************************************************/

    public DomainContactCheckRequestData(
        DomainCheckType CheckType,
        DomainContact.DomainContactType DomainContactType,
        DomainContact oDomainContact,
        string sTtlds,
        int sPrivateLabelId,
        string sShopperID,
        string sSourceURL,
        string sOrderID,
        string sPathway,
        int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_oDomainContact = oDomainContact;
      m_DomainContactType = DomainContactType;
      m_CheckType = CheckType;
      m_sTlds = sTtlds;
      m_PrivateLabelId = sPrivateLabelId;
    }

    /******************************************************************************/

    #region RequestData Members

    /******************************************************************************/

    public override string GetCacheMD5()
    {
      throw new Exception("DomainContactCheck is not a cacheable request.");
    }

    /******************************************************************************/
    /// <summary>
    ///  Generates an Xml string matching the following exemplar:
    ///  <?xml version="1.0" encoding="utf-8"	standalone="no"?>
    ///  <contact type="xfer"	contactType="0"  tlds="COM"
    ///           fname="John"	lname="Doe"  org="NimbleWits Inc"
    ///           sa1="101 N California"  sa2="Suite 201" 
    ///           city="Denver"  sp="CO"  pc="80126" cc="us"
    ///           phone="303-555-2222"	fax="303-555-1111"
    ///           email="jdoe@NimbleWits.com"
    ///           privateLabelId="1"/>
    /// </summary>
    /// <returns>A string containing required XML sequence</returns>

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      Encoding encoding = Encoding.Unicode;
      XmlTextWriter oXmlTextWriter = new XmlTextWriter(new StringWriter(sbRequest));

      oXmlTextWriter.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-16\" standalone=\"no\"");

      oXmlTextWriter.WriteStartElement("contact");
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Type, m_CheckType == DomainCheckType.DomainTransfer ? "xfer" : "");
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.DomainContactType, GetContactTypeString(m_DomainContactType));
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Tlds, m_sTlds);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.FirstName, m_oDomainContact.FirstName);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.LastName, m_oDomainContact.LastName);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Organization, m_oDomainContact.Company);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Address1, m_oDomainContact.Address1);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Address2, m_oDomainContact.Address2);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.City, m_oDomainContact.City);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.State, m_oDomainContact.State);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Zip, m_oDomainContact.Zip);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Country, m_oDomainContact.Country);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Phone, m_oDomainContact.Phone);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Fax, m_oDomainContact.Fax);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.Email, m_oDomainContact.Email);
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.PrivateLabelId, m_PrivateLabelId.ToString());
      oXmlTextWriter.WriteAttributeString(DomainContactAttributes.CanadianPresence, m_oDomainContact.CanadianPresence);

      oXmlTextWriter.WriteEndElement(); // contact

      return sbRequest.ToString();
    }


    /******************************************************************************/

    #endregion

    /******************************************************************************/

  }
}
