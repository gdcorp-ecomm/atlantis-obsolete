using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachActivity.Interface
{
  public class OutreachActivityResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;

    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public DateTime BeginUtcTime { get; private set; }
    public int CurrentQuota{ get; private set; }

    public int DaysLeft { get; private set; }
    public int EmailsScheduled { get; private set; }
    public int EmailsSent { get; private set; }
    public int RemainingEmails { get; private set; }
    public int TotalAllFutureScheduledCampaigns { get; private set; }
    public int TotalCampaignsSentInPast { get; private set; }
    public DateTime EndUtcTime { get; private set; }  


    public OutreachActivityResponseData(DateTime beginUtcTime,
                                        int currentQuota,
                                        int daysLeft,
                                        int emailsScheduled,
                                        int emailsSent,
                                        int remainingEmails,
                                        int totalAllFutureScheduledCampaigns,
                                        int totalCampaignsSentInPast,
                                        DateTime endUtcTime)
    {
      BeginUtcTime = beginUtcTime;
      CurrentQuota = currentQuota;
      DaysLeft = daysLeft;
      EmailsScheduled = emailsScheduled;
      EmailsSent = emailsSent;
      RemainingEmails = remainingEmails;
      TotalAllFutureScheduledCampaigns = totalAllFutureScheduledCampaigns;
      TotalCampaignsSentInPast = totalCampaignsSentInPast;
      EndUtcTime = endUtcTime;

      _success = true;

    }

     public OutreachActivityResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public OutreachActivityResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "OutreachActivityResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      return _resultXML;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
