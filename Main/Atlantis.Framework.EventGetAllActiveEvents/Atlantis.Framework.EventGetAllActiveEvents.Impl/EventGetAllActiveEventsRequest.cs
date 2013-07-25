using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.EventGetAllActiveEvents.Impl.EventDataWS;
using System.Xml;
using Atlantis.Framework.EventGetAllActiveEvents.Interface;

namespace Atlantis.Framework.EventGetAllActiveEvents.Impl
{
  public class EventGetAllActiveEventsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;
      XmlNode responseXml = null;

      try
      {
        EventGetAllActiveEventsRequestData request = (EventGetAllActiveEventsRequestData)oRequestData;

        SupportEventData service = new SupportEventData();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)request.ServiceTimeout.TotalMilliseconds;

        responseXml = service.GetAllActiveEvents(request.ClientName);

        result = new EventGetAllActiveEventsResponseData(responseXml);
      }
      catch (Exception ex)
      {
        result = new EventGetAllActiveEventsResponseData(responseXml, oRequestData, ex);
      }

      return result;
    }

    #endregion
  }
}
