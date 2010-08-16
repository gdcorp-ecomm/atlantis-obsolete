using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OutreachResellerOptout.Interface
{
  public class OutreachResellerOptoutResponseData : IResponseData
  {
    private bool _isSuccess = false;
    private AtlantisException _ex;

    public OutreachResellerOptoutResponseData()
    {
      _isSuccess = true;
    }

    public OutreachResellerOptoutResponseData(AtlantisException exception)
    {
      _ex = exception;
    }

    public OutreachResellerOptoutResponseData(RequestData requestData, Exception ex)
    {
      _ex = new AtlantisException(requestData, "OutreachResellerOptoutResponseData", ex.Message, ex.StackTrace);
    }

    public bool IsSuccess
    {
      get { return _isSuccess; }
    }

    #region IResponseData Members

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion

  }
}
