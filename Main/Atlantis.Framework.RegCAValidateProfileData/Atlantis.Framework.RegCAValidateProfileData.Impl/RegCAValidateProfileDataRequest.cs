using System;
using System.Text;
using System.Xml;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RegCAValidateProfileData.Interface;

namespace Atlantis.Framework.RegCAValidateProfileData.Impl
{
  public class RegCAValidateProfileDataRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData responseData = null;
      string responseXML = string.Empty;

      try
      {
        RegCAValidateProfileDataRequestData regCAValidateProfileDataRequestData = (RegCAValidateProfileDataRequestData)oRequestData;

        RegCaDataWebService.RegCaDataWebSvc regCaDataWebService = new RegCaDataWebService.RegCaDataWebSvc();

        WsConfigElement wsConfigElement = (WsConfigElement)oConfig;
        regCaDataWebService.Url = wsConfigElement.WSURL;
        regCaDataWebService.Timeout = (int)regCAValidateProfileDataRequestData.RequestTimeout.TotalMilliseconds;

        string inputXml = oRequestData.ToXML();
        responseXML = regCaDataWebService.RegistrantCompare(inputXml);
        responseData = new RegCAValidateProfileDataResponseData(responseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new RegCAValidateProfileDataResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new RegCAValidateProfileDataResponseData(responseXML, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
