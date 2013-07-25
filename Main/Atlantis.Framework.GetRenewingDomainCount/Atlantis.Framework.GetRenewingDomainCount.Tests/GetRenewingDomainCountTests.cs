using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.GetRenewingDomainCount.Impl;
using Atlantis.Framework.GetRenewingDomainCount.Interface;


namespace Atlantis.Framework.GetRenewingDomainCount.Tests
{
 
  [TestClass]
  public class GetRenewingDomainCountTests
  {
  
    private const string _shopperId = "842749";
    private const int _daysFromExpire = 300;
    private const int _requestType = 94;
	
    public GetRenewingDomainCountTests()
    {
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
    // public static void MyClassInitialize(TestContext testContext) {    
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
    public void GetRenewingDomainCountTest()
    {
     GetRenewingDomainCountRequestData request = new GetRenewingDomainCountRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , _daysFromExpire);

      	    
	    GetRenewingDomainCountResponseData response = (GetRenewingDomainCountResponseData)DataCache.DataCache.GetProcessRequest(request, _requestType);
          	  
      Debug.WriteLine(string.Format("ExpiringDomains::{0}", response.ExpiringDomains));
      Debug.WriteLine(string.Format("ExpiredDomains::{0}", response.ExpiredDomains));
   
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SerializeTest()
    {
       GetRenewingDomainCountRequestData request = new GetRenewingDomainCountRequestData(_shopperId
          , string.Empty
          , string.Empty
          , string.Empty
          , 0
          , _daysFromExpire);

       GetRenewingDomainCountResponseData response = (GetRenewingDomainCountResponseData)DataCache.DataCache.GetProcessRequest(request, _requestType);

       string xml = response.ToXML();
       Debug.WriteLine(xml);
       int expiringCount = response.ExpiringDomains;
       int expiredCount = response.ExpiredDomains;

       response = new GetRenewingDomainCountResponseData(xml);

       Assert.AreEqual(response.ExpiredDomains + response.ExpiringDomains, expiredCount + expiringCount);
    }
  }
}
