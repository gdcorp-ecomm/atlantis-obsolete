using Atlantis.Framework.DCCForwardingDelete.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.DCCForwardingDelete.Tests
{
  [TestClass]
  public class DCCForwardingDeleteTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCForwardingDeleteValid()
    {
      DCCForwardingDeleteRequestData request = new DCCForwardingDeleteRequestData("857020", string.Empty, string.Empty, string.Empty, 0, 1, 1667126, "MOBILE_CSA_DCC");
      DCCForwardingDeleteResponseData response = (DCCForwardingDeleteResponseData)Engine.Engine.ProcessRequest(request, 112);
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCForwardingDeleteForDomainThatShopperDoesNotOwn()
    {
      DCCForwardingDeleteRequestData request = new DCCForwardingDeleteRequestData("847235", string.Empty, string.Empty, string.Empty, 0, 1, 1665499, "MOBILE_CSA_DCC");
      DCCForwardingDeleteResponseData response = (DCCForwardingDeleteResponseData)Engine.Engine.ProcessRequest(request, 112);

      // This is returning success true, the DCC team is fixing this in a future release
      Assert.IsFalse(response.IsSuccess);
    }
  }
}
