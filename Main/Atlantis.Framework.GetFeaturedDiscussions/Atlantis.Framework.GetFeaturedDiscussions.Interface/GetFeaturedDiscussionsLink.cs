using System;

namespace Atlantis.Framework.GetFeaturedDiscussions.Interface
{  
  public class GetFeaturedDiscussionsLink
  {
    private int _forumId;
    private long _discussionId;
    private string _title;
    private DateTime _createDate;

    public GetFeaturedDiscussionsLink(int forumId, long discussionId, string title, DateTime createDate)
    {
      _forumId = forumId;
      _discussionId = discussionId;
      _title = title;
      _createDate = createDate;
    }

    public int ForumId
    {
      get { return _forumId; }
    }

    public long DiscussionId
    {
      get { return _discussionId; }
    }

    public string Title
    {
      get { return _title; }
    }

    public DateTime CreateDate
    {
      get { return _createDate; }
    }

  }

}
