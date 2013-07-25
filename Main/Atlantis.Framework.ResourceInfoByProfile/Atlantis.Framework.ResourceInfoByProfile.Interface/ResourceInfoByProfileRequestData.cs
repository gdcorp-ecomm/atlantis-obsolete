using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ResourceInfoByProfile.Interface
{
  public class ResourceInfoByProfileRequestData : RequestData
  {
    #region Properties

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    private List<SqlParameter> _parms;

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public List<SqlParameter> Parms
    {
      get { return _parms; }
    }

    #endregion
    #region Constructor
    public ResourceInfoByProfileRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  List<SqlParameter> parms)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _parms = parms;
    }
    #endregion

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
