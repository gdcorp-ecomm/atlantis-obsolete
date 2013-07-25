using System;
using Atlantis.Framework.DCCIsDomainAlertCancellable.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCIsDomainAlertCancellable.Impl
{
  public class DCCIsDomainAlertCancellableRequest : IRequest
  {
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      DCCIsDomainAlertCancellableResponseData responseData = null;

      try
      {
        DCCIsDomainAlertCancellableRequestData request = (DCCIsDomainAlertCancellableRequestData)requestData;
        RegBackorderDataWebSvc.RegBackorderDataWebSvc ws = new RegBackorderDataWebSvc.RegBackorderDataWebSvc();
        ws.Url = ((WsConfigElement)config).WSURL;
        ws.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        string wsResponseXml = ws.IsDomainAlertCancellable(request.ToXML());

        if (wsResponseXml.Contains("error method="))
        {
          responseData = new DCCIsDomainAlertCancellableResponseData(request, wsResponseXml);
        }
        else
        {
          responseData = new DCCIsDomainAlertCancellableResponseData(wsResponseXml);
        }
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCIsDomainAlertCancellableResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new DCCIsDomainAlertCancellableResponseData(requestData, ex);
      }
       
      return responseData;
    }
  }
}
