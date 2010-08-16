using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachCalculateDowngrade.Interface
{
  public class OutreachCalculateDowngradeRequestData : RequestData
  {

    public string OutreachAccountID { get; private set; }
    public DateTime BeginUtcTime { get; private set; }
    public DateTime EndUtcTime { get; private set; }
    public long TargetPlanMonthlyEmails { get; private set; }

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public OutreachCalculateDowngradeRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  string outreachAccountID,
                                  DateTime beginUtcTime,
                                  DateTime endUtcTime,
                                  long targetPlanMonthlyEmails)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      OutreachAccountID = outreachAccountID;
      BeginUtcTime = beginUtcTime;
      EndUtcTime = endUtcTime;
      TargetPlanMonthlyEmails = targetPlanMonthlyEmails;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in OutreachCalculateDowngradeRequestData");     
    }


  }
}
