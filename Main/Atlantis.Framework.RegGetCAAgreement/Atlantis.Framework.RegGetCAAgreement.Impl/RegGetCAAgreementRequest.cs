using System;
using System.Text;
using System.Xml;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RegGetCAAgreement.Interface;

namespace Atlantis.Framework.RegGetCAAgreement.Impl
{
  public class RegGetCAAgreementRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData responseData = null;
      string responseXML = string.Empty;

      try
      {
        RegGetCAAgreementRequestData regGetCAAgreementRequestData = (RegGetCAAgreementRequestData)oRequestData;

        RegCaDataWebService.RegCaDataWebSvc regCaDataWebService = new RegCaDataWebService.RegCaDataWebSvc();

        WsConfigElement wsConfigElement = (WsConfigElement)oConfig;
        regCaDataWebService.Url = wsConfigElement.WSURL;
        regCaDataWebService.Timeout = (int)regGetCAAgreementRequestData.RequestTimeout.TotalMilliseconds;

        responseXML = regCaDataWebService.GetAgreement();
        if (!string.IsNullOrEmpty(responseXML))
        {
          responseData = new RegGetCAAgreementResponseData(responseXML);
        }
        else
        {
          throw new Exception("RegGetCAAgreementRequest returned empty string.");
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new RegGetCAAgreementResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new RegGetCAAgreementResponseData(responseXML, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
