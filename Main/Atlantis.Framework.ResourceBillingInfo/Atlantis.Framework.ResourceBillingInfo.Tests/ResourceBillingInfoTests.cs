using System.Diagnostics;
using Atlantis.Framework.ResourceBillingInfo.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.Testing.MockHttpContext;

namespace Atlantis.Framework.ResourceBillingInfo.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetResourceBillingInfoTests
  {

    private const string _shopperId = "856907";
    private const int _requestType = 216;

    public GetResourceBillingInfoTests()
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
    public void ResourceBillingInfoResourceIdTest()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      int billingResourceId = 400508;
      ResourceBillingInfoRequestData request = new ResourceBillingInfoRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , billingResourceId);

      ResourceBillingInfoResponseData response1 = SessionCache.SessionCache.GetProcessRequest<ResourceBillingInfoResponseData>(request, _requestType);
      ResourceBillingInfoResponseData response2 = SessionCache.SessionCache.GetProcessRequest<ResourceBillingInfoResponseData>(request, _requestType);

      Debug.WriteLine(response2.ToXML());
      Assert.IsTrue(response2.IsSuccess);
      Assert.IsTrue(response1.ToXML().Equals(response2.ToXML()));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ResourceBillingInfoShopperIdTest()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      ResourceBillingInfoRequestData request = new ResourceBillingInfoRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , null);

      ResourceBillingInfoResponseData response1 = SessionCache.SessionCache.GetProcessRequest<ResourceBillingInfoResponseData>(request, _requestType);
      ResourceBillingInfoResponseData response2 = SessionCache.SessionCache.GetProcessRequest<ResourceBillingInfoResponseData>(request, _requestType);

      Debug.WriteLine(response2.ToXML());
      Assert.IsTrue(response2.IsSuccess);
      Assert.IsTrue(response1.ToXML().Equals(response2.ToXML()));
    }
  }
}
