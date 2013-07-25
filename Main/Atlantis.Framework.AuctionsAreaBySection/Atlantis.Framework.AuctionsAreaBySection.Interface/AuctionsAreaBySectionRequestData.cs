using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.AuctionsAreaBySection.Interface
{
  public class AuctionsAreaBySectionRequestData : RequestData
  {
    private string _membersAreaID;
    private string _returnBids;
    private TimeSpan _wsRequestTimeout;

    public AuctionsAreaBySectionRequestData(
      string shopperID, string sourceURL, string orderID, string pathway, 
      int pageCount, string membersAreaID, string returnBids)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      _membersAreaID = membersAreaID;
      _returnBids = returnBids;
      _wsRequestTimeout = new TimeSpan(0, 0, 2);
    }

    #region Properties

    public string MembersAreaID
    {
      get { return _membersAreaID; }
      set { _membersAreaID = value; }
    }

    public string ReturnBids
    {
      get { return _returnBids; }
      set { _returnBids = value; }
      
    }

    public TimeSpan RequestTimeout
    {
      get { return _wsRequestTimeout; }
      set { _wsRequestTimeout = value; }
    }

    #endregion

    #region RequestData Members
    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}-{2}", ShopperID, MembersAreaID, ReturnBids));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
    #endregion
  }
}
