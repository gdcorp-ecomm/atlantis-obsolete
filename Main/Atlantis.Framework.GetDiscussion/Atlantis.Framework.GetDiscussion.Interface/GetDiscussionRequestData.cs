using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.GetDiscussion.Interface
{
  public class GetDiscussionRequestData : RequestData
  {
    private long _threadId;
    

    public GetDiscussionRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, long threadId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _threadId = threadId;
    }

    public long ThreadId
    {
      get { return _threadId; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_threadId.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }
  }
}
