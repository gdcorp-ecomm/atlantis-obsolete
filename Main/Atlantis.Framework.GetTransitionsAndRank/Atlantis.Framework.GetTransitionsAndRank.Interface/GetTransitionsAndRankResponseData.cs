using Atlantis.Framework.Interface;
using System;

namespace Atlantis.Framework.GetTransitionsAndRank.Interface
{
  [Serializable]
  public class GetTransitionsAndRankResponseData : IResponseData
  {
    public string XML { get; set; }
    public string ToXML()
    {
      return XML;
    }

    public AtlantisException AtlException { get; set; }
    public AtlantisException GetException()
    {
      return AtlException;
    }
  }
}
