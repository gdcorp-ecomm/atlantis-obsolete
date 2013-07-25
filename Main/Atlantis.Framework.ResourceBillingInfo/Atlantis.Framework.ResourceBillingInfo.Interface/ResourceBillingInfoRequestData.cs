using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.ResourceBillingInfo.Interface
{
  public class ResourceBillingInfoRequestData : RequestData
  {
    #region Properties
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 5);

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public int? BillingResourceId { get; set; }

    #endregion

    public ResourceBillingInfoRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  int? billingResourceId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      BillingResourceId = billingResourceId;    
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();

      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}", ShopperID, (BillingResourceId.HasValue ? BillingResourceId.Value.ToString() : "GetAll")));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
