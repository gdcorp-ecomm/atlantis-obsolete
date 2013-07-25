using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SocialMediaContestGetVideoIDS.Interface
{
  public class SocialMediaContestGetVideoIDSRequestData : RequestData
  {

    #region Properties
    private int _competitionId;
    private TimeSpan _requestTimeout = new TimeSpan(5);

    public int CompetitionId
    {
      get { return _competitionId; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    #endregion

    public SocialMediaContestGetVideoIDSRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  int competitionId)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _competitionId = competitionId;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(CompetitionId.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

  }
}
