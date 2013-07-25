using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.SurveyService.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for SurveyServiceTests
  /// </summary>
  [TestClass]
  public class SurveyServiceTests
  {
    public SurveyServiceTests()
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
    public void TestSurveyService()
    {
      try
      {
        bool testAsync = false;
        SurveyServiceRequestData request = new SurveyServiceRequestData("822497",
          string.Empty, string.Empty, string.Empty, 0);
        request.IPAddress = IPAddress.Loopback.ToString();
        request.AdVersion = 1;
        request.AgeGroupID = 1;
        request.PoliticalID = 1;
        request.Answers = "Survey answers";
        SurveyServiceResponseData response = null;
        if (testAsync)
        {
          IAsyncResult asyncResult = Engine.Engine.BeginProcessRequest(request, EngineRequests.SurveyServiceAsyncRequest, null, null);
          asyncResult.AsyncWaitHandle.WaitOne();
          response = (SurveyServiceResponseData)Engine.Engine.EndProcessRequest(asyncResult);
        }
        else
        {
          response = (SurveyServiceResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.SurveyServiceRequest);
        }
        Assert.IsTrue(response.IsSuccess);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }
  }
}
