using System;
using System.Collections.Generic;
using Atlantis.Framework.DCCGetDomainByShopper.Interface.Paging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DCCGetDomainByShopper.Interface;

namespace Atlantis.Framework.DCCGetDomainByShopper1.Tests
{
  [TestClass]
  public class DCCGetDomainByShopperTest
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCGetAllDomainsByDomainNamePaging()
    {
      IDomainPaging paging = new DomainNamePaging(SortOrderType.Ascending);

      DCCGetDomainByShopperRequestData request = new DCCGetDomainByShopperRequestData("847235", string.Empty, string.Empty, string.Empty, 0, paging, "MOBILE_CSA_DCC");
      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetDomainByShopperResponseData response = (DCCGetDomainByShopperResponseData)Engine.Engine.ProcessRequest(request, 100);

      string lastDomainName = null;

      foreach (IDictionary<string, string> domainAttributesDictionary in response.Domains.Values)
      {
        if (lastDomainName == null)
        {
          lastDomainName = domainAttributesDictionary["domainname"];
        }

        if (lastDomainName.CompareTo(domainAttributesDictionary["domainname"]) > 0)
        {
          Assert.Fail("Domains are not in domain name order.");
        }

        lastDomainName = domainAttributesDictionary["domainname"];
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCGetAllDomainsByExpirationDatePaging()
    {
      IDomainPaging paging = new ExpirationDatePaging(SortOrderType.Ascending);

      DCCGetDomainByShopperRequestData request = new DCCGetDomainByShopperRequestData("847235", string.Empty, string.Empty, string.Empty, 0, paging, "MOBILE_CSA_DCC");
      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetDomainByShopperResponseData response = (DCCGetDomainByShopperResponseData)Engine.Engine.ProcessRequest(request, 100);

      DateTime lastExpirationDate = DateTime.MinValue;

      foreach (IDictionary<string, string> domainAttributesDictionary in response.Domains.Values)
      {
        if(lastExpirationDate == DateTime.MinValue)
        {
          lastExpirationDate = DateTime.Parse(domainAttributesDictionary["expirationdate"]);
        }

        if(lastExpirationDate > DateTime.Parse(domainAttributesDictionary["expirationdate"]))
        {
          Assert.Fail("Domains are not in expiration date order.");
        }

        lastExpirationDate = DateTime.Parse(domainAttributesDictionary["expirationdate"]);
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCGet5DomainsByDomainNamePaging()
    {
      IDomainPaging paging = new DomainNamePaging(5, string.Empty, SortOrderType.Ascending);

      DCCGetDomainByShopperRequestData request = new DCCGetDomainByShopperRequestData("847235", string.Empty, string.Empty, string.Empty, 0, paging, "MOBILE_CSA_DCC");
      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetDomainByShopperResponseData response = (DCCGetDomainByShopperResponseData)Engine.Engine.ProcessRequest(request, 100);

      if(response.Domains.Count != 5)
      {
        Assert.Fail("5 domains were not returned");
      }
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCGet5DomainsByExpriationDatePaging()
    {
      IDomainPaging paging = new ExpirationDatePaging(5, string.Empty, SortOrderType.Ascending);

      DCCGetDomainByShopperRequestData request = new DCCGetDomainByShopperRequestData("847235", string.Empty, string.Empty, string.Empty, 0, paging, "MOBILE_CSA_DCC");
      request.RequestTimeout = TimeSpan.FromMinutes(1);
      DCCGetDomainByShopperResponseData response = (DCCGetDomainByShopperResponseData)Engine.Engine.ProcessRequest(request, 100);

      if (response.Domains.Count != 5)
      {
        Assert.Fail("5 domains were not returned");
      }
    }
  }
}
