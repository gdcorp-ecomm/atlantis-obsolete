using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Atlantis.Framework.MyaProductCostcoBundle.Impl;
using Atlantis.Framework.MyaProductCostcoBundle.Interface;
using System;


namespace Atlantis.Framework.MyaProductCostcoBundle.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetMyaProductCostcoBundleTests
  {

    private const string _shopperId = "856907";
    private const int _requestType = 371;


    public GetMyaProductCostcoBundleTests()
    { }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get { return testContextInstance; }
      set { testContextInstance = value; }
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
    public void GetMyaCostcoBundleProductsValidShopperDefault()
    {
      MyaProductCostcoBundleRequestData requestData = new MyaProductCostcoBundleRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1);

      MyaProductCostcoBundleResponseData responseData;
      try
      {
        responseData = (MyaProductCostcoBundleResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CostcoBundleProducts.Count));
        foreach (CostcoBundleProduct costcoBundleProduct in responseData.CostcoBundleProducts)
        {
          costcoBundleProduct.CommonName = "Premium DNS";
          Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", costcoBundleProduct.CommonName, costcoBundleProduct.IsFree, costcoBundleProduct.AccountExpirationDate.ToLongDateString(), costcoBundleProduct.IsRenewable);
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
    public void GetMyaCostcoBundleProductsValidShopperGetAll()
    {
      MyaProductCostcoBundleRequestData requestData = new MyaProductCostcoBundleRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductCostcoBundleResponseData responseData;

      try
      {
        responseData = (MyaProductCostcoBundleResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CostcoBundleProducts.Count));
        foreach (CostcoBundleProduct costcoBundleProduct in responseData.CostcoBundleProducts)
        {
          Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", costcoBundleProduct.CommonName, costcoBundleProduct.IsFree, costcoBundleProduct.AccountExpirationDate.ToLongDateString(), costcoBundleProduct.IsRenewable);
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
    public void GetMyaCostcoBundleProductsValidShopperPage1With5PerPage()
    {
      MyaProductCostcoBundleRequestData requestData = new MyaProductCostcoBundleRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1);

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductCostcoBundleResponseData responseData;

      try
      {
        responseData = (MyaProductCostcoBundleResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CostcoBundleProducts.Count));
        foreach (CostcoBundleProduct costcoBundleProduct in responseData.CostcoBundleProducts)
        {
          Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", costcoBundleProduct.CommonName, costcoBundleProduct.IsFree, costcoBundleProduct.AccountExpirationDate.ToLongDateString(), costcoBundleProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.CostcoBundleProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyacostcoBundleProductsInvalidShopper()
    {
      MyaProductCostcoBundleRequestData requestData = new MyaProductCostcoBundleRequestData("2326554512213554"
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1);

      requestData.PagingInfo.ReturnAll = true;

      MyaProductCostcoBundleResponseData responseData;

      try
      {
        responseData = (MyaProductCostcoBundleResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.CostcoBundleProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
