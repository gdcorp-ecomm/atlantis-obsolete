using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.GetHelpArticles.Interface
{
  public class GetHelpArticlesRequestData : RequestData
  {

    private uint[] _articleIds;

    public uint[] ArticleIds
    {
      get { return _articleIds; }
    }

    public GetHelpArticlesRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      uint[] articleIds)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _articleIds = articleIds;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_articleIds.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }
  }
}
