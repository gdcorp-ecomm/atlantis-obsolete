
namespace Atlantis.Framework.BazaarLinks.Interface
{
  public class BazaarResponseLink
  {
    private string _title;
    private string _url;

    public BazaarResponseLink(string title, string url)
    {
      _title = title;
      _url = url;
    }

    public string Title
    {
      get { return _title; }
    }

    public string Url
    {
      get { return _url; }
    }

  }
}
