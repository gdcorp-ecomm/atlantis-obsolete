using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OutreachDetailActivity.Interface;
using Atlantis.Framework.OutreachDetailActivity.Impl.OutreachWS;

namespace Atlantis.Framework.OutreachDetailActivity.Impl
{
  public class OutreachDetailActivityRequest : IRequest
  {
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      OutreachDetailActivityResponseData responseData = null;

      try
      {
        OutreachDetailActivityRequestData request = (OutreachDetailActivityRequestData)requestData;
        OutreachWS.MyaService service = new MyaService();

        service.Url = ((WsConfigElement)config).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        DetailedAccountActivityInfo details = service.GetDetailedAccountActivity(request.OrionAccountID,
                                                                                  request.BeginUtcTime,
                                                                                  request.EndUtcTime);

        responseData = new OutreachDetailActivityResponseData(details.AccountEmailCreditInfo.CreditsAvailable,
                                                              details.AccountEmailCreditInfo.CreditsReserved,
                                                              details.AccountEmailCreditInfo.CreditsUsed,
                                                              details.AccountEmailCreditInfo.CurrentBillingCycleBeginUtcDate,
                                                              details.AccountEmailCreditInfo.CurrentBillingCycleEndUtcDate,
                                                              details.AccountEmailCreditInfo.MailingPackCreditsAvailable,
                                                              details.AccountEmailCreditInfo.MailingPackCreditsReserved,
                                                              details.AccountEmailCreditInfo.MailingPackCreditsTotal,
                                                              details.AccountEmailCreditInfo.MailingPackCreditsTotalReserved,
                                                              details.AccountEmailCreditInfo.MailingPackCreditsTotalUsed,
                                                              details.AccountEmailCreditInfo.MailingPackCreditsUsed,
                                                              details.AccountEmailCreditInfo.MonthlyAllowanceCredits,
                                                              details.AccountEmailCreditInfo.MonthlyAllowanceCreditsAvailable,
                                                              details.AccountEmailCreditInfo.MonthlyAllowanceCreditsReserved,
                                                              details.AccountEmailCreditInfo.MonthlyAllowanceCreditsUsed);
       
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new OutreachDetailActivityResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new OutreachDetailActivityResponseData(requestData, ex);
      }
       
      return responseData;
    }
  }
}
