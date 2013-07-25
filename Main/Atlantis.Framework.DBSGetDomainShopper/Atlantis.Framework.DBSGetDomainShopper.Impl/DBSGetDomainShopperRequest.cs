using System;
using Atlantis.Framework.DBSGetDomainShopper.Impl.DbsWebService;
using Atlantis.Framework.DBSGetDomainShopper.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DBSGetDomainShopper.Impl
{
  public class DBSGetDomainShopperRequest : IRequest
  {

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DBSGetDomainShopperResponseData responseData = null;
      string resultXML = string.Empty;
      
      try
      {
        DBSGetDomainShopperRequestData requestData = (DBSGetDomainShopperRequestData)oRequestData;
        DbsWebService.DomainServices DbsWS = new DomainServices();
        DbsWS.Url = ((WsConfigElement)oConfig).WSURL;
        DbsWS.Timeout = (int)requestData.RequestTimeout.TotalMilliseconds;

        resultXML = DbsWS.GetDomainShopperByLegalResourceId(requestData.ResourceId);
        responseData = new DBSGetDomainShopperResponseData(resultXML);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DBSGetDomainShopperResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DBSGetDomainShopperResponseData(responseData.ToString(), oRequestData, ex);
      }
      return responseData;
    }

  }
}
