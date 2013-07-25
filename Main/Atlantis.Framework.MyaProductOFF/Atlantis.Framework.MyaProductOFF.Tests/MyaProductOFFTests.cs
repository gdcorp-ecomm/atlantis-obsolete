using System;
using Atlantis.Framework.MyaProductOFF.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductOFF.Tests
{
  [TestClass]
  public class MyaProductOFFTests
  {
    [TestMethod]
    public void GetMyaOFFProductsValidShopperDefault()
    {
      MyaProductOFFRequestData requestData = new MyaProductOFFRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      MyaProductOFFResponseData responseData;

      try
      {
        responseData = (MyaProductOFFResponseData)Engine.Engine.ProcessRequest(requestData, 189);

        Console.WriteLine(string.Format("OFF product count: {0}", responseData.OFFProducts.Count));
        foreach (OFFProduct OFFProduct in responseData.OFFProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}", OFFProduct.CommonName, OFFProduct.AccountExpirationDate.ToLongDateString(), OFFProduct.IsRenewable);
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
    public void GetMyaOFFProductsValidShopperGetAll()
    {
      MyaProductOFFRequestData requestData = new MyaProductOFFRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductOFFResponseData responseData;

      try
      {
        responseData = (MyaProductOFFResponseData)Engine.Engine.ProcessRequest(requestData, 189);

        Console.WriteLine(string.Format("OFF product count: {0}", responseData.OFFProducts.Count));
        foreach (OFFProduct OFFProduct in responseData.OFFProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}", OFFProduct.CommonName, OFFProduct.AccountExpirationDate.ToLongDateString(), OFFProduct.IsRenewable);
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
    public void GetMyaOFFProductsValidShopperPage1With5PerPage()
    {
      MyaProductOFFRequestData requestData = new MyaProductOFFRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductOFFResponseData responseData;

      try
      {
        responseData = (MyaProductOFFResponseData)Engine.Engine.ProcessRequest(requestData, 189);

        Console.WriteLine(string.Format("OFF product count: {0}", responseData.OFFProducts.Count));
        foreach (OFFProduct OFFProduct in responseData.OFFProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}", OFFProduct.CommonName, OFFProduct.AccountExpirationDate.ToLongDateString(), OFFProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.OFFProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaOFFProductsInvalidShopper()
    {
      MyaProductOFFRequestData requestData = new MyaProductOFFRequestData("2326554512213554",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductOFFResponseData responseData;

      try
      {
        responseData = (MyaProductOFFResponseData)Engine.Engine.ProcessRequest(requestData, 189);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.OFFProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
