using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OutreachCalculateDowngrade.Interface;
using Atlantis.Framework.OutreachCalculateDowngrade.Impl.OutreachWS;

namespace Atlantis.Framework.OutreachCalculateDowngrade.Impl
{
  public class OutreachCalculateDowngradeRequest : IRequest
  {
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      OutreachCalculateDowngradeResponseData responseData = null;

      try
      {
        OutreachCalculateDowngradeRequestData request = (OutreachCalculateDowngradeRequestData)requestData;

        OutreachWS.MyaService service = new MyaService();

        service.Url = ((WsConfigElement)config).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        DowngradeEligibilityInfo response = service.CalculateRequiredMailingPacksForDowngrade(request.OutreachAccountID,
                                                                                                         request.BeginUtcTime,
                                                                                                         request.EndUtcTime,
                                                                                                         request.TargetPlanMonthlyEmails);
        
        Atlantis.Framework.OutreachCalculateDowngrade.Interface.RequiredMailingPackInfo[] mailingPacks = null;

        if (response.RequiredMailingPacks != null)
        {
          mailingPacks = Array.ConvertAll<OutreachWS.RequiredMailingPackInfo, Atlantis.Framework.OutreachCalculateDowngrade.Interface.RequiredMailingPackInfo>(
            response.RequiredMailingPacks, new Converter<Atlantis.Framework.OutreachCalculateDowngrade.Impl.OutreachWS.RequiredMailingPackInfo, Atlantis.Framework.OutreachCalculateDowngrade.Interface.RequiredMailingPackInfo>(ConvertMailingPackInfo));
        }

        responseData = new OutreachCalculateDowngradeResponseData(response.OrionAccountID, response.NegativeBalance, mailingPacks);
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new OutreachCalculateDowngradeResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new OutreachCalculateDowngradeResponseData(requestData, ex);
      }
       
      return responseData;
    }

   private static Atlantis.Framework.OutreachCalculateDowngrade.Interface.RequiredMailingPackInfo ConvertMailingPackInfo(OutreachWS.RequiredMailingPackInfo mailingPack)
   {
     Atlantis.Framework.OutreachCalculateDowngrade.Interface.RequiredMailingPackInfo result = null;

     if (mailingPack != null)
     {
       result = new Atlantis.Framework.OutreachCalculateDowngrade.Interface.RequiredMailingPackInfo(mailingPack.MailingPackSize,
                                                                                                    mailingPack.pf_id,
                                                                                                    mailingPack.Quantity);
     }

     return result;
   }
  }
}
