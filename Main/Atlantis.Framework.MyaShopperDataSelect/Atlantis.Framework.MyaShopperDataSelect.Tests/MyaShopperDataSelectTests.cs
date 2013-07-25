using Atlantis.Framework.MyaShopperDataSelect.Interface;
using Atlantis.Framework.Testing.MockHttpContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaShopperDataSelect.Tests
{
  /// <summary>
  /// Summary description for MyaShopperDataSelectTests
  /// </summary>
  [TestClass]
  public class MyaShopperDataSelectTests
  {
    private const string _nonHaitiShopperId = "857600";
    private const string _notSeenHaitiShopperId = "857601";
    private const string _hasSeenHaitiShopperId = "857527";
    private const int _requestType = 148;
    private const int _isHaitiShopperCategory = 3;
    private const int _hasSeenAlertCategory = 4;

    public MyaShopperDataSelectTests()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    #region TestContext
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
    #endregion

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
    public void GetHaitiAlertInfoForNonHaitiShopper()
    {
      MyaShopperDataSelectRequestData request = new MyaShopperDataSelectRequestData(_nonHaitiShopperId
                , string.Empty
                , string.Empty
                , string.Empty
                , 0
                , _isHaitiShopperCategory);
      MyaShopperDataSelectResponseData response = (MyaShopperDataSelectResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Assert.IsTrue(response.GetException() == null &&
                    (string.IsNullOrEmpty(response.Data) || string.Compare(response.Data, "1") != 0));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetHaitiAlertInfoForHaitiShopperNotSeen()
    {
      MyaShopperDataSelectRequestData request = new MyaShopperDataSelectRequestData(_notSeenHaitiShopperId
                , string.Empty
                , string.Empty
                , string.Empty
                , 0
                , _isHaitiShopperCategory);
      MyaShopperDataSelectResponseData response1 = (MyaShopperDataSelectResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Assert.IsTrue(response1.GetException() == null &&
                    !string.IsNullOrEmpty(response1.Data) &&
                    string.Compare(response1.Data, "1") == 0);

      request.Category = _hasSeenAlertCategory;
      MyaShopperDataSelectResponseData response2 = (MyaShopperDataSelectResponseData)Engine.Engine.ProcessRequest(request, _requestType);
     
      Assert.IsTrue(response1.GetException() == null &&
                    (string.IsNullOrEmpty(response2.Data) || string.Compare(response2.Data, "1") != 0));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetHaitiAlertInfoForHaitiShopperHasSeen()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      MyaShopperDataSelectRequestData request = new MyaShopperDataSelectRequestData(_hasSeenHaitiShopperId
                , string.Empty
                , string.Empty
                , string.Empty
                , 0
                , _isHaitiShopperCategory);

      MyaShopperDataSelectResponseData response1 = SessionCache.SessionCache.GetProcessRequest<MyaShopperDataSelectResponseData>(request, _requestType);
      MyaShopperDataSelectResponseData sessionTestResponse = SessionCache.SessionCache.GetProcessRequest<MyaShopperDataSelectResponseData>(request, _requestType);

      Assert.IsTrue(response1.GetException() == null &&
                    !string.IsNullOrEmpty(response1.Data) &&
                    string.Compare(response1.Data, "1") == 0);

      request.Category = _hasSeenAlertCategory;
      MyaShopperDataSelectResponseData response2 = SessionCache.SessionCache.GetProcessRequest<MyaShopperDataSelectResponseData>(request, _requestType);

      Assert.IsTrue(response1.GetException() == null &&
                    !string.IsNullOrEmpty(response1.Data) &&
                    string.Compare(response2.Data, "1") == 0);

      Assert.IsTrue(response1.Data == sessionTestResponse.Data);
    }
  }
}
