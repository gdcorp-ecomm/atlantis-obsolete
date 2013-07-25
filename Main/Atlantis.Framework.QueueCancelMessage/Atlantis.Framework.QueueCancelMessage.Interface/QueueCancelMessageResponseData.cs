using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.QueueCancelMessage.Interface
{
  public class QueueCancelMessageResponseData : IResponseData
  {
    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException AtlException { get; set; }
    public AtlantisException GetException()
    {
      return AtlException;
    }
  }
}
