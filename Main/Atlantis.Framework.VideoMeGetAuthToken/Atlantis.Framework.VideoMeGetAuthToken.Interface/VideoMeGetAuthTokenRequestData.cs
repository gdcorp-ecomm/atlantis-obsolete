using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.VideoMeGetAuthToken.Interface
{
  public class VideoMeGetAuthTokenRequestData : RequestData
  {
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);
    private int _appId = 0;
    private bool _appIdSpecified = false;
    private string _fileUId = string.Empty;
    private string _accessKeyId = string.Empty;
    private string _secretKey = string.Empty;

    public VideoMeGetAuthTokenRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
    }

    public Int32 ApplicationId
    {
      get { return _appId; }
      set { _appId = value; }
    }

    public bool ApplicationIdSpecified
    {
      get { return _appIdSpecified; }
      set { _appIdSpecified = value; }
    }

    public string UniqueFileId
    {
      get { return _fileUId; }
      set { _fileUId = value; }
    }

    public string AccessKeyId
    {
      get { return _accessKeyId; }
      set { _accessKeyId = value; }
    }

    public string SecretKey
    {
      get { return _secretKey; }
      set { _secretKey = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("VideoMeGetAuthToken is not a cacheable request.");
    }

    public override string ToXML()
    {
      return string.Empty;
    }


  }

}
