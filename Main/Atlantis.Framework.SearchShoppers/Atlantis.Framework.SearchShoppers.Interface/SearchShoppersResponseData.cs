using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SearchShoppers.Interface
{
  public class SearchShoppersResponseData : IResponseData
  {
    // **************************************************************** //

    List<Dictionary<string, string>> m_lstShoppers = new List<Dictionary<string, string>>();
    string m_sResponseXML;
    AtlantisException m_ex;

    // **************************************************************** //

    public SearchShoppersResponseData(string sSearchShoppersXML)
    {
      m_sResponseXML = sSearchShoppersXML;
      m_ex = null;
      PopulateFromXML(sSearchShoppersXML);
    }
    
    // **************************************************************** //

    public SearchShoppersResponseData(string sResponseXML, AtlantisException exAtlantis)
    {
      m_sResponseXML = sResponseXML;
      m_ex = exAtlantis;
    }
    
    // **************************************************************** //

    public SearchShoppersResponseData(string sResponseXML, RequestData oRequestData, Exception ex)
    {
      m_sResponseXML = sResponseXML;
      m_ex = new AtlantisException(oRequestData, 
                                   "SearchShoppersResponseData", 
                                   ex.Message, 
                                   oRequestData.ToXML());
    }

    // **************************************************************** //

    public string GetShopperAttribute(int index, string sName)
    {
      return m_lstShoppers[index][sName];
    }

    // **************************************************************** //

    public Dictionary<string, string> GetShopperAttributes(int index)
    {
      return m_lstShoppers[index];
    }

    // **************************************************************** //

    public int ShopperCount
    {
      get { return m_lstShoppers.Count; }
    }

    // **************************************************************** //

    void PopulateFromXML(string sSearchShoppersXML)
    {
      XmlDocument xdDoc = new XmlDocument();
      
      xdDoc.LoadXml(sSearchShoppersXML);

      XmlNodeList xnlShoppers = xdDoc.SelectNodes("/ShopperSearchReturn/Shopper");

      foreach (XmlElement xlShopper in xnlShoppers)
      {
        Dictionary<string, string> dictShopper = new Dictionary<string, string>();
        foreach (XmlAttribute attr in xlShopper.Attributes)
        {
          dictShopper.Add(attr.Name, attr.Value);
        }
        m_lstShoppers.Add(dictShopper);
      }
    }

    public bool IsSuccess
    {
      get { return m_sResponseXML.IndexOf("success", StringComparison.OrdinalIgnoreCase) > -1; }
    }

    // **************************************************************** //

    #region IResponseData Members

    // **************************************************************** //

    public AtlantisException GetException()
    {
      return m_ex;
    }

    // **************************************************************** //

    public string ToXML()
    {
      return m_sResponseXML;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
