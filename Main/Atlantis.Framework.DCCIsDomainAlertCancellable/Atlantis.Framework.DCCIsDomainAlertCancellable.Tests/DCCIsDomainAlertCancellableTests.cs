using System.Collections.Generic;
using System.Diagnostics;
using Atlantis.Framework.DCCIsDomainAlertCancellable.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.DCCIsDomainAlertCancellable.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetDCCIsDomainAlertCancellableTests
  {

    private const string _shopperId = "83439";   //DEV: 856907  TEST: 83439
    private const int _requestType = 224;


    public GetDCCIsDomainAlertCancellableTests()
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
    public void DCCIsDomainAlertCancellableTest()
    {
      List<int> billingResourceIds = new List<int>();
      billingResourceIds.Add(12291);
      billingResourceIds.Add(17665);
      billingResourceIds.Add(12271);
      billingResourceIds.Add(17666);

      DCCIsDomainAlertCancellableRequestData request = new DCCIsDomainAlertCancellableRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , "MYA"
         , billingResourceIds);

      DCCIsDomainAlertCancellableResponseData response = (DCCIsDomainAlertCancellableResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
