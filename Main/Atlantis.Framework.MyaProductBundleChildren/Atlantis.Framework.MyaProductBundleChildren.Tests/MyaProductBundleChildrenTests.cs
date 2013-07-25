using System.Diagnostics;
using Atlantis.Framework.MyaProductBundleChildren.Interface;
using Atlantis.Framework.Testing.MockHttpContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductBundleChildren.Tests
{
  [TestClass]
  public class GetMyaProductBundleChildrenTests
  {

    //private const string _shopperId = "858346";
    //private const int _billingResourceId = 15680;   // Bundle with setup SEV = 15663 | Bundle with not setup SEV = 15680
    private const string _shopperId = "856907";
    private const int _billingResourceId = 15475;   // Bundle with setup SEV = 15663 | Bundle with not setup SEV = 15680
    private const int _requestType = 373;

    public GetMyaProductBundleChildrenTests()
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
    public void MyaProductBundleChildrenTest()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      MyaProductBundleChildrenRequestData request = new MyaProductBundleChildrenRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _billingResourceId);

      MyaProductBundleChildrenResponseData response = SessionCache.SessionCache.GetProcessRequest<MyaProductBundleChildrenResponseData>(request, _requestType);
      MyaProductBundleChildrenResponseData response2 = SessionCache.SessionCache.GetProcessRequest<MyaProductBundleChildrenResponseData>(request, _requestType);

      Debug.WriteLine(string.Format("Child Product Count: {0}", response.BundleChildProducts.Count));
      foreach (ChildProduct cp in response.BundleChildProducts)
      {
        Debug.WriteLine("ProductTypeId: {0} | BillingResourceId: {1} | OrionId: {2} | CommonName: {3} | UserWebsiteId: {4} | CustomerId: {5}"
          , cp.ProductTypeId, cp.BillingResourceId, cp.OrionResourceId, cp.CommonName, cp.UserWebsiteId, cp.CustomerId);
      }

      Assert.IsTrue(response.IsSuccess);
      for (int i = 0; i < response.BundleChildProducts.Count; i++)
      {
        Assert.AreEqual(response.BundleChildProducts[i].BillingResourceId, response2.BundleChildProducts[i].BillingResourceId);
      }
    }
  }
}
