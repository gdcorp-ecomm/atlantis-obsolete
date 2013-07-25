using System.Diagnostics;
using Atlantis.Framework.XCPaymentProfileCheck.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.XCPaymentProfileCheckCheck.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetXCPaymentProfileCheckTests
  {

    private const string _shopperIdWithPP = "839409";
    private const string _shopperIdWithoutPP = "857517";
    private const int _paymentProfileCheckRequestType = 175;

    public GetXCPaymentProfileCheckTests()
    {
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
    public void XCPaymentProfileCheckTestShopperWithPP()
    {
      XCPaymentProfileCheckRequestData request = new XCPaymentProfileCheckRequestData(_shopperIdWithPP
         , string.Empty
         , string.Empty
         , string.Empty
         , 0);

      XCPaymentProfileCheckResponseData response = (XCPaymentProfileCheckResponseData)Engine.Engine.ProcessRequest(request, _paymentProfileCheckRequestType);

      Debug.WriteLine(response.ToXML());
      Debug.WriteLine(string.Format("Shopper's Has Instant Purchase: {0}", response.HasInstantPurchasePayment));
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void XCPaymentProfileCheckTestShopperWithoutPP()
    {
      XCPaymentProfileCheckRequestData request = new XCPaymentProfileCheckRequestData(_shopperIdWithoutPP
         , string.Empty
         , string.Empty
         , string.Empty
         , 0);

      XCPaymentProfileCheckResponseData response = (XCPaymentProfileCheckResponseData)Engine.Engine.ProcessRequest(request, _paymentProfileCheckRequestType);

      Debug.WriteLine(response.ToXML());
      Debug.WriteLine(string.Format("Shopper's Has Instant Purchase: {0}", response.HasInstantPurchasePayment));
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
