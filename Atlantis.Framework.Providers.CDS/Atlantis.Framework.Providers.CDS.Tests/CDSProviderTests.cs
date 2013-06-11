using System;
using System.Diagnostics;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Providers.Interface.CDS;
using Atlantis.Framework.Testing.MockHttpContext;
using Atlantis.Framework.Testing.MockProviders;
using Atlantis.Framework.Tokens.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.Providers.CDS.Tests
{
  [TestClass]
  [DeploymentItem("atlantis.config")]
  [DeploymentItem("Atlantis.Framework.CDS.Impl.dll")]
  [DeploymentItem("Atlantis.Framework.Providers.CDS.dll")]
  public class CDSProviderTests
  {
    private IProviderContainer _providerContainer;
    private IProviderContainer ProviderContainer
    {
      get
      {
        if (_providerContainer == null)
        {
          _providerContainer = new MockProviderContainer();

          _providerContainer.RegisterProvider<ISiteContext, TestContexts>();
          _providerContainer.RegisterProvider<IShopperContext, TestContexts>();
          _providerContainer.RegisterProvider<ICDSProvider, CDSProvider>();
        }
        return _providerContainer;
      }
    }
    public CDSProviderTests()
    {
      TokenManager.AutoRegisterTokenHandlers(Assembly.GetExecutingAssembly());
    }

    [TestMethod]
    public void GetJson()
    {
      MockHttpRequest mockHttpRequest = new MockHttpRequest("http://www.debug.godaddy-com.ide/cdstesting/renderpipeline/condition-test?docid=5181863ff778fc24c053cf3c");
      MockHttpContext.SetFromWorkerRequest(mockHttpRequest);

      var cdsProvider = ProviderContainer.Resolve<ICDSProvider>();
      string cdsJson = cdsProvider.GetJson("content/en/sales/1/cdstesting/renderpipeline/condition-test");
      
      Assert.IsTrue(cdsJson.Contains("$1000"));
      
      Debug.WriteLine(cdsJson);
      Console.WriteLine(cdsJson);
    }
  }
}
