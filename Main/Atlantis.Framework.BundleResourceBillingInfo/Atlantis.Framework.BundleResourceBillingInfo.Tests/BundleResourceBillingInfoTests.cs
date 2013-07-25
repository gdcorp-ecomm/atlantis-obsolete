using System.Diagnostics;
using Atlantis.Framework.BundleResourceBillingInfo.Interface;
using Atlantis.Framework.Testing.MockHttpContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.BundleResourceBillingInfo.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetBundleResourceBillingInfoTests
  {

    private const string _shopperId = "856907";
    private const int _requestType = 378;


    public GetBundleResourceBillingInfoTests()
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
    public void BundleResourceBillingInfoTest()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      BundleResourceBillingInfoRequestData request = new BundleResourceBillingInfoRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 15475);

      BundleResourceBillingInfoResponseData response = SessionCache.SessionCache.GetProcessRequest<BundleResourceBillingInfoResponseData>(request, _requestType);
      BundleResourceBillingInfoResponseData response2 = SessionCache.SessionCache.GetProcessRequest<BundleResourceBillingInfoResponseData>(request, _requestType);

      Debug.WriteLine("UnifiedProductId: {0} | PurchasedDuration: {1} | PrivateLabelId: {2} | PfId: {3} | CommonName: {4} | BillingDate: {5} | BillingAttempt: {6} | BillingStatus: {7}"
        , response2.BillingInfo.UnifiedProductId
        , response2.BillingInfo.PurchasedDuration
        , response2.BillingInfo.PrivateLabelId
        , response2.BillingInfo.PfId
        , response2.BillingInfo.CommonName
        , response2.BillingInfo.BillingDate
        , response2.BillingInfo.BillingAttempt
        , response2.BillingInfo.BillingStatus);

      Assert.IsTrue(response.IsSuccess);
      Assert.AreEqual(response.BillingInfo.UnifiedProductId, response2.BillingInfo.UnifiedProductId);
    }
  }
}
