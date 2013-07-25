using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;
using System.Text;

namespace Atlantis.Framework.ShopperCreditLine.Interface
{
  public class ShopperCreditLineRequestData : RequestData
  {
    private TimeSpan _timeOut = TimeSpan.FromSeconds(2);

    public TimeSpan TimeOut
    {
      get { return _timeOut; }
      set { _timeOut = value; }
    }

    public ShopperCreditLineRequestData(string sShopperID,
                                   string sSourceURL,
                                   string sOrderID,
                                   string sPathway,
                                   int iPageCount)
                                   : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
    }

    public override string GetCacheMD5()
    {
      MD5 md5 = new MD5CryptoServiceProvider();
      md5.Initialize();
      byte[] md5Bytes
        = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(ShopperID));
      return BitConverter.ToString(md5Bytes).Replace("-", "");
    }
  }
}
