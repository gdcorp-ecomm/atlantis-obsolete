
namespace Atlantis.Framework.SearchHelp.Interface
{
  
  public class SearchHelpResults
  {
    private uint _articleId;
    private string _title;
    private string _description;

    public SearchHelpResults()
    { }

    public SearchHelpResults(
      uint articleId,
      string title,
      string description)
    {
      _articleId = articleId;
      _title = title;
      _description = description;
    }

    public uint ArticleId
    {
      get { return _articleId; }
    }

    public string Title
    {
      get { return _title; }
    }

    public string Description
    {
      get { return _description; }
    }        
  }
}
