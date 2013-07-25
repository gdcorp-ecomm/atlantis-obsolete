using System;
using Atlantis.Framework.Interface;
using System.Xml;

namespace Atlantis.Framework.EventGetAllActiveEvents.Interface
{
  public class EventGetAllActiveEventsResponseData : IResponseData
  {
    private AtlantisException _exception;
    private XmlNode _responseXml = null;

    public EventGetAllActiveEventsResponseData(XmlNode responseXml)
    {
      _responseXml = responseXml;
    }

    public EventGetAllActiveEventsResponseData(XmlNode responseXml, AtlantisException ex)
    {
      _responseXml = responseXml;
      _exception = ex;
    }

    public EventGetAllActiveEventsResponseData(XmlNode responseXml, RequestData requestData, Exception ex)
    {
      _responseXml = responseXml;
      _exception = new AtlantisException(requestData, "EventGetAllActiveEventsResponseData", ex.Message + ex.StackTrace, requestData.ToXML());
    }

    public XmlNode ResponseNode
    {
      get { return _responseXml; }
    }

    #region IResponseData Members

    public string ToXML()
    {
      string result = null;
      if (_responseXml != null)
      {
        result = _responseXml.OuterXml;
      }
      return result;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion
  }
}
