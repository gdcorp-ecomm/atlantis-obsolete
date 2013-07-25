using System;
using Atlantis.Framework.DBSCreateTdnamAuction.Impl.DbsWebService;
using Atlantis.Framework.DBSCreateTdnamAuction.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DBSCreateTdnamAuction.Impl
{
  public class DBSCreateTdnamAuctionRequest : IRequest
  {

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DBSCreateTdnamAuctionResponseData responseData = null;
      string resultXML = string.Empty;
      
      try
      {
        DBSCreateTdnamAuctionRequestData requestData = (DBSCreateTdnamAuctionRequestData)oRequestData;
        DbsWebService.DomainServices DbsWS = new DomainServices();
        DbsWS.Url = ((WsConfigElement)oConfig).WSURL;
        DbsWS.Timeout = (int)requestData.RequestTimeout.TotalMilliseconds;
        
        resultXML = DbsWS.DomainBuy_CreateTdnamAuction(requestData.RequestXml);
        responseData = new DBSCreateTdnamAuctionResponseData(resultXML);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DBSCreateTdnamAuctionResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DBSCreateTdnamAuctionResponseData(responseData.ToString(), oRequestData, ex);
      }
      return responseData;
    }

  }
}
