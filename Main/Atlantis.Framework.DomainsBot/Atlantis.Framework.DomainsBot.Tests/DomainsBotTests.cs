using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DomainsBot.Interface;
using Atlantis.Framework.Engine;
using System.Threading;

namespace Atlantis.Framework.DomainsBot.Tests
{
  [TestClass]
  public class DomainsBotTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DomainsBotBasicTest()
    {
      DomainsBotRequestData requestData = new DomainsBotRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0);

      requestData.SearchKey = "godaddy";
      List<string> PremiumTLDs = new List<string>();
      PremiumTLDs.Add("com");
      PremiumTLDs.Add("net");
      requestData.AddTLDs(PremiumTLDs);
      requestData.MaxResults = 10;
      requestData.RequestTimeout = TimeSpan.FromMilliseconds(3000);

      DomainsBotResponseData response = (DomainsBotResponseData)Engine.Engine.ProcessRequest(requestData, 17);
    }
  }
}
