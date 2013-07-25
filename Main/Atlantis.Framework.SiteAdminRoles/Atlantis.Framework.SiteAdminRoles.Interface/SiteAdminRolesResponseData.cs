using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace Atlantis.Framework.SiteAdminRoles.Interface
{
  public class SiteAdminRolesResponseData : IResponseData
  {
    private int _roleId;
    private HashSet<string> _allowedUsersAndGroups;
    private bool _isSuccess = false;
    private AtlantisException _exception = null;

    // We actually cache the windows groups for the life of the response object so we don't have to
    // incur expensive active directory queries on every request.
    private Dictionary<string, GroupPrincipal> _groups;

    public SiteAdminRolesResponseData(int roleId, IEnumerable<string> allowedUsersAndGroups)
    {
      _roleId = roleId;
      _allowedUsersAndGroups = new HashSet<string>(allowedUsersAndGroups, StringComparer.InvariantCultureIgnoreCase);
      _groups = new Dictionary<string, GroupPrincipal>(_allowedUsersAndGroups.Count);
      _isSuccess = true;
    }

    public SiteAdminRolesResponseData(int roleId, AtlantisException ex)
    {
      _roleId = roleId;
      _exception = ex;
    }

    public SiteAdminRolesResponseData(RequestData requestData, Exception ex)
    {
      _roleId = -1;
      if (requestData != null)
      {
        SiteAdminRolesRequestData siteAdminRolesRequestData = requestData as SiteAdminRolesRequestData;
        if (siteAdminRolesRequestData != null)
        {
          _roleId = siteAdminRolesRequestData.RoleId;
        }
      }
      _exception = new AtlantisException(requestData, "SiteAdminRolesResponseData", ex.Message, requestData.ToXML(), ex);
    }

    public int RoleId
    {
      get { return _roleId; }
    }

    public bool IsSuccess
    {
      get { return _isSuccess; }
    }

    public bool IsUserAllowed(WindowsIdentity windowsUser)
    {
      bool result = false;

      if (_isSuccess)
      {
        PrincipalContext context = new PrincipalContext(ContextType.Domain, "jomax", "DC=jomax,DC=paholdings,DC=com");
        UserPrincipal user = UserPrincipal.FindByIdentity(context, IdentityType.Sid, windowsUser.User.Value);

        foreach (string groupKey in _allowedUsersAndGroups)
        {
          if (string.Compare(windowsUser.Name, groupKey, true) == 0)
          {
            result = true;
            break;
          }

          GroupPrincipal group = GetGroup(groupKey);
          if (group != null)
          {
            if (user.IsMemberOf(group))
            {
              result = true;
              break;
            }
          }
        }
      }

      return result;
    }

    private GroupPrincipal GetGroup(string groupKey)
    {
      GroupPrincipal result;
      if (_groups.ContainsKey(groupKey))
      {
        result = _groups[groupKey];
      }
      else
      {
        PrincipalContext context = new PrincipalContext(ContextType.Domain, "jomax", "DC=jomax,DC=paholdings,DC=com");
        result = GroupPrincipal.FindByIdentity(context, IdentityType.SamAccountName, groupKey);

        // Note! This code is thread safe because of the atomic assignment of the group object into the dictionary
        // If we change this in any way, it will need to keep thread safety or use locking
        _groups[groupKey] = result;
      }

      return result;
    }

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion
  }
}
