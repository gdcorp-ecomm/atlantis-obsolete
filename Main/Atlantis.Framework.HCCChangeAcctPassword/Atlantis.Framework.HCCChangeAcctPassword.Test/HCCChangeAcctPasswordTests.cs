﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.HCCChangeAcctPassword.Impl;
using Atlantis.Framework.HCCChangeAcctPassword.Interface;
using Atlantis.Framework.Testing.MockHttpContext;


namespace Atlantis.Framework.HCCChangeAcctPassword.Test
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class HCCChangeAcctPasswordTests
  {
  
    private const string _shopperId = "12530";


    public HCCChangeAcctPasswordTests()
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
    public void HCCChangeAcctPasswordTest()
    {
      MockHttpContext.SetMockHttpContext("default.aspx", "http://localhost/default.aspx", string.Empty);

      HCCChangeAcctPasswordRequestData request = new HCCChangeAcctPasswordRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , "7dc936ec-b8fb-497d-9db2-2b46026b06cc"
         , "Password1");

      //HCCChangeAcctPasswordResponseData response = (HCCChangeAcctPasswordResponseData)Engine.Engine.ProcessRequest(request, 284);

      var response = SessionCache.SessionCache.GetProcessRequest<HCCChangeAcctPasswordResponseData>(request, 284);

      //
      // TODO: Add test logic here
      //

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
