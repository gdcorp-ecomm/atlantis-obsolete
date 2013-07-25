using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Atlantis.Framework.MYAGetDBPProductInfoData.Interface;
using Atlantis.Framework.MYAGetDBPProductInfoData.Interface.PageHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.GetDBPProductInfoData.Tests
{
	[TestClass]
	public class GetDBPProductInfoTests
	{
		private const int _getDBPProductInfoListLiteRequestType = 201;
		private const string _shopperId = "822497"; //"840820";  //840820 842749; 

		public GetDBPProductInfoTests() { }

		private TestContext testContextInstance;

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

		[TestMethod]
		[DeploymentItem("atlantis.config")]
		public void MYAGetProductTest()
		{

			PagingInfo pagingInfo = new PagingInfo();

			GetDBPProductInfoRequestData request = new GetDBPProductInfoRequestData(_shopperId,
			                                                                        string.Empty,
			                                                                        string.Empty,
			                                                                        string.Empty,
			                                                                        0,pagingInfo, -1, 1);

			GetDBPProductInfoResponseData response = (GetDBPProductInfoResponseData)Engine.Engine.ProcessRequest(request, _getDBPProductInfoListLiteRequestType);

			foreach (DBPProductInfo dbp in response.dbpProducts)
			{
				Debug.WriteLine("*************************");

				Debug.WriteLine(string.Format("DomainId: {0}", dbp.DomainId));
				Debug.WriteLine(string.Format("DomainName: {0}", dbp.CommonName));
				Debug.WriteLine(string.Format("IsBusiness: {0}", dbp.IsBusiness));
				Debug.WriteLine(string.Format("IsPrivate: {0}", dbp.IsPrivate));
				Debug.WriteLine(string.Format("IsProtected: {0}", dbp.IsProtected));
				Debug.WriteLine(string.Format("IsSmartDomain: {0}", dbp.IsSmartDomain));
				Debug.WriteLine(string.Format("ResourceId: {0}", dbp.ResourceId));
			}
			Debug.WriteLine("*************************");
			Debug.WriteLine(response.ToXML());
			Assert.IsTrue(response.IsSuccess);
		}
	}
}