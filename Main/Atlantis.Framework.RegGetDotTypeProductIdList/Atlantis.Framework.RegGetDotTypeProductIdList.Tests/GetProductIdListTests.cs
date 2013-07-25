﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.RegGetDotTypeProductIdList.Interface;

namespace Atlantis.Framework.RegGetDotTypeProductIdList.Tests
{
  [TestClass]
  public class GetProductIdListTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetDotTypePFIDs()
    {
      RegGetDotTypeProductIdListRequestData request = new RegGetDotTypeProductIdListRequestData("77311",
        string.Empty, string.Empty, string.Empty, 0, "co.uk");
      request.Timeout = 6000;
      RegGetDotTypeProductIdListResponseData response
        = (RegGetDotTypeProductIdListResponseData)Engine.Engine.ProcessRequest(request, 279);
      string responseXML = response.ToXML();
      Assert.IsTrue(response.IsValid);
    }
  }
}
