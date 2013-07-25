
namespace Atlantis.Framework.MYAGetHostingCredits.Interface
{
  public class HostingCredit
  {
    private int _id;
    private int _count;

    public int Id
    {
      get { return _id; }
      set { _id = value; }
    }

    public int Count
    {
      get { return _count; }
      set { _count = value; }
    }
  }
}
