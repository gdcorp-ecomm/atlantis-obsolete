using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MktgSubscribeAdd.Interface;
using Atlantis.Framework.MktgSubscribeAdd.Impl.SubscribeWS;

namespace Atlantis.Framework.MktgSubscribeAdd.Impl
{
  public class MktgSubscribeAddRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;
      string responseText = string.Empty;

      try
      {
        MktgSubscribeAddRequestData mktgRequest = (MktgSubscribeAddRequestData)oRequestData;

        Service service = new Service();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)mktgRequest.RequestTimeout.TotalMilliseconds;

        responseText = service.Subscribe(mktgRequest.Email, mktgRequest.PublicationId, mktgRequest.PrivateLabelId, mktgRequest.EmailType,
                                         mktgRequest.FirstName, mktgRequest.LastName, mktgRequest.RequestedBy, mktgRequest.IPAddress, mktgRequest.Confirmed); 

        result = new MktgSubscribeAddResponseData(responseText);
      }
      catch (AtlantisException aex)
      {
        result = new MktgSubscribeAddResponseData(aex);
      }
      catch (Exception ex)
      {
        result = new MktgSubscribeAddResponseData(oRequestData, ex);
      }

      return result;
    }

    #endregion
  }
}
