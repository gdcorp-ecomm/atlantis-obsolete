using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CustomContent.Interface
{
  public class CustomContentResponseData : IResponseData
  {
    // **************************************************************** //

    Dictionary<string, byte> m_Result;
    AtlantisException m_ex;

    // **************************************************************** //

    public CustomContentResponseData(Dictionary<string, byte> result)
    {
      m_Result = result;
      m_ex = null;
    }

    // **************************************************************** //

    public CustomContentResponseData(Dictionary<string, byte> result, AtlantisException exAtlantis)
    {
      m_Result = result;
      m_ex = exAtlantis;
    }

    // **************************************************************** //

    public CustomContentResponseData(Dictionary<string, byte> result, RequestData oReqestData, Exception ex)
    {
      m_Result = result;
      m_ex = new AtlantisException(oReqestData,
                                   "ContentControlFilterResponseData",
                                   ex.Message,
                                   oReqestData.ToXML());
    }

    // **************************************************************** //

    public Dictionary<string, byte> CustomContentIDs
    {
      get { return m_Result; }
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

      xtwResult.WriteStartElement("CustomContentIDs");

      if (m_Result != null)
      {
        foreach (string sCustomContentID in m_Result.Keys)
        {
          xtwResult.WriteStartElement("CustomContentID");
          xtwResult.WriteValue(sCustomContentID.ToString());
          xtwResult.WriteEndElement(); // CustomContentIDs
        }
      }

      xtwResult.WriteEndElement(); // CustomContentID

      return sbResult.ToString();
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
