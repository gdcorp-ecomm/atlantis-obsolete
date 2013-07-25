using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;


namespace Atlantis.Framework.SearchDiscussions.Interface
{
  public class SearchDiscussionsResponseData : IResponseData
  {

    private bool _success = false;
    private int _totalResults = 0;
    private AtlantisException _ex;
    private List<SearchDiscussionsResults> _wsSearchDiscussionsResult = new List<SearchDiscussionsResults>();

    public SearchDiscussionsResponseData(IEnumerable<SearchDiscussionsResults> wsSearchDiscussionsResult, int totalResults)
    {
      if (wsSearchDiscussionsResult != null)
        _wsSearchDiscussionsResult.AddRange(wsSearchDiscussionsResult);

      _totalResults = totalResults;

      _success = true;

    }

    public int TotalResults
    {
      get { return _totalResults; }
    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public IEnumerable<SearchDiscussionsResults> SearchDiscussionResult
    {
      get { return _wsSearchDiscussionsResult; }
    }

    public SearchDiscussionsResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public SearchDiscussionsResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "SearchDiscussionsResponseData", ex.Message, oRequestData.ToXML());                
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
