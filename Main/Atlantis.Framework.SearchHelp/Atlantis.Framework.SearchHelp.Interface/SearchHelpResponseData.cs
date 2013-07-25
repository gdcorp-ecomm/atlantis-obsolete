using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SearchHelp.Interface
{
  public class SearchHelpResponseData : IResponseData
  {
    private bool _success = false;
    private AtlantisException _ex;
    private List<SearchHelpResults> _wsSearchHelpResults = new List<SearchHelpResults>();

    public SearchHelpResponseData(IEnumerable<SearchHelpResults> wsSearchHelpResults)
    {
      if (wsSearchHelpResults != null)
      {
        _wsSearchHelpResults.AddRange(wsSearchHelpResults);
      }

      _success = true;

    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public IEnumerable<SearchHelpResults> SearchHelpResults
    {
      get { return _wsSearchHelpResults; }
    }

    public SearchHelpResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public SearchHelpResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "SearchHelpResponseData", ex.Message, oRequestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion
  }
}
