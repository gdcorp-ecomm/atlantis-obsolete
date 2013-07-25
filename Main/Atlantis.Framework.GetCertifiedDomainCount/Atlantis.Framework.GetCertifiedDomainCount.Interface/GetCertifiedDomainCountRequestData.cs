using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.GetCertifiedDomainCount.Interface
{
  public class GetCertifiedDomainCountRequestData : RequestData
  {
    private TimeSpan _wsRequestTimeout = new TimeSpan(0, 0, 2);

    public GetCertifiedDomainCountRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    { }

    public TimeSpan RequestTimeout
    {
      get { return _wsRequestTimeout; }
      set {_wsRequestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(ShopperID);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }


  }
}
