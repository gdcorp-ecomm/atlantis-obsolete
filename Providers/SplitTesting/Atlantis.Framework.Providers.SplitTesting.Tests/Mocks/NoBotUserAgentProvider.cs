﻿using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Providers.UserAgentDetection.Interface;

namespace Atlantis.Framework.Providers.SplitTesting.Tests.Mocks
{
  class NoBotUserAgentProvider : ProviderBase, IUserAgentDetectionProvider
  {

    public NoBotUserAgentProvider(IProviderContainer container)
    : base(container) { }

    public bool IsMobileDevice(string userAgent)
    {
      throw new NotImplementedException();
    }

    public bool IsNoRedirectBrowser(string userAgent)
    {
      throw new NotImplementedException();
    }

    public bool IsOutDatedBrowser(string userAgent)
    {
      throw new NotImplementedException();
    }

    public bool IsSearchEngineBot(string userAgent)
    {
      return false;
    }
  }
}
