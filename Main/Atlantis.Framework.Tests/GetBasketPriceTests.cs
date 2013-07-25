using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetBasketPrice.Interface;

namespace Atlantis.Framework.Tests
{
	/// <summary>
	/// Summary description for GetBasketPriceTests
	/// </summary>
	[TestClass]
	public class GetBasketPriceTests
	{
		public GetBasketPriceTests()
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
		public void GetBasketPriceBasic()
		{
			GetBasketPriceRequestData request = new GetBasketPriceRequestData("832652",
				string.Empty, string.Empty, string.Empty, 0, true, string.Empty);
			GetBasketPriceResponseData response = (GetBasketPriceResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.BasketPriceGet);
			Console.WriteLine(response.ToXML());
		}

    [TestMethod]
    public void GetBasketPriceMarketplace()
    {
      GetBasketPriceRequestData request = new GetBasketPriceRequestData("832652",
        string.Empty, string.Empty, string.Empty, 0, true, string.Empty);
      request.BasketType = "marketplace";
      GetBasketPriceResponseData response = (GetBasketPriceResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.BasketPriceGet);
      Console.WriteLine(response.ToXML());
    }

	}
}
