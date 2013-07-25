using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ChangePassword.Interface
{
  public class ChangePasswordRequestData : RequestData
  {
    private int _privateLabelId = 0;
    private string _currentPassword = null;
    private string _newPassword = null;
    private string _newHint = null;
    private string _newLogin = null;
    private bool _useStrongPassword = false;

    public int PrivateLabelId
    {
      get { return _privateLabelId; }
    }

    public string CurrentPassword
    {
      get { return _currentPassword; }
    }

    public string NewPassword
    {
      get { return _newPassword; }
    }

    public string NewHint
    {
      get { return _newHint; }
    }

    public string NewLogin
    {
      get { return _newLogin; }
    }

    public bool UseStrongPassword
    {
      get { return _useStrongPassword; }
    }

    public ChangePasswordRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      int privateLabelId, string currentPassword, string newPassword, string newHint, string newLogin, bool useStrongPassword)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _privateLabelId = privateLabelId;
      _currentPassword = currentPassword;
      _newPassword = newPassword;
      _newHint = newHint;
      _newLogin = newLogin;
      _useStrongPassword = useStrongPassword;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("Change Password is not a cacheable request.");
    }
  }
}
