using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Atlantis.Framework.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DCCDeleteDNS.Interface;

namespace Atlantis.Framework.DCCDeleteDNS.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class DCCDeleteDNSTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCDeleteDNSValid()
    {
      DCCDeleteDNSRequestData request = new DCCDeleteDNSRequestData("9865", string.Empty, string.Empty, string.Empty, 0, 1, false, "000123123ASD.BIZ");

      DnsRecordType record = new DnsRecordType();

      record.Type = "a";
      record.AttributeUid = "37d113bf-c085-44fd-bcd2-5e95d6fc3f39";
      request.addRecord(record);

      DCCDeleteDNSResponseData response = (DCCDeleteDNSResponseData)Engine.Engine.ProcessRequest(request, 108);
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void DCCDeleteDNSForDomainShopperDoesNotOwn()
    {
      DCCDeleteDNSRequestData request = new DCCDeleteDNSRequestData("847235", string.Empty, string.Empty, string.Empty, 0, 1, false, "000123123ASD.BIZ");

      DnsRecordType record = new DnsRecordType();

      record.Type = "a";
      record.AttributeUid = "37d113bf-c085-44fd-bcd2-5e95d6fc3f39";
      request.addRecord(record);

      try
      {
        DCCDeleteDNSResponseData response = (DCCDeleteDNSResponseData)Engine.Engine.ProcessRequest(request, 108);

        if (response.GetException() != null)
        {
          throw response.GetException();
        }
      }
      catch (AtlantisException ex)
      {
        Assert.IsTrue(ex.Message.StartsWith("Could not find DNS zonefile for"));
      }
    }
  }
}
