﻿using Atlantis.Framework.Interface;
using Atlantis.Framework.SplitTesting.Interface;

namespace Atlantis.Framework.Providers.SplitTesting.Tests.Mocks
{
  class MockActiveSplitTestsRequest_1Test_WithNeverEligibleEligibilityRules : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      var tests = @"<data count=""1""><item SplitTestID=""1"" VersionNumber=""1"" EligibilityRules=""neverElgible()"" SplitTestRunID=""1"" TestStartDate=""04/22/2013""/></data>";
      var resp = ActiveSplitTestsResponseData.FromCacheXml(tests);
      return resp;
    }
  }
}
