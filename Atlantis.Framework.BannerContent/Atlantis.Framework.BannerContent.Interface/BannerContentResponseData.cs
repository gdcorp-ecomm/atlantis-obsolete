using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BannerContent.Interface
{
  public class BannerContentResponseData : IResponseData
  {
    // **************************************************************** //

    List<string> m_lstResult;
    AtlantisException m_ex;
    
    // **************************************************************** //

    public BannerContentResponseData(List<string> lstBanners)
    {
      m_lstResult = lstBanners;
      m_ex = null;
    }

    // **************************************************************** //

    public BannerContentResponseData(List<string> lstResult, AtlantisException exAtlantis)
    {
      m_lstResult = lstResult;
      m_ex = exAtlantis;
    }

    // **************************************************************** //

    public BannerContentResponseData(List<string> lstResult, RequestData oReqestData, Exception ex)
    {
      m_lstResult = lstResult;
      m_ex = new AtlantisException(oReqestData,
                                   "DisplayBannerFilterResponseData",
                                   ex.Message,
                                   oReqestData.ToXML());
    }

    // **************************************************************** //

    public List<string> Banners
    {
      get { return m_lstResult; }
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
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("Banners");

      if (m_lstResult != null)
      {
        foreach (string sBanner in m_lstResult)
        {
          xtwResult.WriteStartElement("Banner");
          xtwResult.WriteValue(sBanner);
          xtwResult.WriteEndElement(); // Banner
        }
      }

      xtwResult.WriteEndElement(); // Banners

      return sbResult.ToString();
    }
    
    // **************************************************************** //
    
    #endregion

    // **************************************************************** //
  }
}
