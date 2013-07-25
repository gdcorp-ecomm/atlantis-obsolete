using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetAccountXML.Interface
{
  [Serializable]
  public class GetAccountXMLResponseData : IResponseData
  {
    public string AccountXML { get; set; }
    public string ToXML()
    {
      return AccountXML;
    }

    public AtlantisException AtlException { get; set; }
    public AtlantisException GetException()
    {
      return AtlException;
    }
  }
}
