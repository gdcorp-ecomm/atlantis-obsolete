using System;
using System.Text;
using System.Xml;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RegCheckCaContacts.Interface;

namespace Atlantis.Framework.RegCheckCaContacts.Impl
{
  public class RegCheckCaContactsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData responseData = null;
      string responseXML = string.Empty;

      try
      {
        RegCheckCaContactsRequestData regCheckCaContactsRequestData
          = (RegCheckCaContactsRequestData)oRequestData;
        RegCaDataWebSvc.RegCaDataWebSvc regCaDataWebService = new RegCaDataWebSvc.RegCaDataWebSvc();
        WsConfigElement wsConfigElement = (WsConfigElement)oConfig;
        regCaDataWebService.Url = wsConfigElement.WSURL;
        regCaDataWebService.Timeout = (int)regCheckCaContactsRequestData.RequestTimeout.TotalMilliseconds;
        string inputXml = oRequestData.ToXML();
        responseXML = regCaDataWebService.ValidateDomainAndContactsCA(inputXml);
        responseData = new RegCheckCaContactsResponseData(responseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new RegCheckCaContactsResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new RegCheckCaContactsResponseData(responseXML, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
