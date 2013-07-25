using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetBasket.Interface;
using Atlantis.Framework.AddBasketAttribute.Interface;
using Atlantis.Framework.AddBasketShipping.Interface;

namespace Atlantis.Framework.Tests
{
	/// <summary>
	/// Summary description for GetBasketTest
	/// </summary>
	[TestClass]
	public class GetBasketTests
	{
		public GetBasketTests()
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
		public void GetBasketBasic()
		{
			GetBasketRequestData request = new GetBasketRequestData("832652",
				string.Empty, string.Empty, string.Empty, 0, true);
			GetBasketResponseData response = (GetBasketResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.BasketGet);
			Console.WriteLine(response.ToXML());
		}

    [TestMethod]
    public void GetBasketMarketplace()
    {
      GetBasketRequestData request = new GetBasketRequestData("832652",
        string.Empty, string.Empty, string.Empty, 0, true);
      request.BasketType = "marketplace";
      GetBasketResponseData response = (GetBasketResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.BasketGet);
      Console.WriteLine(response.ToXML());
    }

    [TestMethod]
    public void AddBasketAttributeTest()
    {
      AddBasketAttributeRequestData request = new AddBasketAttributeRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0, "gdshop");
      request.AddAttribute("source_code", "ohai");
      AddBasketAttributeResponseData response = (AddBasketAttributeResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.AddBasketAttribute);
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    public void AddBasketShippingTest()
    {
      BasketShippingInfo info = new BasketShippingInfo();
      info.Email = "mmicco@godaddy.com";
      info.State = "MO";

      AddBasketShippingRequestData request = new AddBasketShippingRequestData(
        "832652", string.Empty, string.Empty, string.Empty, 0, "gdshop", info);
      AddBasketShippingResponseData response = (AddBasketShippingResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.AddBasketShipping);

      Assert.IsTrue(response.IsSuccess);
    }

  }
}
