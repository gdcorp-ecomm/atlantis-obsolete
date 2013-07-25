using System;
using Atlantis.Framework.GetUserProfileByShopperID.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetUserProfileByShopperID.Impl.CommonProfileWS;

namespace Atlantis.Framework.GetUserProfileByShopperID.Impl
{
  public class GetUserProfileByShopperIDRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetUserProfileByShopperIDResponseData oResponseData = null;

      try
      {
        GetUserProfileByShopperIDRequestData request = (GetUserProfileByShopperIDRequestData)oRequestData;
        UserProfile service = new UserProfile();
        service.Url = ((WsConfigElement)oConfig).WSURL;

        WsUserProfile profile = service.GetUserProfileByShopperId(request.ShopperID);

        if (profile == null)
        {
          oResponseData = new GetUserProfileByShopperIDResponseData();
        }
        else
        {
          oResponseData = new GetUserProfileByShopperIDResponseData(profile.UserProfileId,
                                                     profile.IsMember,
                                                     profile.FirstName,
                                                     profile.LastName,
                                                     profile.UserName,
                                                     profile.ShopperId,
                                                     profile.UserAccountStatusId,
                                                     profile.RealName,
                                                     profile.EmailAddress,
                                                     profile.EmailAddressIsPublic,
                                                     profile.Occupation,
                                                     profile.WebSite,
                                                     profile.Avatar,
                                                     profile.AvatarUrl,
                                                     profile.Signature,
                                                     profile.FilerPrefix,
                                                     profile.City,
                                                     profile.State,
                                                     profile.Country);
        }
      }
      catch (Exception ex)
      {
        oResponseData = new GetUserProfileByShopperIDResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    
  }
}
