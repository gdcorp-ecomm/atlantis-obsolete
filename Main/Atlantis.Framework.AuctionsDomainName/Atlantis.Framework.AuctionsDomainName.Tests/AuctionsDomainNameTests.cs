using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.AuctionsDomainName.Interface;

namespace Atlantis.Framework.AuctionsDomainName.Tests
{
    [TestClass]
    public class AuctionsDomainNameTests
    {
        [TestMethod]
        [DeploymentItem("atlantis.config")]
        public void AuctionDomainNameLookup()
        {
            AuctionsDomainNameResponseData response = null;
            string domain = "topdog.com";
            AuctionToCheck auctionCheck = new AuctionToCheck(domain);
            AuctionsDomainNameRequestData request = new AuctionsDomainNameRequestData("840420", string.Empty, string.Empty, string.Empty, 0, auctionCheck, string.Empty, string.Empty, "whois", 3000);
            response = (AuctionsDomainNameResponseData)Engine.Engine.ProcessRequest(request, 325);

            Assert.IsTrue(response._isSuccess);
        }
    }
}
