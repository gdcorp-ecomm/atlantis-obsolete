using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.SocialMediaContestGetVideoIDS.Interface;

namespace Atlantis.Framework.SocialMediaContestGetVideoIDS.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetMediaIds
  {
    public GetMediaIds()
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
    [DeploymentItem("Atlantis.config")]
    //[DeploymentItem("Interop.gdDataCacheLib.dll")]
    //[DeploymentItem("Interop.gdSQLConnect.dll")]
    public void GetMediaIdsTest()
    {
      List<int> mediaIds = new List<int>();
      int _competitionId = 2;
      SocialMediaContestGetVideoIDSRequestData request = new SocialMediaContestGetVideoIDSRequestData("850774"
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _competitionId);

      SocialMediaContestGetVideoIDSResponseData response = (SocialMediaContestGetVideoIDSResponseData)DataCache.DataCache.GetProcessRequest(request, 223);
      mediaIds = response.SocialMediaIds;
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
