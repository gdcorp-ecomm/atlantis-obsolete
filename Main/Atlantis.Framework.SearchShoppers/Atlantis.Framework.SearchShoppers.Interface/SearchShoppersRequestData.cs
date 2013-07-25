using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SearchShoppers.Interface
{
  public class SearchShoppersRequestData : RequestData
  {
    // **************************************************************** //
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    public class SearchField
    {
      private string m_sFieldName;
      private string m_sMatchValue;

      public SearchField(string sName, string sValue)
      {
        this.m_sFieldName = sName;
        this.m_sMatchValue = sValue;
      }

      public string FieldName
      {
        get { return m_sFieldName; }
      }

      public string MatchValue
      {
        get { return m_sMatchValue; }
      }
    }

    // **************************************************************** //

    string m_sRequestedBy;
    string m_sIPAddress;
    List<SearchField> m_lstSearchFields = new List<SearchField>();
    List<string> m_lstReturnFields = new List<string>();

    // **************************************************************** //

    public SearchShoppersRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount, 
                                  string sRequestedBy)
                                  : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sRequestedBy = sRequestedBy;
      m_sIPAddress = "";
    }

    // **************************************************************** //

    public SearchShoppersRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  string sRequestedBy,
                                  IEnumerable<SearchField> searchFields,
                                  IEnumerable<string> returnFields)
                                  : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sRequestedBy = sRequestedBy;
      m_sIPAddress = "";
      AddSearchFields(searchFields);
      AddReturnFields(returnFields);
    }

    // **************************************************************** //

    public SearchShoppersRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  string sRequestedBy, 
                                  string sIPAddress)
                                  : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sRequestedBy = sRequestedBy;
      this.IPAddress = sIPAddress;
    }

    // **************************************************************** //

    public SearchShoppersRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  string sRequestedBy,
                                  string sIPAddress,
                                  IEnumerable<SearchField> searchFields,
                                  IEnumerable<string> returnFields)
                                  : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_sRequestedBy = sRequestedBy;
      this.IPAddress = sIPAddress;
      AddSearchFields(searchFields);
      AddReturnFields(returnFields);
    }

    // **************************************************************** //

    public void AddSearchField(string sFieldName, string sMatchValue)
    {
      m_lstSearchFields.Add(new SearchField(sFieldName, sMatchValue));
    }

    // **************************************************************** //

    public void AddSearchFields(IEnumerable<SearchField> searchFields)
    {
      m_lstSearchFields.AddRange(searchFields);
    }

    // **************************************************************** //

    public void AddReturnField(string sFieldName)
    {
      m_lstReturnFields.Add(sFieldName);
    }

    // **************************************************************** //

    public void AddReturnFields(IEnumerable<string> returnFields)
    {
      m_lstReturnFields.AddRange(returnFields);
    }

    // **************************************************************** //

    public string RequestedBy
    {
      get { return m_sRequestedBy; }
      set { m_sRequestedBy = value; }
    }

    // **************************************************************** //

    public string IPAddress
    {
      get { return GetLocalAddress(); }
      set
      {
        m_sIPAddress = "";
        IPAddress address;
        if (System.Net.IPAddress.TryParse(value, out address))
          m_sIPAddress = address.ToString();
      }
    }

    // **************************************************************** //

    string GetLocalAddress()
    {
      if(m_sIPAddress.Length == 0)
      {
        IPAddress[] addresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;

        if (addresses.Length > 0)
          m_sIPAddress = addresses[0].ToString();
      }

      return m_sIPAddress;
    }

    // **************************************************************** //

    #region RequestData  Members

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    
    // **************************************************************** //

    public override string GetCacheMD5()
    {
      throw new Exception("SearchShoppers is not a cacheable request.");
    }

    // **************************************************************** //

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("ShopperSearch");
      xtwRequest.WriteAttributeString("IPAddress", GetLocalAddress());
      xtwRequest.WriteAttributeString("RequestedBy", m_sRequestedBy);

      xtwRequest.WriteStartElement("SearchFields");
      foreach (SearchField field in m_lstSearchFields)
      {
        xtwRequest.WriteStartElement("Field");
        xtwRequest.WriteAttributeString("Name", field.FieldName);
        xtwRequest.WriteValue(field.MatchValue);
        xtwRequest.WriteEndElement(); // Field
      }
      xtwRequest.WriteEndElement();  // SearchFields

      xtwRequest.WriteStartElement("ReturnFields");
      foreach (string sField in m_lstReturnFields)
      {
        xtwRequest.WriteStartElement("Field");
        xtwRequest.WriteAttributeString("Name", sField);
        xtwRequest.WriteEndElement(); // Field
      }
      xtwRequest.WriteEndElement(); // ReturnFields

      xtwRequest.WriteEndElement(); // ShopperSearch

      return sbRequest.ToString();
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
