using Atlantis.Framework.Interface;
using System.Security.Cryptography;
using System.Text;
using System;

namespace Atlantis.Framework.HCCGetAccountList.Interface
{
  public class HCCGetAccountListRequestData : RequestData
  {
    static readonly TimeSpan _requestTimeout = TimeSpan.FromSeconds(20);
    public HCCGetAccountListRequestData(string shopperId,
								                        string sourceUrl,
								                        string orderId,
								                        string pathway,
								                        int pageCount) : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = _requestTimeout;
    }

    public TimeSpan RequestTimeout { get; set; }
    public override string GetCacheMD5()
    {
      MD5 md5 = new MD5CryptoServiceProvider();

      byte[] data = Encoding.UTF8.GetBytes(base.ShopperID);

      byte[] hash = md5.ComputeHash(data);
      string result = Encoding.UTF8.GetString(hash);
      return result;
    }
  }
}
