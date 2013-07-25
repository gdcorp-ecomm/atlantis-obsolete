using System;
using Atlantis.Framework.MyaProductSSL.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductSSL.Tests
{
  [TestClass]
  public class MyaProductSSLTests
  {
    [TestMethod]
    public void GetMyaSSLProductsValidShopperDefault()
    {
      //expring shoppers 839627 824606 822286 832127
      MyaProductSSLRequestData requestData = new MyaProductSSLRequestData("832127",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      MyaProductSSLResponseData responseData;

      try
      {
        responseData = (MyaProductSSLResponseData)Engine.Engine.ProcessRequest(requestData, 183);

        Console.WriteLine(string.Format("SSL product count: {0}", responseData.SSLProducts.Count));
        foreach (SSLProduct SSLProduct in responseData.SSLProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}", SSLProduct.CommonName, SSLProduct.AccountExpirationDate.ToLongDateString(), SSLProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaSSLProductsValidShopperGetAll()
    {
      MyaProductSSLRequestData requestData = new MyaProductSSLRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductSSLResponseData responseData;

      try
      {
        responseData = (MyaProductSSLResponseData)Engine.Engine.ProcessRequest(requestData, 183);

        Console.WriteLine(string.Format("SSL product count: {0}", responseData.SSLProducts.Count));
        foreach (SSLProduct SSLProduct in responseData.SSLProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}", SSLProduct.CommonName, SSLProduct.AccountExpirationDate.ToLongDateString(), SSLProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaSSLProductsValidShopperPage1With5PerPage()
    {
      MyaProductSSLRequestData requestData = new MyaProductSSLRequestData("856907",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductSSLResponseData responseData;

      try
      {
        responseData = (MyaProductSSLResponseData)Engine.Engine.ProcessRequest(requestData, 183);

        Console.WriteLine(string.Format("SSL product count: {0}", responseData.SSLProducts.Count));
        foreach (SSLProduct SSLProduct in responseData.SSLProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}", SSLProduct.CommonName, SSLProduct.AccountExpirationDate.ToLongDateString(), SSLProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.SSLProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaSSLProductsInvalidShopper()
    {
      MyaProductSSLRequestData requestData = new MyaProductSSLRequestData("2326554512213554",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductSSLResponseData responseData;

      try
      {
        responseData = (MyaProductSSLResponseData)Engine.Engine.ProcessRequest(requestData, 183);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.SSLProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
