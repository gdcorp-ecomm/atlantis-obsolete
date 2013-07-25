using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BonzaiRemoveAddOn.Interface
{
  public class BonzaiRemoveAddOnRequestData : RequestData
  {
    #region Properties

    private string _accountUid;
    private string _addOnType;
    private string _attributeUid;
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public string AccountUid
    {
      get { return _accountUid; }
    }

    public string AddOnType
    {
      get { return _addOnType; }
    }

    public string AttributeUid
    {
      get { return _attributeUid; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    #endregion

    public BonzaiRemoveAddOnRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  string accountUid,
                                  string attributeUid,
                                  string addOnType)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _accountUid = accountUid;
      _addOnType = addOnType;
      _attributeUid = attributeUid;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in BonzaiRemoveAddOnRequestData");     
    }
  }
}
