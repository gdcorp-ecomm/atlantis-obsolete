using System;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.VideoMeGetAuthToken.Interface;
using Atlantis.Framework.VideoMeGetAuthToken.Impl.GetAuthToken;

namespace Atlantis.Framework.VideoMeGetAuthToken.Impl
{
  public class VideoMeGetAuthTokenRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;

      string _token = string.Empty;
      VideoMeExternalService service = null;
      try
      {
        VideoMeGetAuthTokenRequestData request = (VideoMeGetAuthTokenRequestData)oRequestData;
        service = new VideoMeExternalService();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;
        _token = service.GetOneTimeAuthToken(request.ApplicationId, request.ApplicationIdSpecified, request.UniqueFileId,
          request.AccessKeyId, request.SecretKey);

        result = new VideoMeGetAuthTokenResponseData(_token);
      }
      catch (AtlantisException exAtlantis)
      {
        result = new VideoMeGetAuthTokenResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        result = new VideoMeGetAuthTokenResponseData(oRequestData, ex);
      }


      return result;
    }

    #endregion
  }
}
