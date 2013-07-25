using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;
using Atlantis.Framework.IsShopperInOptoutList.Interface;
using Atlantis.Framework.IsShopperInOptoutList.Impl.RegWhoisOptOutWebSvc;

namespace Atlantis.Framework.IsShopperInOptoutList.Impl
{
  public class ShopperInOptoutListRequest : IRequest
  {

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      ShopperInOptoutListResponseData responseData = null;
      try
      {
        string regWhoisOptOutWsUrl = ((WsConfigElement)oConfig).WSURL;
        ShopperInOptoutListRequestData request = (ShopperInOptoutListRequestData)oRequestData;
        RegWhoisOptOutWebSvcService regWhoisOptOutWs = new RegWhoisOptOutWebSvcService();
        regWhoisOptOutWs.Url = regWhoisOptOutWsUrl;

        string isOptOut = regWhoisOptOutWs.IsShopperInOptoutList("isoptedout");

        responseData = new ShopperInOptoutListResponseData(isOptOut);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new ShopperInOptoutListResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new ShopperInOptoutListResponseData(oRequestData, ex);
      }
      return responseData;   
    }
  }
}
