using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductQBC.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Atlantis.Framework.MyaProductQBC.Tests
{
	[TestClass]
	public class GetMyaProductQBCTests
	{
		private const string _shopperId = "856907";
		private const int _requestType = 469;
	
	
		public GetMyaProductQBCTests()
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
		public void GetMyaQBCProductsValidShopperDefault()
		{
			MyaProductQBCRequestData requestData = new MyaProductQBCRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			MyaProductQBCResponseData responseData;
			try
			{
				responseData = (MyaProductQBCResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.QBCProducts.Count));
				foreach (QBCProduct qbcProduct in responseData.QBCProducts)
				{
					qbcProduct.CommonName = "Premium DNS";
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", qbcProduct.CommonName, qbcProduct.IsFree, qbcProduct.AccountExpirationDate.ToLongDateString(), qbcProduct.IsRenewable);
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
		public void GetMyaQBCProductsValidShopperGetAll()
		{
			MyaProductQBCRequestData requestData = new MyaProductQBCRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductQBCResponseData responseData;

			try
			{
				responseData = (MyaProductQBCResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.QBCProducts.Count));
				foreach (QBCProduct qbcProduct in responseData.QBCProducts)
				{
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", qbcProduct.CommonName, qbcProduct.IsFree, qbcProduct.AccountExpirationDate.ToLongDateString(), qbcProduct.IsRenewable);
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
		public void GetMyaQBCProductsValidShopperPage1With5PerPage()
		{
			MyaProductQBCRequestData requestData = new MyaProductQBCRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 1;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductQBCResponseData responseData;

			try
			{
				responseData = (MyaProductQBCResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.QBCProducts.Count));
				foreach (QBCProduct qbcProduct in responseData.QBCProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", qbcProduct.CommonName, qbcProduct.IsFree, qbcProduct.AccountExpirationDate.ToLongDateString(), qbcProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.QBCProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaQBCProductsValidShopperPage2With5PerPage()
		{
			MyaProductQBCRequestData requestData = new MyaProductQBCRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 2;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductQBCResponseData responseData;

			try
			{
				responseData = (MyaProductQBCResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.QBCProducts.Count));
				foreach (QBCProduct qbcProduct in responseData.QBCProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", qbcProduct.CommonName, qbcProduct.IsFree, qbcProduct.AccountExpirationDate.ToLongDateString(), qbcProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.QBCProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaQBCProductsInvalidShopper()
		{
			MyaProductQBCRequestData requestData = new MyaProductQBCRequestData("2326554512213554"
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductQBCResponseData responseData;

			try
			{
				responseData = (MyaProductQBCResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.QBCProducts.Count == 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
