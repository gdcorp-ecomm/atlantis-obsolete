using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.RedeemCreditEx.Interface;
using System.Xml;

namespace Atlantis.Framework.RedeemCreditEx.Impl
{
  public class RedeemCreditExRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      RedeemCreditExRequestData requestData = (RedeemCreditExRequestData)oRequestData;
      RedeemCreditExResponseData responseData = null;
      WsConfigElement configuration = (WsConfigElement)oConfig;

      CMS.WSCgdCMSService cms = new CMS.WSCgdCMSService();
      cms.Url = configuration.WSURL;

      try
      {
        string response = cms.RedeemCreditEx(requestData.RedeemXML);
        if (string.Compare(response.Substring(0, 36), "<RESPONSE><MESSAGE>Success</MESSAGE>", true) != 0)
        {
          string data = string.Format("Redeem XML: {0}, Response: {1}", requestData.RedeemXML, response);
          AtlantisException aex = new AtlantisException(oRequestData, "RedeemCreditExRequest.RequestHandler", "Could not redeem credit", data);
          responseData = new RedeemCreditExResponseData(aex);
        }
        else
        {
          responseData = new RedeemCreditExResponseData(response);
        }
      }
      catch (Exception ex)
      {
        string data = "Redeem XML: " + requestData.RedeemXML;
        AtlantisException aex = new AtlantisException(oRequestData, "RedeemCreditExRequest.RequestHandler", "Could not redeem credit", data, ex);
        responseData = new RedeemCreditExResponseData(aex);
      }

      return responseData;
    }
  }
}
