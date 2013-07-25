using System;
using Atlantis.Framework.Ecc.Interface.Authentication;
using Atlantis.Framework.Ecc.Interface.jsonHelpers;
using Atlantis.Framework.ECCGetEmailPlanInfo.Interface;
using Atlantis.Framework.ECCGetEmailPlanInfoForShopper.Impl.Json;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Nimitz;

namespace Atlantis.Framework.ECCGetEmailPlanInfo.Impl
{
  public class ECCGetEmailPlanInfoRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData responseData;
      EccGetEmailPlanInfoRequestData plansRequest = (EccGetEmailPlanInfoRequestData)oRequestData;

      const int pageNumber = 1;
      const int resultsPerPage = 100000;
      const string requestMethod = "getEmailPlanInfoForShopper";

      string requestKey;
      string authName;
      string authToken;

      string nimitzAuthXml = NetConnect.LookupConnectInfo(oConfig, ConnectLookupType.Xml);
      NimitzAuthHelper.GetConnectionCredentials(nimitzAuthXml, out requestKey, out authName, out authToken);

      try
      {
        WsConfigElement wsConfig = ((WsConfigElement)oConfig);

        EccJsonEmailPlanInfoRequest oJsonRequestBody = new EccJsonEmailPlanInfoRequest();
        oJsonRequestBody.EmailType = ((int)plansRequest.EmailType).ToString();
        oJsonRequestBody.ShopperId = plansRequest.ShopperID;
        oJsonRequestBody.ResellerId = plansRequest.ResellerId.ToString();
        oJsonRequestBody.AccountUid = plansRequest.AccountUid;
        oJsonRequestBody.SubAccount = plansRequest.Subaccount;
        oJsonRequestBody.DeepLoad = plansRequest.DeepLoad;

        EccJsonRequest<EccJsonEmailPlanInfoRequest> oRequest = new EccJsonRequest<EccJsonEmailPlanInfoRequest>();
        oRequest.Id = authName;
        oRequest.Token = authToken;
        oRequest.Return = new EccJsonPaging(pageNumber, resultsPerPage, String.Empty, string.Empty);
        oRequest.Parameters = oJsonRequestBody;

        string sRequest = oRequest.ToJson();

        string response = EccJsonRequestHandler.PostRequest(sRequest, wsConfig.WSURL, requestMethod, requestKey);
        responseData = new EccGetEmailPlanInfoResponseData(response);
      }
      catch (Exception ex)
      {
        responseData = new EccGetEmailPlanInfoResponseData(oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }

}
