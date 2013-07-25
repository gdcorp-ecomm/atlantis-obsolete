using System;
using System.Collections.Generic;

using System.Text;

namespace Atlantis.Framework.GetCoupons.Interface
{
  public class AdWordCoupon
  {

    #region Properties

    private string _couponKey = null;
    private string _orderId = null;
    private string _vendor = null;
    private int _couponValue = 0;
    private bool _outOfStock = false;
    private string _couponCode = string.Empty;
    
    public string CouponKey { get { return _couponKey; } }

    public string OrderId { get { return _orderId; } }

    public string Vendor { get { return _vendor; } }

    public int CouponValue { get { return _couponValue; } }

    public bool OutOfStock { get { return _outOfStock; } }

    public string CouponCode { get { return _couponCode; } }

    #endregion 

    public AdWordCoupon(string couponKey
      , string orderId
      , string vendor
      , int couponValue
      , bool outOfStock )
    {
      _couponKey = couponKey;
      _orderId = orderId;
      _vendor = vendor;
      _couponValue = couponValue;
      _outOfStock = outOfStock;
      _couponCode = string.Empty;
    }
    
    public AdWordCoupon(string couponKey
      , string orderId
      , string vendor
      , int couponValue
      , bool outOfStock
      , string couponCode)
    {
      _couponKey = couponKey;
      _orderId = orderId;
      _vendor = vendor;
      _couponValue = couponValue;
      _outOfStock = outOfStock;
      _couponCode = couponCode;
    }
  }
}
