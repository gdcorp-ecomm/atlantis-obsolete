using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.ReceiptUpsell.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for ReceiptUpsellTests
  /// </summary>
  [TestClass]
  public class ReceiptUpsellTests
  {
    public ReceiptUpsellTests()
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
    [DeploymentItem("Interop.gdSQLConnect.dll")]
    public void ReceiptUpsellBasicTest()
    {
      ReceiptUpsellRequestData request = new ReceiptUpsellRequestData(
        "832652", string.Empty, "1", "UnitTestPathway", 7,
        7, 3604, 1, 777, 3605, 2, 7777, "UnitTest 7Upgrade", 1);
      ReceiptUpsellResponseData response =
        (ReceiptUpsellResponseData)Engine.Engine.ProcessRequest(
        request, EngineRequests.ReceiptUpsell);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
