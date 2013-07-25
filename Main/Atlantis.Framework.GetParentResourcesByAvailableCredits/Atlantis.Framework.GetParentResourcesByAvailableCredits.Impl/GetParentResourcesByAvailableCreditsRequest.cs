using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetParentResourcesByAvailableCredits.Interface;
using System.Xml;

namespace Atlantis.Framework.GetParentResourcesByAvailableCredits.Impl
{
  public class GetParentResourcesByAvailableCreditsRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetParentResourcesByAvailableCreditsRequestData requestData = (GetParentResourcesByAvailableCreditsRequestData)oRequestData;
      GetParentResourcesByAvailableCreditsResponseData responseData = new GetParentResourcesByAvailableCreditsResponseData();
      WsConfigElement configuration = (WsConfigElement)oConfig;

      CMS.WSCgdCMSService cms = new CMS.WSCgdCMSService();
      cms.Url = configuration.WSURL;

      try
      {
        string response = cms.GetParentResourcesByAvailableCredits(requestData.ShopperID, 
          requestData.ChildUnifiedProductID, requestData.ParentDisplayGroupID, requestData.CreditType);

        XmlDocument responseDocument = new XmlDocument();
        responseDocument.LoadXml(response);

        if (string.Compare(responseDocument.SelectSingleNode("/RESPONSE/MESSAGE").InnerText, "Success", true) != 0)
        {
          string data = string.Format("Response: {0}, ChildUnifiedProductID: {1}, ParentDisplayGroupID: {2}, CreditType: {3}",
            response, requestData.ChildUnifiedProductID, requestData.ParentDisplayGroupID, requestData.CreditType);

          responseData.AtlException = new AtlantisException(requestData,
            "GetParentResourcesByAvailableCreditsRequest.RequestHandler", "Could not get resources",
            data);
        }
        else
        {
          responseData.XML = responseDocument.SelectSingleNode("/RESPONSE/PURCHASERESOURCES").OuterXml;
        }
      }
      catch (Exception ex)
      {
        string data = string.Format("ChildUnifiedProductID: {0}, ParentDisplayGroupID: {1}, CreditType: {2}",
             requestData.ChildUnifiedProductID, requestData.ParentDisplayGroupID, requestData.CreditType);

        responseData.AtlException = new AtlantisException(requestData,
          "GetParentResourcesByAvailableCreditsRequest.RequestHandler", "Could not get resources",
          data, ex);
      }

      return responseData;
    }
  }
}
