using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.BonzaiApplyAddOn.Interface;
using Atlantis.Framework.BonzaiApplyAddOn.Impl.BonzaiWebService;

namespace Atlantis.Framework.BonzaiApplyAddOn.Impl
{
  public class BonzaiApplyAddOnRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      BonzaiWebService.WebServiceResponse wsResponse = null;
      BonzaiApplyAddOnResponseData responseData = null;

      try
      {
        BonzaiApplyAddOnRequestData bonzaiRequestData = (BonzaiApplyAddOnRequestData)requestData;
        BonzaiWebService.Service bonzaiWS = new Service();
        bonzaiWS.Url = ((WsConfigElement)config).WSURL;
        bonzaiWS.Timeout = (int)bonzaiRequestData.RequestTimeout.TotalMilliseconds;
        wsResponse = bonzaiWS.ApplyAddOn(bonzaiRequestData.ShopperID, bonzaiRequestData.AccountUid, bonzaiRequestData.AddOnType);

        if (wsResponse.ResultCode == 0)
        {
          responseData = new BonzaiApplyAddOnResponseData();
        }
        else
        {
          throw new AtlantisException(requestData, 
            "BonzaiApplyAddOnRequest::RequestHandler", 
            "Invalid BonzaiWebservice Request",
            string.Format("ResponseCode: {0} -- {1}", wsResponse.ResultCode, TranslateResponse(wsResponse.ResultCode)));
        }
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new BonzaiApplyAddOnResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new BonzaiApplyAddOnResponseData(requestData, ex);
      }
       
      return responseData;
    }

    #region Error Helper Method
    private string TranslateResponse(int responseCode)
    {
      string responseString = string.Empty;

      switch (responseCode)
      {
        case -1:
          responseString = "Invalid Database Connection";
          break;
        case -100:
          responseString = "No Resource Available";
          break;
        case -101:
          responseString = "Unable To Update Resource";
          break;
        case -103:
          responseString = "Unable To Obtain Resource Data For Shopper";
          break;
        case -200:
          responseString = "Orion Webservice Call Failed";
          break;
        case -201:
          responseString = "Unable To Add Attribute";
          break;
        case -203:
          responseString = "Orion AddOn Already Exists";
          break;
        case -300:
          responseString = "Missing Shopper ID";
          break;
        case -301:
          responseString = "Missing Account UID";
          break;
        case -302:
          responseString = "Missing AddOn Type";
          break;
        case -303:
          responseString = "AddOn Type Not Supported";
          break;
      }
      return responseString;
    }
    #endregion
  }
}
