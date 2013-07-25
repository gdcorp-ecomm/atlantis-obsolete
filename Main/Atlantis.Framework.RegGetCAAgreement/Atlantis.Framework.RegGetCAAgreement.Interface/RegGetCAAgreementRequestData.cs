using System;
using System.Text;
using System.Xml;
using System.IO;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.RegGetCAAgreement.Interface
{
  public class RegGetCAAgreementRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }

    public RegGetCAAgreementRequestData(
      string shopperID,
      string sourceURL,
      string orderID,
      string pathway,
      int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(4);
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes("RegGetCAAgreementRequestData");
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

    #endregion
  }
}
