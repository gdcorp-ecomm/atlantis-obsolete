using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using System.Xml.Serialization;
using System.IO;

namespace Atlantis.Framework.GetCreditSummary.Interface
{

  public class GetCreditSummaryRequestData : RequestData
  {

    public GetCreditSummaryRequestData(string shopperID,
                                      string sourceURL,
                                      string orderID,
                                      string pathway,
                                      int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      bstrShopperID = shopperID;
    }

    public override string GetCacheMD5()
    {
      return String.Empty;
    }

    public string bstrShopperID { get; set; }

  }
}
