﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.MktgGetShopperPreferences.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MktgGetShopperPreferences.Impl
{
  public class MktgGetShopperPreferencesRequest: IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      IResponseData result = null;
      string responseText = string.Empty;

      try
      {
        MktgGetShopperPreferencesRequestData mktgRequest = (MktgGetShopperPreferencesRequestData)requestData;

        PreferencesWS.Service service = new PreferencesWS.Service();
        service.Url = ((WsConfigElement)config).WSURL;
        service.Timeout = (int)mktgRequest.RequestTimeout.TotalMilliseconds;
        responseText = service.GetShopperOptIns(mktgRequest.ShopperID);
        result = new MktgGetShopperPreferencesResponseData(responseText);
      }
      catch (AtlantisException aex)
      {
        result = new MktgGetShopperPreferencesResponseData(aex);
      }
      catch (Exception ex)
      {
        result = new MktgGetShopperPreferencesResponseData(requestData, ex);
      }

      return result;
    }

    #endregion
  }
}
