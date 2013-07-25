using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductSafeSite.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.MyaProductSafeSite.Tests
{
	[TestClass]
	public class GetMyaProductSafeSiteTests
	{
		private const string _shopperId = "856907";
		private const int _requestType = 465;
	
	
		public GetMyaProductSafeSiteTests()
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
		public void GetMyaSafeSiteProductsValidShopperDefault()
		{
			MyaProductSafeSiteRequestData requestData = new MyaProductSafeSiteRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			MyaProductSafeSiteResponseData responseData;
			try
			{
				responseData = (MyaProductSafeSiteResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.SafeSiteProducts.Count));
				foreach (SafeSiteProduct safeSiteProduct in responseData.SafeSiteProducts)
				{
					safeSiteProduct.CommonName = "Premium DNS";
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", safeSiteProduct.CommonName, safeSiteProduct.IsFree, safeSiteProduct.AccountExpirationDate.ToLongDateString(), safeSiteProduct.IsRenewable);
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
		public void GetMyaSafeSiteProductsValidShopperGetAll()
		{
			MyaProductSafeSiteRequestData requestData = new MyaProductSafeSiteRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductSafeSiteResponseData responseData;

			try
			{
				responseData = (MyaProductSafeSiteResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.SafeSiteProducts.Count));
				foreach (SafeSiteProduct safeSiteProduct in responseData.SafeSiteProducts)
				{
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", safeSiteProduct.CommonName, safeSiteProduct.IsFree, safeSiteProduct.AccountExpirationDate.ToLongDateString(), safeSiteProduct.IsRenewable);
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
		public void GetMyaSafeSiteProductsValidShopperPage1With5PerPage()
		{
			MyaProductSafeSiteRequestData requestData = new MyaProductSafeSiteRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 1;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductSafeSiteResponseData responseData;

			try
			{
				responseData = (MyaProductSafeSiteResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.SafeSiteProducts.Count));
				foreach (SafeSiteProduct safeSiteProduct in responseData.SafeSiteProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", safeSiteProduct.CommonName, safeSiteProduct.IsFree, safeSiteProduct.AccountExpirationDate.ToLongDateString(), safeSiteProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.SafeSiteProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaSafeSiteProductsValidShopperPage2With5PerPage()
		{
			MyaProductSafeSiteRequestData requestData = new MyaProductSafeSiteRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 2;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductSafeSiteResponseData responseData;

			try
			{
				responseData = (MyaProductSafeSiteResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.SafeSiteProducts.Count));
				foreach (SafeSiteProduct safeSiteProduct in responseData.SafeSiteProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", safeSiteProduct.CommonName, safeSiteProduct.IsFree, safeSiteProduct.AccountExpirationDate.ToLongDateString(), safeSiteProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.SafeSiteProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaSafeSiteProductsInvalidShopper()
		{
			MyaProductSafeSiteRequestData requestData = new MyaProductSafeSiteRequestData("2326554512213554"
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductSafeSiteResponseData responseData;

			try
			{
				responseData = (MyaProductSafeSiteResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.SafeSiteProducts.Count == 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}