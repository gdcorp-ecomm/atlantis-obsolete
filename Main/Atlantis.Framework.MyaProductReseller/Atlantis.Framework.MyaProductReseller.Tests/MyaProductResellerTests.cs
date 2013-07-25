using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductReseller.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.MyaProductReseller.Tests
{
	[TestClass]
	public class GetMyaProductResellerTests
	{
		private const string _shopperId = "842749";
		private const int _requestType = 461;
	
	
		public GetMyaProductResellerTests()
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
		public void GetMyaResellerProductsValidShopperDefault()
		{
			MyaProductResellerRequestData requestData = new MyaProductResellerRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			MyaProductResellerResponseData responseData;
			try
			{
				responseData = (MyaProductResellerResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Reseller product count: {0}", responseData.ResellerProducts.Count));
				foreach (ResellerProduct ResellerProduct in responseData.ResellerProducts)
				{
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", ResellerProduct.CommonName, ResellerProduct.IsFree, ResellerProduct.AccountExpirationDate.ToLongDateString(), ResellerProduct.IsRenewable);
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
		public void GetMyaResellerProductsValidShopperGetAll()
		{
			MyaProductResellerRequestData requestData = new MyaProductResellerRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductResellerResponseData responseData;

			try
			{
				responseData = (MyaProductResellerResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Reseller product count: {0}", responseData.ResellerProducts.Count));
				foreach (ResellerProduct ResellerProduct in responseData.ResellerProducts)
				{
					Debug.WriteLine("CommonName: {0}, ProductType: {1}, Account Expiration: {2}, ResourceId: {3}, PrivateLabelType: {4}, Description: {5}, ParentBundleId: {6}"
						, ResellerProduct.CommonName, ResellerProduct.ProductTypeId, ResellerProduct.AccountExpirationDate.ToLongDateString(), ResellerProduct.BillingResourceId
						, ResellerProduct.PrivateLabelGroupType, ResellerProduct.Description, ResellerProduct.ParentBundleId);
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
		public void GetMyaResellerProductsValidShopperPage1With5PerPage()
		{
			MyaProductResellerRequestData requestData = new MyaProductResellerRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 1;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductResellerResponseData responseData;

			try
			{
				responseData = (MyaProductResellerResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Reseller product count: {0}", responseData.ResellerProducts.Count));
				foreach (ResellerProduct ResellerProduct in responseData.ResellerProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", ResellerProduct.CommonName, ResellerProduct.IsFree, ResellerProduct.AccountExpirationDate.ToLongDateString(), ResellerProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.ResellerProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaResellerProductsValidShopperPage2With5PerPage()
		{
			MyaProductResellerRequestData requestData = new MyaProductResellerRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 2;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductResellerResponseData responseData;

			try
			{
				responseData = (MyaProductResellerResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Reseller product count: {0}", responseData.ResellerProducts.Count));
				foreach (ResellerProduct ResellerProduct in responseData.ResellerProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", ResellerProduct.CommonName, ResellerProduct.IsFree, ResellerProduct.AccountExpirationDate.ToLongDateString(), ResellerProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.ResellerProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaResellerProductsInvalidShopper()
		{
			MyaProductResellerRequestData requestData = new MyaProductResellerRequestData("2326554512213554"
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductResellerResponseData responseData;

			try
			{
				responseData = (MyaProductResellerResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.ResellerProducts.Count == 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
