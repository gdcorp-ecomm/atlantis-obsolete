using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCGetDomainContacts.Interface;

namespace Atlantis.Framework.DCCGetDomainContacts.Impl
{
  public class DCCGetDomainContactsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCGetDomainContactsResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        DsWeb.RegCheckDomainStatusWebSvcService oDsWeb = new DsWeb.RegCheckDomainStatusWebSvcService();
        DCCGetDomainContactsRequestData oRequest = (DCCGetDomainContactsRequestData)oRequestData;
        oDsWeb.Url = ((WsConfigElement)oConfig).WSURL;
        oDsWeb.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
        responseXml = oDsWeb.GetDomainInfoByNameWithContacts(oRequest.ToXML());
        responseData = new DCCGetDomainContactsResponseData(responseXml);
        
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCGetDomainContactsResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCGetDomainContactsResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    #endregion


  }
}
