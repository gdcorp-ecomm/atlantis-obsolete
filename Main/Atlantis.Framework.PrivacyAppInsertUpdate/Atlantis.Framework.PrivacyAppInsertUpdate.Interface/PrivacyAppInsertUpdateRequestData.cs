using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.PrivacyAppInsertUpdate.Interface
{
  public class PrivacyAppInsertUpdateRequestData : RequestData
  {
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);
    private string _privacyXml = string.Empty;

    public PrivacyAppInsertUpdateRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
    }

    public string PrivacyXML
    {
      get { return _privacyXml; }
      set { _privacyXml = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("PrivacyAppInsertUpdate is not a cacheable request.");
    }

    public override string ToXML()
    {
      return string.Empty;
    }

  }
}
