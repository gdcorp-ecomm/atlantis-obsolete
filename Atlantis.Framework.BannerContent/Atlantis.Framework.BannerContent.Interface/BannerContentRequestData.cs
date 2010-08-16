using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BannerContent.Interface
{
	/// <summary>
	/// Requests BannerContent data.  Cacheable.
	/// </summary>
  public class BannerContentRequestData : RequestData
  {
        // **************************************************************** //

    string m_sAppHeaderValue;
    string m_sFromAppValue;
    string m_sISCCodeValue;
    string m_sIPAddress;
    int m_iDisplayBannerPriceTypeID;

    // **************************************************************** //

    public BannerContentRequestData(string sShopperID,
                                    string sSourceURL,
                                    string sOrderID,
                                    string sPathway,
                                    int iPageCount)
                                    : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sAppHeaderValue = "";
      m_sFromAppValue = "";
      m_sISCCodeValue = "";
      m_sIPAddress = "";
      m_iDisplayBannerPriceTypeID = 0;
    }

    // **************************************************************** //

    public BannerContentRequestData(string sShopperID,
                                    string sSourceURL,
                                    string sOrderID,
                                    string sPathway,
                                    int iPageCount,
                                    string sAppHeaderValue,
                                    string sFromAppValue,
                                    string sISCCodeValue,
                                    string sIPAddress,
                                    int iDisplayBannerPriceTypeID)
                                    : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sAppHeaderValue = sAppHeaderValue;
      m_sFromAppValue = sFromAppValue;
      m_sISCCodeValue = sISCCodeValue;
      m_sIPAddress = sIPAddress;
      m_iDisplayBannerPriceTypeID = iDisplayBannerPriceTypeID;
    }

    // **************************************************************** //

    public string AppHeaderValue
    {
      get { return m_sAppHeaderValue; }
      set { m_sAppHeaderValue = value; }
    }

    // **************************************************************** //

    public string FromAppValue
    {
      get { return m_sFromAppValue; }
      set { m_sFromAppValue = value; }
    }

    // **************************************************************** //

    public string ISCCodeValue
    {
      get { return m_sISCCodeValue; }
      set { m_sISCCodeValue = value; }
    }

    // **************************************************************** //


    public string IPAddress
    {
      get { return m_sIPAddress; }
      set { m_sIPAddress = value; }
    }

    // **************************************************************** //

    public int DisplayBannerPriceTypeID
    {
      get { return m_iDisplayBannerPriceTypeID; }
      set { m_iDisplayBannerPriceTypeID = value; }
    }


    // **************************************************************** //

    public string DisplayBannerFilterRequestXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("DisplayBannerFilter");


      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "s_AppHeaderValue");
      xtwResult.WriteAttributeString("value", AppHeaderValue);
      xtwResult.WriteEndElement(); // param

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "s_FromAppValue");
      xtwResult.WriteAttributeString("value", FromAppValue);
      xtwResult.WriteEndElement(); // param

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "s_ISCCodeValue");
      xtwResult.WriteAttributeString("value", ISCCodeValue);
      xtwResult.WriteEndElement(); // param

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "n_displayBanner_priceTypeID");
      xtwResult.WriteAttributeString("value", DisplayBannerPriceTypeID.ToString());
      xtwResult.WriteEndElement(); // param


      xtwResult.WriteEndElement(); // DisplayBannerFilter

      return sbResult.ToString();
    }

    // **************************************************************** //

    public string DisplayBannerFilterRegExRequestXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("DisplayBannerFilterRegEx");

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "n_displayBanner_priceTypeID");
      xtwResult.WriteAttributeString("value", DisplayBannerPriceTypeID.ToString());
      xtwResult.WriteEndElement(); // param


      xtwResult.WriteEndElement(); // DisplayBannerFilter

      return sbResult.ToString();
    }

    // **************************************************************** //

    public string DisplayBannerFilterIPAddressRequestXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("DisplayBannerFilterIPAddress");

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "n_displayBanner_priceTypeID");
      xtwResult.WriteAttributeString("value", DisplayBannerPriceTypeID.ToString());
      xtwResult.WriteEndElement(); // param


      xtwResult.WriteEndElement(); // DisplayBannerFilter

      return sbResult.ToString();
    }

    // **************************************************************** //

    #region RequestData Members

    // **************************************************************** //

    public override string ToXML()
    {
      StringBuilder sbResult = new StringBuilder();

      sbResult.Append("<DisplayBannerRequests>");
      
      sbResult.Append(DisplayBannerFilterRequestXML());
      sbResult.Append(DisplayBannerFilterRegExRequestXML());
      sbResult.Append(DisplayBannerFilterIPAddressRequestXML());

      sbResult.Append("</DisplayBannerRequests>");

      return sbResult.ToString();
    }

    // **************************************************************** //

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(m_sAppHeaderValue 
                                                                    + m_sFromAppValue 
                                                                    + m_sISCCodeValue 
                                                                    + m_sIPAddress 
                                                                    + m_iDisplayBannerPriceTypeID.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
