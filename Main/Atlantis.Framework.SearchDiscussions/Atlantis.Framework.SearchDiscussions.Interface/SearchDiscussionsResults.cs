using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.SearchDiscussions.Interface
{

  public class SearchDiscussionsResults
  {
    private long _threadID;
    private int _forumId;
    private string _title;
    private int _creatorId;
    private string _creator;
    private bool _locked;
    private int _viewsCount;
    private int _publishStatusId;
    private DateTime _createDate;
    private int _categoryId;
    private string _categoryName;
    private long _commentId;
    private int _commentAuthorId;
    private string _commentAuthor;
    private DateTime _commentModifiedDate;
    private int _commentCount;
    private bool _sticky;
    private bool _featured;
    private int _newCommentCount;
    private int _popularity;

    public SearchDiscussionsResults()
    { }

    public SearchDiscussionsResults(
      long threadID,
       int forumId,
       string title,
       int creatorId,
       string creator,
       bool locked,
       int viewsCount,
       int publishStatusId,
       DateTime createDate,
       int categoryId,
       string categoryName,
       long commentId,
       int commentAuthorId,
       string commentAuthor,
       DateTime commentModifiedDate,
       int commentCount,
       bool sticky,
       bool featured,
       int newCommentCount,
       int popularity)
    {
      _threadID = threadID;
      _forumId = forumId;
      _title = title;
      _creatorId = creatorId;
      _creator = creator;
      _locked = locked;
      _viewsCount = viewsCount;
      _publishStatusId = publishStatusId;
      _createDate = createDate;
      _categoryId = categoryId;
      _categoryName = categoryName;
      _commentId = commentId;
      _commentAuthorId = commentAuthorId;
      _commentAuthor = commentAuthor;
      _commentModifiedDate = commentModifiedDate;
      _commentCount = commentCount;
      _sticky = sticky;
      _featured = featured;
      _newCommentCount = newCommentCount;
      _popularity = popularity;
    }

    public int Popularity
    {
      get { return _popularity; }
    }

    public int NewCommentCount
    {
      get { return _newCommentCount; }
    }

    public bool Featured
    {
      get { return _featured; }
    }

    public bool Sticky
    {
      get { return _sticky; }
    }

    public int CommentCount
    {
      get { return _commentCount; }
    }

    public DateTime CommentModifiedDate
    {
      get { return _commentModifiedDate; }
    }

    public string CommentAuthor
    {
      get { return _commentAuthor; }
    }


    public int CommentAuthorId
    {
      get { return _commentAuthorId; }
    }

    public long CommentId
    {
      get { return _commentId; }
    }

    public string CategoryName
    {
      get { return _categoryName; }
    }

    public int CategoryId
    {
      get { return _categoryId; }
    }

    public DateTime CreateDate
    {
      get { return _createDate; }
    }

    public int PublishStatusId
    {
      get { return _publishStatusId; }
    }

    public int ViewsCount
    {
      get { return _viewsCount; }
    }

    public bool Locked
    {
      get { return _locked; }
    }

    public string Creator
    {
      get { return _creator; }
    }

    public int CreatorId
    {
      get { return _creatorId; }
    }

    public string Title
    {
      get { return _title; }
    }

    public int ForumId
    {
      get { return _forumId; }
    }

    public long ThreadID
    {
      get { return _threadID; }
    }

   
  }
}
