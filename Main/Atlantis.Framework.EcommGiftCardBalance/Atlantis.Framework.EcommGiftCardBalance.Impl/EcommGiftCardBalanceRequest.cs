using Atlantis.Framework.Interface;
using Atlantis.Framework.EcommGiftCardBalance.Interface;

namespace Atlantis.Framework.EcommGiftCardBalance.Impl
{
  public class EcommGiftCardBalanceRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      EcommGiftCardBalanceRequestData getBalance = (EcommGiftCardBalanceRequestData)oRequestData;
      EcommGiftCardBalanceResponseData oResponseData = null;
      try
      {
        WscGiftCard.wscGiftCardService oSvc = new WscGiftCard.wscGiftCardService();
        oSvc.Url = ((WsConfigElement)oConfig).WSURL;
        oSvc.Timeout = (int)getBalance.RequestTimeout.TotalMilliseconds;
        int result = oSvc.GetGiftCardBalance(getBalance.AccountNumber, getBalance.OrderID);
        oResponseData = new EcommGiftCardBalanceResponseData(result);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new EcommGiftCardBalanceResponseData(oRequestData, exAtlantis);
      }
      return oResponseData;
    }

    #endregion
  }
}
