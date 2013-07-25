using System;
using Atlantis.Framework.DBSSellerInterested.Impl.DbsWebService;
using Atlantis.Framework.DBSSellerInterested.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DBSSellerInterested.Impl
{
  public class DBSSellerInterestedRequest : IRequest
  {

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DBSSellerInterestedResponseData responseData = null;
      string resultXML = string.Empty;
      
      try
      {
        DBSSellerInterestedRequestData requestData = (DBSSellerInterestedRequestData)oRequestData;
        DbsWebService.DomainServices DbsWS = new DomainServices();
        DbsWS.Url = ((WsConfigElement)oConfig).WSURL;
        DbsWS.Timeout = (int)requestData.RequestTimeout.TotalMilliseconds;
        
        resultXML = DbsWS.Status_UpdateSiteSellerInterested(requestData.RequestXml);
        responseData = new DBSSellerInterestedResponseData(resultXML);

      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DBSSellerInterestedResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DBSSellerInterestedResponseData(responseData.ToString(), oRequestData, ex);
      }
      return responseData;
    }

  }
}
