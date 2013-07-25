using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.SearchHelp.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;

namespace Atlantis.Framework.SearchHelp.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class SearchHelpTests
  {
    private const string _shopperId = "832652";

    public SearchHelpTests()
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
    public void SearchHelpBasic()
    {
      SearchHelpRequestData request = new SearchHelpRequestData(_shopperId, string.Empty, string.Empty, string.Empty, 0,
                                                          "email", 0, 100);

      ////request.UserName = "helpsystemuser";
      ////request.Pwd = "JanaNesp9*AP4u";
     
      SearchHelpResponseData response = (SearchHelpResponseData)DataCache.DataCache.GetProcessRequest(request, 77);
      Assert.IsTrue(response.IsSuccess);

    }
  }
}
