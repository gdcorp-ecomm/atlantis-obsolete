using System;
using Atlantis.Framework.MyaProductAdSpace.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductAdSpace.Tests
{
  [TestClass]
  public class MyaProductAdSpaceTests
  {
    [TestMethod]
    public void GetMyaAdSpaceProductsValidShopperDefault()
    {
      MyaProductAdSpaceRequestData requestData = new MyaProductAdSpaceRequestData("858346",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      MyaProductAdSpaceResponseData responseData;

      try
      {
        responseData = (MyaProductAdSpaceResponseData)Engine.Engine.ProcessRequest(requestData, 212);

        Console.WriteLine(string.Format("AdSpace product count: {0}", responseData.AdSpaceProducts.Count));
        foreach (AdSpaceProduct adSpaceProduct in responseData.AdSpaceProducts)
        {
          Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", adSpaceProduct.CommonName, adSpaceProduct.IsFree, adSpaceProduct.AccountExpirationDate.ToLongDateString(), adSpaceProduct.IsRenewable);
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
    public void GetMyaAdSpaceProductsValidShopperGetAll()
    {
      MyaProductAdSpaceRequestData requestData = new MyaProductAdSpaceRequestData("858346",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductAdSpaceResponseData responseData;

      try
      {
        responseData = (MyaProductAdSpaceResponseData)Engine.Engine.ProcessRequest(requestData, 212);

        Console.WriteLine(string.Format("AdSpace product count: {0}", responseData.AdSpaceProducts.Count));
        foreach (AdSpaceProduct adSpaceProduct in responseData.AdSpaceProducts)
        {
          Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", adSpaceProduct.CommonName, adSpaceProduct.IsFree, adSpaceProduct.AccountExpirationDate.ToLongDateString(), adSpaceProduct.IsRenewable);
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
    public void GetMyaAdSpaceProductsValidShopperPage1With5PerPage()
    {
      MyaProductAdSpaceRequestData requestData = new MyaProductAdSpaceRequestData("858346",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductAdSpaceResponseData responseData;

      try
      {
        responseData = (MyaProductAdSpaceResponseData)Engine.Engine.ProcessRequest(requestData, 212);

        Console.WriteLine(string.Format("AdSpace product count: {0}", responseData.AdSpaceProducts.Count));
        foreach (AdSpaceProduct adSpaceProduct in responseData.AdSpaceProducts)
        {
          Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", adSpaceProduct.CommonName, adSpaceProduct.IsFree, adSpaceProduct.AccountExpirationDate.ToLongDateString(), adSpaceProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.AdSpaceProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaAdSpaceProductsInvalidShopper()
    {
      MyaProductAdSpaceRequestData requestData = new MyaProductAdSpaceRequestData("2326554512213554",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductAdSpaceResponseData responseData;

      try
      {
        responseData = (MyaProductAdSpaceResponseData)Engine.Engine.ProcessRequest(requestData, 212);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.AdSpaceProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
