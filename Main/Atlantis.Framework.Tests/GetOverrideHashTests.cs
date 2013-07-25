using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetOverrideHash.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for GetOverrideHashTests
  /// </summary>
  [TestClass]
  public class GetOverrideHashTests
  {
    public GetOverrideHashTests()
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

    [DeploymentItem("Interop.gdOverrideLib.dll")]
    [TestMethod]
    public void GetCostHash()
    {
      GetOverrideHashRequestData request = new GetOverrideHashRequestData(string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        0,
                                                                        779,
                                                                        1,
                                                                        4001,
                                                                        4001, 5000);
      GetOverrideHashResponseData response = (GetOverrideHashResponseData)Atlantis.Framework.Engine.Engine.ProcessRequest(request, EngineRequests.PriceOverrideHash);
      Console.WriteLine(response.Hash);
    }
  }
}
