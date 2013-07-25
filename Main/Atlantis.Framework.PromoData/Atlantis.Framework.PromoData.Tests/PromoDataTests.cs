﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.PromoData.Interface;

namespace Atlantis.Framework.PromoData.Tests
{
  [TestClass]
  public class PromoDataTests
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetPromoData()
    {
      int amount = 0;
      string awardType = string.Empty;
      //PromoDataRequestData request = new PromoDataRequestData("77311", string.Empty,
      //  String.Empty, string.Empty, 0, "sample");
      PromoDataRequestData request = new PromoDataRequestData("77311", string.Empty,
        String.Empty, string.Empty, 0, "iscSSLStd1299");
      request.RequestTimeout = new TimeSpan(0,0,60);
      PromoDataResponseData response
        = (PromoDataResponseData)Engine.Engine.ProcessRequest(request, 365);

      if (response.IsValid 
        && response.PromoProduct.IsActivePromoForPrivateLabelTypeId(1))
      {
        IProductAward award = response.PromoProduct.GetProductAward(3604);
        amount = award.GetAwardAmount("EUR");
        awardType = award.AwardType;
      }

      Assert.IsTrue(amount > 0 && !string.IsNullOrEmpty(awardType));
    }
  }
}
