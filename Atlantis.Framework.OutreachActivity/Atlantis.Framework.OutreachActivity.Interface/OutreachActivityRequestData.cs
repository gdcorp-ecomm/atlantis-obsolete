using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachActivity.Interface
{
  public class OutreachActivityRequestData : RequestData
  {

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public string OrionAccountID { get; private set; }
    public DateTime BeginUtcTime { get; private set; }
    public DateTime EndUtcTime { get; private set; }
    

    public OutreachActivityRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  string orionAccountID,
                                  DateTime beginUtcTime,
                                  DateTime endUtcTime)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      OrionAccountID = orionAccountID;
      BeginUtcTime = beginUtcTime;
      EndUtcTime = endUtcTime;      
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in OutreachActivityRequestData");     
      
    }


  }
}
