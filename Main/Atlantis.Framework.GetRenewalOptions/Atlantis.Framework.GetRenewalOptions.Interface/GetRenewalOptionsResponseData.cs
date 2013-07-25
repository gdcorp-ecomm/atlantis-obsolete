using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetRenewalOptions.Interface
{
  [Serializable]
  public class GetRenewalOptionsResponseData : IResponseData
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
