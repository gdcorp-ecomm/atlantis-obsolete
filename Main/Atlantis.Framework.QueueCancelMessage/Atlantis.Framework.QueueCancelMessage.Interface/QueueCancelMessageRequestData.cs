using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.QueueCancelMessage.Interface
{
  public class QueueCancelMessageRequestData : RequestData
  {
    private QueueCancelMessageRequestData()
      : base("", "", "", "", 0)
    {}

    public QueueCancelMessageRequestData( string shopperID, string sourceURL, string orderID, 
                                          string pathway, int pageCount, string input)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      Input = input;
    }

    public override string GetCacheMD5()
    {
      return string.Empty;
    }

    public string Input { get; set; }
  }
}
