using System;

namespace Atlantis.Framework.OutreachDetailActivityMulti.Interface
{
  public class OutreachDetailActivityAccount
  {
    public string OutreachAccountID { get; private set; }
    public DateTime BeginUtcTime { get; private set; }
    public DateTime EndUtcTime { get; private set; }

    public OutreachDetailActivityAccount(string outreachAccountID, DateTime beginUtcTime, DateTime endUtcTime)
    {
      OutreachAccountID = outreachAccountID;
      BeginUtcTime = beginUtcTime;
      EndUtcTime = endUtcTime;
    }
  }
}
