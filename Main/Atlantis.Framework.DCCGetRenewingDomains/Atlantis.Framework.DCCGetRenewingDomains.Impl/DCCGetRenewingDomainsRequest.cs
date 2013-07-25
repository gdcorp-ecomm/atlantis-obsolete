using System;
using Atlantis.Framework.DCCGetRenewingDomains.Impl.DsWeb;
using Atlantis.Framework.DCCGetRenewingDomains.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCGetRenewingDomains.Impl
{
  public class DCCGetRenewingDomainsRequest : IRequest
  {
    private const int INITIAL_DOMAIN_GET_COUNT = 50;
    private const int ADDITIONAL_DOMAIN_GET_COUNT = 500;

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCGetRenewingDomainsResponseData responseData = null;

      DCCGetRenewingDomainsRequestData getRenewingDomainsRequestData = oRequestData as DCCGetRenewingDomainsRequestData;

      switch (getRenewingDomainsRequestData.Type)
      {
        case DCCGetRenewingDomainsRequestData.RequestType.TimeSpan:
          responseData = GetRenewingDomainsByTimeSpan(getRenewingDomainsRequestData, oConfig);
          break;
        case DCCGetRenewingDomainsRequestData.RequestType.Count:
          responseData = GetRenewingDomainsByCount(getRenewingDomainsRequestData, oConfig);
          break;
        case DCCGetRenewingDomainsRequestData.RequestType.DomainName:
          responseData = GetRenewingDomainsByDomainName(getRenewingDomainsRequestData, oConfig);
          break;
      }

      return responseData;
    }

    private static DCCGetRenewingDomainsResponseData GetRenewingDomainsByTimeSpan(DCCGetRenewingDomainsRequestData requestData, ConfigElement oConfig)
    {
      DCCGetRenewingDomainsResponseData responseData = GetDCCDomainsList(requestData, oConfig, INITIAL_DOMAIN_GET_COUNT);
      
      if (responseData.ResultCount > INITIAL_DOMAIN_GET_COUNT)
      {
        int totalDomainCount = responseData.ResultCount;
        DateTime? boundryDomainExpiration = responseData.LastExpirationDate;

        if (requestData != null)
        {
          requestData.BoundryExpirationDate = boundryDomainExpiration;

          for (int i = INITIAL_DOMAIN_GET_COUNT; i < totalDomainCount; i += ADDITIONAL_DOMAIN_GET_COUNT)
          {
            DCCGetRenewingDomainsResponseData additionalResponseData = GetDCCDomainsList(requestData, oConfig, ADDITIONAL_DOMAIN_GET_COUNT);
            if (additionalResponseData.Domains != null && additionalResponseData.Domains.Count > 0)
            {
              responseData.AddDomainsToList(additionalResponseData.ToXML());
              requestData.BoundryExpirationDate = additionalResponseData.LastExpirationDate;
            }
            else
            {
              // There are no more expiring domains
              break;
            }
          }
        }

      }

      return responseData;
    }

    private static DCCGetRenewingDomainsResponseData GetRenewingDomainsByCount(DCCGetRenewingDomainsRequestData requestData, ConfigElement oConfig)
    {
      return GetDCCDomainsList(requestData, oConfig, requestData.DomainCount);
    }

    private static DCCGetRenewingDomainsResponseData GetRenewingDomainsByDomainName(DCCGetRenewingDomainsRequestData requestData, ConfigElement oConfig)
    {
      return GetDCCDomainsList(requestData, oConfig, ADDITIONAL_DOMAIN_GET_COUNT);
    }

    private static DCCGetRenewingDomainsResponseData GetDCCDomainsList(RequestData oRequestData, ConfigElement oConfig, uint count)
    {
      string responseXml = string.Empty;
      DCCGetRenewingDomainsResponseData responseData = null;
      RegCheckDomainStatusWebSvcService oDsWeb = null;

      try
      {
        DCCGetRenewingDomainsRequestData oRequest = (DCCGetRenewingDomainsRequestData)oRequestData;
        oRequest.DomainCount = count;

        oDsWeb = new RegCheckDomainStatusWebSvcService();
        oDsWeb.Url = ((WsConfigElement)oConfig).WSURL;
        oDsWeb.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;
        responseXml = oDsWeb.GetDCCDomainList(oRequest.ToXML());

        switch (oRequest.Type)
        {
          case DCCGetRenewingDomainsRequestData.RequestType.TimeSpan:
            responseData = new DCCGetRenewingDomainsResponseData(responseXml, oRequest.TimeSpanFromExpiration);
            break;
          case DCCGetRenewingDomainsRequestData.RequestType.Count:
          case DCCGetRenewingDomainsRequestData.RequestType.DomainName:
            responseData = new DCCGetRenewingDomainsResponseData(responseXml);
            break;
        }
        
      }
      catch (Exception ex)
      {
        responseData = new DCCGetRenewingDomainsResponseData(responseXml, oRequestData, ex);
      }
      finally
      {
        if(oDsWeb != null)
        {
          oDsWeb.Dispose();
        }
      }

      return responseData;
    }
  }
}
