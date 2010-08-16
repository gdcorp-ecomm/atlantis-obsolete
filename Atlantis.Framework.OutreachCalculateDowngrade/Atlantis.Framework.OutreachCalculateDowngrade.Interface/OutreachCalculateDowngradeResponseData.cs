using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachCalculateDowngrade.Interface
{
  public class OutreachCalculateDowngradeResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private bool _success = false;
    private List<RequiredMailingPackInfo> _wsRequiredMailingPackInfo = new List<RequiredMailingPackInfo>();

    public long NegativeBalance { get; private set; }
    public string OutreachAccountID { get; private set; }

    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public IEnumerable<RequiredMailingPackInfo> RequiredMailingPacks
    {
      get { return _wsRequiredMailingPackInfo; }
    }

    public OutreachCalculateDowngradeResponseData(string outreachAccountID,
                                                    long negativeBalance,
                                                    IEnumerable<RequiredMailingPackInfo> wsRequiredMailingPackInfo)
    {
      OutreachAccountID = outreachAccountID;
      NegativeBalance = negativeBalance;

      if (wsRequiredMailingPackInfo != null)
      {
        _wsRequiredMailingPackInfo.AddRange(wsRequiredMailingPackInfo);
      }

      _success = true;
    }

     public OutreachCalculateDowngradeResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public OutreachCalculateDowngradeResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "OutreachCalculateDowngradeResponseData",
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
