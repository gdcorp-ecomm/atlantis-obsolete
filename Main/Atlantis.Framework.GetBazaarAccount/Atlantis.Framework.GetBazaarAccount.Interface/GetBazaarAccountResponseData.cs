using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetBazaarAccount.Interface
{
  public class GetBazaarAccountResponseData : IResponseData
  {
    private bool _success = false;
    private AtlantisException _ex;

    private bool _isBazaarMember;
    private string _manageProfileUrl;
    private string _inviteUrl;
    private string _contributeUrl;
    private string _discussionsUrl;
    private string _joinNowUrl;
    private int _resourcesCount;
    private int _discussionCount;

    public GetBazaarAccountResponseData(
      bool isBazaarMember,
      string manageProfileUrl,
      string inviteUrl,
      string contributeUrl,
      string discussionsUrl,
      string joinNowUrl,
      int resourcesCount,
      int discussionCount)
    {
      _isBazaarMember = isBazaarMember;
      _manageProfileUrl = manageProfileUrl;
      _inviteUrl = inviteUrl;
      _contributeUrl = contributeUrl;
      _discussionsUrl = discussionsUrl;
      _joinNowUrl = joinNowUrl;
      _resourcesCount = resourcesCount;
      _discussionCount = discussionCount;
    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public bool IsBazaarMember
    {
      get { return _isBazaarMember; }
    }

    public string ManageProfileUrl
    {
      get { return _manageProfileUrl; }
    }

    public string InviteUrl
    {
      get { return _inviteUrl; }
    }

    public string ContributeUrl
    {
      get { return _contributeUrl; }
    }

    public string DiscussionsUrl
    {
      get { return _discussionsUrl; }
    }

    public string JoinNowUrl
    {
      get { return _joinNowUrl; }
    }

    public int ResourcesCount
    {
      get { return _resourcesCount; }
    }

    public int DiscussionCount
    {
      get { return _discussionCount; }
    }

    public GetBazaarAccountResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public GetBazaarAccountResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "GetBazaarAccountResponseData", ex.Message, oRequestData.ToXML());    
    }

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion
  }
}
