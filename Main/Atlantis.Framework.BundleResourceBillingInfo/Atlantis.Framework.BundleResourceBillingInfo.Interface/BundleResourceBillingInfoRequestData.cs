using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BundleResourceBillingInfo.Interface
{
  public class BundleResourceBillingInfoRequestData : RequestData
  {
    #region Properties

    public TimeSpan RequestTimeout { get; set; }
    public int BundleResourceId { get; private set; }

    #endregion

    public BundleResourceBillingInfoRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount
      , int bundleResourceId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      BundleResourceId = bundleResourceId;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();

      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}", ShopperID, BundleResourceId));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
