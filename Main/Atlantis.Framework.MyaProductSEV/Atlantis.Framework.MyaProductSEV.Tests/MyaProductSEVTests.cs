using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductSEV.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductSEV.Tests
{
	[TestClass]
	public class GetMyaProductSEVTests
	{
		private const string _shopperId = "856907";
		private const int _requestType = 467;
		
		public GetMyaProductSEVTests()
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
		public void GetMyaSEVProductsValidShopperDefault()
		{
			MyaProductSEVRequestData requestData = new MyaProductSEVRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			MyaProductSEVResponseData responseData;
			try
			{
				responseData = (MyaProductSEVResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("SEV product count: {0}", responseData.SEVProducts.Count));
				foreach (SEVProduct sevProduct in responseData.SEVProducts)
				{
					sevProduct.CommonName = "Search Engine Visibility";
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", sevProduct.CommonName, sevProduct.IsFree, sevProduct.AccountExpirationDate.ToLongDateString(), sevProduct.IsRenewable);
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
		public void GetMyaSEVProductsValidShopperGetAll()
		{
			MyaProductSEVRequestData requestData = new MyaProductSEVRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductSEVResponseData responseData;

			try
			{
				responseData = (MyaProductSEVResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("SEV product count: {0}", responseData.SEVProducts.Count));
				foreach (SEVProduct sevProduct in responseData.SEVProducts)
				{
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", sevProduct.CommonName, sevProduct.IsFree, sevProduct.AccountExpirationDate.ToLongDateString(), sevProduct.IsRenewable);
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
		public void GetMyaSEVProductsValidShopperPage1With5PerPage()
		{
			MyaProductSEVRequestData requestData = new MyaProductSEVRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 1;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductSEVResponseData responseData;

			try
			{
				responseData = (MyaProductSEVResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("SEV product count: {0}", responseData.SEVProducts.Count));
				foreach (SEVProduct sevProduct in responseData.SEVProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3} ExternalResourceId: {4}", sevProduct.CommonName, sevProduct.IsFree, sevProduct.AccountExpirationDate.ToLongDateString(), sevProduct.IsRenewable, sevProduct.OrionResourceId);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.SEVProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaSEVProductsValidShopperPage2With5PerPage()
		{
			MyaProductSEVRequestData requestData = new MyaProductSEVRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 2;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductSEVResponseData responseData;

			try
			{
				responseData = (MyaProductSEVResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("SEV product count: {0}", responseData.SEVProducts.Count));
				foreach (SEVProduct sevProduct in responseData.SEVProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3} ExternalResourceId: {4}", sevProduct.CommonName, sevProduct.IsFree, sevProduct.AccountExpirationDate.ToLongDateString(), sevProduct.IsRenewable, sevProduct.OrionResourceId);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.SEVProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaSEVProductsInvalidShopper()
		{
			MyaProductSEVRequestData requestData = new MyaProductSEVRequestData("2326554512213554"
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductSEVResponseData responseData;

			try
			{
				responseData = (MyaProductSEVResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.SEVProducts.Count == 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
