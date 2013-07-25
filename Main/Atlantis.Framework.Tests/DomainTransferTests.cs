using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DomainTransfer.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for DomainTransferTests
  /// </summary>
  [TestClass]
  public class DomainTransferTests
  {
    public DomainTransferTests()
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
    public void TestDomainTransfer()
    {
      DomainTransferRequestData domainTransferRequestData = new DomainTransferRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "CANADA.CA", 1, "127.0.0.1");
      domainTransferRequestData.WaitTime = 10000;
      DomainTransferResponseData domainTransferResponseData = (DomainTransferResponseData)Engine.Engine.ProcessRequest(domainTransferRequestData, EngineRequests.DomainTransfer);
      Assert.IsNotNull(domainTransferResponseData);
      Assert.IsNotNull(domainTransferResponseData.FirstDomain);

      domainTransferRequestData = new DomainTransferRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "MIKEMICCO.COM", 1724, "127.0.0.1");
      domainTransferRequestData.WaitTime = 10000;
      domainTransferRequestData.RegistrarID = "2";
      domainTransferResponseData = (DomainTransferResponseData)Engine.Engine.ProcessRequest(domainTransferRequestData, EngineRequests.DomainTransfer);
      Assert.IsNotNull(domainTransferResponseData);
      Assert.IsNotNull(domainTransferResponseData.FirstDomain);

      domainTransferRequestData = new DomainTransferRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "MICROSOFT.BIZ", 1, "127.0.0.1");
      domainTransferRequestData.WaitTime = 10000;
      domainTransferResponseData = (DomainTransferResponseData)Engine.Engine.ProcessRequest(domainTransferRequestData, EngineRequests.DomainTransfer);
      Assert.IsNotNull(domainTransferResponseData);
      Assert.IsNotNull(domainTransferResponseData.FirstDomain);

      domainTransferRequestData = new DomainTransferRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "THISISSOPAINFULTOTEST102.COM", 1, "127.0.0.1");
      domainTransferRequestData.WaitTime = 10000;
      domainTransferResponseData = (DomainTransferResponseData)Engine.Engine.ProcessRequest(domainTransferRequestData, EngineRequests.DomainTransfer);
      Assert.IsNotNull(domainTransferResponseData);
      Assert.IsNotNull(domainTransferResponseData.FirstDomain);

      domainTransferRequestData = new DomainTransferRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "THISISSOPAINFULTOTEST112.COM", 1, "127.0.0.1");
      domainTransferRequestData.WaitTime = 10000;
      domainTransferResponseData = (DomainTransferResponseData)Engine.Engine.ProcessRequest(domainTransferRequestData, EngineRequests.DomainTransfer);
      Assert.IsNotNull(domainTransferResponseData);
      Assert.IsNotNull(domainTransferResponseData.FirstDomain);

    }

  }
}
