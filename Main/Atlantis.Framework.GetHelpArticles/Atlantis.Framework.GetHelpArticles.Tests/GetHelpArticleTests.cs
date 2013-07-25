using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetHelpArticles.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;

namespace Atlantis.Framework.GetHelpArticles.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetHelpArticleTests
  {
    private const string _shopperId = "832652";

    public GetHelpArticleTests()
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
    public void GetHelpArticlestestBasic()
    {
      uint[] articleIds = { 5300, 5556, 5547, 5301, 5550, 5548, 5549, 5552, 5303, 5299, 5313, 5304 };
      GetHelpArticlesRequestData request = new GetHelpArticlesRequestData(_shopperId, string.Empty, string.Empty, string.Empty, 0, articleIds);
      GetHelpArticlesResponseData response = (GetHelpArticlesResponseData)DataCache.DataCache.GetProcessRequest(request, 79);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
