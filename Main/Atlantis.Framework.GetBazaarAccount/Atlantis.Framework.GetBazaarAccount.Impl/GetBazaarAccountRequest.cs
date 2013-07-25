using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetBazaarAccount.Interface;
using Atlantis.Framework.GetBazaarAccount.Impl.BazaarWS;

namespace Atlantis.Framework.GetBazaarAccount.Impl
{
  public class GetBazaarAccountRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetBazaarAccountResponseData oResponseData = null;

      try
      {
        GetBazaarAccountRequestData request = (GetBazaarAccountRequestData)oRequestData;
        BazaarWS.BazaarWebService service = new BazaarWebService();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        BazaarWS.BazaarAccount account = service.GetBazaarAccount(request.ShopperID);

        oResponseData = new GetBazaarAccountResponseData(account.IsBazaarMember,
                                                          account.ManageProfileUrl,
                                                          account.InviteUrl,
                                                          account.ContributeUrl,
                                                          account.DiscussionsUrl,
                                                          account.JoinNowUrl,
                                                          account.ResourcesCount,
                                                          account.DiscussionsCount);

      }
      catch (Exception ex)
      {
        oResponseData = new GetBazaarAccountResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
