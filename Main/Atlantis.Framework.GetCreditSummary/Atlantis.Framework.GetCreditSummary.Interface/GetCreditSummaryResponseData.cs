using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetCreditSummary.Interface
{
  [Serializable]
  public class GetCreditSummaryResponseData : IResponseData 
  {
    #region IResponseData Members

    public string ResponseXML;
    string IResponseData.ToXML()
    {
      return ResponseXML;
    }

    public AtlantisException AtlException { get; set; }

    
    public AtlantisException GetException()
    {
      return AtlException;
    }

    #endregion
  }
}
