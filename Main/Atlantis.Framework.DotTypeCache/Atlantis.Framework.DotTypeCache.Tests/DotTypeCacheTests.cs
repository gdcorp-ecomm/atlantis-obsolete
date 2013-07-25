﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DotTypeCache.Interface;
using Atlantis.Framework.Providers.Interface.ProviderContainer;
using Atlantis.Framework.Testing.MockHttpContext;
using Atlantis.Framework.Interface;
using System.Web;
using System.IO;

namespace Atlantis.Framework.DotTypeCache.Tests
{
  [TestClass]
  public class DotTypeCacheTests
  {
    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
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

    [TestInitialize]
    public void InitializeTests()
    {
      HttpProviderContainer.Instance.RegisterProvider<ISiteContext, TestContexts>();
      HttpProviderContainer.Instance.RegisterProvider<IShopperContext, TestContexts>();
      HttpProviderContainer.Instance.RegisterProvider<IManagerContext, TestContexts>();
      MockHttpContext.SetMockHttpContext("default.aspx", "http://siteadmin.debug.intranet.gdg/default.aspx", string.Empty);
      ISiteContext siteContext = HttpProviderContainer.Instance.Resolve<ISiteContext>();
      ((TestContexts)siteContext).SetContextInfo(1, "832652");
      IShopperContext shopperContext = HttpProviderContainer.Instance.Resolve<IShopperContext>();
      ((TestContexts)shopperContext).SetContextInfo(1, "832652");
      IManagerContext managerContext = HttpProviderContainer.Instance.Resolve<IManagerContext>();
      ((TestContexts)managerContext).SetContextInfo(1, "832652");

    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [DeploymentItem("Interop.gdDataCacheLib.dll")]
    public void GetDotTypeProductIds()
    {
      int productIdDefault = DotTypeCache.GetRegistrationProductId("co.uk", 2, 1);
      int productIdFirstRegistrar = DotTypeCache.GetTransferProductId("co.uk", "1", 2, 1);
      int productIdSecondRegistrar = DotTypeCache.GetRegistrationProductId("co.uk","2", 2, 1);
      string description = DotTypeCache.GetAdditionalInfoValue("co.uk", "Description");
      IDotTypeInfo info = DotTypeCache.GetDotTypeInfo("co.uk");
      Assert.IsTrue((productIdDefault * productIdFirstRegistrar * productIdSecondRegistrar) != 0);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [DeploymentItem("Interop.gdDataCacheLib.dll")]
    public void GetDotTypeProductIds2()
    {
      List<int> regLengths = new List<int>();
      regLengths.Add(1);
      regLengths.Add(2);
      regLengths.Add(3);
      regLengths.Add(4);
      regLengths.Add(5);
      regLengths.Add(6);
      regLengths.Add(7);
      regLengths.Add(8);
      regLengths.Add(9);
      regLengths.Add(10);
      IDotTypeInfo dotTypeInfo = DotTypeCache.GetDotTypeInfo("CO.UK");
      List<int> RegistrationProductIds = dotTypeInfo.GetValidRegistrationProductIdList(1, regLengths.ToArray());
      List<int> TransferProductIds = dotTypeInfo.GetValidTransferProductIdList(1, regLengths.ToArray());
      List<int> renewProductIds = dotTypeInfo.GetValidRenewalProductIdList(1, regLengths.ToArray());
      List<int> renewProductIds2 = dotTypeInfo.GetValidRenewalProductIdList("1", 1, regLengths.ToArray());
      List<int> renewProductIds3 = dotTypeInfo.GetValidRenewalProductIdList("2", 1, regLengths.ToArray());
      int renewProductId = dotTypeInfo.GetRenewalProductId("1", 2, 1);
      Assert.IsTrue(renewProductId == 13313);
      Assert.IsTrue((RegistrationProductIds.Count * TransferProductIds.Count * renewProductIds.Count) != 0);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [DeploymentItem("Interop.gdDataCacheLib.dll")]
    public void GetDotTypeProductIdsXxx()
    {
      List<int> regLengths = new List<int>();
      regLengths.Add(1);
      regLengths.Add(2);
      regLengths.Add(3);
      regLengths.Add(4);
      regLengths.Add(5);
      regLengths.Add(6);
      regLengths.Add(7);
      regLengths.Add(8);
      regLengths.Add(9);
      regLengths.Add(10);
      //IDotTypeInfo dotTypeInfo = DotTypeCache.GetDotTypeInfo("XXX");
      int productId = DotTypeCache.GetPreRegProductId("XXX", 1, 1);
      ///List<int> RegistrationProductIds = dotTypeInfo.GetValidRegistrationProductIdList(1, regLengths.ToArray());
      ///List<int> TransferProductIds = dotTypeInfo.GetValidTransferProductIdList(1, regLengths.ToArray());
      //List<int> renewProductIds = dotTypeInfo.GetValidRenewalProductIdList(1, regLengths.ToArray());
      Assert.IsTrue(productId != 0);
    }


    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
      DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
    TestMethod]
      [Ignore]
    public void GetMinMaxLengths()
    {
        StreamWriter sw = new StreamWriter("C:\\maxminlist.csv", true);

        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);

        //registration
        if (info.HasRegistrationIds)
        {
            int min = info.MinRegistrationLength;
            int max = info.MaxRegistrationLength;
                sw.WriteLine("registration, " + dotType + ", " + min.ToString() + ", " + max.ToString());
        }

        //renewal
        if (info.HasRenewalIds)
        {
            int min = info.MinRenewalLength;
            int max = info.MaxRenewalLength;
                sw.WriteLine("renewal, " + dotType + ", " + min.ToString() + ", " + max.ToString());
        }

        //transfer
        if (info.HasTransferIds)
        {
            int min = info.MinTransferLength;
            int max = info.MaxTransferLength;
                sw.WriteLine("transfer, " + dotType + ", " + min.ToString() + ", " + max.ToString());
        }
        sw.Close();
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
      TestMethod]
      [Ignore]
    public void GetProductIDsByTLDandDuration()
    {
        StreamWriter sw = new StreamWriter("C:\\pfidlist.csv", true);

        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);

        //registration
        if (info.HasRegistrationIds)
        {
            int min = info.MinRegistrationLength;
            int max = info.MaxRegistrationLength;
            for (int i = min; i <= max; i++)
            {
                int productID = DotTypeCache.GetRegistrationProductId(dotType, i, 1);
                sw.WriteLine("registration, " + dotType + ", " + i.ToString() + ", " + productID);
            }
        }

        //renewal
        if (info.HasRenewalIds)
        {
            int min = info.MinRenewalLength;
            int max = info.MaxRenewalLength;
            for (int i = min; i <= max; i++)
            {
                int productID = DotTypeCache.GetRenewalProductId(dotType, i, 1);
                sw.WriteLine("renewal, " + dotType + ", " + i.ToString() + ", " + productID);
            }
        }

        //transfer
        if (info.HasTransferIds)
        {
            int min = info.MinTransferLength;
            int max = info.MaxTransferLength;
            for (int i = min; i <= max; i++)
            {
                int productID = DotTypeCache.GetTransferProductId(dotType, i, 1);
                sw.WriteLine("transfer, " + dotType + ", " + i.ToString() + ", " + productID);
            }
        }

        sw.Close();
    }

    #region GetDotTypeInfo

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
      TestMethod]
    public void GetDotTypeInfo()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        Assert.IsNotNull(info);
        Assert.AreEqual(dotType.ToUpper(), info.DotType, "DotType does not match for : " + dotType.ToUpper());
        Assert.AreEqual((string)testContextInstance.DataRow["HasPreRegIds"], info.HasPreRegIds.ToString(),
            "HasPreRegIds does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["HasPreRegIds"] + " Actual: " + info.HasPreRegIds.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["HasRegistrationIds"], info.HasRegistrationIds.ToString(),
            "HasRegistrationIds does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["HasRegistrationIds"] + " Actual: " + info.HasRegistrationIds.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["HasRenewalIds"], info.HasRenewalIds.ToString(),
            "HasRenewalIds does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["HasRenewalIds"] + " Actual: " + info.HasRenewalIds.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["HasTransferIds"], info.HasTransferIds.ToString(),
            "HasTransferIds does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["HasTransferIds"] + " Actual: " + info.HasTransferIds.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["HasExpiredAuctionIds"], info.HasExpiredAuctionRegIds.ToString(),
            "HasExpiredAuctionIds does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["HasExpiredAuctionIds"] + " Actual: " + info.HasExpiredAuctionRegIds.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MaxPreRegLength"], info.MaxPreRegLength.ToString(),
            "MaxPreRegLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MaxPreRegLength"] + " Actual: " + info.MaxPreRegLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MaxExpAuctionRegLength"], info.MaxExpiredAuctionRegLength.ToString(),
            "MaxExpAuctionRegLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MaxExpAuctionRegLength"] + " Actual: " + info.MaxExpiredAuctionRegLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MaxRegistrationLength"], info.MaxRegistrationLength.ToString(),
            "MaxRegistrationLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MaxRegistrationLength"] + " Actual: " + info.MaxRegistrationLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MaxRenewalLength"], info.MaxRenewalLength.ToString(),
            "MaxRenewalLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MaxRenewalLength"] + " Actual: " + info.MaxRenewalLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MaxTransferLength"], info.MaxTransferLength.ToString(),
            "MaxTransferLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MaxTransferLength"] + " Actual: " + info.MaxTransferLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MinPreRegLength"], info.MinPreRegLength.ToString(),
            "MinPreRegLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MinPreRegLength"] + " Actual: " + info.MinPreRegLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MinExpAuctionRegLength"], info.MinExpiredAuctionRegLength.ToString(),
           "MinExpAuctionRegLength does not match for: " + dotType.ToUpper() + ". Expected: " +
           (string)testContextInstance.DataRow["MinExpAuctionRegLength"] + " Actual: " + info.MinExpiredAuctionRegLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MinRegistrationLength"], info.MinRegistrationLength.ToString(),
            "MinRegistrationLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MinRegistrationLength"] + " Actual: " + info.MinRegistrationLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MinRenewalLength"], info.MinRenewalLength.ToString(),
            "MinRenewalLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MinRenewalLength"] + " Actual: " + info.MinRenewalLength.ToString());
        Assert.AreEqual((string)testContextInstance.DataRow["MinTransferLength"], info.MinTransferLength.ToString(),
            "MinTransferLength does not match for: " + dotType.ToUpper() + ". Expected: " +
            (string)testContextInstance.DataRow["MinTransferLength"] + " Actual: " + info.MinTransferLength.ToString());
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetDotTypeInfo_Empty()
    {
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(string.Empty);
        Assert.AreEqual("INVALID", info.DotType);
    }

    [TestMethod]
    public void N_GetDotTypeInfo_Invalid()
    {
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo("blah");
        Assert.AreEqual("INVALID", info.DotType);
    }

    [TestMethod]
    public void N_GetDotTypeInfo_Null()
    {
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(null);
        Assert.AreEqual("INVALID", info.DotType);
    }

    #endregion

    #endregion

    #region HasDotTypeInfo

    [DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
      DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
          DataAccessMethod.Sequential), TestMethod]
    public void HasDotTypeInfo()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        bool result = DotTypeCache.HasDotTypeInfo(dotType);
        Assert.IsTrue(result, "HasDotTypeInfo not returned for " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_HasDotTypeInfo_Empty()
    {
        bool result = DotTypeCache.HasDotTypeInfo(string.Empty);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void N_HasDotTypeInfo_Invalid()
    {
        bool result = DotTypeCache.HasDotTypeInfo("blah");
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void N_HasDotTypeInfo_Null()
    {
        bool result = DotTypeCache.HasDotTypeInfo(null);
        Assert.IsFalse(result);
    }

    #endregion

    #endregion

    #region GetPreRegProductId

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetPreRegProductId_MinimumPreRegLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasPreRegIds)
        {
            int productId = DotTypeCache.GetPreRegProductId(dotType, info.MinPreRegLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetPreRegProductId_MaximumPreRegLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasPreRegIds)
        {
            int productId = DotTypeCache.GetPreRegProductId(dotType, info.MaxPreRegLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetPreRegProductId_BulkProductId()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasPreRegIds)
        {
            int productId = DotTypeCache.GetPreRegProductId(dotType, info.MinPreRegLength, 100);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);

            //verify it is different than domainCount = 1
            int productId1stTier = DotTypeCache.GetPreRegProductId(dotType, info.MinPreRegLength, 1);
            Assert.AreNotEqual(productId1stTier, productId, "ProductID for bulk tiers is the same for dotType: " + dotType);
        }
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetPreRegProductId_EmptyDotType()
    {
        int productId = DotTypeCache.GetPreRegProductId(string.Empty, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetPreRegProductId_InvalidDotType()
    {
        int productId = DotTypeCache.GetPreRegProductId("blah", 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetPreRegProductId_NullDotType()
    {
        int productId = DotTypeCache.GetPreRegProductId(null, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetPreRegProductId_InvalidRegistrationLength()
    {
        int productId = DotTypeCache.GetPreRegProductId("com", 20, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetPreRegProductId_InvalidDomainCount()
    {
        int productId = DotTypeCache.GetPreRegProductId("com", 1, 10000);
        Assert.AreEqual(0, productId);
    }

    #endregion

    #endregion

    #region GetExpiredAucctionRegistrationProductID

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetExpiredAuctionRegistrationProductId_MinimumRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasExpiredAuctionRegIds)
        {
            int productId = DotTypeCache.GetExpiredAuctionRegProductId(dotType, info.MinExpiredAuctionRegLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetExpiredAuctionRegistrationProductId_MaximumRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasExpiredAuctionRegIds)
        {
            int productId = DotTypeCache.GetExpiredAuctionRegProductId(dotType, info.MaxExpiredAuctionRegLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetExpiredAuctionRegistrationProductId_BulkProductID()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasExpiredAuctionRegIds)
        {
            int productId = DotTypeCache.GetExpiredAuctionRegProductId(dotType, info.MinExpiredAuctionRegLength, 100);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    #endregion

    #region GetRegistrationProductId

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetRegistrationProductId_MinimumRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasRegistrationIds)
        {
            int productId = DotTypeCache.GetRegistrationProductId(dotType, info.MinRegistrationLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetRegistrationProductId_MaximumRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasRegistrationIds)
        {
            int productId = DotTypeCache.GetRegistrationProductId(dotType, info.MaxRegistrationLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetRegistrationProductId_BulkProductId()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasRegistrationIds)
        {
            int productId = DotTypeCache.GetRegistrationProductId(dotType, info.MinRegistrationLength, 100);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetRegistrationProductId_EmptyDotType()
    {
        int productId = DotTypeCache.GetRegistrationProductId(string.Empty, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRegistrationProductId_InvalidDotType()
    {
        int productId = DotTypeCache.GetRegistrationProductId("blah", 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRegistrationProductId_NullDotType()
    {
        int productId = DotTypeCache.GetRegistrationProductId(null, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRegistrationProductId_InvalidRegistrationLength()
    {
        int productId = DotTypeCache.GetRegistrationProductId("com", 20, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRegistrationProductId_LargeDomainCount()
    {
        int productId = DotTypeCache.GetRegistrationProductId("com", 1, 10000);
        Assert.AreNotEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRegistrationProductId_InvalidDomainCount()
    {
        int productId = DotTypeCache.GetRegistrationProductId("com", 1, -1);
        Assert.AreNotEqual(0, productId);
    }


    #endregion

    #endregion

    #region GetTransferProductId

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetTransferProductId_MinimumTransferLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasTransferIds)
        {
            int productId = DotTypeCache.GetTransferProductId(dotType, info.MinTransferLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetTransferProductId_MaximumTransferLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasTransferIds)
        {
            int productId = DotTypeCache.GetTransferProductId(dotType, info.MaxTransferLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetTransferProductId_BulkProductId()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasTransferIds)
        {
            int productId = DotTypeCache.GetTransferProductId(dotType, info.MinTransferLength, 100);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetTransferProductId_EmptyDotType()
    {
        int productId = DotTypeCache.GetTransferProductId(string.Empty, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetTransferProductId_InvalidDotType()
    {
        int productId = DotTypeCache.GetTransferProductId("blah", 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetTransferProductId_NullDotType()
    {
        int productId = DotTypeCache.GetTransferProductId(null, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetTransferProductId_InvalidTransferLength()
    {
        int productId = DotTypeCache.GetTransferProductId("com", 20, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetTransferProductId_LargeDomainCount()
    {
        int productId = DotTypeCache.GetTransferProductId("com", 1, 10000);
        Assert.AreNotEqual(0, productId);
    }

    #endregion

    #endregion

    #region GetRenewalProductId

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetRenewalProductId_MinimumRenewalLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasRenewalIds)
        {
            int productId = DotTypeCache.GetRenewalProductId(dotType, info.MinRenewalLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetRenewalProductId_MaximumRenewalLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasTransferIds)
        {
            int productId = DotTypeCache.GetRenewalProductId(dotType, info.MaxRenewalLength, 1);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetRenewalProductId_BulkProductId()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasRenewalIds)
        {
            int productId = DotTypeCache.GetRenewalProductId(dotType, info.MinRenewalLength, 100);
            Assert.IsTrue(productId > 0, "ProductID < 0 for dotType: " + dotType);
        }
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetRenewalProductId_EmptyDotType()
    {
        int productId = DotTypeCache.GetRenewalProductId(string.Empty, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRenewalProductId_InvalidDotType()
    {
        int productId = DotTypeCache.GetRenewalProductId("blah", 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRenewalProductId_NullDotType()
    {
        int productId = DotTypeCache.GetRenewalProductId(null, 1, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRenewalProductId_InvalidRenewalLength()
    {
        int productId = DotTypeCache.GetRenewalProductId("com", 20, 1);
        Assert.AreEqual(0, productId);
    }

    [TestMethod]
    public void N_GetRenewalProductId_LargeDomainCount()
    {
        int productId = DotTypeCache.GetRenewalProductId("com", 1, 10000);
        Assert.AreNotEqual(0, productId);
    }

    #endregion

    #endregion

    #region GetMinPreRegLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMinPreRegLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int preRegLength = DotTypeCache.GetMinPreRegLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MinPreRegLength"], preRegLength.ToString(),
            "MinPreRegLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMinPreRegLength_Empty()
    {
        int preRegLength = DotTypeCache.GetMinPreRegLength(string.Empty);
        Assert.AreEqual(1, preRegLength);
    }

    [TestMethod]
    public void N_GetMinPreRegLength_Invalid()
    {
        int preRegLength = DotTypeCache.GetMinPreRegLength("blah");
        Assert.AreEqual(1, preRegLength);
    }

    [TestMethod]
    public void N_GetMinPreRegLength_Null()
    {
        int preRegLength = DotTypeCache.GetMinPreRegLength(null);
        Assert.AreEqual(1, preRegLength);
    }

    #endregion

    #endregion

    #region GetMaxPreRegLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMaxPreRegLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int preRegLength = DotTypeCache.GetMaxPreRegLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MaxPreRegLength"], preRegLength.ToString(),
            "MaxPreRegLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMaxPreRegLength_Empty()
    {
        int preRegLength = DotTypeCache.GetMaxPreRegLength(string.Empty);
        Assert.AreEqual(10, preRegLength);
    }

    [TestMethod]
    public void N_GetMaxPreRegLength_Invalid()
    {
        int preRegLength = DotTypeCache.GetMaxPreRegLength("blah");
        Assert.AreEqual(10, preRegLength);
    }

    [TestMethod]
    public void N_GetMaxPreRegLength_Null()
    {
        int preRegLength = DotTypeCache.GetMaxPreRegLength(null);
        Assert.AreEqual(10, preRegLength);
    }

    #endregion

    #endregion

    #region GetMinExpiredAuctionRegistrationLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMinExpiredAuctionRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);

        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasExpiredAuctionRegIds)
        {
            int regLength = DotTypeCache.GetMinExpiredAuctionRegLength(dotType);
            Assert.AreEqual((string)testContextInstance.DataRow["MinExpAuctionRegLength"], regLength.ToString(),
                "MinExpAuctionRegLength is not as expected for dotType: " + dotType);
        }
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMinExpiredAuctionRegistrationLength_Empty()
    {
        int regLength = DotTypeCache.GetMinExpiredAuctionRegLength(string.Empty);
        Assert.AreEqual(1, regLength);
    }

    [TestMethod]
    public void N_GetMinExpiredAuctionRegistrationLength_Invalid()
    {
        int regLength = DotTypeCache.GetMinExpiredAuctionRegLength("blah");
        Assert.AreEqual(1, regLength);
    }

    [TestMethod]
    public void N_GetMinExpiredAuctionRegistrationLength_Null()
    {
        int regLength = DotTypeCache.GetMinExpiredAuctionRegLength(null);
        Assert.AreEqual(1, regLength);
    }

    #endregion

    #endregion

    #region GetMaxExpiredAuctionRegistrationLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMaxExpiredAuctionRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);

        IDotTypeInfo info = DotTypeCache.GetDotTypeInfo(dotType);
        if (info.HasExpiredAuctionRegIds)
        {
            int regLength = DotTypeCache.GetMaxExpiredAuctionRegLength(dotType);
            Assert.AreEqual((string)testContextInstance.DataRow["MaxExpAuctionRegLength"], regLength.ToString(),
                "MaxExpAuctionRegLength is not as expected for dotType: " + dotType);
        }
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMaxExpiredAuctionRegistrationLength_Empty()
    {
        int regLength = DotTypeCache.GetMaxExpiredAuctionRegLength(string.Empty);
        Assert.AreEqual(10, regLength);
    }

    [TestMethod]
    public void N_GetMaxExpiredAuctionRegistrationLength_Invalid()
    {
        int regLength = DotTypeCache.GetMaxExpiredAuctionRegLength("blah");
        Assert.AreEqual(10, regLength);
    }

    [TestMethod]
    public void N_GetMaxExpiredAuctionRegistrationLength_Null()
    {
        int regLength = DotTypeCache.GetMaxExpiredAuctionRegLength(null);
        Assert.AreEqual(10, regLength);
    }

    #endregion

    #endregion

    #region GetMinRegistrationLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMinRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int regLength = DotTypeCache.GetMinRegistrationLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MinRegistrationLength"], regLength.ToString(),
            "MinRegistrationLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMinRegistrationLength_Empty()
    {
        int regLength = DotTypeCache.GetMinRegistrationLength(string.Empty);
        Assert.AreEqual(1, regLength);
    }

    [TestMethod]
    public void N_GetMinRegistrationLength_Invalid()
    {
        int regLength = DotTypeCache.GetMinRegistrationLength("blah");
        Assert.AreEqual(1, regLength);
    }

    [TestMethod]
    public void N_GetMinRegistrationLength_Null()
    {
        int regLength = DotTypeCache.GetMinRegistrationLength(null);
        Assert.AreEqual(1, regLength);
    }

    #endregion

    #endregion

    #region GetMaxRegistrationLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMaxRegistrationLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int regLength = DotTypeCache.GetMaxRegistrationLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MaxRegistrationLength"], regLength.ToString(),
            "MaxRegistrationLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMaxRegistrationLength_Empty()
    {
        int regLength = DotTypeCache.GetMaxRegistrationLength(string.Empty);
        Assert.AreEqual(10, regLength);
    }

    [TestMethod]
    public void N_GetMaxRegistrationLength_Invalid()
    {
        int regLength = DotTypeCache.GetMaxRegistrationLength("blah");
        Assert.AreEqual(10, regLength);
    }

    [TestMethod]
    public void N_GetMaxRegistrationLength_Null()
    {
        int regLength = DotTypeCache.GetMaxRegistrationLength(null);
        Assert.AreEqual(10, regLength);
    }

    #endregion

    #endregion

    #region GetMinTransferLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMinTransferLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int transferLength = DotTypeCache.GetMinTransferLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MinTransferLength"], transferLength.ToString(),
            "MinTransferLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMinTransferLength_Empty()
    {
        int transferLength = DotTypeCache.GetMinTransferLength(string.Empty);
        Assert.AreEqual(1, transferLength);
    }

    [TestMethod]
    public void N_GetMinTransferLength_Invalid()
    {
        int transferLength = DotTypeCache.GetMinTransferLength("blah");
        Assert.AreEqual(1, transferLength);
    }

    [TestMethod]
    public void N_GetMinTransferLength_Null()
    {
        int transferLength = DotTypeCache.GetMinTransferLength(null);
        Assert.AreEqual(1, transferLength);
    }

    #endregion

    #endregion

    #region GetMaxTransferLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetMaxTransferLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int transferLength = DotTypeCache.GetMaxTransferLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MaxTransferLength"], transferLength.ToString(),
            "MaxTransferLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMaxTransferLength_Empty()
    {
        int transferLength = DotTypeCache.GetMaxTransferLength(string.Empty);
        Assert.AreEqual(10, transferLength);
    }

    [TestMethod]
    public void N_GetMaxTransferLength_Invalid()
    {
        int transferLength = DotTypeCache.GetMaxTransferLength("blah");
        Assert.AreEqual(10, transferLength);
    }

    [TestMethod]
    public void N_GetMaxTransferLength_Null()
    {
        int transferLength = DotTypeCache.GetMaxTransferLength(null);
        Assert.AreEqual(10, transferLength);
    }

    #endregion

    #endregion

    #region GetMinRenewalLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
      DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
      TestMethod]
    public void GetMinRenewalLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int renewalLength = DotTypeCache.GetMinRenewalLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MinRenewalLength"], renewalLength.ToString(),
            "MinRenewalLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMinRenewalLength_Empty()
    {
        int renewalLength = DotTypeCache.GetMinRenewalLength(string.Empty);
        Assert.AreEqual(1, renewalLength);
    }

    [TestMethod]
    public void N_GetMinRenewalLength_Invalid()
    {
        int renewalLength = DotTypeCache.GetMinRenewalLength("blah");
        Assert.AreEqual(1, renewalLength);
    }

    [TestMethod]
    public void N_GetMinRenewalLength_Null()
    {
        int renewalLength = DotTypeCache.GetMinRenewalLength(null);
        Assert.AreEqual(1, renewalLength);
    }


    #endregion

    #endregion

    #region GetMaxRenewalLength

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("atlantis.config"), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
    DeploymentItem("Interop.gdDataCacheLib.dll"),
        TestMethod]
    public void GetMaxRenewalLength()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        int renewalLength = DotTypeCache.GetMaxRenewalLength(dotType);
        Assert.AreEqual((string)testContextInstance.DataRow["MaxRenewalLength"], renewalLength.ToString(),
            "MaxRenewalLength is not as expected for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetMaxRenewalLength_Empty()
    {
        int renewalLength = DotTypeCache.GetMaxRenewalLength(string.Empty);
        Assert.AreEqual(10, renewalLength);
    }

    [TestMethod]
    public void N_GetMaxRenewalLength_Invalid()
    {
        int renewalLength = DotTypeCache.GetMaxRenewalLength("blah");
        Assert.AreEqual(10, renewalLength);
    }

    [TestMethod]
    public void N_GetMaxRenewalLength_Null()
    {
        int renewalLength = DotTypeCache.GetMaxRenewalLength(null);
        Assert.AreEqual(10, renewalLength);
    }

    #endregion

    #endregion

    #region GetAdditionalInfo

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetAdditionalInfo()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        Dictionary<string, string> addlInfo = DotTypeCache.GetAdditionalInfo(dotType);
        Assert.IsNotNull(addlInfo, "Additional Info is null for dotType: " + dotType);
        Assert.AreNotEqual(0, addlInfo.Count, "Additional Items Count invalid for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetAdditionalInfo_Empty()
    {
        Dictionary<string, string> addlInfo = DotTypeCache.GetAdditionalInfo(string.Empty);
        Assert.IsNotNull(addlInfo);
        Assert.AreEqual(0, addlInfo.Count);
    }

    #endregion

    #endregion

    #region GetAdditionalInfoValue

    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\DotTypesData.xml", "DotType",
        DataAccessMethod.Sequential), DeploymentItem("Atlantis.Framework.DotTypeCache.Tests\\DotTypesData.xml"),
        TestMethod]
    public void GetAdditionalInfoValue()
    {
        string dotType = System.Convert.ToString(testContextInstance.DataRow["DotTypeName"]);
        string result = DotTypeCache.GetAdditionalInfoValue(dotType, "LandingPageUrl");
        Assert.AreNotEqual(0, result.Length, "LandingPageUrl not returned for dotType: " + dotType);
    }

    #region Negative Tests

    [TestMethod]
    public void N_GetAdditionalInfoValue_EmptyDotType()
    {
        string result = DotTypeCache.GetAdditionalInfoValue(string.Empty, "LandingPageUrl");
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void N_GetAdditionalInfoValue_InvalidDotType()
    {
        string result = DotTypeCache.GetAdditionalInfoValue("blah", "LandingPageUrl");
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void N_GetAdditionalInfoValue_NullDotType()
    {
        string result = DotTypeCache.GetAdditionalInfoValue(null, "LandingPageUrl");
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void N_GetAdditionalInfoValue_EmptyValue()
    {
        string result = DotTypeCache.GetAdditionalInfoValue("com", string.Empty);
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void N_GetAdditionalInfoValue_InvalidValue()
    {
        string result = DotTypeCache.GetAdditionalInfoValue("com", "blah");
        Assert.AreEqual(0, result.Length);
    }

    [TestMethod]
    public void N_GetAdditionalInfoValue_NullValue()
    {
        string result = DotTypeCache.GetAdditionalInfoValue("com", null);
        Assert.AreEqual(0, result.Length);
    }

    #endregion

    #endregion
  }
}
