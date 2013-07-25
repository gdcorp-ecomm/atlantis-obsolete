using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Atlantis.Framework.BizRegDomain.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.BizRegDomain.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BizRegDomainTests
    {
        public BizRegDomainTests()
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
        [DeploymentItem("atlantis.config")]
        public void BizRegDomainHasCategoryPath()
        {
            BizRegDomainResponseData response = null;
            string domain = "samanthamyers.info";
            BizRegDomainRequestData request = new BizRegDomainRequestData(string.Empty, string.Empty, string.Empty, string.Empty, 0, domain, 20000);
            response = (BizRegDomainResponseData)Engine.Engine.ProcessRequest(request, 318);

            Assert.IsTrue(response.Business.CategoryPaths[0] != string.Empty);
        }


        [TestMethod]
        [DeploymentItem("atlantis.config")]
        public void BizRegDomainHasNoPath()
        {
            BizRegDomainResponseData response = null;
            string domain = "mydogsbutt.info";
            BizRegDomainRequestData request = new BizRegDomainRequestData(string.Empty, string.Empty, string.Empty, string.Empty, 0, domain, 3000);
            response = (BizRegDomainResponseData)Engine.Engine.ProcessRequest(request, 318);

            Assert.IsTrue(response.Business.CategoryPaths.Count == 0);
        }
    }
}
