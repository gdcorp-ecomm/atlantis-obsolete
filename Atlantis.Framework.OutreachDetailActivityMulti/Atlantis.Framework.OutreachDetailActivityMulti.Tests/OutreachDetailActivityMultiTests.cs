using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.OutreachDetailActivityMulti.Impl;
using Atlantis.Framework.OutreachDetailActivityMulti.Interface;
using System;

namespace Atlantis.Framework.OutreachDetailActivityMulti.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetOutreachDetailActivityMultiTests
  {
  
    private const string _shopperId = "";
	
	
    public GetOutreachDetailActivityMultiTests()
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
    public void OutreachDetailActivityMultiTest()
    {

      ////////CE8B08DB-AFDE-4FD6-AF3E-A0F1CBC10510 
      ////////9A006F20-AA4E-4D2F-B900-C463EBFC08BA  
      ////////E6E012C8-FAF0-11DE-9D9E-005056956427  
      ////////E6E012C9-FAF0-11DE-9D9E-005056956427  
      ////////15424558-FD3B-4EE8-BF70-87831D48F854 
      ////////F41FA89F-FA7E-4E32-B91E-A6F096597F50  
      DateTime dateStart = new DateTime(2010, 2, 22);
      DateTime dateEnd = new DateTime(2010, 3, 21);

     OutreachDetailActivityMultiRequestData request = new OutreachDetailActivityMultiRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0 );

      OutreachDetailActivityAccount account1 = new OutreachDetailActivityAccount("CE8B08DB-AFDE-4FD6-AF3E-A0F1CBC10510", dateStart, dateEnd);
      OutreachDetailActivityAccount account2 = new OutreachDetailActivityAccount("9A006F20-AA4E-4D2F-B900-C463EBFC08BA", dateStart, dateEnd);
      OutreachDetailActivityAccount account3 = new OutreachDetailActivityAccount("E6E012C8-FAF0-11DE-9D9E-005056956427", dateStart, dateEnd);
      OutreachDetailActivityAccount account4 = new OutreachDetailActivityAccount("E6E012C9-FAF0-11DE-9D9E-005056956427", dateStart, dateEnd);
      OutreachDetailActivityAccount account5 = new OutreachDetailActivityAccount("15424558-FD3B-4EE8-BF70-87831D48F854", dateStart, dateEnd);

      request.AddOutreachAccount(account1);
      request.AddOutreachAccount(account2);
      request.AddOutreachAccount(account3);
      request.AddOutreachAccount(account4);
      request.AddOutreachAccount(account5);

      OutreachDetailActivityMultiResponseData response = (OutreachDetailActivityMultiResponseData)Engine.Engine.ProcessRequest(request, 164);
      
	  // Cache call
	  //OutreachDetailActivityMultiResponseData response = (OutreachDetailActivityMultiResponseData)DataCache.DataCache.GetProcessRequest(request, _requestType);

      //
      // TODO: Add test logic here
      //
	  
      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
