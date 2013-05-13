using Atlantis.Framework.Tokens.Interface;

namespace Atlantis.Framework.Providers.CDS
{
  internal class CDSWidgetTokenEncoding : ITokenEncoding
  {
    private const string ENCODED_QUOTE = "\\\"";
    private const string QUOTE = "\"";

    public string DecodeTokenData(string rawTokenData)
    {
      if (!string.IsNullOrEmpty(rawTokenData))
      {
        return rawTokenData.Replace(ENCODED_QUOTE, QUOTE);
      }
      else
      {
        return rawTokenData;
      }
    }

    public string EncodeTokenResult(string tokenResult)
    {
      if (!string.IsNullOrEmpty(tokenResult))
      {
        return tokenResult.Replace(QUOTE, ENCODED_QUOTE);
      }
      else
      {
        return tokenResult;
      }
    }
  }
}
