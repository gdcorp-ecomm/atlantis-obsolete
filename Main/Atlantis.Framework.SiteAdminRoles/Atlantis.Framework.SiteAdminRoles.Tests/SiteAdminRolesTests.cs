using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.SiteAdminRoles.Interface;
using System.Security.Principal;
using System.Threading;
using System.DirectoryServices.AccountManagement;

namespace Atlantis.Framework.SiteAdminRoles.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class SiteAdminRolesTests
  {
    public SiteAdminRolesTests()
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
    public void SiteAdminRolesBasic()
    {
      SiteAdminRolesRequestData request = new SiteAdminRolesRequestData(
        string.Empty, string.Empty, string.Empty, string.Empty, 0, 1);
      SiteAdminRolesResponseData response = (SiteAdminRolesResponseData)DataCache.DataCache.GetProcessRequest(request, 222);

      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    public void ResponseDataActiveDirectoryCheck()
    {
      HashSet<string> allowedGroups = new HashSet<string>();
      allowedGroups.Add(@"jomax\acarradus");
      allowedGroups.Add(@"jomax\corpwebadmins");

      SiteAdminRolesResponseData response = new SiteAdminRolesResponseData(1, allowedGroups);

      WindowsIdentity user = WindowsIdentity.GetCurrent();
      bool isAllowed = response.IsUserAllowed(user);

      Assert.IsTrue(isAllowed);
    }

  }
}
