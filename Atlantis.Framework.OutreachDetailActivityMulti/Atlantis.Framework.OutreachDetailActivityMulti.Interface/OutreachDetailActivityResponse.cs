using System;

namespace Atlantis.Framework.OutreachDetailActivityMulti.Interface
{
  public class OutreachDetailActivityResponse
  {
    public string OutreachAccountID { get; private set; }
    public DateTime BeginUtcTime { get; private set; }
    public DateTime EndUtcTime { get; private set; }
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


    public OutreachDetailActivityResponse(string outreachAccountID, 
                                              long creditsAvailable,
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
      OutreachAccountID = outreachAccountID;
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
    }

  }
}
