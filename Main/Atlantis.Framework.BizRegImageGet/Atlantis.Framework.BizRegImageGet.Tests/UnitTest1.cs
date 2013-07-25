using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Atlantis.Framework.BizRegImageGet.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.BizRegImageGet.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class UnitTest1
  {
    public UnitTest1()
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
    public void BizRegImageGetHasThumbnail80()
    {
      BizRegImageGetResponseData response = null;
      int dataid = 86;
      string dataimagetype = "Thumbnail80";
      BizRegImageGetRequestData request = new BizRegImageGetRequestData(string.Empty, string.Empty, string.Empty, string.Empty, 0, dataid, dataimagetype, 20000);
      response = (BizRegImageGetResponseData)Engine.Engine.ProcessRequest(request, 346);

      Assert.IsTrue(!string.IsNullOrEmpty(response.URL.ImageURL));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void BizRegImageGetNoImage()
    {
      BizRegImageGetResponseData response = null;
      int dataid = 0;
      string dataimagetype = "Thumbnail150";
      BizRegImageGetRequestData request = new BizRegImageGetRequestData(string.Empty, string.Empty, string.Empty, string.Empty, 0, dataid, dataimagetype, 20000);
      response = (BizRegImageGetResponseData)Engine.Engine.ProcessRequest(request, 346);

      Assert.IsTrue(string.IsNullOrEmpty(response.URL.ImageURL));
    }
  }
}
