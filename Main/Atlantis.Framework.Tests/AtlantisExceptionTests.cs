using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DataProvider.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for AtlantisExceptionTests
  /// </summary>
  [TestClass]
  public class AtlantisExceptionTests
  {
    public AtlantisExceptionTests()
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
    public void TestExceptionLogging()
    {
      try
      {
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms.Add("shopper_id", "822497");
        parms.Add("profile_id", "150256");
        DataProviderRequestData request = new DataProviderRequestData("822497",
          string.Empty, string.Empty, string.Empty, 0, "somewrongrequestname", parms);
        DataProviderResponseData response = null;
        response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
      }
      catch (AtlantisException ex)
      {
        Assert.IsNotNull(ex);
      }
      catch (Exception)
      {
        Assert.Fail();
      }
    }

    private static string getIPAddress()
    {
      string hostName = System.Net.Dns.GetHostName();
      System.Net.IPHostEntry ip = System.Net.Dns.GetHostEntry(hostName);
      System.Net.IPAddress[] ipList = ip.AddressList;
      return ipList[0].ToString();
    }
  }
}
