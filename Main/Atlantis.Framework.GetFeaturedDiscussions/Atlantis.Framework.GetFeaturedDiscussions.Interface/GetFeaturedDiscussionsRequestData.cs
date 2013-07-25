using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.GetFeaturedDiscussions.Interface
{
  public class GetFeaturedDiscussionsRequestData : RequestData
  {
    private int _forumId;
    public GetFeaturedDiscussionsRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, int forumId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _forumId = forumId;
    }

    public int ForumID
    {
      get { return _forumId; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_forumId.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }
  }
}
