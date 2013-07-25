using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.NameserverCheck.Interface;

namespace Atlantis.Framework.Tests
{
  [TestClass]
  public class NameserverCheck
  {
    private TestContext testContextInstance;
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    [TestMethod]
    public void TestNameserverCheck()
    {
      List<string> lstNameservers = new List<string>(4);
      lstNameservers.Add("park1.secureserver.net");
      lstNameservers.Add("park2.secureserver.net");
      lstNameservers.Add("park3.secureserver.net");
      lstNameservers.Add("park4.secureserver.net");
      NameserverCheckRequestData oNameserverCheckRequestData = new NameserverCheckRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, lstNameservers, 1, "127.0.0.1");
      NameserverCheckResponseData oNameserverCheckResponseData = (NameserverCheckResponseData)Engine.Engine.ProcessRequest(oNameserverCheckRequestData, EngineRequests.NameserverCheck);
      Assert.IsNotNull(oNameserverCheckResponseData);
    }

    [TestMethod]
    public void TestNameserverCheckAsync()
    {
      NameserverCheckRequestData oNameserverCheckRequestData = new NameserverCheckRequestData("832652", "SourceURL", "OrderID", "Pathway", 0, "park1.secureserver.net", 1, "127.0.0.1");
      IAsyncResult ar = Engine.Engine.BeginProcessRequest(oNameserverCheckRequestData, EngineRequests.NameserverCheckAsync, null, null);
      ar.AsyncWaitHandle.WaitOne();
      NameserverCheckResponseData oNameserverCheckResponseData = (NameserverCheckResponseData)Engine.Engine.EndProcessRequest(ar);
      Assert.IsNotNull(oNameserverCheckResponseData);
    }
  }
}
