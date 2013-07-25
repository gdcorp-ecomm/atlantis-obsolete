using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DCCForwardingUpdate.Interface;


namespace Atlantis.Framework.DCCForwardingUpdate.Tests
{
  [TestClass]
  public class DCCForwardingUpdateTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ForwardingUpdatePermanentValid()
    {
      DCCForwardingUpdateRequestData request = new DCCForwardingUpdateRequestData("857020", 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  0, 
                                                                                  1,
                                                                                  1667126, 
                                                                                  "MOBILE_CSA_DCC", 
                                                                                  "http://testy123.com", 
                                                                                  RedirectType.Permanent,
                                                                                  true);
      
      DCCForwardingUpdateResponseData response = (DCCForwardingUpdateResponseData)Engine.Engine.ProcessRequest(request, 111);
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ForwardingUpdateTemporaryValid()
    {
      DCCForwardingUpdateRequestData request = new DCCForwardingUpdateRequestData("857020", 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  0, 
                                                                                  1, 
                                                                                  1665502, 
                                                                                  "MOBILE_CSA_DCC", 
                                                                                  "http://testy123.com", 
                                                                                  RedirectType.Temporary,
                                                                                  true);

      DCCForwardingUpdateResponseData response = (DCCForwardingUpdateResponseData)Engine.Engine.ProcessRequest(request, 111);
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void ForwardingUpdateForDomainThatShopperDoesNotOwn()
    {
      DCCForwardingUpdateRequestData request = new DCCForwardingUpdateRequestData("847235", 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  string.Empty, 
                                                                                  0, 
                                                                                  1, 
                                                                                  1665502, 
                                                                                  "MOBILE_CSA_DCC",
                                                                                  "http://testy123.com",
                                                                                  RedirectType.Permanent,
                                                                                  true);


      DCCForwardingUpdateResponseData response = (DCCForwardingUpdateResponseData)Engine.Engine.ProcessRequest(request, 111);
      // This is returning success, the DCC team is fixing this in a future release
      Assert.IsFalse(response.IsSuccess);
    }
  }
}
