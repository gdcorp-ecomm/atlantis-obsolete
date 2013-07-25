using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BonzaiApplyAddOn.Interface
{
  public class BonzaiApplyAddOnRequestData : RequestData
  {
    #region Properties

    private string _accountUid;
    private string _addOnType;
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public string AccountUid
    {
      get { return _accountUid; }
    }

    public string AddOnType
    {
      get { return _addOnType; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    #endregion

    public BonzaiApplyAddOnRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  string accountUid,
                                  string addOnType)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _accountUid = accountUid;
      _addOnType = addOnType;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in BonzaiApplyAddOnRequestData");     
    }


  }
}
