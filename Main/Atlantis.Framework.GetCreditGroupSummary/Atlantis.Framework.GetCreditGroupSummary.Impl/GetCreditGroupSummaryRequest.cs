using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetCreditGroupSummary.Interface;
using System.Xml;

namespace Atlantis.Framework.GetCreditGroupSummary.Impl
{
  public class GetCreditGroupSummaryRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetCreditGroupSummaryRequestData requestData = (GetCreditGroupSummaryRequestData)oRequestData;
      GetCreditGroupSummaryResponseData responseData = new GetCreditGroupSummaryResponseData();
      WsConfigElement configuration = (WsConfigElement)oConfig;

      CMS.WSCgdCMSService cms = new CMS.WSCgdCMSService();
      cms.Url = configuration.WSURL;
      cms.Timeout = (int)requestData.RequestTimeout.TotalMilliseconds;

      try
      {
        string response = cms.GetCreditGroupSummary(requestData.ShopperID, requestData.DisplayGroupID, 0);
        
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(response);

        if(string.Compare(doc.SelectSingleNode("/RESPONSE/MESSAGE").InnerText, "Success", true) != 0)
        {
          string data = string.Format("DisplayGroupID: {0}, Response: {1}", requestData.DisplayGroupID, response);
          responseData.AtlException = new AtlantisException(requestData,
            "GetCreditGroupSummaryRequest.RequestHandler", "Could not retrieve summary of credit group", data);
        }
        else
        {
          responseData.XML = doc.SelectSingleNode("/RESPONSE/CREDITS").OuterXml;
        }
      }
      catch (Exception ex)
      {
        string data = string.Format("DisplayGroupID: {0}", requestData.DisplayGroupID);
        responseData.AtlException = new AtlantisException(requestData,
          "GetCreditGroupSummaryRequest.RequestHandler", "Could not retrieve summary of credit group", data, ex);
      }

      return responseData;
    }
  }
}
