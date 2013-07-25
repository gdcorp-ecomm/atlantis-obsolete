using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.VideoMeGetAuthToken.Interface
{
  public class VideoMeGetAuthTokenResponseData : IResponseData
  {
    private string _token = string.Empty;
    private bool _isValid = false;
    private AtlantisException _ex;

    public VideoMeGetAuthTokenResponseData(string token)
    {
      if (!string.IsNullOrEmpty(token))
      {
        _token = token;
        _isValid = true;
      }
    }

    public string Token
    {
      get { return _token; }
    }

    public bool IsValid
    {
      get { return _isValid; }
    }

    public VideoMeGetAuthTokenResponseData(AtlantisException ex)
    {
      _isValid = false;
      _ex = ex;
    }

    public VideoMeGetAuthTokenResponseData(RequestData oRequestData, Exception ex)
    {
      _isValid = false;
      _ex = new AtlantisException(oRequestData, "VideoMeGetAuthTokenResponseData", ex.Message, oRequestData.ToXML());
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
