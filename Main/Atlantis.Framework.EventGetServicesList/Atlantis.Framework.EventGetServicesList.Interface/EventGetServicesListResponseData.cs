using System;
using Atlantis.Framework.Interface;
using System.Xml;

namespace Atlantis.Framework.EventGetServicesList.Interface
{
  public class EventGetServicesListResponseData : IResponseData
  {
    private AtlantisException _exception;
    private XmlNode _responseXml = null;

    public EventGetServicesListResponseData(XmlNode responseXml)
    {
      _responseXml = responseXml;
    }

    public EventGetServicesListResponseData(XmlNode responseXml, AtlantisException ex)
    {
      _responseXml = responseXml;
      _exception = ex;
    }

    public EventGetServicesListResponseData(XmlNode responseXml, RequestData requestData, Exception ex)
    {
      _responseXml = responseXml;
      _exception = new AtlantisException(requestData, "EventGetServicesListResponseData", ex.Message + ex.StackTrace, requestData.ToXML());
    }

    public XmlNode ResponseNode
    {
      get { return _responseXml; }
    }

    public string GetServiceName(int serviceId)
    {
      string result = null;
      if (_responseXml != null)
      {
        string xpathQuery = "./Service[@id = \"" + serviceId.ToString() + "\"]";
        XmlElement serviceElement = _responseXml.SelectSingleNode(xpathQuery) as XmlElement;
        if (serviceElement != null)
        {
          result = serviceElement.GetAttribute("name");
        }
      }
      return result;
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
