using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.OutreachActivity.Interface;
using Atlantis.Framework.OutreachActivity.Impl.OutreachWS;

namespace Atlantis.Framework.OutreachActivity.Impl
{
  public class OutreachActivityRequest : IRequest
  {
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      OutreachActivityResponseData responseData = null;

      try
      {

        OutreachActivityRequestData request = (OutreachActivityRequestData)requestData;
        OutreachWS.MyaService service = new MyaService();

        service.Url = ((WsConfigElement)config).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        AccountActivityInfo activity = service.GetAccountActivity(request.OrionAccountID,
                                                                  request.BeginUtcTime,
                                                                  request.EndUtcTime);


        responseData = new OutreachActivityResponseData(activity.BeginUtcTime,
                                                        activity.CurrentQuota,
                                                        activity.DaysLeft,
                                                        activity.EmailsScheduled,
                                                        activity.EmailsSent,
                                                        activity.RemainingEmails,
                                                        activity.TotalAllFutureScheduledCampaigns,
                                                        activity.TotalCampaignsSentInPast,
                                                        activity.EndUtcTime);
         
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new OutreachActivityResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new OutreachActivityResponseData(requestData, ex);
      }
       
      return responseData;
    }
  }
}
