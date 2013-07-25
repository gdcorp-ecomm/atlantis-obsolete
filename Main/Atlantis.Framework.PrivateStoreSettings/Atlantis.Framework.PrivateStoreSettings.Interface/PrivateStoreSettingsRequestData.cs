using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.PrivateStoreSettings.Interface
{
  public class PrivateStoreSettingsRequestData : RequestData
  {

    #region Properties
    private bool _isPreview=false;
    private bool _isSecure = false;
    private int _marketplaceShopID = 0;

    public bool IsPreview
    {
      get
      {
        return _isPreview;
      }
      set
      {
        _isPreview = value;
      }
    }

    public bool IsSecure
    {
      get
      {
        return _isSecure;
      }
      set
      {
        _isSecure = value;
      }
    }

    public int MarketplaceShopID
    {
      get
      {
        return _marketplaceShopID;
      }
      set
      {
        _marketplaceShopID = value;
      }
    }
    #endregion

    #region Constructors
    public PrivateStoreSettingsRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  int marketplaceShopID,
                                  bool previewData,
                                  bool isSecureConnection)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      _marketplaceShopID = marketplaceShopID;
      _isPreview = previewData;
      _isSecure = isSecureConnection;
    }
    #endregion

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_marketplaceShopID.ToString()+":"+_isPreview.ToString()+":"+_isSecure.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
