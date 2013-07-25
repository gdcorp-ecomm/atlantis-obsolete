using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DataProvider.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for DataProviderTests
  /// </summary>
  [TestClass]
  public class DataProviderTests
  {
    public DataProviderTests()
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
    [DeploymentItem("Interop.gdSQLConnect.dll")]
    [DeploymentItem("DataProvider.xml")]
    public void TestDbAccess()
    {
      try
      {
        bool testAsync = false;
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms.Add("shopper_id", "822497");
        parms.Add("profile_id", "150256");
        DataProviderRequestData request = new DataProviderRequestData("822497",
          string.Empty, string.Empty, string.Empty, 0, "buyerprofiledetails", parms);
        DataProviderResponseData response = null;
        if (testAsync)
        {
          IAsyncResult asyncResult = Engine.Engine.BeginProcessRequest(request, EngineRequests.DataProviderRequest, null, null);
          asyncResult.AsyncWaitHandle.WaitOne();
          response = (DataProviderResponseData)Engine.Engine.EndProcessRequest(asyncResult);
        }
        else
        {
          response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
        }
        Assert.IsNotNull(response.GetResponseObject() as DataSet);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }
    [TestMethod]
    [DeploymentItem("Interop.gdSQLConnect.dll")]
    [DeploymentItem("DataProvider.xml")]
    public void TestWsAccess()
    {
      try
      {
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms.Add("xmlInput", "832652");
        DataProviderRequestData request = new DataProviderRequestData("832652",
          string.Empty, string.Empty, string.Empty, 0, "domaincontactcheck_validate", parms);
        DataProviderResponseData response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
        Assert.IsNotNull(response.GetResponseObject() as string);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    [DeploymentItem("Interop.gdSQLConnect.dll")]
    [DeploymentItem("DataProvider.xml")]
    public void DataProviderWebServiceTest()
    {
      try
      {
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms["shopper_id"] = "832652";
        parms["application_id"] = (Int16)2;
        parms["privateLabelId"] = 1;
        DataProviderRequestData request = new DataProviderRequestData("",
          string.Empty, string.Empty, string.Empty, 0, "JustForYouOffers_GetOffersWithPlId", parms);
        request.Timeout = 2000;
        DataProviderResponseData response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
      }
      catch
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    [DeploymentItem("Interop.gdSQLConnect.dll")]
    [DeploymentItem("DataProvider.xml")]
    public void DataProviderDatabaseTest()
    {
      try
      {
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms["shopper_id"] = "832652";
        DataProviderRequestData request = new DataProviderRequestData("",
          string.Empty, string.Empty, string.Empty, 0, "buyerprofiles", parms);
        request.Timeout = 2000;
        DataProviderResponseData response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
      }
      catch
      {
        Assert.Fail();
      }
    }

    [TestMethod]
    [DeploymentItem("DataProvider.xml")]
    public void TestWebServiceOutputVar()
    {
      string xmlInput = "<gdPrivacyApp applicationID=\"4\"><firstName value=\"blue\" /><lastName value=\"puppy\" /><email value=\"blue@puppy.com\" /></gdPrivacyApp>";

      Dictionary<string, object> parms = new Dictionary<string, object>();
      parms.Add("bstrXML", xmlInput);
      parms.Add("pbstrOutput", string.Empty);

      DataProviderRequestData request = new DataProviderRequestData(
        string.Empty, string.Empty, string.Empty, "pathway", 0, "PrivacyAppInsertUpdate", parms);
      DataProviderResponseData response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);

    }

    [TestMethod]
    [DeploymentItem("Interop.gdSQLConnect.dll")]
    [DeploymentItem("DataProvider.xml")]
    public void TestRestAccess()
    {
      try
      {
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms.Add("privateLabelId", "1");
        parms.Add("shopperId", "832652");
        parms.Add("requestType", "MyAccount");
        parms.Add("realtime", "true");
        DataProviderRequestData request = new DataProviderRequestData("832652",
          string.Empty, string.Empty, string.Empty, 0, "menuxmlservice_request", parms);
        DataProviderResponseData response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
        Assert.IsNotNull(response.GetResponseObject() as string);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }
  }
}
