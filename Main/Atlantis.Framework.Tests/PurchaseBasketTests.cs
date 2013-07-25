using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.PurchaseBasket.Interface;

namespace Atlantis.Framework.Tests
{
  /// <summary>
  /// Summary description for PurchaseBasketTests
  /// </summary>
  [TestClass]
  public class PurchaseBasketTests
  {
    public PurchaseBasketTests()
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

    [DeploymentItem("Interop.gdBaskerHelperLib.dll")]
    [TestMethod]
    public void PurchaseBasketSmokeTest()
    {
      PurchaseBasketRequestData request = new PurchaseBasketRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0);

      PaymentUseGiftCard gc1 = new PaymentUseGiftCard();
      gc1.AccountNumber = "702791";
      gc1.Amount = 100;
      request.AddPayment(gc1);

      PaymentUseGiftCard gc2 = new PaymentUseGiftCard();
      gc2.AccountNumber = "702792";
      gc2.Amount = 100;
      request.AddPayment(gc2);

      PaymentUseCreditCard cc = new PaymentUseCreditCard();
      cc.AccountName = "GoDaddy";
      cc.AccountNumber = "6011111111111117";
      cc.Type = "Discover";
      cc.NoCVV = "1";
      cc.ExpirationMonth = 12;
      cc.ExpirationYear = 2012;
      cc.Amount = 500;
      request.AddPayment(cc);

      PurchaseBasketResponseData response = (PurchaseBasketResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.PurchaseBasket);
      Assert.IsTrue(response.IsSuccess);
    }

    [DeploymentItem("Interop.gdBaskerHelperLib.dll")]
    [TestMethod]
    public void PurchaseBasketInvalidCC()
    {
      string presetXml = "<PaymentInformation><PaymentOrigin order_billing=\"domestic\" _repversion=\"-1\" refunded_by=\"\" entered_by=\"customer\" _webserver=\"cart.debug.godaddy-com.ide\" from_app=\"\" order_source=\"Online\" remote_addr=\"127.0.0.1\" remote_host=\"127.0.0.1\" currencyDisplay=\"USD\" /><BillingInfo street1=\"12246 N 59th St\" street2=\"\" city=\"Scottsdale\" email=\"mmicco@godaddy.com\" fax=\"\" first_name=\"Michael\" last_name=\"Micco\" company=\"\" country=\"us\" state=\"NA\" zip=\"85254\" phone1=\"303-333-3333\" phone2=\"(480) 609-8682 \" /><Payments><CCPayment account_number=\"|BASKETDEV200904|1l2rqhNZA2u4fghSlstogocpgHl1MOVhafVWpFFmlvi4AqDuudrz2c9bB7RG7Q/O&#xD;&#xA;1xn9jhgqtoRGBwBfIM41XnFq6HqS2yMcBlLYjUmgKeqBwvjJP8jpHLSCLwtK8U2e&#xD;&#xA;9He+DVv4KONe5AUFlQCla2bhHeNhoXUUywDIwhirsTGXN7B08kfyMgjwNvJIh6zj&#xD;&#xA;2AckY3s9eB4OHaH+7eDAKY4LxZVnW4wmmO7i76JipweLSnuaOkvaYasz50nceBsA&#xD;&#xA;TXjqxWyl0cc+9Mr+NA21Nht4hKRN+i62VWEalzVoTUuaYLZri97DCrkUiMoIfSMX&#xD;&#xA;as+ZT38rpyHGA/bdlmL8Mg==&#xD;&#xA;\" type=\"Discover\" expmonth=\"3\" expyear=\"2012\" account_name=\"GoDaddy\" cvv=\"\" no_cvv=\"\" /></Payments></PaymentInformation>";
      PurchaseBasketRequestData request = new PurchaseBasketRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0);
      request.AddPrebuiltPurchaseXml(presetXml);
      PurchaseBasketResponseData response = (PurchaseBasketResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.PurchaseBasket);
      Assert.IsTrue(response.IsSuccess);
    }

  }
}
