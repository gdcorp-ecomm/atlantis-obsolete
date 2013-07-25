﻿using System;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ShopperPriceType.Interface
{
  public class ShopperPriceTypeRequestData : RequestData
  {
    private int _privateLabelId;
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(2);

    public ShopperPriceTypeRequestData(string shopperId,
                                       string sourceUrl,
                                       string orderId,
                                       string pathway,
                                       int pageCount,
                                       int privateLabelId)
                                       : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _privateLabelId = privateLabelId;
    }

    public int PrivateLabelID
    {
      get { return _privateLabelId; }
      set { _privateLabelId = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      MD5 md5 = new MD5CryptoServiceProvider();
      md5.Initialize();

      byte[] md5Bytes = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(ShopperID + _privateLabelId.ToString()));
      return BitConverter.ToString(md5Bytes).Replace("-", "");
    }

    #endregion
  }
}
