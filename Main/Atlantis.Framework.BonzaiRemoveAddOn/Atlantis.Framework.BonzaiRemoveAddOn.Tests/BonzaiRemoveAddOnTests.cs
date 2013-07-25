using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.BonzaiRemoveAddOn.Impl;
using Atlantis.Framework.BonzaiRemoveAddOn.Interface;


namespace Atlantis.Framework.BonzaiRemoveAddOn.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetBonzaiRemoveAddOnTests
  {

    private const string _shopperId = "840820";
    private const string _accountUid = "3b2056cf-fee1-11de-9d9e-005056956427";
    private const string _attributeUid = "174b68cf-807e-4a25-a6f0-ee7beff1fa1b";
    private const string _addOnType = "DedicatedIp";  // "ColdFusion";
    private const int _bonzaiRequestType = 136;

    public GetBonzaiRemoveAddOnTests()
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
    public void BonzaiRemoveAddOnTest()
    {
      BonzaiRemoveAddOnRequestData request = new BonzaiRemoveAddOnRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _accountUid
         , _attributeUid
         , _addOnType);

      BonzaiRemoveAddOnResponseData response = (BonzaiRemoveAddOnResponseData)Engine.Engine.ProcessRequest(request, _bonzaiRequestType);

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
