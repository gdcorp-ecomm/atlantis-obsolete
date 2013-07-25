using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.PrivacyAppGetEmailByHash.Interface
{
  public class PrivacyAppGetEmailByHashRequestData : RequestData
  {
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);
    private string _emailHashKey = string.Empty;

    public PrivacyAppGetEmailByHashRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount, string emailHashKey)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      _emailHashKey = emailHashKey;
    }

    public string EmailHashKey
    {
      get { return _emailHashKey; }
      set { _emailHashKey = value; }
    }
    
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(EmailHashKey);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));
      xtwRequest.WriteStartElement("request");


      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

  }

}
