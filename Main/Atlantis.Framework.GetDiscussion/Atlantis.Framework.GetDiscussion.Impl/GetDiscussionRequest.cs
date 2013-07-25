using System;
using Atlantis.Framework.GetDiscussion.Interface;
using Atlantis.Framework.GetDiscussion.Impl.ForumWS;
using Atlantis.Framework.Interface;


namespace Atlantis.Framework.GetDiscussion.Impl
{
  public class GetDiscussionRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetDiscussionResponseData oResponseData = null;

      try
      {
        GetDiscussionRequestData request = (GetDiscussionRequestData)oRequestData;
        ForumWS.Administration service = new Administration();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        ForumWS.WsDiscussion discussion = service.GetDiscussion(request.ThreadId);
        
        oResponseData = new GetDiscussionResponseData(discussion.ThreadId,
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
      catch(Exception ex)
      {
        oResponseData = new GetDiscussionResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
 
  }
}
