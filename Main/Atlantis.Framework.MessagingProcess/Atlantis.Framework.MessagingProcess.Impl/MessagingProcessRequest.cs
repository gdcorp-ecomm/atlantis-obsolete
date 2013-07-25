using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MessagingProcess.Interface;

namespace Atlantis.Framework.MessagingProcess.Impl
{
  public class MessagingProcessRequest : IRequest
  {

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      MessagingProcessResponseData response = null;
      string responseXml = string.Empty;

      try
      {
        MessagingProcessRequestData request = (MessagingProcessRequestData)oRequestData;
        MessagingWS.WSCgdMessagingSystemService messagingWS = new MessagingWS.WSCgdMessagingSystemService();
        messagingWS.Url = ((WsConfigElement)oConfig).WSURL;
        responseXml = messagingWS.ProcessXml(request.ToXML());

        response = new MessagingProcessResponseData(responseXml);
      }
      catch (AtlantisException exAtlantis)
      {
        response = new MessagingProcessResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        response = new MessagingProcessResponseData(responseXml, oRequestData, ex);
      }

      return response;
    }

    #endregion
  }
}
