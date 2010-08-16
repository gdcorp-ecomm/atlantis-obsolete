using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachDetailActivityMulti.Interface
{
  public class OutreachDetailActivityMultiRequestData : RequestData
  {

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    private List<OutreachDetailActivityAccount> _accounts = null;
    public OutreachDetailActivityAccount[] Accounts
    {
      get
      { return _accounts.ToArray(); }
    }

    public void AddOutreachAccount(OutreachDetailActivityAccount outreachAccount)
    {      
      _accounts.Add(outreachAccount);
    }

    public OutreachDetailActivityMultiRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _accounts = new List<OutreachDetailActivityAccount>();
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in OutreachDetailActivityMultiRequestData");     
    }


  }
}
