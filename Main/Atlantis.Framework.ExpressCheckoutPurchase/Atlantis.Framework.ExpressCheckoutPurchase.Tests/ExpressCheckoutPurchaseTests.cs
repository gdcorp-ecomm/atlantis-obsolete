using System.Diagnostics;
using Atlantis.Framework.AddItem.Interface;
using Atlantis.Framework.ExpressCheckoutPurchase.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.ExpressCheckoutPurchase.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetExpressCheckoutPurchaseTests
  {

    private const string _shopperId = "856907";  // Valid: 856907  WithFraudulentEmail: 857623
    private const int _xcRequestType = 178;


    public GetExpressCheckoutPurchaseTests()
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
    public void ExpressCheckoutPurchaseSucceedSingleTest()
    {
      AddItemRequestData addItemRequest = new AddItemRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0);
      addItemRequest.AddItem("710", "1");

      ExpressCheckoutPurchaseRequestData request = new ExpressCheckoutPurchaseRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , "DEVMYAWEB"
        , "172.16.44.254"
        , false
        , "Customer"
        , "Online"
        , addItemRequest
        , null
        , null);

      ExpressCheckoutPurchaseResponseData response = (ExpressCheckoutPurchaseResponseData)Engine.Engine.ProcessRequest(request, _xcRequestType);

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ExpressCheckoutPurchaseSucceedMultipleTest()
    {
      AddItemRequestData addItemRequest = new AddItemRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0);
      addItemRequest.AddItem("5605", "1");
      addItemRequest.AddItem("4437", "1");
      addItemRequest.AddItem("892", "1");

      ExpressCheckoutPurchaseRequestData request = new ExpressCheckoutPurchaseRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , "DEVMYAWEB"
        , "172.16.44.254"
        , false
        , "Customer"
        , "Online"
        , addItemRequest
        , null
        , null);

      ExpressCheckoutPurchaseResponseData response = (ExpressCheckoutPurchaseResponseData)Engine.Engine.ProcessRequest(request, _xcRequestType);

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ExpressCheckoutPurchaseFailTest()
    {
      AddItemRequestData addItemRequest = new AddItemRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0);

      ExpressCheckoutPurchaseRequestData request = new ExpressCheckoutPurchaseRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , "DEVMYAWEB"
        , "172.16.44.254"
        , false
        , "Customer"
        , "Online"
        , addItemRequest
        , null
        , null);

      ExpressCheckoutPurchaseResponseData response = (ExpressCheckoutPurchaseResponseData)Engine.Engine.ProcessRequest(request, _xcRequestType);

      Debug.WriteLine(response.ToXML());
      Debug.WriteLine(response.Error.Description);
      Assert.IsFalse(response.IsSuccess);
    }
  }
}
