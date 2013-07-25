using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DomainCheck.Interface;

namespace Atlantis.Framework.Tests
{
  public static class DomainCheckSyntaxCodes
  {
    public const int NoErrors = 1000;
    public const int MinimumLength = 2101;
    public const int MaximumLength = 2102;
    public const int InvalidCharacters = 2111;
    public const int InvalidTld = 2112;
    public const int LeadingHyhen = 2121;
    public const int TrailingHyphen = 2122;
    public const int Hypen34 = 2123;
    public const int Profanity = 2131;
    public const int AllNumeric = 2141;
    public const int Reserved = 2151;
    public const int IdnDomain = 2162;
  }

  /// <summary>
  /// Summary description for DomainCheck
  /// </summary>
  [TestClass]
  public class DomainCheck
  {
    public DomainCheck()
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
    public void DomainCheckTest()
    {
      DomainCheckRequestData domainCheckRequestData = new DomainCheckRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "TESTDOMAINAVAILABLE.COM", 1, "127.0.0.1");
      DomainCheckResponseData domainCheckResponseData = (DomainCheckResponseData)Engine.Engine.ProcessRequest(domainCheckRequestData, EngineRequests.DomainCheck);
      Assert.IsNotNull(domainCheckResponseData);
    }

    [TestMethod]
    public void DomainCheckTestDuplicate()
    {
      DomainCheckRequestData domainCheckRequestData = new DomainCheckRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "TESTDOMAINAVAILABLE.COM", 1, "127.0.0.1");
      domainCheckRequestData.AddDomainName("test1.com");
      domainCheckRequestData.AddDomainName("TEST1.com");
      DomainCheckResponseData domainCheckResponseData = (DomainCheckResponseData)Engine.Engine.ProcessRequest(domainCheckRequestData, EngineRequests.DomainCheck);
      Assert.AreEqual(2, domainCheckResponseData.Domains.Count);
    }

    [TestMethod]
    public void TestDomainCheckAsync()
    {
      DomainCheckRequestData domainCheckRequestData = new DomainCheckRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "TESTDOMAINAVAILABLE.COM", 1, "127.0.0.1");
      IAsyncResult ar = Engine.Engine.BeginProcessRequest(domainCheckRequestData, EngineRequests.DomainCheckAsync, null, null);
      ar.AsyncWaitHandle.WaitOne();
      DomainCheckResponseData domainCheckResponseData = (DomainCheckResponseData)Engine.Engine.EndProcessRequest(ar);
      Assert.IsNotNull(domainCheckResponseData);
    }

    [TestMethod]
    public void TestDomainCheckIdn()
    {
      string idnUrl = "விஜுதாமஸ்.COM";
      string idnPunyCode = (new System.Globalization.IdnMapping()).GetAscii(idnUrl).ToUpper();
      string langRegTag = "TAM";
      DomainCheckRequestData domainCheckRequestData = new DomainCheckRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, idnPunyCode, langRegTag, 1, "127.0.0.1");
      DomainCheckResponseData domainCheckResponseData = (DomainCheckResponseData)Engine.Engine.ProcessRequest(domainCheckRequestData, EngineRequests.DomainCheck);
      KeyValuePair<string, DomainAttributes> firstDomain = domainCheckResponseData.FirstDomain;
      Assert.IsTrue(firstDomain.Value.SyntaxCode == DomainCheckSyntaxCodes.NoErrors);
    }
  }
}
