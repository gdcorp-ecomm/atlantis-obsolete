using System;
using System.IO;
using System.Xml.XPath;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OrionGetAccountTransition.Interface
{
  public class OrionGetAccountTransitionResponseData : IResponseData
  {
    string _resultXML;
    private AtlantisException _exception = null;

    public bool IsSuccess 
    {
      get { return _exception == null; }
    }

    public string AccountTransitionStatus { get; private set; }


    public OrionGetAccountTransitionResponseData(RequestData requestData, string xml)
    {
      _resultXML = xml;
      AccountTransitionStatus = ParseResponse(requestData, xml);
    }

     public OrionGetAccountTransitionResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public OrionGetAccountTransitionResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "OrionGetAccountTransitionResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }

    private string ParseResponse(RequestData requestData, string xml)
    {
      string status = string.Empty;

      try
      {
        XPathNavigator nav = new XPathDocument(new StringReader(xml)).CreateNavigator();
        XPathNodeIterator node = nav.Select("//accounttransition/status");
        node.MoveNext();
        status = node.Current.Value;
      }
      catch (Exception ex)
      {
        _exception = new AtlantisException(requestData, "OrionGetAccountTransitionResponseData::ParseResponse", ex.Message + Environment.NewLine + ex.StackTrace, string.Empty);
      }

      return status;
    }

    #region IResponseData Members

    public string ToXML()
    {
      return _resultXML;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
