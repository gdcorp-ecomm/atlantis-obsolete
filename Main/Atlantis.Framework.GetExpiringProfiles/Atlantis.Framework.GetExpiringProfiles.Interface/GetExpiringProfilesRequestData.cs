using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.GetExpiringProfiles.Interface
{
  public class GetExpiringProfilesRequestData : RequestData
  {
    private int _daysBefore;
    private int _daysAfter;
    private TimeSpan _wsRequestTimeout;

    public GetExpiringProfilesRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  int daysBefore,
                                  int daysAfter)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _daysAfter = daysAfter;
      _daysBefore = daysBefore;
      _wsRequestTimeout = new TimeSpan(0, 0, 2);
    }

    public int DaysBefore
    {
      get { return _daysBefore; }
      set { _daysBefore = value; }
    }

    public int DaysAfter
    {
      get { return _daysAfter; }
      set { _daysAfter = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _wsRequestTimeout; }
      set { _wsRequestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();

      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}-{2}",
        ShopperID, _daysBefore, _daysAfter));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

  }
}
