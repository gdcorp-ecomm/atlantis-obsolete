using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.OrionGetUsage.Impl;
using Atlantis.Framework.OrionGetUsage.Interface;
using System;


namespace Atlantis.Framework.OrionGetUsage.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class OrionGetUsageTests
  {
    const string _shopper_id = "840820";
    string _orionResourceId = "7b233a4b-979b-497e-80ed-5dde71a31b0d"; //"be9297bc-f8e6-49a5-9b95-33db354271f1";    
    string _usageType = "DISK_SPACE";
    DateTime _startDate = Convert.ToDateTime("07/21/2006");
    DateTime _endDate = Convert.ToDateTime("08/21/2006");
    TimeSpan _timeout = new TimeSpan(0, 0, 30);
    int _requestType = 127;

    public OrionGetUsageTests()
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
    public void OrionGetUsageTest()
    {
      OrionGetUsageRequestData request = new OrionGetUsageRequestData(_shopper_id
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , _orionResourceId
         , _usageType
         , _startDate
         , _endDate
         , _timeout);

      OrionGetUsageResponseData response = (OrionGetUsageResponseData)Engine.Engine.ProcessRequest(request, _requestType);

      //This line is needed for test harness only...
      //invoke datacache to properly load dll so call to datacache within OrionGetUsageRequest works
      DataCache.DataCache.GetPrivateLabelType(1);  

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
