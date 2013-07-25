using System;
using Atlantis.Framework.DBSSellerNotInterested.Impl.DbsWebService;
using Atlantis.Framework.DBSSellerNotInterested.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DBSSellerNotInterested.Impl
{
  public class DBSSellerNotInterestedRequest : IRequest
  {

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DBSSellerNotInterestedResponseData responseData = null;
      string resultXML = string.Empty;
      
      try
      {
        DBSSellerNotInterestedRequestData requestData = (DBSSellerNotInterestedRequestData)oRequestData;
        DbsWebService.DomainServices DbsWS = new DomainServices();
        DbsWS.Url = ((WsConfigElement)oConfig).WSURL;
        DbsWS.Timeout = (int)requestData.RequestTimeout.TotalMilliseconds;

        resultXML = DbsWS.DomainBuy_SellerNotInterestedByResourceId(requestData.ResourceId);
        responseData = new DBSSellerNotInterestedResponseData(resultXML);

      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DBSSellerNotInterestedResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DBSSellerNotInterestedResponseData(responseData.ToString(), oRequestData, ex);
      }
      return responseData;
    }

  }
}
