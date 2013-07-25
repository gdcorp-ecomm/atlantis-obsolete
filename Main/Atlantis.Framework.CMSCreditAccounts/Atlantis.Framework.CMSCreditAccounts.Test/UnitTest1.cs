using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.CMSCreditAccounts.Interface;

namespace Atlantis.Framework.CMSCreditAccounts.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void TestMethod1()
    {
      List<ProductGroupRequest> productGroups = new List<ProductGroupRequest>();
      productGroups.Add(new ProductGroupRequest(4, true, true));
      productGroups.Add(new ProductGroupRequest(15, true, true));
      productGroups.Add(new ProductGroupRequest(23, true, true));
      productGroups.Add(new ProductGroupRequest(50, true, true));
      productGroups.Add(new ProductGroupRequest(1, true, true));
      CMSCreditAccountsRequestData request = new CMSCreditAccountsRequestData("75866", string.Empty, string.Empty, string.Empty,
                                 0,productGroups,"eu");
      CMSCreditAccountsResponseData response = (CMSCreditAccountsResponseData)Engine.Engine.ProcessRequest(request, 427);
      System.Diagnostics.Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
