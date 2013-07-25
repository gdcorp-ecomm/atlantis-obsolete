using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.CertifiedSiteSeal.Interface;

namespace Atlantis.Framework.CertifiedSiteSeal.Tests
{
    /// <summary>
    /// Summary description for CertifiedSiteSealTests
    /// </summary>
    [TestClass]
    public class CertifiedSiteSealTests
    {
        public CertifiedSiteSealTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [TestMethod]
        [DeploymentItem("atlantis.config")]
        public void CertifiedSiteSealGetCertifiedDomain()
        {
            CertifiedSiteSealRequestData request = new CertifiedSiteSealRequestData("840420", string.Empty, string.Empty, string.Empty, 0, "jdevsharp1.com", "proximaApp", "Th3His0!", "whois", 3000);
            CertifiedSiteSealResponseData response = (CertifiedSiteSealResponseData)Engine.Engine.ProcessRequest(request, 316);
            Assert.IsTrue(response._isSuccess);
        }

        [TestMethod]
        [DeploymentItem("atlantis.config")]
        public void CertifiedSiteSealGetNotCertifiedDomain()
        {
            CertifiedSiteSealRequestData request = new CertifiedSiteSealRequestData("840420", string.Empty, string.Empty, string.Empty, 0, "lunchbucket.com", "proximaApp", "Th3His0!", "whois", 3000);
            CertifiedSiteSealResponseData response = (CertifiedSiteSealResponseData)Engine.Engine.ProcessRequest(request, 316);
            Assert.IsTrue(response._isSuccess);
        }
    }
}

