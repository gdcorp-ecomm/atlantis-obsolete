using System;
using Atlantis.Framework.Interface;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace Atlantis.Framework.RegIsValidXN.Interface
{
  public class RegIsValidXNRequestData : RequestData
  {
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);
    private string _domainName = string.Empty;
    private int _tldId = -1;
    private string _scriptTag = string.Empty;

    public RegIsValidXNRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string domainName, int tldId, string scriptTag)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _domainName = domainName;
      _tldId = tldId;
      _scriptTag = scriptTag;

    }

    public string DomainName
    {
      get { return _domainName; }
      set { _domainName = value; }
    }

    public int TldId
    {
      get { return _tldId; }
      set { _tldId = value; }
    }

    public string ScriptTag
    {
      get { return _scriptTag; }
      set { _scriptTag = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("RegIsValidXN is not a cacheable request.");
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("request");
      xtwRequest.WriteAttributeString("appname", Environment.MachineName);
      xtwRequest.WriteAttributeString("domainname", _domainName);
      xtwRequest.WriteAttributeString("tldid", _tldId.ToString());
      xtwRequest.WriteAttributeString("langtag", _scriptTag);

      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

  }
}
