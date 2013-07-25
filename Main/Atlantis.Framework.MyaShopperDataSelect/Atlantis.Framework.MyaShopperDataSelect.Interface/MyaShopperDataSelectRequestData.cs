using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MyaShopperDataSelect.Interface
{
  public class MyaShopperDataSelectRequestData : RequestData
  {
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public int Category { get; set; }

    public MyaShopperDataSelectRequestData(string shopperID,
                                           string sourceUrl,
                                           string orderID,
                                           string pathway,
                                           int pageCount,
                                           int category)
      : base(shopperID, sourceUrl, orderID, pathway, pageCount)
    {
      Category = category;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();

      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}", ShopperID, Category.ToString()));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
