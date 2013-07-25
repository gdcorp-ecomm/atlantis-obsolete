﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.LogDomainSearchResults.Interface;

namespace Atlantis.Framework.LogDomainSearchResults.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class LogDomainSearchResults
  {
    private const string _shopperId = "856045";

    public LogDomainSearchResults()
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
    public void TestMethod1()
    {
      /*
     * <domainSearch>
     *    <search visitGuid='108753C2-D5BB-4A44-895F-975923ACA480' time='2009-10-19 14:24:56.580' pageCount='1' domain='xyz.com' isAvailable='1'>
     *      <results>
     *        <suggested domain='xyz.net' registrationType='1' area='1' position='1' price='1099'>
     *        <suggested domain='xyz.info' registrationType='1' area='1' position='2' price='1099'>
     *      </results>
     *   </search>
     * </domainSearch>
     * 
     * Description:
     * <search - Contains the domain name being searched. only 1 expected.
     *      visitGUid -- from pathway cookie        
     *      time -- datetime
     *      pageCount -- from pageCount cookie
     *      domain -- domain name being searched. ex: xyz123.com
     *      isAvailable -- 0 = not available, 1 = available 
     *   <results> 
     *      <suggested -- a node for each result
     *          domain -- domain name being suggested. ex: xyz123.net   
     *          registrationType -- 0 , 1, 2, (0=Backorder, 1=PreRegistration, 2=Registration, 3=Transfer, 4=Bulk, 5=BulkTransfer)
     *          area -- strip mall, additional, premium, international, pricing)
     *          position -- position it appears in the list (1,2,3,etc for first, second, ...) 
     *          price -- price displayed to shopper (no decimals)
     *          spunName -- type of spun name (0-not spun, 1-internal, 2-external). Internal represents the  prefix and suffix names 's', 'site', etc.  External are the names obtained by DomainsBot.
     *   </results>
     * </search>
     */
      LogDomainSearchResultsRequestData request = new LogDomainSearchResultsRequestData(_shopperId, string.Empty, string.Empty, string.Empty, 0,
                                                                                        "xyz.com", 1);
      request.AddSuggestedDomain("xyz.net", SuggestedRegistrationType.PreRegistration, 3, 1, "1099", 0, SuggestedSpunName.NotSpun, DomainAvailability.Available);
      request.AddSuggestedDomain("xyz.info", SuggestedRegistrationType.PreRegistration, 1, 2, "1099", 0, SuggestedSpunName.NotSpun, DomainAvailability.Available);      
      LogDomainSearchResultsResponseData response = (LogDomainSearchResultsResponseData)Engine.Engine.ProcessRequest(request, 130);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
