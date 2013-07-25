using System;
using System.Text;
using System.Xml;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RegRegistryPartnersData.Interface;

namespace Atlantis.Framework.RegRegistryPartnersData.Impl
{
  public class RegRegistryPartnersDataRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData responseData = null;
      string responseXML = string.Empty;

      try
      {
        RegRegistryPartnersDataRequestData regRegistryPartnersDataRequestData = (RegRegistryPartnersDataRequestData)oRequestData;

        RegistryPartnersData.RegistryPartnersData registryPartnersDataWebService = new RegistryPartnersData.RegistryPartnersData();

        WsConfigElement wsConfigElement = (WsConfigElement)oConfig;
        registryPartnersDataWebService.Url = wsConfigElement.WSURL;
        registryPartnersDataWebService.Timeout = (int)regRegistryPartnersDataRequestData.RequestTimeout.TotalMilliseconds;

        string inputXml = oRequestData.ToXML();
        responseXML = registryPartnersDataWebService.GetCurrentTldSnapshotList(inputXml);
        responseData = new RegRegistryPartnersDataResponseData(responseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new RegRegistryPartnersDataResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new RegRegistryPartnersDataResponseData(responseXML, oRequestData, ex);
      }

      return responseData;
    }

    #endregion
  }
}
