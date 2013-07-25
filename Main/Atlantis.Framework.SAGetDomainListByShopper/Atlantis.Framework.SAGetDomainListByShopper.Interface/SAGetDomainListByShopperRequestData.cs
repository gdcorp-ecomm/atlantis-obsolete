using System;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SAGetDomainListByShopper.Interface
{
  public class SAGetDomainListByShopperRequestData : RequestData
  {
    public SAGetDomainListByShopperRequestData(string shopperId, string sourceURL, string orderId, string pathway, int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      RequestTimeout = new TimeSpan(0, 0, 0, 30);
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
