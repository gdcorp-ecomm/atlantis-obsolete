using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BillingOrionUpgradeInfo.Interface
{
  public class BillingOrionUpgradeInfoResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;
    private List<UpgradeInfo> _upgradeInfos;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public List<UpgradeInfo> UpgradeInfos
    {
      get { return _upgradeInfos; }
    }

    public BillingOrionUpgradeInfoResponseData(List<UpgradeInfo> upgradeInfos)
    {
      _upgradeInfos = upgradeInfos;
      _success = true;
    }

     public BillingOrionUpgradeInfoResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public BillingOrionUpgradeInfoResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "BillingOrionUpgradeInfoResponseData",
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
