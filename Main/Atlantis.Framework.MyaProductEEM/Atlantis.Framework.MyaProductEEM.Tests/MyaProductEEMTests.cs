using System;
using System.Diagnostics;
using Atlantis.Framework.MyaProductEEM.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.MyaProductEEM.Tests
{
	[TestClass]
	public class GetMyaProductEEMTests
	{
		private const string _shopperId = "856907";
		private const int _requestType = 471;
	
	
		public GetMyaProductEEMTests()
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
		public void GetMyaEEMProductsValidShopperDefault()
		{
			MyaProductEEMRequestData requestData = new MyaProductEEMRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			MyaProductEEMResponseData responseData;
			try
			{
				responseData = (MyaProductEEMResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.EEMProducts.Count));
				foreach (EEMProduct eemProduct in responseData.EEMProducts)
				{
					eemProduct.CommonName = "Premium DNS";
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenewable: {3}", eemProduct.CommonName, eemProduct.IsFree, eemProduct.AccountExpirationDate.ToLongDateString(), eemProduct.IsRenewable);
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
		public void GetMyaEEMProductsValidShopperGetAll()
		{
			MyaProductEEMRequestData requestData = new MyaProductEEMRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductEEMResponseData responseData;

			try
			{
				responseData = (MyaProductEEMResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Debug.WriteLine(string.Format("Premium DNS product count: {0}", responseData.EEMProducts.Count));
				foreach (EEMProduct eemProduct in responseData.EEMProducts)
				{
					Debug.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", eemProduct.CommonName, eemProduct.IsFree, eemProduct.AccountExpirationDate.ToLongDateString(), eemProduct.IsRenewable);
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
		public void GetMyaEEMProductsValidShopperPage1With5PerPage()
		{
			MyaProductEEMRequestData requestData = new MyaProductEEMRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 1;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductEEMResponseData responseData;

			try
			{
				responseData = (MyaProductEEMResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.EEMProducts.Count));
				foreach (EEMProduct eemProduct in responseData.EEMProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", eemProduct.CommonName, eemProduct.IsFree, eemProduct.AccountExpirationDate.ToLongDateString(), eemProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.EEMProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaEEMProductsValidShopperPage2With5PerPage()
		{
			MyaProductEEMRequestData requestData = new MyaProductEEMRequestData(_shopperId
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = false;
			requestData.PagingInfo.CurrentPage = 2;
			requestData.PagingInfo.RowsPerPage = 5;

			MyaProductEEMResponseData responseData;

			try
			{
				responseData = (MyaProductEEMResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Premium DNS product count: {0}", responseData.EEMProducts.Count));
				foreach (EEMProduct eemProduct in responseData.EEMProducts)
				{
					Console.WriteLine("CommonName: {0}, Is Free: {1}, Account Expiration: {2}, IsRenwable: {3}", eemProduct.CommonName, eemProduct.IsFree, eemProduct.AccountExpirationDate.ToLongDateString(), eemProduct.IsRenewable);
				}

				Console.WriteLine(string.Format("Current Page: {0}", requestData.PagingInfo.CurrentPage));
				Console.WriteLine(string.Format("Rows per Page: {0}", requestData.PagingInfo.RowsPerPage));
				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.EEMProducts.Count <= 5);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void GetMyaEEMProductsInvalidShopper()
		{
			MyaProductEEMRequestData requestData = new MyaProductEEMRequestData("2326554512213554"
				 , string.Empty
				 , string.Empty
				 , string.Empty
				 , 0
				 , 1);

			requestData.PagingInfo.ReturnAll = true;

			MyaProductEEMResponseData responseData;

			try
			{
				responseData = (MyaProductEEMResponseData)Engine.Engine.ProcessRequest(requestData, _requestType);

				Console.WriteLine(string.Format("Total Records: {0}", responseData.PagingResult.TotalNumberOfRecords));
				Console.WriteLine(string.Format("Total Pages: {0}", responseData.PagingResult.TotalNumberOfPages));

				Assert.IsTrue(responseData.EEMProducts.Count == 0);
			}
			catch (Exception ex)
			{
				Assert.Fail(ex.Message);
			}
		}
	}
}
