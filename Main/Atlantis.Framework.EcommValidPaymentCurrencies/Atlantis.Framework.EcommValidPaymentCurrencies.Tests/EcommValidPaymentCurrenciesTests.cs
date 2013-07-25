using System;
using Atlantis.Framework.EcommValidPaymentCurrencies.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.EcommValidPaymentCurrencies.Tests
{
  [TestClass]
  public class EcommValidPaymentCurrenciesTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetValidCurrencies()
    {
      EcommValidPaymentCurrenciesRequestData requestData = new EcommValidPaymentCurrenciesRequestData("847235",
                                                                                                      "http://atlantis.framework.ecommvalidpaymenttype.tests/",
                                                                                                      string.Empty,
                                                                                                      Guid.NewGuid().ToString(),
                                                                                                      0,
                                                                                                      "gdshop");
      try
      {
        EcommValidPaymentCurrenciesResponseData responseData = (EcommValidPaymentCurrenciesResponseData)Engine.Engine.ProcessRequest(requestData, 363);

        if (responseData.IsSuccess)
        {
          if(responseData.IsValidPaymentCurrency("USD"))
          {
            Console.WriteLine("USD is a valid payment currency.");
          }

          if(responseData.IsValidPaymentCurrency("GBP"))
          {
            Console.WriteLine("GBP is a valid payment currency.");
          }

          if (responseData.IsValidPaymentCurrency("EUR"))
          {
            Console.WriteLine("EUR is a valid payment currency.");
          }
        }
        else
        {
          Assert.Fail();
        }
      }
      catch (Exception ex)
      {
        Console.Write(ex.Message);
        Assert.Fail();
      }

    }
  }
}
