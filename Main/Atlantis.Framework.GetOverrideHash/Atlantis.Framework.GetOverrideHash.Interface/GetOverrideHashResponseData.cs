using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetOverrideHash.Interface
{
  public class GetOverrideHashResponseData : IResponseData
  {
    // **************************************************************** //

    string m_sHash;
    AtlantisException m_ex;
    
    // **************************************************************** //

    public GetOverrideHashResponseData(string sHash)
    {
      m_sHash = sHash;
    }

    // **************************************************************** //

    public GetOverrideHashResponseData(string sHash, AtlantisException exAtlantis)
    {
      m_sHash = sHash;
      m_ex = exAtlantis;
    }

    // **************************************************************** //

    public GetOverrideHashResponseData(string sHash, RequestData oRequestData, Exception ex)
    {
      m_sHash = sHash;
      m_ex = new AtlantisException(oRequestData,
                                   "GetOverrideHashResponseData",
                                   ex.Message,
                                   oRequestData.ToXML());
    }

    // **************************************************************** //

    public string Hash
    {
      get { return m_sHash; }
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

      xtwResult.WriteStartElement("OverrideHash");
      if(m_sHash != null)
        xtwResult.WriteValue(m_sHash);
      xtwResult.WriteEndElement(); // OverrideHash

      return sbResult.ToString();
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
