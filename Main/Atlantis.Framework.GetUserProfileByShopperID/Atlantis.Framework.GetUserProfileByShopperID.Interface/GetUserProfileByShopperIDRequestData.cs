using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;


namespace Atlantis.Framework.GetUserProfileByShopperID.Interface
{
  public class GetUserProfileByShopperIDRequestData : RequestData
  {
    public GetUserProfileByShopperIDRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
     
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(ShopperID);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }
  }
}
