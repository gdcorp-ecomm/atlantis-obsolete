using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.EventGetServicesList.Impl.EventDataWS;
using Atlantis.Framework.EventGetServicesList.Interface;
using System.Xml;

namespace Atlantis.Framework.EventGetServicesList.Impl
{
  public class EventGetServicesListRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;
      XmlNode responseXml = null;

      try
      {
        EventGetServicesListRequestData request = (EventGetServicesListRequestData)oRequestData;

        SupportEventData service = new SupportEventData();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)request.ServiceTimeout.TotalMilliseconds;

        responseXml = service.GetServicesList(request.ClientName);

        result = new EventGetServicesListResponseData(responseXml);
      }
      catch (Exception ex)
      {
        result = new EventGetServicesListResponseData(responseXml, oRequestData, ex);
      }

      return result;
    }

    #endregion
  }
}
