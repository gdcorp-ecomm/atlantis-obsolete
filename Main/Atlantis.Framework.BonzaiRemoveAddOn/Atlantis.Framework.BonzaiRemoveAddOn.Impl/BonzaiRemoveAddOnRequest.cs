using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.BonzaiRemoveAddOn.Interface;
using Atlantis.Framework.BonzaiRemoveAddOn.Impl.BonzaiWebService;

namespace Atlantis.Framework.BonzaiRemoveAddOn.Impl
{
  public class BonzaiRemoveAddOnRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      BonzaiWebService.WebServiceResponse wsResponse = null;
      BonzaiRemoveAddOnResponseData responseData = null;

      try
      {
        BonzaiRemoveAddOnRequestData bonzaiRequestData = (BonzaiRemoveAddOnRequestData)requestData;
        BonzaiWebService.Service bonzaiWS = new Service();
        bonzaiWS.Url = ((WsConfigElement)config).WSURL;
        bonzaiWS.Timeout = (int)bonzaiRequestData.RequestTimeout.TotalMilliseconds;
        wsResponse = bonzaiWS.RemoveAddOn(bonzaiRequestData.ShopperID, bonzaiRequestData.AccountUid, bonzaiRequestData.AttributeUid, bonzaiRequestData.AddOnType);

        if (wsResponse.ResultCode == 0)
        {
          responseData = new BonzaiRemoveAddOnResponseData();
        }
        else
        {
          throw new AtlantisException(requestData, 
            "BonzaiRemoveAddOnRequest::RequestHandler", 
            "Invalid BonzaiWebservice Request",
            string.Format("ResponseCode: {0} -- {1}", wsResponse.ResultCode, TranslateResponse(wsResponse.ResultCode)));
        }
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new BonzaiRemoveAddOnResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new BonzaiRemoveAddOnResponseData(requestData, ex);
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
        case -102:
          responseString = "Unable To Remove Resource";
          break;
        case -103:
          responseString = "Unable To Obtain Resource Data For Shopper";
          break;
        case -200:
          responseString = "Orion Webservice Call Failed";
          break;
        case -202:
          responseString = "Unable To Remove Attribute";
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
        case -304:
          responseString = "Argument Missing Attribute UID";
          break;
      }
      return responseString;
    }
    #endregion
  }
}
