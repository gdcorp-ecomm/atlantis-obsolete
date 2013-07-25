using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetGuestbookPage.Interface;
using AddGuestbook = Atlantis.Framework.AddGuestbookComment.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for GuestbookTests
  /// </summary>
  [TestClass]
  public class GuestbookTests
  {
    public GuestbookTests()
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
    public void GetGuestbookPage()
    {
      GetGuestbookPageRequestData request = new GetGuestbookPageRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0, 47397, "www.godaddy.com");
      request.FirstCommentRow = 1;
      request.CommentsPerPage = 20;
      GetGuestbookPageResponseData response = (GetGuestbookPageResponseData)DataCache.DataCache.GetProcessRequest(request, EngineRequests.GetGuestbookPage);
      Assert.IsTrue(response.GetComments().Count > 0);

      request = new GetGuestbookPageRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0, 47397, "www.godaddy.com");
      request.FirstCommentRow = 20;
      response = (GetGuestbookPageResponseData)DataCache.DataCache.GetProcessRequest(request, EngineRequests.GetGuestbookPage);
      Assert.IsTrue(response.GetComments().Count > 0);

    }

    [TestMethod]
    public void AddGuestbookComment()
    {
      AddGuestbook.AddGuestbookCommentRequestData request = new AddGuestbook.AddGuestbookCommentRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0,
        47397, "www.godaddy.com", "Unit Tester", "mmicco@godaddy.com", Guid.NewGuid().ToString() + " is the best guid ever!");
      request.CommentType = 1;
      AddGuestbook.AddGuestbookCommentResponseData response = (AddGuestbook.AddGuestbookCommentResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.AddGuestbookComment);
      Assert.IsTrue(response.Result == "Success");
    }
  }
}
