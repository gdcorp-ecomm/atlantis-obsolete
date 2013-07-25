using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetUserProfileByShopperID.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;


namespace Atlantis.Framework.GetUserProfileByShopperID.Tests
{

  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetUserProfileByShoppnigIDTests
  {
    private const string _shopperId = "856045";

    public GetUserProfileByShoppnigIDTests()
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
    public void GetUserProfileByShopperIDBasic()
    {
      GetUserProfileByShopperIDRequestData request = new GetUserProfileByShopperIDRequestData(_shopperId, string.Empty, string.Empty, string.Empty, 0);
      GetUserProfileByShopperIDResponseData response = (GetUserProfileByShopperIDResponseData)Engine.Engine.ProcessRequest(request, 73);
//      GetUserProfileByShopperIDResponseData response = (GetUserProfileByShopperIDResponseData)DataCache.DataCache.GetProcessRequest(request, 73);
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void CheckForProfileByShopperId()
    {
      string shopperId = "xxdkdi1235";
      GetUserProfileByShopperIDRequestData request = new GetUserProfileByShopperIDRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0);
      GetUserProfileByShopperIDResponseData response = (GetUserProfileByShopperIDResponseData)Engine.Engine.ProcessRequest(request, 73);
      Assert.IsTrue(!response.IsSuccess);
    }
  }
}
