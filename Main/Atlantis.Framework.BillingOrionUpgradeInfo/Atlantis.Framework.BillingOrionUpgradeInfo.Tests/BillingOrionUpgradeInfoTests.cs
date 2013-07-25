using System.Diagnostics;
using Atlantis.Framework.BillingOrionUpgradeInfo.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.BillingOrionUpgradeInfo.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetBillingOrionUpgradeInfoTests
  {

    private const string _shopperId = "842749";
    private const int _billingOrionUpgradeInfo = 143;


    public GetBillingOrionUpgradeInfoTests()
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
    public void BillingOrionUpgradeInfoTest()
    {
      int resourceId = 372813;  // 372813 321596

      BillingOrionUpgradeInfoRequestData request = new BillingOrionUpgradeInfoRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , resourceId);

      //request.RequestTimeout = new System.TimeSpan(0, 0, 30);
      BillingOrionUpgradeInfoResponseData response = (BillingOrionUpgradeInfoResponseData)Engine.Engine.ProcessRequest(request, _billingOrionUpgradeInfo);

      foreach (UpgradeInfo ui in response.UpgradeInfos)
      {
        Debug.WriteLine("************************************");
        Debug.WriteLine(string.Format("AttributeDescription: {0}", ui.AttributeDescription));
        Debug.WriteLine(string.Format("CustomerOwns: {0}", ui.CustomerOwns));
        Debug.WriteLine(string.Format("FamilyDescription: {0}", ui.FamilyDescription));
        Debug.WriteLine(string.Format("FamilyDescriptionExtended: {0}", ui.FamilyDescriptionExtended));
        Debug.WriteLine(string.Format("FamilyGroupId: {0}", ui.FamilyGroupId));
        Debug.WriteLine(string.Format("OrionAttributeFamilyId: {0}", ui.OrionAttributeFamilyId));
        Debug.WriteLine(string.Format("OrionAttributeTypeId: {0}", ui.OrionAttributeTypeId));
        Debug.WriteLine(string.Format("OrionValue: {0}", ui.OrionValue));
        Debug.WriteLine(string.Format("PfId: {0}", ui.PfId));
        Debug.WriteLine(string.Format("Rank: {0}", ui.Rank));
        Debug.WriteLine(string.Format("RenewalPfId: {0}", ui.RenewalPfId));
        Debug.WriteLine(string.Format("TransitionAware: {0}", ui.TransitionAware));
        Debug.WriteLine(string.Format("UpgradeOption: {0}", ui.UpgradeOption));
      }

      Assert.IsTrue(response.IsSuccess);
    }
  }
}
