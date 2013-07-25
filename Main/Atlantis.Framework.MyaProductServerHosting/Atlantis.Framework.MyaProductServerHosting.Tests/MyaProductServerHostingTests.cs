using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductServerHosting.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductServerHosting.Tests
{
  [TestClass]
  public class GetMyaProductServerHostingTests
  {
    private const string _shopperId = "855552";
    private const int _requestType = 185;

    public GetMyaProductServerHostingTests()
    { }

    #region Dedicated Server Tests

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaDedicatedHostingProductsValidShopperDefault()
    {
      MyaProductServerHostingRequestData requestData = new MyaProductServerHostingRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1
         , true
         , MyaProductServerHostingRequestData.ServerType.DedHosting);

      MyaProductServerHostingResponseData responseData;
      try
      {
        responseData = (MyaProductServerHostingResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Dedicated Hosting product count: {0}", responseData.ServerHostingProducts.Count));
        foreach (ServerHostingProduct dedicatedHostingProduct in responseData.ServerHostingProducts)
        {
          dedicatedHostingProduct.CommonName = "Dedicated Hosting";
          DebugWrite(dedicatedHostingProduct);
        }

        Debug.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Debug.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Debug.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Debug.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.IsSuccess);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaDedicatedHostingProductsValidShopperGetAll()
    {
      MyaProductServerHostingRequestData requestData = new MyaProductServerHostingRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1
         , true
         , MyaProductServerHostingRequestData.ServerType.DedHosting); 

      requestData.PagingInfo.ReturnAll = true;

      MyaProductServerHostingResponseData responseData;

      try
      {
        responseData = (MyaProductServerHostingResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Dedicated Hosting product count: {0}", responseData.ServerHostingProducts.Count));
        foreach (ServerHostingProduct dedicatedHostingProduct in responseData.ServerHostingProducts)
        {
          DebugWrite(dedicatedHostingProduct);
        }

        Debug.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Debug.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.IsSuccess);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaDedicatedHostingProductsValidShopperPage1With5PerPage()
    {
      MyaProductServerHostingRequestData requestData = new MyaProductServerHostingRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1
         , true
         , MyaProductServerHostingRequestData.ServerType.DedHosting); 

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductServerHostingResponseData responseData;

      try
      {
        responseData = (MyaProductServerHostingResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Dedicated Hosting product count: {0}", responseData.ServerHostingProducts.Count));
        foreach (ServerHostingProduct dedicatedHostingProduct in responseData.ServerHostingProducts)
        {
          DebugWrite(dedicatedHostingProduct);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.ServerHostingProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaDedicatedHostingProductsInvalidShopper()
    {
      MyaProductServerHostingRequestData requestData = new MyaProductServerHostingRequestData("2326554512213554"
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1
         , true
         , MyaProductServerHostingRequestData.ServerType.DedHosting); 

      requestData.PagingInfo.ReturnAll = true;

      MyaProductServerHostingResponseData responseData;

      try
      {
        responseData = (MyaProductServerHostingResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.ServerHostingProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    #endregion

    #region Virtual Dedicated Server Tests

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaVDedicatedHostingProductsValidShopperGetAll()
    {
      MyaProductServerHostingRequestData requestData = new MyaProductServerHostingRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1
         , true
         , MyaProductServerHostingRequestData.ServerType.VDedHosting);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductServerHostingResponseData responseData;

      try
      {
        responseData = (MyaProductServerHostingResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Virt Dedicated Hosting product count: {0}", responseData.ServerHostingProducts.Count));
        foreach (ServerHostingProduct vdedHostingProduct in responseData.ServerHostingProducts)
        {
          DebugWrite(vdedHostingProduct);
        }

        Debug.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Debug.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.IsSuccess);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    #endregion

    #region Ded and VDed combo tests

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaDevAndVDedComboHostingProductsValidShopperGetAll()
    {
      MyaProductServerHostingRequestData requestData = new MyaProductServerHostingRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1
         , true
         , MyaProductServerHostingRequestData.ServerType.Ded_And_VDedHosting);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductServerHostingResponseData responseData;

      try
      {
        responseData = (MyaProductServerHostingResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Server Hosting product count: {0}", responseData.ServerHostingProducts.Count));
        foreach (ServerHostingProduct serverHostingProduct in responseData.ServerHostingProducts)
        {
          DebugWrite(serverHostingProduct);
        }

        Debug.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Debug.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.IsSuccess);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    #endregion

    #region Helper methods

    private static void DebugWrite(ServerHostingProduct product)
    {
      Debug.WriteLine("CommonName: {0}, ProductTypeId: {5}, ProductType: {6}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}, IsPending: {4}", product.CommonName, product.IsFree, product.AccountExpirationDate.ToLongDateString(), product.IsRenewable, product.IsPendingSetup, product.ProductTypeId, product.ProductType);
    }

    #endregion

  }
}
