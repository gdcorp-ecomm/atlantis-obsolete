using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.MktgGetShopperPreferences.Interface;

namespace Atlantis.Framework.MktgGetShopperPreference.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestMethod1()
    {
      MktgGetShopperPreferencesRequestData request = new MktgGetShopperPreferencesRequestData("75866", string.Empty, string.Empty, string.Empty,
                                 0);
      MktgGetShopperPreferencesResponseData response = (MktgGetShopperPreferencesResponseData)Engine.Engine.ProcessRequest(request, 340);
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
