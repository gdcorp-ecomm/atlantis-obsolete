using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetHelpArticles.Interface
{
  public class GetHelpArticlesResponseData : IResponseData
  {
    private bool _success = false;
    private AtlantisException _ex;
    private List<GetHelpArticlesResult> _wsGetHelpArticleResults = new List<GetHelpArticlesResult>();

    public GetHelpArticlesResponseData(IEnumerable<GetHelpArticlesResult> wsGetHelpArticleResults)
    {
      if (wsGetHelpArticleResults != null)
      {
        _wsGetHelpArticleResults.AddRange(wsGetHelpArticleResults);
      }

      _success = true;
    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public IEnumerable<GetHelpArticlesResult> Articles
    {
      get { return _wsGetHelpArticleResults; }
    }

    public GetHelpArticlesResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public GetHelpArticlesResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "GetHelpArticlesResponseData", ex.Message, oRequestData.ToXML());
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
