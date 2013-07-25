using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.Backorder.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for BackorderCheck
  /// </summary>
  [TestClass]
  public class BackorderCheck
  {
    public BackorderCheck()
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
    public void TestBackorderCheck()
    {
      BackorderRequestData backorderRequestData = new BackorderRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "INTEL.COM", 1);
      string requestXml = backorderRequestData.ToXML();      
      BackorderResponseData backorderResponseData = (BackorderResponseData)Engine.Engine.ProcessRequest(backorderRequestData, EngineRequests.DomainBackorder);
      bool isSuccess = backorderResponseData.IsSuccess;
      Assert.IsNotNull(backorderResponseData);
    }
  }
}
