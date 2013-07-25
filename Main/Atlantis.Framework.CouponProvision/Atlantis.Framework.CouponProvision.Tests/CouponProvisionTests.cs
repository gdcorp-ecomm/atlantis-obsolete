using System.Diagnostics;
using Atlantis.Framework.CouponProvision.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.CouponProvision.Tests
{
  /// <summary>
  /// Summary description for CouponProvisionTests
  /// </summary>
  [TestClass]
  public class CouponProvisionTests
  {
    public CouponProvisionTests()
    {
      //
      // TODO: Add constructor logic here
      //
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
    public void CouponProvisionTest()
    {
      int couponKey = 3895;
      string shopperId = "859012";
      CouponProvisionRequestData request = new CouponProvisionRequestData(
        shopperId,
        null,
        null,
        null,
        0,
        couponKey);

      CouponProvisionResponseData response = (CouponProvisionResponseData)Engine.Engine.ProcessRequest(request, 203);

      Debug.WriteLine(response.ToXML());
      Assert.IsNull(response.GetException());
    }
  }
}
