using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.EventGetServicesList.Interface
{
  public class EventGetServicesListRequestData : RequestData
  {
    private string _clientName = string.Empty;

    public TimeSpan RequestTimeout { get; set; }

    public EventGetServicesListRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, string clientName)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _clientName = clientName;
      RequestTimeout = TimeSpan.FromSeconds(3);
    }

    [Obsolete("Please use RequestTimeout instead.")]
    public TimeSpan ServiceTimeout
    {
      get { return RequestTimeout; }
      set { RequestTimeout = value; }
    }

    public string ClientName
    {
      get { return _clientName; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(ClientName);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
