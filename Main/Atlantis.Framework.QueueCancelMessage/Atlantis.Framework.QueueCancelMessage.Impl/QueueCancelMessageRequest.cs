using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.QueueCancelMessage.Interface;

namespace Atlantis.Framework.QueueCancelMessage.Impl
{
  public class QueueCancelMessageRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      QueueCancelMessageResponseData responseData = new QueueCancelMessageResponseData();
      QueueCancelMessageRequestData requestData = (QueueCancelMessageRequestData)oRequestData;
      WsConfigElement configuration = (WsConfigElement)oConfig;

      Cancellation.wscgdCancellationService cancellation = new Cancellation.wscgdCancellationService();
      cancellation.Url = configuration.WSURL;

      try
      {
        string output = cancellation.QueueCancelMsg(requestData.Input);

        if (string.Compare("<Status>Success</Status>", output, true) != 0)
        {
          string data = string.Format("Input: {0}, Result: {1}", requestData.Input, output);
          responseData.AtlException = new AtlantisException(oRequestData,
            "QueueCancelMessageRequest.RequestHandler", "Could not queue message", data);
        }
      }
      catch (Exception ex)
      {
        string data = string.Format("Input: {0}", requestData.Input);
        responseData.AtlException = new AtlantisException(oRequestData,
          "QueueCancelMessageRequest.RequestHandler", "Could not queue message", data, ex);
      }

      return responseData;
    }
  }
}
