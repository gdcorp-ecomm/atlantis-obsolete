﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.SBSDomainRegistrar.Interface;

namespace Atlantis.Framework.SBSDomainRegistrar.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class SBSDomainRegistrarTest
  {
    public SBSDomainRegistrarTest()
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
    public void SBSDomainRegistrarCheck()
    {
      SBSDomainRegistrarRequestData request = new SBSDomainRegistrarRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0, "BLUEGREENINFO.US");
      SBSDomainRegistrarResponseData response 
        = (SBSDomainRegistrarResponseData)Engine.Engine.ProcessRequest(request, 198);
      string result = response.PrivateLabelId + " : " + response.Status;
      Assert.IsFalse(response.IsActive);
    }
  }
}
