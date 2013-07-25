using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetCoupons.Interface
{
  public class GetCouponsRequestData : RequestData
  {
    private TimeSpan  _requestTimeOut = new TimeSpan(0, 0, 2);

    public TimeSpan RequestTimeOut 
    { 
      get { return _requestTimeOut; } 
      set { _requestTimeOut = value; } 
    }

    public GetCouponsRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    { }
    
    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(this.ShopperID);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
