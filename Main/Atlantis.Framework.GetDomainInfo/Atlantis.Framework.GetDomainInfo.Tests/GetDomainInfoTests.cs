﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetDomainInfo.Interface;
using Atlantis.Framework.SessionCache;
using Atlantis.Framework.Testing.MockHttpContext;

namespace Atlantis.Framework.GetDomainInfo.Test
{
  /// <summary>
  /// Summary description for GetDomainInfoTests
  /// </summary>
  [TestClass]
  public class GetDomainInfoTests
  {
    public GetDomainInfoTests()
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
    public void GetDomainInfoTypeBasic()
    {
      MockHttpContext.SetMockHttpContext("test.aspx", "http://127.0.0.1/test.aspx", string.Empty);

      GetDomainInfoRequestData request = new GetDomainInfoRequestData(string.Empty, string.Empty, string.Empty, string.Empty, 0, "849362", "BATHRAKAALI.COM");

      GetDomainInfoResponseData response = SessionCache.SessionCache.GetProcessRequest <GetDomainInfoResponseData>(request, 93);

      Assert.IsTrue(response.IsSuccess);
    }
  }
}
