using System;
using Atlantis.Framework.MyaProductFaxThruEmail.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductFaxThruEmail.Tests
{
  [TestClass]
  public class MyaProductFaxThruEmailTests
  {
    [TestMethod]
    public void GetMyaFaxThruEmailProductsValidShopperDefault()
    {
      MyaProductFaxThruEmailRequestData requestData = new MyaProductFaxThruEmailRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      MyaProductFaxThruEmailResponseData responseData;

      try
      {
        responseData = (MyaProductFaxThruEmailResponseData)Engine.Engine.ProcessRequest(requestData, 188);

        Console.WriteLine(string.Format("FaxThruEmail product count: {0}", responseData.FaxThruEmailProducts.Count));
        foreach (FaxThruEmailProduct FaxThruEmailProduct in responseData.FaxThruEmailProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}, Is Free: {3}", FaxThruEmailProduct.CommonName, FaxThruEmailProduct.AccountExpirationDate.ToLongDateString(), FaxThruEmailProduct.IsRenewable, FaxThruEmailProduct.IsFree);
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
    public void GetMyaFaxThruEmailProductsValidShopperGetAll()
    {
      MyaProductFaxThruEmailRequestData requestData = new MyaProductFaxThruEmailRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductFaxThruEmailResponseData responseData;

      try
      {
        responseData = (MyaProductFaxThruEmailResponseData)Engine.Engine.ProcessRequest(requestData, 188);

        Console.WriteLine(string.Format("FaxThruEmail product count: {0}", responseData.FaxThruEmailProducts.Count));
        foreach (FaxThruEmailProduct FaxThruEmailProduct in responseData.FaxThruEmailProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}, Is Free: {3}", FaxThruEmailProduct.CommonName, FaxThruEmailProduct.AccountExpirationDate.ToLongDateString(), FaxThruEmailProduct.IsRenewable, FaxThruEmailProduct.IsFree);
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
    public void GetMyaFaxThruEmailProductsValidShopperPage1With5PerPage()
    {
      MyaProductFaxThruEmailRequestData requestData = new MyaProductFaxThruEmailRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductFaxThruEmailResponseData responseData;

      try
      {
        responseData = (MyaProductFaxThruEmailResponseData)Engine.Engine.ProcessRequest(requestData, 188);

        Console.WriteLine(string.Format("FaxThruEmail product count: {0}", responseData.FaxThruEmailProducts.Count));
        foreach (FaxThruEmailProduct FaxThruEmailProduct in responseData.FaxThruEmailProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}, Is Free: {3}", FaxThruEmailProduct.CommonName, FaxThruEmailProduct.AccountExpirationDate.ToLongDateString(), FaxThruEmailProduct.IsRenewable, FaxThruEmailProduct.IsFree);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.FaxThruEmailProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaFaxThruEmailProductsInvalidShopper()
    {
      MyaProductFaxThruEmailRequestData requestData = new MyaProductFaxThruEmailRequestData("2326554512213554",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductFaxThruEmailResponseData responseData;

      try
      {
        responseData = (MyaProductFaxThruEmailResponseData)Engine.Engine.ProcessRequest(requestData, 188);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.FaxThruEmailProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
