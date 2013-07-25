using System;
using Atlantis.Framework.DCCGetRenewingDomains.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.Testing.MockHttpContext;

namespace Atlantis.Framework.DCCDCCGetRenewingDomains.Tests
{
  [TestClass]
  public class DCCDCCGetRenewingDomainsTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetExpiringDomainsWithin90Days()
    {
      DCCGetRenewingDomainsRequestData request = new DCCGetRenewingDomainsRequestData("847235",
                                                                                new TimeSpan(91, 0, 0, 0),
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "GET_RENEWING_DOMAINS_UNIT_TEST");

      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetRenewingDomainsResponseData response = (DCCGetRenewingDomainsResponseData)Engine.Engine.ProcessRequest(request, 126);
      Assert.IsTrue(response.IsSuccess);
      Console.WriteLine(response.ToXML());
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SerializeGetExpiringDomainsWithin90Days()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      DCCGetRenewingDomainsRequestData request = new DCCGetRenewingDomainsRequestData("847235",
                                                                                new TimeSpan(91, 0, 0, 0),
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "GET_RENEWING_DOMAINS_UNIT_TEST");

      request.RequestTimeout = TimeSpan.FromMinutes(1);

      DCCGetRenewingDomainsResponseData response = SessionCache.SessionCache.GetProcessRequest<DCCGetRenewingDomainsResponseData>(request, 126);

      Assert.IsTrue(response.IsSuccess);
      Console.WriteLine(response.ToXML());
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetExpiringDomainsWithin1Year()
    {
      DCCGetRenewingDomainsRequestData request = new DCCGetRenewingDomainsRequestData("847235",
                                                                                new TimeSpan(365, 0, 0, 0),
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "GET_RENEWING_DOMAINS_UNIT_TEST");

      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetRenewingDomainsResponseData response = (DCCGetRenewingDomainsResponseData)Engine.Engine.ProcessRequest(request, 126);
      Assert.IsTrue(response.IsSuccess);
      Console.WriteLine(response.ToXML());
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetExpiringDomainsNegativeDays()
    {
      DCCGetRenewingDomainsRequestData request = new DCCGetRenewingDomainsRequestData("847235",
                                                                                new TimeSpan(-1, 0, 0, 0),
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "GET_RENEWING_DOMAINS_UNIT_TEST");

      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetRenewingDomainsResponseData response = (DCCGetRenewingDomainsResponseData)Engine.Engine.ProcessRequest(request, 126);
      Assert.IsTrue(response.IsSuccess);
      Console.WriteLine(response.ToXML());
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetExpiringDomainsByCount()
    {
      DCCGetRenewingDomainsRequestData request = new DCCGetRenewingDomainsRequestData("847235",
                                                                                15,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "GET_RENEWING_DOMAINS_UNIT_TEST");

      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetRenewingDomainsResponseData response = (DCCGetRenewingDomainsResponseData)Engine.Engine.ProcessRequest(request, 126);
      Assert.IsTrue(response.IsSuccess);
      Assert.IsTrue(response.Domains.Count > 0 && response.Domains.Count <= 15); // Some of the domains may not be active status
      Console.WriteLine(response.ToXML());
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetExpiringDomainsByDomainName()
    {
      DCCGetRenewingDomainsRequestData request = new DCCGetRenewingDomainsRequestData("847235",
                                                                                "TIMQBCDEVBASIC.COM",
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "GET_RENEWING_DOMAINS_UNIT_TEST");

      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetRenewingDomainsResponseData response = (DCCGetRenewingDomainsResponseData)Engine.Engine.ProcessRequest(request, 126);
      Assert.IsTrue(response.IsSuccess);
      Assert.IsTrue(response.Domains.Count == 1);
      Console.WriteLine(response.ToXML());
    }
  }
}
