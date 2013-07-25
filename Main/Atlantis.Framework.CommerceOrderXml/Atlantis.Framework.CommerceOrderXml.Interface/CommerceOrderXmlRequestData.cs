using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CommerceOrderXml.Interface
{
  public class CommerceOrderXmlRequestData : RequestData
  {
    #region Properties
    private string _recentOrderId;
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public string RecentOrderId
    {
      get { return _recentOrderId; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    #endregion
    public CommerceOrderXmlRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  string recentOrderId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _recentOrderId = recentOrderId;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("COMMERCE_ORDER_XML-{0}-{1}", ShopperID, RecentOrderId));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
