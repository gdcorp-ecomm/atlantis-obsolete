using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetCreditGroupSummary.Interface
{
  public class GetCreditGroupSummaryRequestData : RequestData
  {
    private TimeSpan _wsRequestTimeout;

    private GetCreditGroupSummaryRequestData()
      : base("", "", "", "", 0)
    { }

    public GetCreditGroupSummaryRequestData(string shopperID, string sourceURL, string orderID, 
                                            string pathway, int pageCount, int displayGroupID)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      DisplayGroupID = displayGroupID;
      _wsRequestTimeout = new TimeSpan(0, 0, 2); 
    }

    public TimeSpan RequestTimeout
    {
      get { return _wsRequestTimeout; }
      set { _wsRequestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      return string.Empty;
    }

    public int DisplayGroupID { get; set; }
  }
}
