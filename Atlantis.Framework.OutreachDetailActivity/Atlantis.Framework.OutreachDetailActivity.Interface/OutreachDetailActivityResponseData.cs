using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachDetailActivity.Interface
{
  public class OutreachDetailActivityResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;

    public long CreditsAvailable { get; private set; }
    public long CreditsReserved { get; private set; }
    public long CreditsUsed { get; private set; }
    public DateTime CurrentBillingCycleBeginUtcDate { get; private set; }
    public DateTime CurrentBillingCycleEndUtcDate { get; private set; }
    public long MailingPackCreditsAvailable { get; private set; }
    public long MailingPackCreditsReserved { get; private set; }
    public long MailingPackCreditsTotal { get; private set; }
    public long MailingPackCreditsTotalReserved { get; private set; }
    public long MailingPackCreditsTotalUsed { get; private set; }
    public long MailingPackCreditsUsed { get; private set; }
    public long MonthlyAllowanceCredits { get; private set; }
    public long MonthlyAllowanceCreditsAvailable { get; private set; }
    public long MonthlyAllowanceCreditsReserved { get; private set; }
    public long MonthlyAllowanceCreditsUsed { get; private set; }
    


    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public OutreachDetailActivityResponseData(long creditsAvailable,
                                              long creditsReserved,
                                              long creditsUsed,
                                              DateTime currentBillingCycleBeginUtcDate,
                                              DateTime currentBillingCycleEndUtcDate,
                                              long mailingPackCreditsAvailable,
                                              long mailingPackCreditsReserved,
                                              long mailingPackCreditsTotal,
                                              long mailingPackCreditsTotalReserved,
                                              long mailingPackCreditsTotalUsed,
                                              long mailingPackCreditsUsed,
                                              long monthlyAllowanceCredits,
                                              long monthlyAllowanceCreditsAvailable,
                                              long monthlyAllowanceCreditsReserved,
                                              long monthlyAllowanceCreditsUsed)
    {
      CreditsAvailable = creditsAvailable;
      CreditsReserved = creditsReserved;
      CreditsUsed = creditsUsed;
      CurrentBillingCycleBeginUtcDate = currentBillingCycleBeginUtcDate;
      CurrentBillingCycleEndUtcDate = currentBillingCycleEndUtcDate;
      MailingPackCreditsAvailable = mailingPackCreditsAvailable;
      MailingPackCreditsReserved = mailingPackCreditsReserved;
      MailingPackCreditsTotal = mailingPackCreditsTotal;
      MailingPackCreditsTotalUsed = mailingPackCreditsTotalUsed;
      MailingPackCreditsUsed = mailingPackCreditsUsed;
      MonthlyAllowanceCredits = monthlyAllowanceCredits;
      MonthlyAllowanceCreditsAvailable = monthlyAllowanceCreditsAvailable;
      MonthlyAllowanceCreditsReserved = monthlyAllowanceCreditsReserved;
      MonthlyAllowanceCreditsUsed = monthlyAllowanceCreditsUsed;

      _success = true;
    }

     public OutreachDetailActivityResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public OutreachDetailActivityResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "OutreachDetailActivityResponseData",
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
