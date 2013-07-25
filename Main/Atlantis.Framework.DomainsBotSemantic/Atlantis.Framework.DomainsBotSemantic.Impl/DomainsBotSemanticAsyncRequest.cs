using System;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainsBotSemantic.Interface;
using Atlantis.Framework.DomainsBotSemantic.Impl.domainsBotSemantic;

namespace Atlantis.Framework.DomainsBotSemantic.Impl
{
  public class DomainsBotSemanticAsyncRequest : IAsyncRequest
  {
    public IAsyncResult BeginHandleRequest(RequestData domainsBotSemanticRequestData, ConfigElement configElement, AsyncCallback asyncCallback, object state)
    {
      DomainsBotSemanticRequestData requestData = (DomainsBotSemanticRequestData)domainsBotSemanticRequestData;
      FirstImpact3 firstImpact = new FirstImpact3();
      firstImpact.Timeout = requestData.Timeout;
      firstImpact.Url = ((WsConfigElement)configElement).WSURL;
      AsyncState asyncState = new AsyncState(domainsBotSemanticRequestData, configElement, firstImpact, state);
      IAsyncResult asyncResult = firstImpact.BeginSearchAvailableDomains(requestData.DomainNameToSearch,
                                                                         requestData.GetDotTypesString(),
                                                                         requestData.MaxResults,
                                                                         requestData.AddDashes,
                                                                         requestData.AddRelated,
                                                                         requestData.AddCompound,
                                                                          requestData.AddVariations,
                                                                         requestData.RemoveKeys,
                                                                         String.Empty,
                                                                         String.Empty,
                                                                         asyncCallback,
                                                                         state);
      return asyncResult;
    }

    public IResponseData EndHandleRequest(IAsyncResult asyncResult)
    {
      IResponseData responseData = null;
      AsyncState asyncState = (AsyncState)asyncResult.AsyncState; 
      try
      {
        FirstImpact3 firstImpact = (FirstImpact3)asyncState.Request;
        Domain[] searchResponse = firstImpact.EndSearchAvailableDomains(asyncResult);
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
        responseData = new DomainsBotSemanticResponseData(asyncState.RequestData, exception);
      }
      return responseData;
    }
  }
}
