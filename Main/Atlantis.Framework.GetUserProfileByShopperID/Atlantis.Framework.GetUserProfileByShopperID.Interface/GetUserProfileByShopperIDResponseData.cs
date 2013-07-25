using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetUserProfileByShopperID.Interface
{
  public class GetUserProfileByShopperIDResponseData : IResponseData
  {

    private bool _success = false;
    private AtlantisException _ex;

    private long _userProfileID;
    private bool _isMember;
    private string _firstName;
    private string _lastName;
    private string _userName;
    private string _shopperId;
    private int _userAccountStatusId;
    private string _realName;
    private string _emailAddress;
    private bool _emailAddressisPublic;
    private string _occupation;
    private string _webSite;
    private string _avatar;
    private string _avatarUrl;
    private string _signature;
    private string _filerPrefix;
    private string _city;
    private string _state;
    private string _country;



    public GetUserProfileByShopperIDResponseData(long userProfileID,
      bool isMember,
      string firstName,
      string lastName,
      string userName,
      string shopperId,
      int userAccountStatusId,
      string realName,
      string emailAddress,
      bool emailAddressisPublic,
      string occupation,
      string webSite,
      string avatar,
      string avatarUrl,
      string signature,
      string filerPrefix,
      string city,
      string state,
      string country)
    {
      _userProfileID = userProfileID;
      _isMember = isMember;
      _firstName = firstName;
      _lastName = lastName;
      _userName = userName;
      _shopperId = shopperId;
      _userAccountStatusId = userAccountStatusId;
      _realName = realName;
      _emailAddress = emailAddress;
      _emailAddressisPublic = emailAddressisPublic;
      _occupation = occupation;
      _webSite = webSite;
      _avatar = avatar;
      _avatarUrl = avatarUrl;
      _signature = signature;
      _filerPrefix = filerPrefix;
      _city = city;
      _state = state;
      _country = country;
      _success = true;
    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public long UserProfileID
    {
      get { return _userProfileID; }
    }

    public bool IsMember
    {
      get { return _isMember; }
    }

    public string FirstName
    {
      get { return _firstName; }
    }

    public string LastName
    {
      get { return _lastName; }
    }

    public string UserName
    {
      get { return _userName; }
    }

    public string ShopperId
    {
      get { return _shopperId; }
    }

    public int UserAccountStatusId
    {
      get { return _userAccountStatusId; }
    }

    public string RealName
    {
      get { return _realName; }
    }

    public string EmailAddress
    {
      get { return _emailAddress; }
    }

    public bool EmailAddressisPublic
    {
      get { return _emailAddressisPublic; }
    }

    public string Occupation
    {
      get { return _occupation; }
    }

    public string WebSite
    {
      get { return _webSite; }
    }
    public string Avatar
    {
      get { return _avatar; }
    }

    public string AvatarUrl
    {
      get { return _avatarUrl; }
    }

    public string Signature
    {
      get { return _signature; }
    }

    public string FilerPrefix
    {
      get { return _filerPrefix; }
    }

    public string City
    {
      get { return _city; }
    }

    public string State
    {
      get { return _state; }
    }

    public string Country
    {
      get { return _country; }
    }

    public GetUserProfileByShopperIDResponseData()
    {
    }

    public GetUserProfileByShopperIDResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public GetUserProfileByShopperIDResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "GetUserProfileByShopperIDResponseData", ex.Message, oRequestData.ToXML());    
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
