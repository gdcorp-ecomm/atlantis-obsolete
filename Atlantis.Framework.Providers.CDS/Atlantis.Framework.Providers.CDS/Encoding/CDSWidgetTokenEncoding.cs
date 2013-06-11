using Atlantis.Framework.Tokens.Interface;

namespace Atlantis.Framework.Providers.CDS
{
  internal class CDSWidgetTokenEncoding : ITokenEncoding
  {
    private const string DOUBLE_ENCODED_QUOTE = "\\\\\"";
    private const string SINGLE_ENCODED_QUOTE = "\\\"";
    private const string QUOTE = "\"";

    public string DecodeTokenData(string rawTokenData)
    {
      string result = rawTokenData;

      if (!string.IsNullOrEmpty(rawTokenData))
      {
        result = rawTokenData.Replace(DOUBLE_ENCODED_QUOTE, QUOTE).Replace(SINGLE_ENCODED_QUOTE, QUOTE);
      }

      return result;
    }

    public string EncodeTokenResult(string tokenResult)
    {
      string result = tokenResult;

      if (!string.IsNullOrEmpty(tokenResult))
      {
        result = tokenResult.Replace(QUOTE, SINGLE_ENCODED_QUOTE);
      }

      return result;
    }
  }
}
