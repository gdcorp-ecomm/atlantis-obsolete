using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.MYAGetUpgradeDomain.Interface;


namespace Atlantis.Framework.MYAGetUpgradeDomain.Tests
{
  [TestClass]
  public class MYAGetUpgradeDomainTests
  {
    private const string _shopperId = "849362";  //840820 842749;
    private const int _numRows = 100;
    private const bool _returnAll = false;

    public MYAGetUpgradeDomainTests()
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
    public void MYAGetUpgradeDomainTest()
    {

      MYAGetUpgradeDomainRequestData request = new MYAGetUpgradeDomainRequestData(_shopperId,
        string.Empty,
        string.Empty,
        string.Empty,
        0, _numRows, _returnAll);

      MYAGetUpgradeDomainResponseData response = (MYAGetUpgradeDomainResponseData)Engine.Engine.ProcessRequest(request, 166);

      foreach (MyaUpgradeDomain ud in response.MyaUpgradeDomains)
      {


        Debug.WriteLine("*************************");
        Debug.WriteLine(string.Format("DomainName: {0}", ud.DomainName));
        Debug.WriteLine(string.Format("ResourceID: {0}", ud.ResourceID.ToString()));
        Debug.WriteLine(string.Format("DomainID: {0}", ud.DomainID.ToString()));
        Debug.WriteLine(string.Format("IsPrivate: {0}", ud.IsPrivate.ToString()));
        Debug.WriteLine(string.Format("IsBusiness: {0}", ud.IsBusiness.ToString()));
        Debug.WriteLine(string.Format("IsProtected: {0}", ud.IsProtected.ToString()));
        Debug.WriteLine(string.Format("IsSmartDomain: {0}", ud.IsSmartDomain.ToString()));
      }
      Debug.WriteLine("*************************");
      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
