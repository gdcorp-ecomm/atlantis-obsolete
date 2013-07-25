using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuthRetrieve.Interface
{
  public class AuthRetrieveRequestData : RequestData
  {
    public string SPKey { get; set; }
    public string Artifact { get; set; }
    public TimeSpan RequestTimeout { get; set; }

    public AuthRetrieveRequestData(string shopperId
      , string sourceUrl
      , string orderIo
      , string pathway
      , int pageCount
      , string spKey
      , string artifact)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      SPKey = string.IsNullOrEmpty(spKey) ? string.Empty : spKey;
      Artifact = string.IsNullOrEmpty(artifact) ? string.Empty : artifact;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in AuthRetrieveRequestData");
    }
  }
}
