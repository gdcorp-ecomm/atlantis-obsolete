using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DPPDomainSearch.Interface;
using System;
using System.Threading;

namespace Atlantis.Framework.DPPDomainSearch.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class DPPDomainSearchTests
  {
    public DPPDomainSearchTests()
    {
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DPPDomainSearchValidDomain()
    {
      DPPDomainSearchVendorList vlist = new DPPDomainSearchVendorList();
      vlist.AddRange ( new DPPDomainSearchVendor[] { DPPDomainSearchVendor.Auctions, DPPDomainSearchVendor.FabulousDomains });
      DPPDomainSearchRequestData request = new DPPDomainSearchRequestData("839627", string.Empty, string.Empty, string.Empty, 0, vlist, "1godaddy31.com", "c1wsdv-rphil", "172.18.172.26", 1, "DPP Avail Check", 5, "");
      DPPDomainSearchResponseData response = (DPPDomainSearchResponseData)Engine.Engine.ProcessRequest(request, 323);
      Assert.IsTrue(response._isSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DPPDomainSearchDomainNotOnAuction()
    {
      DPPDomainSearchVendorList vlist = new DPPDomainSearchVendorList();
      vlist.AddRange(new DPPDomainSearchVendor[] { DPPDomainSearchVendor.Auctions });
      DPPDomainSearchRequestData request = new DPPDomainSearchRequestData("839627", string.Empty, string.Empty, string.Empty, 0, vlist, "lunchbucket.com", "c1wsdv-rphil", "172.18.172.26", 1, "DPP Avail Check", 5, "");
      DPPDomainSearchResponseData response = (DPPDomainSearchResponseData)Engine.Engine.ProcessRequest(request, 323);
      Assert.IsTrue(response._isSuccess);
    }


    private volatile bool _asyncSearchComplete = false;
    private DPPDomainSearchResponseData _asyncResponse = null;

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DPPDomainSearchAsyncTest()
    {
      _asyncResponse = null;

      DPPDomainSearchVendorList vlist = new DPPDomainSearchVendorList();
      vlist.AddRange(new DPPDomainSearchVendor[] { DPPDomainSearchVendor.Auctions, DPPDomainSearchVendor.FabulousDomains });

      DPPDomainSearchRequestData request = new DPPDomainSearchRequestData("839627", string.Empty, string.Empty, string.Empty, 0, vlist, "lunchbox.com", "c1wsdv-rphil", "172.18.172.26", 1, "DPP Avail Check", 5, "");
      request._requestTimeout = TimeSpan.FromMilliseconds(1);

      IAsyncResult asyncResult = Engine.Engine.BeginProcessRequest(request, 330, EndDPPDomainSearchAsyncTest, null);
      while (!_asyncSearchComplete)
      {
        Thread.Sleep(TimeSpan.FromMilliseconds(500));
      }

      Assert.IsNotNull(_asyncResponse);
      Assert.IsTrue(_asyncResponse._isSuccess);
    }

    private void EndDPPDomainSearchAsyncTest(IAsyncResult result)
    {
      _asyncResponse = Engine.Engine.EndProcessRequest(result) as DPPDomainSearchResponseData;
      _asyncSearchComplete = true;
    }

  }
}
