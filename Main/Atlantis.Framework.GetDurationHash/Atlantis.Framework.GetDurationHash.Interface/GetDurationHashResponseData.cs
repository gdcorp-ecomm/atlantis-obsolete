using System;
using System.Text;
using System.IO;
using System.Xml;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetDurationHash.Interface
{
  public class GetDurationHashResponseData : IResponseData
  {
    // **************************************************************** //

    string m_sHash;
    AtlantisException m_ex;
    
    // **************************************************************** //

    public GetDurationHashResponseData(string sHash)
    {
      m_sHash = sHash;
    }

    // **************************************************************** //

    public GetDurationHashResponseData(string sHash, AtlantisException exAtlantis)
    {
      m_sHash = sHash;
      m_ex = exAtlantis;
    }

    // **************************************************************** //

    public GetDurationHashResponseData(string sHash, RequestData oRequestData, Exception ex)
    {
      m_sHash = sHash;
      m_ex = new AtlantisException(oRequestData,
                                   "GetDurationHashResponseData",
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

      xtwResult.WriteStartElement("DurationHash");
      if(m_sHash != null)
        xtwResult.WriteValue(m_sHash);
      xtwResult.WriteEndElement(); // DurationHash

      return sbResult.ToString();
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
