using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetRenewalOptions.Interface;

namespace Atlantis.Framework.GetRenewalOptions.Tests
{
  [TestClass]
  public class GetRenewalOptionsTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetRenewalOptionsBasic()
    {
      GetRenewalOptionsRequestData requestData = new GetRenewalOptionsRequestData("847235", "http://localhost",
        "", "", 0, "383392", "hosting", "billing", 1);
      GetRenewalOptionsResponseData responseData = (GetRenewalOptionsResponseData)Engine.Engine.ProcessRequest(requestData, 75);
      Assert.AreEqual(1546, responseData.XML.Length);
    }
  }
}
