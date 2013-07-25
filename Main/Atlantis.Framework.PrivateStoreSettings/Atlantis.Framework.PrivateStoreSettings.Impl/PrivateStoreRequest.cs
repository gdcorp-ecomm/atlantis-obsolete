using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.PrivateStoreSettings.Interface;
namespace Atlantis.Framework.PrivateStoreSettings.Impl
{
  public class PrivateStoreRequest : IRequest
  {

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      PrivateStoreSettingsRequestData requestData = (PrivateStoreSettingsRequestData)oRequestData;
      PrivateStoreSettingsResponseData responseData;
      try
      {
        PrivateStoreSvc.PrivateStore oSvc = new Atlantis.Framework.PrivateStoreSettings.Impl.PrivateStoreSvc.PrivateStore();
        PrivateStoreSvc.PrivateStoreSettings resultInfo;
        oSvc.Url = ((WsConfigElement)oConfig).WSURL;
        resultInfo=oSvc.GetPrivateStoreSettings(requestData.MarketplaceShopID, requestData.IsPreview, requestData.IsSecure);
        if (resultInfo.ResponseState.Status == PrivateStoreSvc.StatusCode.Success)
        {
          responseData = new PrivateStoreSettingsResponseData(resultInfo.ResponseState.Status.ToString(), resultInfo.MarketplaceShopID,
            resultInfo.MarketplaceShopName, resultInfo.MarketplaceStoreUrl, resultInfo.IsStoreHeaderImageOn,
            resultInfo.StoreHeaderImageUrl, resultInfo.StoreTagLine, resultInfo.StoreHomePageText, resultInfo.StoreHomePageUrl,
            resultInfo.IsPreview);
        }
        else
        {
          AtlantisException problemOccured = new AtlantisException(requestData,
            resultInfo.ResponseState.Source,
            resultInfo.ResponseState.Message,
            resultInfo.ResponseState.StackTrace);
          responseData = new PrivateStoreSettingsResponseData(requestData, problemOccured);
        }
        return responseData;
      }
      catch (System.Exception ex)
      {
        AtlantisException systemError = new AtlantisException(requestData, "PrivateStoreRequest", "UnHandledException","ShopID:"+requestData.MarketplaceShopID.ToString(),ex);
        responseData = new PrivateStoreSettingsResponseData(requestData, systemError);
      }
      return responseData;
    }

    #endregion
  }
}
