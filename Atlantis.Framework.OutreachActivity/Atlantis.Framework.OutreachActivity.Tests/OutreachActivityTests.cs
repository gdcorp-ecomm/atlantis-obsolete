using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.OutreachActivity.Impl;
using Atlantis.Framework.OutreachActivity.Interface;
using System;

namespace Atlantis.Framework.OutreachActivity.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetOutreachActivityTests
  {
  
    private const string _shopperId = "";
	
	
    public GetOutreachActivityTests()
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
    public void OutreachActivityTest()
    {
      string orionId = "CE8B08DB-AFDE-4FD6-AF3E-A0F1CBC10510";
      DateTime dateStart = new DateTime(2010, 2, 22);
      DateTime dateEnd = new DateTime(2010, 3, 21);
      
      OutreachActivityRequestData request = new OutreachActivityRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , orionId
         , dateStart
         , dateEnd);

      OutreachActivityResponseData response = (OutreachActivityResponseData)Engine.Engine.ProcessRequest(request, 160);

      // Cache call
      //OutreachActivityResponseData response = (OutreachActivityResponseData)DataCache.DataCache.GetProcessRequest(request, _requestType);

      //
      // TODO: Add test logic here
      //

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
