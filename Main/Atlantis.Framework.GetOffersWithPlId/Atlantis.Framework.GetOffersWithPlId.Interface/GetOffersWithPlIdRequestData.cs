﻿using System;
using System.Security.Cryptography;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetOffersWithPlId.Interface
{
  public class GetOffersWithPlIdRequestData : RequestData
  {
    #region Properties

    private short _applicationId = 0;
    private int _privateLabelId = -1;
    private TimeSpan _requestTimeout;

    public short ApplicationId { get { return _applicationId; } }
    public int PrivateLabelId { get { return _privateLabelId; } }
    /// <summary>
    /// Request Timeout in milliseconds
    /// </summary>
    public TimeSpan RequestTimeout { get { return _requestTimeout; } set { _requestTimeout = value; } }

    #endregion

    public GetOffersWithPlIdRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  short applicationId,
                                  int privateLabelId
                                  )
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _applicationId = applicationId;
      _privateLabelId = privateLabelId;
      _requestTimeout = new TimeSpan(0, 0, 2);
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}-{1}-{2}",
        ShopperID, _applicationId, _privateLabelId));
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }


  }
}
