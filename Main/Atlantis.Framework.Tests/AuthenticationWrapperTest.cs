using Atlantis.Framework.BasePages.Authentication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  ///This is a test class for AuthenticationWrapperTest and is intended
  ///to contain all AuthenticationWrapperTest Unit Tests
  ///</summary>
  [TestClass()]
  public class AuthenticationWrapperTest
  {
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

    /// <summary>
    ///A test for Authentication
    ///</summary>
    [TestMethod()]
    [DeploymentItem("Atlantis.Framework.BasePages.dll")]
    public void GetMgrDecryptedValues()
    {
      using (AuthenticationWrapper_Accessor target = new AuthenticationWrapper_Accessor())
      {
        string mstk = "kfaeoglbeatbcaohdiieudyfiiejfdpcqgbiocfglfpfzdaaljoiaioebichcjrcaijjmbtdocgfrcnbxcgfojvggbkbqfne";
        //string mstk = "ieuuairoaodoufadoiufaoduf";
        object userId;
        object userName;
        int result = target.Authentication.GetMgrDecryptedValues(mstk, out userId, out userName);

        Assert.AreNotEqual(0, userId.ToString().Length);
      }
    }
  }
}
