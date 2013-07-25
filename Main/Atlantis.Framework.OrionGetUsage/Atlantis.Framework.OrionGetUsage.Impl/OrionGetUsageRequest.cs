using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OrionGetUsage.Interface;
using Atlantis.Framework.OrionSecurityAuth.Interface;
using Atlantis.Framework.OrionGetUsage.Impl.OrionQuotaService;

namespace Atlantis.Framework.OrionGetUsage.Impl
{
  public class OrionGetUsageRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData usageRequestData, ConfigElement config)
    {
      int resultCode = 1;
      string error = string.Empty;
      string authToken = string.Empty;
      UsageReport usageReport = null;
      OrionGetUsageResponseData responseUsageData = null;

      try
      {
        OrionSecurityAuthResponseData responseSecurityData = GetOrionAuthToken(usageRequestData);

        OrionGetUsageRequestData orionRequestData = (OrionGetUsageRequestData)usageRequestData;

        if (responseSecurityData.IsSuccess && !string.IsNullOrEmpty(responseSecurityData.AuthToken))
        {
          Atlantis.Framework.OrionGetUsage.Impl.OrionQuotaService.Quotas quotaService =
            new Atlantis.Framework.OrionGetUsage.Impl.OrionQuotaService.Quotas();
          quotaService.Url = ((WsConfigElement)config).WSURL;
          quotaService.SecureHeaderValue = new Atlantis.Framework.OrionGetUsage.Impl.OrionQuotaService.SecureHeader();
          quotaService.SecureHeaderValue.Token = responseSecurityData.AuthToken;
          quotaService.Timeout = (int)orionRequestData.Timeout.TotalMilliseconds;

          resultCode = quotaService.GetUsage(new Guid(orionRequestData.OrionResourceId)
            , orionRequestData.UsageType
            , orionRequestData.StartDate
            , orionRequestData.EndDate
            , out usageReport
            , out error);
        }


        if (usageReport != null && resultCode != 1 && string.IsNullOrEmpty(error))
        {
          responseUsageData = new OrionGetUsageResponseData(usageReport.AccountUID.ToString()
          , usageReport.Amount
          , usageReport.BaseQuotaElementUID.ToString()
          , usageReport.CurrentBaseQuotaAllowed
          , usageReport.CurrentExtendedQuotaAllowed
          , usageReport.DateCreated
          , usageReport.FirstReportedUsage
          , usageReport.LastReportedUsage
          , usageReport.MeasurementUnit
          , usageReport.OverageProtection
          , usageReport.TotalUsage
          , usageReport.UsageType
          , resultCode
          , error);
        }
        else
        {
          string usageError = string.Format("RESULT CODE: {0} - ERROR: {1}", resultCode, error);
          throw new AtlantisException(usageRequestData, "OrionGetUsageRequest::RequestHandler", usageError, usageError);
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseUsageData = new OrionGetUsageResponseData(exAtlantis);

      }
      catch (Exception ex)
      {
        responseUsageData = new OrionGetUsageResponseData(usageRequestData, ex);
      }

      return responseUsageData;
    }

    #region OrionSecurity
    private OrionSecurityAuthResponseData GetOrionAuthToken(RequestData accountRequestData)
    {
      OrionSecurityAuthRequestData securityRequestData = null;

      securityRequestData = new OrionSecurityAuthRequestData(accountRequestData.ShopperID,
        accountRequestData.SourceURL,
        accountRequestData.OrderID,
        accountRequestData.Pathway,
        accountRequestData.PageCount,
        "OrionGetAccountsByUID");

      OrionSecurityAuthResponseData responseSecurityData = 
        (OrionSecurityAuthResponseData)DataCache.DataCache.GetProcessRequest(
          securityRequestData, securityRequestData.OrionSecurityAuthRequestType);

      return responseSecurityData;
    }
    #endregion

  }
}
