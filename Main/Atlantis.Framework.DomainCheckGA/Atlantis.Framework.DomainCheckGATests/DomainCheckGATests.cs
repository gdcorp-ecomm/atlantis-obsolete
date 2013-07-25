﻿using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DomainCheckGA.Interface;
using System.Net;
using System.Threading;

namespace Atlantis.Framework.DomainCheckGA.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class DomainCheckGATests
  {
    public DomainCheckGATests()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DomainCheckGABasicTest()
    {
      DomainToCheckGA domain = new DomainToCheckGA("spoonyx.xxx", false);
      DomainCheckGARequestData request = new DomainCheckGARequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0,
        domain, 1, "127.0.0.1", "UnitTest");
      request.WaitTime = TimeSpan.FromSeconds(5);
      request.CheckDataType = "SRAD";

      DomainCheckGAResponseData response = (DomainCheckGAResponseData)Engine.Engine.ProcessRequest(request, 16);
      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DomainCheckGATimeoutTest()
    {
      List<DomainToCheckGA> domains = new List<DomainToCheckGA>();
      domains.Add(new DomainToCheckGA("micco.com", false));
      domains.Add(new DomainToCheckGA("micco1.com", false));
      domains.Add(new DomainToCheckGA("micco2.com", false));
      domains.Add(new DomainToCheckGA("micco3.com", false));
      domains.Add(new DomainToCheckGA("micco4.com", false));

      DomainCheckGARequestData request = new DomainCheckGARequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0,
        domains, 1, "127.0.0.1", "UnitTest");
      request.WaitTime = TimeSpan.FromSeconds(5);
      request.ServiceTimeout = TimeSpan.FromMilliseconds(1);

      DomainCheckGAResponseData response = (DomainCheckGAResponseData)Engine.Engine.ProcessRequest(request, 16);
      Assert.IsFalse(response.IsSuccess);
      Assert.AreEqual(response.ServiceExceptionStatus, WebExceptionStatus.Timeout);
    }

    private volatile bool _asyncSearchComplete = false;
    private DomainCheckGAResponseData _asyncResponse = null;

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DomainCheckGAAsyncTest()
    {
      _asyncResponse = null;

      List<DomainToCheckGA> domains = new List<DomainToCheckGA>();
      domains.Add(new DomainToCheckGA("micco.com", false));
      domains.Add(new DomainToCheckGA("micco1.com", false));
      domains.Add(new DomainToCheckGA("micco2.com", false));
      domains.Add(new DomainToCheckGA("micco3.com", false));
      domains.Add(new DomainToCheckGA("micco4.com", false));

      DomainCheckGARequestData request = new DomainCheckGARequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0,
        domains, 1, "127.0.0.1", "UnitTest");
      request.WaitTime = TimeSpan.FromSeconds(5);
      request.ServiceTimeout = TimeSpan.FromMilliseconds(1);

      IAsyncResult asyncResult = Engine.Engine.BeginProcessRequest(request, 21, EndDomainCheckGAAsyncTest, null);
      while (!_asyncSearchComplete)
      {
        Thread.Sleep(TimeSpan.FromMilliseconds(500));
      }

      Assert.IsNotNull(_asyncResponse);
      Assert.IsTrue(_asyncResponse.IsSuccess);
    }

    private void EndDomainCheckGAAsyncTest(IAsyncResult result)
    {
      _asyncResponse = Engine.Engine.EndProcessRequest(result) as DomainCheckGAResponseData;
      _asyncSearchComplete = true;
    }
  }
}
