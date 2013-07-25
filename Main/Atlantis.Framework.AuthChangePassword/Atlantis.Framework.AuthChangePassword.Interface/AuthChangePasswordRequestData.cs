using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuthChangePassword.Interface
{
  public class AuthChangePasswordRequestData : RequestData
  {
    public int PrivateLabelId { get; private set; }
    public string CurrentPassword { get; private set; }
    public string NewPassword { get; private set; }
    public string NewHint { get; private set; }
    public string NewLogin { get; private set; }
    public bool UseStrongPassword { get; private set; }

    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public AuthChangePasswordRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      int privateLabelId, string currentPassword, string newPassword, string newHint, string newLogin, bool useStrongPassword)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      PrivateLabelId = privateLabelId;
      CurrentPassword = currentPassword;
      NewPassword = newPassword;
      NewHint = newHint;
      NewLogin = newLogin;
      UseStrongPassword = useStrongPassword;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("Change Password is not a cacheable request.");
    }
  }
}
