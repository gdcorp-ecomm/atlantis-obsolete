using System.Diagnostics;
using Atlantis.Framework.CRMLynxPermission.Interface;
using Atlantis.Framework.Testing.MockHttpContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.CRMLynxPermission.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetCRMLynxPermissionTests
  {

    private const string _shopperId = "";
    private const int _mgrUserId = 4692;
    private const int _requestType = 353;

    public GetCRMLynxPermissionTests()
    { }

    private TestContext testContextInstance;

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
    public void CRMLynxPermissionTest()
    {
      CRMLynxPermissionRequestData request = new CRMLynxPermissionRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _mgrUserId
         , "CancelSetupProducts");

      CRMLynxPermissionResponseData response = (CRMLynxPermissionResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SerializeTest()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      CRMLynxPermissionRequestData request = new CRMLynxPermissionRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _mgrUserId
         , "CancelSetupProducts");

      CRMLynxPermissionResponseData response = SessionCache.SessionCache.GetProcessRequest<CRMLynxPermissionResponseData>(request, _requestType);

      string xml = response.SerializeSessionData();
      Debug.WriteLine(xml);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
