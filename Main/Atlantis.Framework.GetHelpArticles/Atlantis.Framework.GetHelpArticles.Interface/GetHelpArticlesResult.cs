

namespace Atlantis.Framework.GetHelpArticles.Interface
{
  public class GetHelpArticlesResult
  {
    private uint _articleId;    
    private string _title;
    private string[] _tags;
    private string _description;
    private string _content;    
    private uint[] _topicIds;



    public GetHelpArticlesResult()
    { }

    public GetHelpArticlesResult(
      uint articleId,
      string title,
      string[] tags,
      string description,
      string content,
      uint[] topicIds)
    {
      _articleId = articleId;
      _title = title;
      _tags = tags;
      _description = description;
      _content = content;
      _topicIds = topicIds;
    }

    public uint ArticleId
    {
      get { return _articleId; }
    }

    public string Title
    {
      get { return _title; }
    }

    public string[] Tags
    {
      get { return _tags; }
    }

    public string Description
    {
      get { return _description; }
    }

    public string Content
    {
      get { return _content; }
    }

    public uint[] TopicIds
    {
      get { return _topicIds; }
    }
  }
  
}
