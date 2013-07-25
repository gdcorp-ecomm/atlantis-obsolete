using System;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainsBotTypo.Interface;
using Atlantis.Framework.DomainsBotTypo.Impl.domainsBotTypo;

namespace Atlantis.Framework.DomainsBotTypo.Impl
{
  public class DomainsBotTypoAsyncRequest : IAsyncRequest
  {
    public IAsyncResult BeginHandleRequest(RequestData domainsBotTypoRequestData, ConfigElement configElement, AsyncCallback asyncCallback, object state)
    {
      DomainsBotTypoRequestData requestData = (DomainsBotTypoRequestData)domainsBotTypoRequestData;
      TypoGenerator typoGenerator = new TypoGenerator();
      typoGenerator.Url = ((WsConfigElement)configElement).WSURL;
      AsyncState asyncState = new AsyncState(domainsBotTypoRequestData, configElement, typoGenerator, state);
      IAsyncResult asyncResult = typoGenerator.BeginGetTypos(requestData.DomainNameToSearch,
                                                             requestData.GetDotTypesString(),
                                                             requestData.DoCharacterReplacement,
                                                             requestData.DoCharacterPermutation,
                                                             requestData.DoCharacterOmission,
                                                             requestData.UseDoubledCharacter,
                                                             requestData.UseMissingDot,
                                                             requestData.ExcludeNumbers,
                                                             requestData.MaxResults, 
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
        TypoGenerator typoGenerator = (TypoGenerator)asyncState.Request;
        string[] searchResponse = typoGenerator.EndGetTypos(asyncResult);
        responseData = new DomainsBotTypoResponseData(searchResponse.Length);
        foreach (string domain in searchResponse)
        {
          ((DomainsBotTypoResponseData)responseData).AddDomain(domain);
        }
      }
      catch (AtlantisException atlantisException)
      {
        responseData = new DomainsBotTypoResponseData(atlantisException);
      }
      catch (Exception exception)
      {
        responseData = new DomainsBotTypoResponseData(asyncState.RequestData, exception);
      }
      return responseData;
    }
  }
}
