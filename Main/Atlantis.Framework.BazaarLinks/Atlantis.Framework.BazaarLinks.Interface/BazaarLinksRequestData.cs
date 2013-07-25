using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.BazaarLinks.Interface
{
  public class BazaarLinksRequestData : RequestData
  {
    private int _resourceCount = 0;
    private int _discussionCount = 0;

    public BazaarLinksRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      int resourceCount, int discussionCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _resourceCount = resourceCount;
      _discussionCount = discussionCount;
    }

    public int ResourceCount
    {
      get { return _resourceCount; }
    }

    public int DiscussionCount
    {
      get { return _discussionCount; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_resourceCount.ToString() + ":" + _discussionCount.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
