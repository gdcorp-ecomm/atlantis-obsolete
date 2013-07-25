using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.Tests
{
	/// <summary>
	/// Summary description for DataCacheTests
	/// </summary>
	[TestClass]
	public class DataCacheTests
	{
		public DataCacheTests()
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
		public void GetShopperProductBasic()
		{
			Dictionary<string, int> shopperProductData = Atlantis.Framework.DataCache.DataCache.GetShopperProduct("832652");
			Assert.IsTrue(shopperProductData.Keys.Count > 0);

			shopperProductData = Atlantis.Framework.DataCache.DataCache.GetShopperProduct("849076");
			Assert.IsTrue(shopperProductData.Keys.Count == 0);

      shopperProductData = Atlantis.Framework.DataCache.DataCache.GetShopperProduct("cim");
      Assert.IsTrue(shopperProductData.Keys.Count == 0);
		}

		[TestMethod]
		public void GetShopperProductCached()
		{
			Dictionary<string, int> shopperProductData = Atlantis.Framework.DataCache.DataCache.GetShopperProduct("832652");
			Assert.IsTrue(shopperProductData.Keys.Count > 0);
			Dictionary<string, int> shopperProductDataCached = Atlantis.Framework.DataCache.DataCache.GetShopperProduct("832652");
			Assert.ReferenceEquals(shopperProductData, shopperProductDataCached);
		}

    [TestMethod]
    public void GetCurrencyDataAll()
    {
      Dictionary<string, Dictionary<string, string>> currencyDataAll = Atlantis.Framework.DataCache.DataCache.GetCurrencyDataAll();
      Assert.IsTrue(currencyDataAll.Keys.Count > 0);
      Assert.IsTrue(currencyDataAll.ContainsKey("USD"));
    }

    [TestMethod]
    public void GetTLDData()
    {
      Dictionary<string, Dictionary<string, string>> tldData = DataCache.DataCache.GetTLDData("0");
      Assert.IsTrue(tldData.Count > 0);
    }

    [TestMethod]
    public void GetDotTypes()
    {
      HashSet<string> dotTypes = DataCache.DataCache.GetValidDotTypes();
      Assert.IsTrue(dotTypes.Count > 0);
    }
	}
}
