using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.Engine;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetCreditSummary.Impl;
using Atlantis.Framework.GetCreditSummary.Interface;

namespace Atlantis.Framework.GetCreditSummary.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetCreditSummaryTests
  {
    public GetCreditSummaryTests()
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
    public void GetCreditSummary()
    {
      string expectedResponseXML = "<RESPONSE><MESSAGE>Success</MESSAGE><CREDITS totalCredits=\"3\"><CREDIT><DisplayGroupID>4</DisplayGroupID><DisplayGroup>Turbo SSL (1 Year)</DisplayGroup><CreditType>Paid</CreditType><AvailableCredit>1</AvailableCredit></CREDIT><CREDIT><DisplayGroupID>43</DisplayGroupID><DisplayGroup>Turbo SSL</DisplayGroup><CreditType>Paid</CreditType><AvailableCredit>1</AvailableCredit></CREDIT><CREDIT><DisplayGroupID>49</DisplayGroupID><DisplayGroup>SSL</DisplayGroup><CreditType>Paid</CreditType><AvailableCredit>1</AvailableCredit></CREDIT></CREDITS></RESPONSE>";
      GetCreditSummaryRequestData request = new GetCreditSummaryRequestData("856601", "http://localhost", "", "", 0);
      GetCreditSummaryResponseData response = (GetCreditSummaryResponseData)Engine.Engine.ProcessRequest(request, 82);
      Assert.AreEqual(expectedResponseXML,response.ResponseXML,false);
    }

    [TestMethod]
    [ExpectedException(typeof(AtlantisException))]
    public void InvalidShopper()
    {
      GetCreditSummaryRequestData request = new GetCreditSummaryRequestData("bogusShopperDude", "http://localhost", "", "", 0);
      GetCreditSummaryResponseData response = (GetCreditSummaryResponseData)Engine.Engine.ProcessRequest(request, 82);
    }
  }
}
