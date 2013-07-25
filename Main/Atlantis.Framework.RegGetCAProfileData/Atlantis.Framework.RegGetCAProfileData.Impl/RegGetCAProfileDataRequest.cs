using System;
using System.Text;
using System.Xml;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RegGetCAProfileData.Interface;

namespace Atlantis.Framework.RegGetCAProfileData.Impl
{
  public class RegGetCAProfileDataRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData responseData = null;
      string responseXML = string.Empty;

      try
      {
        RegGetCAProfileDataRequestData regGetCAProfileDataRequestData = (RegGetCAProfileDataRequestData)oRequestData;

        RegCaDataWebService.RegCaDataWebSvc regCaDataWebService = new RegCaDataWebService.RegCaDataWebSvc();

        WsConfigElement wsConfigElement = (WsConfigElement)oConfig;
        regCaDataWebService.Url = wsConfigElement.WSURL;
        regCaDataWebService.Timeout = (int)regGetCAProfileDataRequestData.RequestTimeout.TotalMilliseconds;

        string inputXml = oRequestData.ToXML();
        responseXML = regCaDataWebService.GetProfileDataFromShopperId(inputXml);
        responseData = new RegGetCAProfileDataResponseData(responseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new RegGetCAProfileDataResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new RegGetCAProfileDataResponseData(responseXML, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
