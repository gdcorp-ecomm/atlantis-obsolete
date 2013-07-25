using Atlantis.Framework.MyaShopperDataUpdate.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaShopperDataUpdate.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class MyaShopperDataUpdateTests
  {
    private const string _shopperId = "857527";
    private const int _requestType = 149;

    public MyaShopperDataUpdateTests()
    {
      //
      // TODO: Add constructor logic here
      //
    }

    #region Test Context
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
    public void UpdateHaitiAlertViewed()
    {
      MyaShopperDataUpdateRequestData request = new MyaShopperDataUpdateRequestData(_shopperId
          , string.Empty
          , string.Empty
          , string.Empty
          , 0
          , 4
          , "1");

      MyaShopperDataUpdateResponseData response = (MyaShopperDataUpdateResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Assert.IsTrue(response.GetException() == null && response.Successful);
    }
  }
}
