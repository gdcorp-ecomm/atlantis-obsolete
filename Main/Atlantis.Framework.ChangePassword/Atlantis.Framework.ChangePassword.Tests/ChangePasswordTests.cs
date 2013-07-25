using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.ChangePassword.Interface;
using Atlantis.Framework.Interface;
using System.Threading;

namespace Atlantis.Framework.ChangePassword.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class ChangePasswordTests
  {
    // shopper in DEV used by these tests (made specifically for them)
    private const string _shopperId = "856084";
    private const string _userName1 = "joepassword";
    private const string _userName2 = "joepassword2";
    private const string _pw1 = "password";
    private const string _pw2 = "password2";
    private const string _pw3 = "Password222";
    private const string _hint1 = "pw";
    private const string _hint2 = "pw2";

    public ChangePasswordTests()
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
    public void ChangePasswordNoCapital()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, "weakpassword", "weak pw", _userName1, true);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.PasswordStrengthNoCapital));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordNoNumber()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, "Weakpassword", "weak pw", _userName1, true);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.PasswordStrengthNoNumeric));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [ExpectedException(typeof(AtlantisException))]
    public void ChangePasswordNonsecureWSInConfig()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, "weakpassword", "weak pw", _userName1, true);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 1071);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordMinLength()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, "Wkpw5", "weak pw", _userName1, true);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.PasswordToShort));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordLoginNameUsed()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, _pw1, _hint1, "testarvind", false);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.LoginAlreadyTaken));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordInvalidAuthentication()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, "password7", _pw1, _hint1, _userName1, false);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.Failure));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordInvalidHintPassword()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _userName1, _pw1, _pw1, _userName1, false);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.PasswordHintMatch));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordInvalidHintLogin()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, _pw1, _userName1, _userName1, false);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.LoginHintMatch));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordInvalidLoginPassword()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, _userName1, _hint1, _userName1, false);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsFalse(response.IsSuccess);
      Assert.IsTrue(response.StatusCodes.Contains(ChangePasswordStatusCodes.LoginPasswordMatch));
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ChangePasswordValid()
    {
      ChangePasswordRequestData request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw1, _pw2, _hint1, _userName1, false);
      ChangePasswordResponseData response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsTrue(response.IsSuccess);

      Thread.Sleep(500);

      request = new ChangePasswordRequestData(
        _shopperId, string.Empty, string.Empty, string.Empty, 0,
        1, _pw2, _pw1, _hint1, _userName1, false);
      response = (ChangePasswordResponseData)Engine.Engine.ProcessRequest(request, 71);
      Assert.IsTrue(response.IsSuccess);
    }

  }
}
