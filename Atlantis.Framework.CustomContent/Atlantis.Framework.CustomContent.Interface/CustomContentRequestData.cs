using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CustomContent.Interface
{
	/// <summary>
	/// Requests CustomContent Data.  Cacheable.
	/// </summary>
  public class CustomContentRequestData : RequestData
  {
        // **************************************************************** //

    string m_sAppHeaderValue;
    string m_sFromAppValue;
    string m_sISCCodeValue;
    string m_sIPAddress;
    string m_sCustomContentIDList;


    // **************************************************************** //

    public CustomContentRequestData(string sShopperID,
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
      m_sCustomContentIDList = "";
    }

    // **************************************************************** //

    public CustomContentRequestData(string sShopperID,
                                    string sSourceURL,
                                    string sOrderID,
                                    string sPathway,
                                    int iPageCount,
                                    string sAppHeaderValue,
                                    string sFromAppValue,
                                    string sISCCodeValue,
                                    string sIPAddress,
                                    string sCustomContentIDList)
                                    : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sAppHeaderValue = sAppHeaderValue;
      m_sFromAppValue = sFromAppValue;
      m_sISCCodeValue = sISCCodeValue;
      m_sIPAddress = sIPAddress;
      m_sCustomContentIDList = sCustomContentIDList;
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

    public string CustomContentIDList
    {
      get { return m_sCustomContentIDList; }
      set
      {
        string temp = value;
        string[] values = temp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        temp = string.Join(",",values);
        m_sCustomContentIDList = temp;
      }
    }

    // **************************************************************** //

    public string CustomContentFilterRequestXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("ContentControlFilter");


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
      xtwResult.WriteAttributeString("name", "s_customContentIDList");
      xtwResult.WriteAttributeString("value", CustomContentIDList);
      xtwResult.WriteEndElement(); // param


      xtwResult.WriteEndElement(); // ContentControlFilter

      return sbResult.ToString();
    }

    // **************************************************************** //

    public string CustomContentFilterRegExRequestXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("ContentControlFilterRegEx");

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "s_customContentIDList");
      xtwResult.WriteAttributeString("value", CustomContentIDList);
      xtwResult.WriteEndElement(); // param


      xtwResult.WriteEndElement(); // ContentControlFilterRegEx

      return sbResult.ToString();
    }

    // **************************************************************** //

    public string CustomContentFilterIPAddressRequestXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("ContentControlFilterIPAddress");

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "s_customContentIDList");
      xtwResult.WriteAttributeString("value", CustomContentIDList);
      xtwResult.WriteEndElement(); // param


      xtwResult.WriteEndElement(); // ContentControlFilterIPAddress

      return sbResult.ToString();
    }

    // **************************************************************** //

    #region RequestData Members

    // **************************************************************** //

    public override string ToXML()
    {
      StringBuilder sbResult = new StringBuilder();

      sbResult.Append("<CustomContentRequests>");

      sbResult.Append(CustomContentFilterRequestXML());
      sbResult.Append(CustomContentFilterRegExRequestXML());
      sbResult.Append(CustomContentFilterIPAddressRequestXML());

      sbResult.Append("</CustomContentRequests>");

      return sbResult.ToString();
    }

    // **************************************************************** //

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      string sValue = m_sAppHeaderValue + m_sFromAppValue + m_sISCCodeValue + m_sCustomContentIDList;

      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sValue);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sMD5 = BitConverter.ToString(md5Bytes, 0);
      return sMD5.Replace("-", "");
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
