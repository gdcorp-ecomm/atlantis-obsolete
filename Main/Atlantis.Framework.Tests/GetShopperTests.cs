using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetShopper.Interface;
using Atlantis.Framework.UpdateShopper.Interface;

namespace Atlantis.Framework.Tests
{
	/// <summary>
	/// Summary description for UnitTest1
	/// </summary>
	[TestClass]
	public class GetShopperTests
	{
		public GetShopperTests()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
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
		public void GetShopperBasic()
		{
			GetShopperRequestData request = new GetShopperRequestData("832652", string.Empty, string.Empty, string.Empty, 0);
			request.AddField("first_name");
			request.AddField("last_name");
			GetShopperResponseData response = (GetShopperResponseData)Atlantis.Framework.Engine.Engine.ProcessRequest(request, EngineRequests.ShopperGet);

			Console.WriteLine(response.ToXML());
			string firstName = response.GetField("first_name");
			string lastName = response.GetField("last_name");
		}

    [TestMethod]
    public void UpdateShopperBasic()
    {
      UpdateShopperRequestData request = new UpdateShopperRequestData("832652", string.Empty, string.Empty,
        string.Empty, 0, "unittest");
      request.AddUpdateField("phone1", "303-333-3333");
      UpdateShopperResponseData response = (UpdateShopperResponseData)Engine.Engine.ProcessRequest(
        request, EngineRequests.UpdateShopper);
      Assert.IsTrue(response.IsSuccess);
    }
	}
}
