using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.PresentationCentral.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for PresentationCentralTests
  /// </summary>
  [TestClass]
  public class PresentationCentralTests
  {
    public PresentationCentralTests()
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
    public void TestHeader()
    {
      HtmlRequestData request = new HtmlRequestData("header2", "sales", 1, false, "",
        "http://localhost:2008/Sales/Default.aspx?prog_id=godaddy", "", "", 0);
      request.ParamsElement.Attributes["bobsblog"] = "What&#x27;s better than a Beaver? Our new ad showing Danica&#x27;s other side.";
      request.ParamsElement.Attributes["spkey"] = "GDSWPWEBNETMMICCO";
      request.ParamsElement.Attributes["inApp"] = "sales";

      HtmlResponseData data1 = (HtmlResponseData)Atlantis.Framework.DataCache.DataCache.GetProcessRequest(request, EngineRequests.PresentationCentralHtml);
      HtmlResponseData data2 = (HtmlResponseData)Atlantis.Framework.DataCache.DataCache.GetProcessRequest(request, EngineRequests.PresentationCentralHtml);

      Assert.AreEqual(data1.GetTransformAttribute("header2", "css"), data2.GetTransformAttribute("header2", "css"));
      Assert.AreEqual(data1.ToXML(), data2.ToXML());
    }
  }
}
