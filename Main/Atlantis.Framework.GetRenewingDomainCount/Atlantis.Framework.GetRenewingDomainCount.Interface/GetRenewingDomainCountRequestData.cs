using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetRenewingDomainCount.Interface
{
  public class GetRenewingDomainCountRequestData : RequestData
  {

    #region Properties

    private int _daysFromExpire = 0;
    private TimeSpan _requestTimeOut = new TimeSpan(0, 0, 2);

    public int DaysFromExpire 
    { 
      get { return _daysFromExpire; }
    }
    
    public TimeSpan RequestTimeout
    { 
      get { return _requestTimeOut; } 
      set { _requestTimeOut = value; } 
    }

    #endregion 

    public GetRenewingDomainCountRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  int daysFromExpire)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _daysFromExpire = daysFromExpire;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}", ShopperID, DaysFromExpire));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
