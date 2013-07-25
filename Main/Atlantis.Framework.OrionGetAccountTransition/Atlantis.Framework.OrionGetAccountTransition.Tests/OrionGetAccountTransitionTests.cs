using Atlantis.Framework.OrionGetAccountTransition.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.OrionGetAccountTransition.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetOrionGetAccountTransitionTests
  {

    private const string _shopperId = "85552";
    string accountUid = "7d98e3d3-1909-11e0-8837-0050569575d8";
    int _requestType = 329;

    public GetOrionGetAccountTransitionTests()
    { }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get { return testContextInstance; }
      set { testContextInstance = value; }
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
    public void OrionGetAccountTransitionTest()
    {
      //This line is needed for test harness only...
      //invoke datacache to properly load dll so call to datacache within OrionGetUsageRequest works
      DataCache.DataCache.GetPrivateLabelType(1);

      OrionGetAccountTransitionRequestData request = new OrionGetAccountTransitionRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , string.Empty
         , accountUid
         , null
         , null);

      OrionGetAccountTransitionResponseData response = (OrionGetAccountTransitionResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Assert.IsTrue(response.IsSuccess);
    }
  }
}
