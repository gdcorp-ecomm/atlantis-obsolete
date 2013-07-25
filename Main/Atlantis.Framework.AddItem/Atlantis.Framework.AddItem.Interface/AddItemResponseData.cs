using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AddItem.Interface
{
  public class AddItemResponseData : IResponseData
  {
    // **************************************************************** //

    string m_sResponseXML;
    AtlantisException m_ex;

    // **************************************************************** //

    public AddItemResponseData(string sResponseXML)
    {
      m_sResponseXML = sResponseXML;
      m_ex = null;
    }

    // **************************************************************** //

    public AddItemResponseData(string sResponseXML, AtlantisException exAtlantis)
    {
      m_sResponseXML = sResponseXML;
      m_ex = exAtlantis;
    }

    // **************************************************************** //

    public AddItemResponseData(string sResponseXML, RequestData oRequestData, Exception ex)
    {
      m_sResponseXML = sResponseXML;
      m_ex = new AtlantisException(oRequestData, 
                                   "AddItemResponseData", 
                                   ex.Message, 
                                   oRequestData.ToXML());
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
