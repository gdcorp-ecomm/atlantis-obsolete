using Atlantis.Framework.Interface;
using Atlantis.Framework.Providers.Split.Interface;

namespace Atlantis.Framework.Providers.Split
{
  public class SplitProvider : ProviderBase, ISplitProvider
  {
    StandardSplitValue _standardSplit;
    PCSplitValue _pcSplit;
    ISiteContext _siteContext;

    public SplitProvider(IProviderContainer container)
      : base(container)
    { 
    }

    private void LoadSplits()
    {
      if (_siteContext == null)
      {
        _siteContext = Container.Resolve<ISiteContext>();
        _standardSplit = new StandardSplitValue(_siteContext);
        _pcSplit = new PCSplitValue(_siteContext);
      }
    }

    public int SplitValue
    {
      get
      {
        LoadSplits();
        return _standardSplit.SplitValue;
      }
      set
      {
        LoadSplits();
        _standardSplit.SplitValue = value;
      }
    }

    public int PCSplitValue
    {
      get
      {
        LoadSplits();
        return _pcSplit.SplitValue;
      }
      set
      {
        LoadSplits();
        _pcSplit.SplitValue = value;
      }
    }

    private static string _splitCookieLifeAppSetting = "ATLANTIS_SPLITPROVIDER_COOKIELIFE_HOURS";
    public static string SplitCookieLifeAppsettingName
    {
      get
      {
        return _splitCookieLifeAppSetting;
      }
      set
      {
        _splitCookieLifeAppSetting = value;
      }
    }

  }
}
