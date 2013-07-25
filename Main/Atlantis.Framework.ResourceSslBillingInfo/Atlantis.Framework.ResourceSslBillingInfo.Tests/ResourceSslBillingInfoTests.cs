using System.Diagnostics;
using Atlantis.Framework.ResourceSslBillingInfo.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.ResourceSslBillingInfo.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetResourceSslBillingInfoTests
  {
    private const string _shopperId = "856907";
    private const int _requestType = 389;
    private const int FreeSslResourceId = 418955;
    private const int PurchasedSslResourceId = 399172;


    public GetResourceSslBillingInfoTests()
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
    public void ResourceSslBillingInfoTest()
    {
      ResourceSslBillingInfoRequestData request = new ResourceSslBillingInfoRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , FreeSslResourceId);

      ResourceSslBillingInfoResponseData response = (ResourceSslBillingInfoResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Debug.WriteLine(string.Format("ResourceId: {0} | IsFree: {1}", response.ResourceBillingInfo, response.ResourceBillingInfo.IsFree));
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
