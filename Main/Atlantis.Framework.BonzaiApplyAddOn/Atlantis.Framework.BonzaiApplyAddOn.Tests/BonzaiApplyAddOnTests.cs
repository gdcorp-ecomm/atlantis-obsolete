using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.BonzaiApplyAddOn.Impl;
using Atlantis.Framework.BonzaiApplyAddOn.Interface;


namespace Atlantis.Framework.BonzaiApplyAddOn.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetBonzaiApplyAddOnTests
  {

    private const string _shopperId = "840820";
    private const string _accountUID = "7f254312-12dc-4c30-a75d-db84b63d5a02";
    private const string _addOnType = "DedicatedIp";  // "ColdFusion";
    private const int _bonzaiRequestType = 135;

    public GetBonzaiApplyAddOnTests()
    { }

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
    public void BonzaiApplyAddOnTest()
    {
      BonzaiApplyAddOnRequestData request = new BonzaiApplyAddOnRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _accountUID
         , _addOnType);

      BonzaiApplyAddOnResponseData response = (BonzaiApplyAddOnResponseData)Engine.Engine.ProcessRequest(request, _bonzaiRequestType);

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
