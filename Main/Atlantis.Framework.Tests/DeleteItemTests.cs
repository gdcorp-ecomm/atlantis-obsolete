using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DeleteItem.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for DeleteItemTests
  /// </summary>
  [TestClass]
  public class DeleteItemTests
  {
    public DeleteItemTests()
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
    public void DeleteItemStandard()
    {
      // Note used for manuall debugging only as you have to 
      // supply your own row and item id
      int rowId = 3;
      int itemId = 6;
      string shopperId = "832652";

      DeleteItemRequestData request = new DeleteItemRequestData(shopperId, string.Empty,
        string.Empty, string.Empty, 0);
      request.AddItem(rowId, itemId);
      DeleteItemResponseData response = (DeleteItemResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.CartItemDelete);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
