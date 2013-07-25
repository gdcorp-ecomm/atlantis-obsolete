using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetCreditSummary.Interface;


namespace Atlantis.Framework.GetCreditSummary.Impl
{
  public class GetCreditSummaryRequest : IRequest
  {

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetCreditSummaryRequestData requestData = (GetCreditSummaryRequestData)oRequestData;
      GetCreditSummaryResponseData responseData = new GetCreditSummaryResponseData();

      WsConfigElement configuration = (WsConfigElement)oConfig;

      WSCgdCMS.WSCgdCMSService service = new Atlantis.Framework.GetCreditSummary.Impl.WSCgdCMS.WSCgdCMSService();
      service.Url = configuration.WSURL;

      try
      {
        string responseXML = service.GetCreditSummary(requestData.ShopperID);

        if(responseXML.IndexOf("<error>",StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException atlException = new AtlantisException(oRequestData, "GetCreditSummartRequest.RequestHandler", responseXML, oRequestData.ToXML());
          responseData.AtlException = atlException;
        }
        responseData.ResponseXML = responseXML;
      }
      catch (Exception ex)
      {
        if (ex is AtlantisException)
        {
          responseData.AtlException = ex as AtlantisException;
        }
        else
        {
          responseData.AtlException = new AtlantisException(oRequestData, "GetCreditSummartRequest.RequestHandler", "Failure in GetCreditSummary", oRequestData.ToXML(), ex);
        }
          
      }

      return responseData;
    }

    #endregion
  }
}
