using System.Diagnostics;
using Atlantis.Framework.GetCoupons.Interface;
using Atlantis.Framework.Testing.MockHttpContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.GetCoupons.Tests
{
  [TestClass]
  public class GetCouponsTests
  {

    private const string _shopperId = "842749";
    private const string _userName = "jks";

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

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void GetCoupons()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      GetCouponsRequestData request = new GetCouponsRequestData(_shopperId
        , string.Empty
        , string.Empty
        , string.Empty
        , 0);
           

      GetCouponsResponseData response = SessionCache.SessionCache.GetProcessRequest<GetCouponsResponseData>(request, 86);

      foreach (AdWordCoupon coupon in response.GetCouponList())
      {
        Assert.IsFalse(string.IsNullOrEmpty(coupon.CouponKey));
        Debug.WriteLine(string.Format("CouponKey: {0}", coupon.CouponKey)); 
        
        Assert.IsTrue(coupon.CouponValue > 0);
        Debug.WriteLine(string.Format("CouponValue: {0}", coupon.CouponValue)); 

        Assert.IsFalse(string.IsNullOrEmpty(coupon.OrderId));
        Debug.WriteLine(string.Format("OrderId: {0}", coupon.OrderId)); 

        Assert.IsFalse(string.IsNullOrEmpty(coupon.Vendor));
        Debug.WriteLine(string.Format("Vendor: {0}", coupon.Vendor));
        Debug.WriteLine(string.Format("OutOfStock: {0}", coupon.OutOfStock));
        Debug.WriteLine("");
      }

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }
  }
}
