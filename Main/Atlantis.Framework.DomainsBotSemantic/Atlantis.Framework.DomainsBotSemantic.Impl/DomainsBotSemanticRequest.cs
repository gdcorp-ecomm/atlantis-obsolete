using System;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainsBotSemantic.Interface;
using Atlantis.Framework.DomainsBotSemantic.Impl.domainsBotSemantic;

namespace Atlantis.Framework.DomainsBotSemantic.Impl
{
  public class DomainsBotSemanticRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData domainsBotSemanticRequestData, ConfigElement configElement)
    {
      IResponseData responseData = null;
      try
      {
        DomainsBotSemanticRequestData requestData = (DomainsBotSemanticRequestData)domainsBotSemanticRequestData;
        Domain[] searchResponse;
        using (FirstImpact3 firstImpact = new FirstImpact3())
        {
          firstImpact.Url = ((WsConfigElement)configElement).WSURL;
          firstImpact.Timeout = requestData.Timeout;
          searchResponse = firstImpact.SearchAvailableDomains(requestData.DomainNameToSearch,
                                                              requestData.GetDotTypesString(),
                                                              requestData.MaxResults,
                                                              requestData.AddDashes,
                                                              requestData.AddRelated,
                                                              requestData.AddCompound,
                                                              requestData.AddVariations,
                                                              requestData.RemoveKeys,
                                                              String.Empty,
                                                              String.Empty);
        } 
        responseData = new DomainsBotSemanticResponseData(searchResponse.Length);
        foreach (Domain domain in searchResponse)
        {
          ((DomainsBotSemanticResponseData)responseData).AddDomain(domain.DomainName);
        }
      }
      catch (AtlantisException atlantisException)
      {
        responseData = new DomainsBotSemanticResponseData(atlantisException);
      }
      catch (Exception exception)
      {
        responseData = new DomainsBotSemanticResponseData(domainsBotSemanticRequestData, exception);
      }
      return responseData;
    }
  }
}
