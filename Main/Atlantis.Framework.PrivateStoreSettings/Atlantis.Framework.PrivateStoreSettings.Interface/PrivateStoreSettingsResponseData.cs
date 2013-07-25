using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.PrivateStoreSettings.Interface
{
  public class PrivateStoreSettingsResponseData:IResponseData
  {
    AtlantisException _ex;

    #region ResponseData
    private string _responseStateField;
    private int _marketplaceShopIDField;
    private string _marketplaceShopNameField;
    private string _marketplaceStoreUrlField;
    private bool _isStoreHeaderImageOnField;
    private string _storeHeaderImageUrlField;
    private string _storeTagLineField;
    private string _storeHomePageTextField;
    private string _storeHomePageUrlField;
    private bool _isPreviewField;

    /// <remarks/>
    public string ResponseState
    {
      get
      {
        return this._responseStateField;
      }
    }

    /// <remarks/>
    public int MarketplaceShopID
    {
      get
      {
        return this._marketplaceShopIDField;
      }
    }

    /// <remarks/>
    public string MarketplaceShopName
    {
      get
      {
        return this._marketplaceShopNameField;
      }
    }

    /// <remarks/>
    public string MarketplaceStoreUrl
    {
      get
      {
        return this._marketplaceStoreUrlField;
      }
    }

    /// <remarks/>
    public bool IsStoreHeaderImageOn
    {
      get
      {
        return this._isStoreHeaderImageOnField;
      }
    }

    /// <remarks/>
    public string StoreHeaderImageUrl
    {
      get
      {
        return this._storeHeaderImageUrlField;
      }
    }

    /// <remarks/>
    public string StoreTagLine
    {
      get
      {
        return this._storeTagLineField;
      }
    }

    /// <remarks/>
    public string StoreHomePageText
    {
      get
      {
        return this._storeHomePageTextField;
      }
    }

    /// <remarks/>
    public string StoreHomePageUrl
    {
      get
      {
        return this._storeHomePageUrlField;
      }
    }

    /// <remarks/>
    public bool IsPreview
    {
      get
      {
        return this._isPreviewField;
      }
    }
    #endregion

    #region IResponseData Members

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion

    #region Constructors
    public PrivateStoreSettingsResponseData(string responseState, int marketplaceShopID, string marketplaceShopName,
        string marketplaceStoreUrl, bool isStoreHeaderImageOn, string storeHeaderImageUrl, string storeTagLine,
        string storeHomePageText, string storeHomePageUrl, bool isPreview)
    {
      _responseStateField = responseState;
      _marketplaceShopIDField = marketplaceShopID;
      _marketplaceShopNameField = marketplaceShopName;
      _marketplaceStoreUrlField = marketplaceStoreUrl;
      _isStoreHeaderImageOnField = isStoreHeaderImageOn;
      _storeHeaderImageUrlField = storeHeaderImageUrl;
      _storeTagLineField = storeTagLine;
      _storeHomePageTextField = storeHomePageText;
      _storeHomePageUrlField = storeHomePageUrl;
      _isPreviewField = isPreview;
    }
    public PrivateStoreSettingsResponseData(RequestData oRequestData, AtlantisException ex)
    {
      _ex = ex;
    }
    public PrivateStoreSettingsResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData,
                                   "PrivateStoreSettings", 
                                   ex.Message, string.Empty);
    }
    #endregion
  }
}
