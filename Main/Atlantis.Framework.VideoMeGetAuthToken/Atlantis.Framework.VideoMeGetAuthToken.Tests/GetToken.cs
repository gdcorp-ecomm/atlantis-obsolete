using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.VideoMeGetAuthToken.Interface;

namespace Atlantis.Framework.VideoMeGetAuthToken.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetToken
  {
    public GetToken()
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
    public void GetTokenTest()
    {
      VideoMeGetAuthTokenRequestData request = new VideoMeGetAuthTokenRequestData(
        "850774", string.Empty, string.Empty, string.Empty, 0);
      request.ApplicationId = 1090;
      request.ApplicationIdSpecified = true;
      request.UniqueFileId = "123456";
      request.AccessKeyId = "F4FF1DF6CA6E8AE15BB3";
      request.SecretKey = "464b7170a1dcf25651a30774949108170161dad2";

      VideoMeGetAuthTokenResponseData response = (VideoMeGetAuthTokenResponseData)Engine.Engine.ProcessRequest(request, 213);
      string token = response.Token;
      Assert.IsTrue(response.IsValid);

    }
  }
}
