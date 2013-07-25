using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.SearchDiscussions.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;

namespace Atlantis.Framework.SearchDiscussions.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class SearchDiscussionsTests
  {
    private const string _shopperId = "832652";

    public SearchDiscussionsTests()
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
    public void SearchDiscussionsBasic()
    {
      SearchDiscussionsRequestData request = new SearchDiscussionsRequestData(_shopperId, string.Empty, string.Empty, string.Empty, 0, 195,
                                                                            "test ", 25, 1, DateTime.MinValue, 24);
      SearchDiscussionsResponseData response = (SearchDiscussionsResponseData)DataCache.DataCache.GetProcessRequest(request, 76);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
