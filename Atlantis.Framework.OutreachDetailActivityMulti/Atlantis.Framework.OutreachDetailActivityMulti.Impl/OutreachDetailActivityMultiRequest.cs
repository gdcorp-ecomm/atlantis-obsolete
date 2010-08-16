using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OutreachDetailActivityMulti.Interface;
using Atlantis.Framework.OutreachDetailActivityMulti.Impl.OutreachWS;

namespace Atlantis.Framework.OutreachDetailActivityMulti.Impl
{
  public class OutreachDetailActivityMultiRequest : IRequest
  {
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      OutreachDetailActivityMultiResponseData responseData = null;

      try
      {
        OutreachDetailActivityMultiRequestData request = (OutreachDetailActivityMultiRequestData)requestData;
        OutreachWS.MyaService service = new MyaService();

        service.Url = ((WsConfigElement)config).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        AccountInfoQuery[] requestAccounts = null;

        if (request.Accounts != null)
        {
          requestAccounts = Array.ConvertAll<OutreachDetailActivityAccount, AccountInfoQuery>(
            request.Accounts, new Converter<OutreachDetailActivityAccount, AccountInfoQuery>(ConvertAccountForRequest));


          DetailedAccountActivityInfo[] response = service.GetDetailedAccountActivityForMultipleAccounts(requestAccounts);

          OutreachDetailActivityResponse[] responseAccounts = null;

          if (response != null)
          {
            responseAccounts = Array.ConvertAll<DetailedAccountActivityInfo, OutreachDetailActivityResponse>(
              response, new Converter<DetailedAccountActivityInfo, OutreachDetailActivityResponse>(ConvertAccountForResponse));
          }

          responseData = new OutreachDetailActivityMultiResponseData(responseAccounts);

        }


      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new OutreachDetailActivityMultiResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new OutreachDetailActivityMultiResponseData(requestData, ex);
      }
       
      return responseData;
    }

   private static AccountInfoQuery ConvertAccountForRequest(OutreachDetailActivityAccount account)
   {
     AccountInfoQuery result = null;
     if (account != null)
     {
       result = new AccountInfoQuery();
       result.OrionAccountID = account.OutreachAccountID;
       result.BeginUtcTime = account.BeginUtcTime;
       result.EndUtcTime = account.EndUtcTime;
     }

     return result;
   }

   private static OutreachDetailActivityResponse ConvertAccountForResponse(DetailedAccountActivityInfo account)
   {
     OutreachDetailActivityResponse result = null;
     if (account != null)
     {
        result = new OutreachDetailActivityResponse(account.OrionAccountID,
                                                    account.AccountEmailCreditInfo.CreditsAvailable,
                                                    account.AccountEmailCreditInfo.CreditsReserved,
                                                    account.AccountEmailCreditInfo.CreditsUsed,
                                                    account.AccountEmailCreditInfo.CurrentBillingCycleBeginUtcDate,
                                                    account.AccountEmailCreditInfo.CurrentBillingCycleEndUtcDate,
                                                    account.AccountEmailCreditInfo.MailingPackCreditsAvailable,
                                                    account.AccountEmailCreditInfo.MailingPackCreditsReserved,
                                                    account.AccountEmailCreditInfo.MailingPackCreditsTotal,
                                                    account.AccountEmailCreditInfo.MailingPackCreditsTotalReserved,
                                                    account.AccountEmailCreditInfo.MailingPackCreditsTotalUsed,
                                                    account.AccountEmailCreditInfo.MailingPackCreditsUsed,
                                                    account.AccountEmailCreditInfo.MonthlyAllowanceCredits,
                                                    account.AccountEmailCreditInfo.MonthlyAllowanceCreditsAvailable,
                                                    account.AccountEmailCreditInfo.MonthlyAllowanceCreditsReserved,
                                                    account.AccountEmailCreditInfo.MonthlyAllowanceCreditsUsed);
      
     }

     return result;
   }
  }
}
