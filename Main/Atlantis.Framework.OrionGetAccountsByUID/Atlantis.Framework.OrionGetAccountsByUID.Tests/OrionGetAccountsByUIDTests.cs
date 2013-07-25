using System.Diagnostics;
using Atlantis.Framework.OrionGetAccountsByUID.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.OrionGetAccountsByUID.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetOrionGetAccountsByUIDTests
  {

    private const string _shopperId = "840820";
    string _appName = "Atlantis.Framework.OrionGetAccountsByUID.Tests";
    string _messageId = string.Empty;
    string[] _accountUid = { "7b233a4b-979b-497e-80ed-5dde71a31b0d" };
    string[] _returnAttributeList = { "plan_features", "subdomain", "aliasdomain", "ftpuseraccount" };// Used to get orion accounts by attributes.           
    int _requestType = 129;

    public GetOrionGetAccountsByUIDTests()
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
    public void OrionGetAccountsByUIDTest()
    {
      OrionGetAccountsByUIDRequestData request = new OrionGetAccountsByUIDRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _appName
         , _messageId
         , _accountUid
         , _returnAttributeList);

      OrionGetAccountsByUIDResponseData response = (OrionGetAccountsByUIDResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      //This line is needed for test harness only...
      //invoke datacache to properly load dll so call to datacache within OrionGetUsageRequest works
      DataCache.DataCache.GetPrivateLabelType(1);  

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
