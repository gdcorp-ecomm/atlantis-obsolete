using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.LogDomainSearchResults.Interface;
using Atlantis.Framework.LogDomainSearchResults.Impl.LogDomainSearchResultsWS;

namespace Atlantis.Framework.LogDomainSearchResults.Impl
{
  public class LogDomainSearchResultsRequest : IRequest
  {

    

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      LogDomainSearchResultsResponseData oResponseData = null;

      try
      {
        LogDomainSearchResultsRequestData request = (LogDomainSearchResultsRequestData)oRequestData;
        
        LogDomainSearchResultsWS.Service service = new Service();

        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        service.LogDomainSearchResults(request.ToXML());

        oResponseData = new LogDomainSearchResultsResponseData();
                
        
      }
      catch (Exception ex)
      {
        oResponseData = new LogDomainSearchResultsResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
