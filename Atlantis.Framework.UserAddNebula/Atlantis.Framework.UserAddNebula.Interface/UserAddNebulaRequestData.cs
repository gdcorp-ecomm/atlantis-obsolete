using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.UserAddNebula.Interface
{
  public class UserAddNebulaRequestData : RequestData
  {
    private string _managerAccessKey = string.Empty;
    private string _secretKey = string.Empty;
    private string _userUniqueId = string.Empty;
    private int _quota = 0;
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    public UserAddNebulaRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
    }

    public string ManagerAccessKey
    {
      get { return _managerAccessKey; }
      set { _managerAccessKey = value; }
    }

    public string SecretKey
    {
      get { return _secretKey; }
      set { _secretKey = value; }
    }

    public string UserUniqueId
    {
      get { return _userUniqueId; }
      set { _userUniqueId = value; }
    }

    public int Quota
    {
      get { return _quota; }
      set { _quota = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }


    public override string GetCacheMD5()
    {
      throw new NotImplementedException("UserAddNebula is not a cacheable request.");
    }

    public override string ToXML()
    {
      return string.Empty;
    }

  }
}
