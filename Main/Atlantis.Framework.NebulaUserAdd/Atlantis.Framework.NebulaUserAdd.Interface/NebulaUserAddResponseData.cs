using System;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.NebulaUserAdd.Interface
{
  public class NebulaUserAddResponseData : IResponseData
  {
    private AtlantisException _ex;
    private bool _isSuccess = false;
    private string _accessKey = string.Empty;
    private string _secretKey = string.Empty;

    public NebulaUserAddResponseData(string accessKey, string secretKey, int responseCode)
    {
      if (responseCode == 200)
      {
        _isSuccess = true;
        _accessKey = accessKey;
        _secretKey = secretKey;
      }

    }

    public bool IsSuccess
    {
      get { return _isSuccess; }
    }

    public string AccessKey
    {
      get { return _accessKey; }
    }

    public string SecretKey
    {
      get { return _secretKey; }
    }

    public NebulaUserAddResponseData(AtlantisException ex)
    {
      _isSuccess = false;
      _ex = ex;
    }

    public NebulaUserAddResponseData(RequestData oRequestData, Exception ex)
    {
      _isSuccess = false;
      _ex = new AtlantisException(oRequestData, "NebulaUserAddResponseData", ex.Message, oRequestData.ToXML());
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
