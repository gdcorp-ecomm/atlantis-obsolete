using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachDetailActivityMulti.Interface
{
  public class OutreachDetailActivityMultiResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private List<OutreachDetailActivityResponse> _wsOutreachDetailActivityResponse = new List<OutreachDetailActivityResponse>();
    
    
    private bool _success = false;

    public bool IsSuccess
    {
      get
      {
        return _success;
      }
    }

    public int AccountCount
    {
      get { return _wsOutreachDetailActivityResponse.Count; }
    }

    public IEnumerable<OutreachDetailActivityResponse> OutreachDetailActivityAccounts
    {
      get { return _wsOutreachDetailActivityResponse; }
    }

    public OutreachDetailActivityMultiResponseData(IEnumerable<OutreachDetailActivityResponse> wsOutreachDetailActivityResposne)
    {
      if (wsOutreachDetailActivityResposne != null)
        _wsOutreachDetailActivityResponse.AddRange(wsOutreachDetailActivityResposne);

      _success = true;
    }

    public OutreachDetailActivityMultiResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public OutreachDetailActivityMultiResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "OutreachDetailActivityMultiResponseData",
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
