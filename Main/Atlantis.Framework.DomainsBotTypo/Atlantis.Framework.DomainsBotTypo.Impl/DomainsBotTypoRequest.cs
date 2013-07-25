using System;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainsBotTypo.Interface;
using Atlantis.Framework.DomainsBotTypo.Impl.domainsBotTypo;

namespace Atlantis.Framework.DomainsBotTypo.Impl
{
  public class DomainsBotTypoRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData domainsBotTypoRequestData, ConfigElement configElement)
    {
      IResponseData responseData = null;
      try
      {
        DomainsBotTypoRequestData requestData = (DomainsBotTypoRequestData)domainsBotTypoRequestData;
        string[] searchResponse;
        using (TypoGenerator typoGenerator = new TypoGenerator())
        {
          typoGenerator.Url = ((WsConfigElement)configElement).WSURL;
          searchResponse = typoGenerator.GetTypos(requestData.DomainNameToSearch,
                                                requestData.GetDotTypesString(),
                                                requestData.DoCharacterReplacement,
                                                requestData.DoCharacterPermutation,
                                                requestData.DoCharacterOmission,
                                                requestData.UseDoubledCharacter,
                                                requestData.UseMissingDot,
                                                requestData.ExcludeNumbers,
                                                requestData.MaxResults);
        }
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
        responseData = new DomainsBotTypoResponseData(domainsBotTypoRequestData, exception);
      }
      return responseData;
    }
  }
}
