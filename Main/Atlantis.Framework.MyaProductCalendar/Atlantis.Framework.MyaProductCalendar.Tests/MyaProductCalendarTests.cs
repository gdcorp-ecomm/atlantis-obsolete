using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductCalendar.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.MyaProductCalendar.Tests
{
  [TestClass]
  public class GetMyaProductCalendarTests
  {
    private const string _shopperId = "856907";
    private const int _requestType = 466;
	
	
    public GetMyaProductCalendarTests()
    { }

    private TestContext testContextInstance;

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
    public void GetMyaCalendarProductsValidShopperDefault()
    {
      MyaProductCalendarRequestData requestData = new MyaProductCalendarRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1);

      MyaProductCalendarResponseData responseData;
      try
      {
        responseData = (MyaProductCalendarResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CalendarProducts.Count));
        foreach (CalendarProduct calendarProduct in responseData.CalendarProducts)
        {
          calendarProduct.CommonName = "Premium DNS";
          Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", calendarProduct.CommonName, calendarProduct.IsFree, calendarProduct.AccountExpirationDate.ToLongDateString(), calendarProduct.IsRenewable);
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
    public void GetMyaCalendarProductsValidShopperGetAll()
    {
      MyaProductCalendarRequestData requestData = new MyaProductCalendarRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1); 

      requestData.PagingInfo.ReturnAll = true;

      MyaProductCalendarResponseData responseData;

      try
      {
        responseData = (MyaProductCalendarResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CalendarProducts.Count));
        foreach (CalendarProduct calendarProduct in responseData.CalendarProducts)
        {
          Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", calendarProduct.CommonName, calendarProduct.IsFree, calendarProduct.AccountExpirationDate.ToLongDateString(), calendarProduct.IsRenewable);
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
    public void GetMyaCalendarProductsValidShopperPage1With5PerPage()
    {
      MyaProductCalendarRequestData requestData = new MyaProductCalendarRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1); 

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 1;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductCalendarResponseData responseData;

      try
      {
        responseData = (MyaProductCalendarResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CalendarProducts.Count));
        foreach (CalendarProduct calendarProduct in responseData.CalendarProducts)
        {
          Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", calendarProduct.CommonName, calendarProduct.IsFree, calendarProduct.AccountExpirationDate.ToLongDateString(), calendarProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.CalendarProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaCalendarProductsValidShopperPage2With5PerPage()
    {
      MyaProductCalendarRequestData requestData = new MyaProductCalendarRequestData(_shopperId
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1); 

      requestData.PagingInfo.ReturnAll = false;
      requestData.PagingInfo.CurrentPage = 2;
      requestData.PagingInfo.RowsPerPage = 5;

      MyaProductCalendarResponseData responseData;

      try
      {
        responseData = (MyaProductCalendarResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.CalendarProducts.Count));
        foreach (CalendarProduct calendarProduct in responseData.CalendarProducts)
        {
          Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", calendarProduct.CommonName, calendarProduct.IsFree, calendarProduct.AccountExpirationDate.ToLongDateString(), calendarProduct.IsRenewable);
        }

        Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
        Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.CalendarProducts.Count <= 5);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMyaCalendarProductsInvalidShopper()
    {
      MyaProductCalendarRequestData requestData = new MyaProductCalendarRequestData("2326554512213554"
         , string.Empty
         , string.Empty
         , string.Empty
         , 0
         , 1); 

      requestData.PagingInfo.ReturnAll = true;

      MyaProductCalendarResponseData responseData;

      try
      {
        responseData = (MyaProductCalendarResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

        Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
        Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

        Assert.IsTrue(responseData.CalendarProducts.Count == 0);
      }
      catch (Exception ex)
      {
        Assert.Fail(ex.Message);
      }
    }
  }
}
