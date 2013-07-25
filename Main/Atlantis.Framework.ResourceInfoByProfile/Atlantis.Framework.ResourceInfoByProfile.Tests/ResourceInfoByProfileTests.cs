using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using Atlantis.Framework.ResourceInfoByProfile.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.ResourceInfoByProfile.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GetResourceInfoByProfileTests
  {
  
    private const string _shopperId = "842749";
    private const int _resourceInfoByProfileRequestType = 125;

    public string CertName { get; set; }
    public string AppName { get; set; }

    public GetResourceInfoByProfileTests()
    {
    }

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

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [DeploymentItem("app.config")]
    public void ResourceInfoByProfileTest()
    {
      List<SqlParameter> parms = new List<SqlParameter>();
      parms.Add(new SqlParameter("@shopper_id", _shopperId));
      //parms.Add(new SqlParameter("@returnAll", 1));
      // parms.Add(new SqlParameter("rowsperpage", 14));
      // parms.Add(new SqlParameter("@namespaceFilterList", "bundle"));
      // parms.Add(new SqlParameter("@sortcol", "nameSpace"));

      ResourceInfoByProfileRequestData request = new ResourceInfoByProfileRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , parms);

      ResourceInfoByProfileResponseData response = (ResourceInfoByProfileResponseData)Engine.Engine.ProcessRequest(request, _resourceInfoByProfileRequestType);

      foreach (ResourceInfo ri in response.ResourceInfos)
      {
        Console.WriteLine("***************************");
        Console.WriteLine(string.Format("WorkId: {0}", ri.WorkId));
        Console.WriteLine(string.Format("ResourceId: {0}", ri.ResourceId));
        Console.WriteLine(string.Format("NameSpace: {0}", ri.NameSpace));
        Console.WriteLine(string.Format("PP_ShopperProfileId: {0}", ri.PpShopperProfileId));
        Console.WriteLine(string.Format("ProductDescription: {0}", ri.ProductDescription));
        Console.WriteLine(string.Format("Info: {0}", ri.Info));
        Console.WriteLine(string.Format("BillingDate: {0}", ri.BillingDate));
        Console.WriteLine(string.Format("OrderId: {0}", ri.OrderId));
        Console.WriteLine(string.Format("RenewalSku: {0}", ri.RenewalSku));
        Console.WriteLine(string.Format("IsLimited: {0}", ri.IsLimited));
        Console.WriteLine(string.Format("PfId: {0}", ri.PfId));
        Console.WriteLine(string.Format("RecordToKeep: {0}", ri.RecordToKeep));
        Console.WriteLine(string.Format("AutoRenewFlag: {0}", ri.AutoRenewFlag));
        Console.WriteLine(string.Format("AllowRenewals: {0}", ri.AllowRenewals));
        Console.WriteLine(string.Format("RecurringPayment: {0}", ri.RecurringPayment));
        Console.WriteLine(string.Format("NumberOfPeriods: {0}", ri.NumberOfPeriods));
        Console.WriteLine(string.Format("RenewalPfId: {0}", ri.RenewalPfId));
        Console.WriteLine(string.Format("GdShopProductTypeId: {0}", ri.GdshopProductTypeId));
        Console.WriteLine(string.Format("IsPastDue: {0}", ri.IsPastDue));
        Console.WriteLine(string.Format("UsageStartDate: {0}", ri.UsageStartDate));
        Console.WriteLine(string.Format("UsageEndDate: {0}", ri.UsageEndDate));
        Console.WriteLine(string.Format("ExternalResourceId: {0}", ri.ExternalResourceId));
      }
      Debug.WriteLine("***************************");
      Debug.WriteLine("***************************");
      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [DeploymentItem("app.config")]
    public void ResourceInfoByProfileSerializeTest()
    {
      List<SqlParameter> parms = new List<SqlParameter>();
      parms.Add(new SqlParameter("@shopper_id", _shopperId));
      //parms.Add(new SqlParameter("@returnAll", 1));
      // parms.Add(new SqlParameter("rowsperpage", 14));
      // parms.Add(new SqlParameter("@namespaceFilterList", "bundle"));
      // parms.Add(new SqlParameter("@sortcol", "nameSpace"));

      ResourceInfoByProfileRequestData request = new ResourceInfoByProfileRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , parms);

      ResourceInfoByProfileResponseData response = (ResourceInfoByProfileResponseData)Engine.Engine.ProcessRequest(request, _resourceInfoByProfileRequestType);
      ResourceInfoByProfileResponseData serializedResponse = new ResourceInfoByProfileResponseData(response.ToXML());
      //     serializedResponse.ToXML();

      Assert.AreEqual(response.ResourceInfos.Count, serializedResponse.ResourceInfos.Count);

      foreach (ResourceInfo r in response.ResourceInfos)
      {
        foreach (ResourceInfo sr in serializedResponse.ResourceInfos)
        {
          if (r.ResourceId == sr.ResourceId && r.OrderId == sr.OrderId)
          {
            Assert.AreEqual(r.WorkId, sr.WorkId, string.Format("WorkId on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.ResourceId, sr.ResourceId, string.Format("ResourceID on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.NameSpace == null ? string.Empty : r.NameSpace, sr.NameSpace, string.Format("NameSpace on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.PpShopperProfileId, sr.PpShopperProfileId, string.Format("PpShopperProfileId on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.ProductDescription == null ? string.Empty : r.ProductDescription, sr.ProductDescription, string.Format("ProductDescription on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.Info == null ? string.Empty : r.Info, sr.Info, string.Format("Info on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.BillingDate.ToString(), sr.BillingDate.ToString(), string.Format("BillingDate on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.OrderId == null ? string.Empty : r.OrderId, sr.OrderId, string.Format("OrderID on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.RenewalSku == null ? string.Empty : r.RenewalSku, sr.RenewalSku, string.Format("RenewalSku on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.IsLimited, sr.IsLimited, string.Format("IsLimited on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.PfId, sr.PfId, string.Format("PfId on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.RecordToKeep, sr.RecordToKeep, string.Format("RecordToKeep on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.AutoRenewFlag, sr.AutoRenewFlag, string.Format("AutoRenewFlag on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.AllowRenewals, sr.AllowRenewals, string.Format("AllowRenewals on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.RecurringPayment == null ? string.Empty : r.RecurringPayment, sr.RecurringPayment, string.Format("RecurringPayment on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.NumberOfPeriods, sr.NumberOfPeriods, string.Format("NumberOfPeriods on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.RenewalPfId, sr.RenewalPfId, string.Format("RenewalPfId on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.GdshopProductTypeId, sr.GdshopProductTypeId, string.Format("GdshopProductTypeId on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.IsPastDue, sr.IsPastDue, string.Format("IsPastDue on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.UsageStartDate.ToString(), sr.UsageStartDate.ToString(), string.Format("UsageStartDate on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.UsageEndDate.ToString(), sr.UsageEndDate.ToString(), string.Format("UsageEndDate on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
            Assert.AreEqual(r.ExternalResourceId == null ? string.Empty : r.ExternalResourceId, sr.ExternalResourceId, string.Format("ExternalResourceID on ResourceID: {0} & {1}", r.ResourceId, sr.ResourceId));
          }
        }
      }

      Assert.IsTrue(serializedResponse.IsSuccess);
    }
  }
}
