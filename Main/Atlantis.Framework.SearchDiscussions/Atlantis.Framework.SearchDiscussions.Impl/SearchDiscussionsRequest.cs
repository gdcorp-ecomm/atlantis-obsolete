using System;
using System.Collections.Generic;
using Atlantis.Framework.SearchDiscussions.Interface;
using Atlantis.Framework.SearchDiscussions.Impl.ForumsWS;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SearchDiscussions.Impl
{
  public class SearchDiscussionsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      SearchDiscussionsResponseData oResponseData = null;

      try
      {
        SearchDiscussionsRequestData request = (SearchDiscussionsRequestData)oRequestData;
        ForumsWS.Administration service = new Administration();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        int totalResults;
        ForumsWS.WsDiscussion[] discussions = service.SearchDiscussions(request.ForumId,
                                                                        request.SearchWord,
                                                                        request.MaximumRows,
                                                                        request.StartRowIndex,
                                                                        request.NewDate,
                                                                        request.PopularHours,
                                                                        out totalResults);

        SearchDiscussionsResults[] discussionResults = null;

        if (discussions != null)
        {
          discussionResults = Array.ConvertAll<WsDiscussion, SearchDiscussionsResults>(
            discussions, new Converter<WsDiscussion, SearchDiscussionsResults>(ConvertSearchDiscussionResults));
        }

        oResponseData = new SearchDiscussionsResponseData(discussionResults, totalResults);

      }
      catch (Exception ex)
      {
        oResponseData = new SearchDiscussionsResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    private static SearchDiscussionsResults ConvertSearchDiscussionResults(WsDiscussion discussion)
    {
      SearchDiscussionsResults result = null;

      if (discussion != null)
      {
        result = new SearchDiscussionsResults(
          discussion.ThreadId,
          discussion.ForumId,
          discussion.Title,
          discussion.CreatorId,
          discussion.Creator,
          discussion.Locked,
          discussion.ViewsCount,
          discussion.PublishStatusId,
          discussion.CreateDate,
          discussion.CategoryId,
          discussion.CategoryName,
          discussion.CommentId,
          discussion.CommentAuthorId,
          discussion.CommentAuthor,
          discussion.CommentModifiedDate,
          discussion.CommentCount,
          discussion.Sticky,
          discussion.Featured,
          discussion.NewCommentCount,
          discussion.Popularity);
      }

      return result;
    }

    #endregion
  }
}
