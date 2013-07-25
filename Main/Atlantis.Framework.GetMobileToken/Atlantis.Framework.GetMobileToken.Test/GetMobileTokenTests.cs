using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetMobileToken.Interface;

namespace Atlantis.Framework.GetMobileToken.Test
{
  [TestClass]
  public class GetMobileTokenTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetMobilTokenTypeBasic()
    {
      GetMobileTokenRequestData request = new GetMobileTokenRequestData(string.Empty, string.Empty, string.Empty, string.Empty, 0, "TestArvind", "password", 1, Guid.NewGuid().ToString());
      request.CertificateName = "corp.web.cart.dev.client.godaddy.com";
      request.DataSourceName = "corp.web.cart.godaddy";
      request.ApplicationName = "GetMobileToken Tester";
      
      GetMobileTokenResponseData response = (GetMobileTokenResponseData) Engine.Engine.ProcessRequest(request, 84);

      Assert.IsTrue(response.IsSuccess);
    }
  }
}
