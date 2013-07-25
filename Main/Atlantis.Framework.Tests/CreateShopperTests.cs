using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Atlantis.Framework.CreateShopper.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for CreateShopperTests
  /// </summary>
  [TestClass]
  public class CreateShopperTests
  {
    public CreateShopperTests()
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
    public void CreateValidShopper()
    {
      CreateShopperRequestData request = new CreateShopperRequestData(string.Empty, string.Empty, string.Empty, 0, 1);
      CreateShopperResponseData response = (CreateShopperResponseData)Atlantis.Framework.Engine.Engine.ProcessRequest(request, EngineRequests.CreateShopper);
      Assert.IsNotNull(response);
    }

    [TestMethod]
    public void CreateInValidShopper()
    {
      string sErrorMsg = null;
      try
      {
        CreateShopperRequestData request = new CreateShopperRequestData(string.Empty, string.Empty, string.Empty, 0, -123123);
        CreateShopperResponseData response = (CreateShopperResponseData)Atlantis.Framework.Engine.Engine.ProcessRequest(request, EngineRequests.CreateShopper);
      }
      catch (Exception ex)
      {
        sErrorMsg = ex.Message;
      }
      Assert.IsNotNull(sErrorMsg);
    }
  }
}
