using System;
using Atlantis.Framework.MyaProductPhotoAlbum.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductPhotoAlbum.Tests
{
  [TestClass]
  public class MyaProductPhotoAlbumTests
  {
    [TestMethod]
    public void GetMyaPhotoAlbumProductsValidShopperDefault()
    {
      MyaProductPhotoAlbumRequestData requestData = new MyaProductPhotoAlbumRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      MyaProductPhotoAlbumResponseData responseData;

      try
      {
        responseData = (MyaProductPhotoAlbumResponseData)Engine.Engine.ProcessRequest(requestData, 190);

        Console.WriteLine(string.Format("PhotoAlbum product count: {0}", responseData.PhotoAlbumProducts.Count));
        foreach (PhotoAlbumProduct PhotoAlbumProduct in responseData.PhotoAlbumProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}, Is Free: {3}", PhotoAlbumProduct.CommonName, PhotoAlbumProduct.AccountExpirationDate.ToLongDateString(), PhotoAlbumProduct.IsRenewable, PhotoAlbumProduct.IsFree);
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
    public void GetMyaPhotoAlbumProductsValidShopperGetAll()
    {
      MyaProductPhotoAlbumRequestData requestData = new MyaProductPhotoAlbumRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductPhotoAlbumResponseData responseData;

      try
      {
        responseData = (MyaProductPhotoAlbumResponseData)Engine.Engine.ProcessRequest(requestData, 190);

        Console.WriteLine(string.Format("PhotoAlbum product count: {0}", responseData.PhotoAlbumProducts.Count));
        foreach (PhotoAlbumProduct PhotoAlbumProduct in responseData.PhotoAlbumProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}, Is Free: {3}", PhotoAlbumProduct.CommonName, PhotoAlbumProduct.AccountExpirationDate.ToLongDateString(), PhotoAlbumProduct.IsRenewable, PhotoAlbumProduct.IsFree);
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
    public void GetMyaPhotoAlbumProductsValidShopperPage1With5PerPage()
    {
      MyaProductPhotoAlbumRequestData requestData = new MyaProductPhotoAlbumRequestData("857020",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductPhotoAlbumResponseData responseData;

      try
      {
        responseData = (MyaProductPhotoAlbumResponseData)Engine.Engine.ProcessRequest(requestData, 190);

        Console.WriteLine(string.Format("PhotoAlbum product count: {0}", responseData.PhotoAlbumProducts.Count));
        foreach (PhotoAlbumProduct PhotoAlbumProduct in responseData.PhotoAlbumProducts)
        {
          Console.WriteLine("CommonName: {0}, Expiration: {1}, IsRenwable: {2}, Is Free: {3}", PhotoAlbumProduct.CommonName, PhotoAlbumProduct.AccountExpirationDate.ToLongDateString(), PhotoAlbumProduct.IsRenewable, PhotoAlbumProduct.IsFree);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.PhotoAlbumProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    public void GetMyaPhotoAlbumProductsInvalidShopper()
    {
      MyaProductPhotoAlbumRequestData requestData = new MyaProductPhotoAlbumRequestData("2326554512213554",
                                                                                              1,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              string.Empty,
                                                                                              0);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductPhotoAlbumResponseData responseData;

      try
      {
        responseData = (MyaProductPhotoAlbumResponseData)Engine.Engine.ProcessRequest(requestData, 190);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.PhotoAlbumProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
