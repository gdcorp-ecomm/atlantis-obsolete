using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetBasketPrice.Interface
{
  public class GetBasketPriceRequestData : RequestData
  {
    // **************************************************************** //

    public GetBasketPriceRequestData(string sShopperID,
                                string sSourceURL,
                                string sOrderID,
                                string sPathway,
                                int iPageCount)
                                : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount) 
    {
      DeleteRefund = false;
      PaymentType = string.Empty;
    }

    // **************************************************************** //

    public GetBasketPriceRequestData(string sShopperID,
                                string sSourceURL,
                                string sOrderID,
                                string sPathway,
                                int iPageCount,
                                bool bDeleteRefund,
                                string sPaymentType)
                                : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      DeleteRefund = bDeleteRefund;
      PaymentType = sPaymentType;
    }

    string _basketType = string.Empty;
    public string BasketType
    {
      get { return _basketType; }
      set { _basketType = value; }
    }

    public bool DeleteRefund { get; set; }

    public string PaymentType { get; set; }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(20);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    // **************************************************************** //

    #region RequestData Members

    // **************************************************************** //

    public override string GetCacheMD5()
    {
      throw new Exception("GetBasketPrice is not a cacheable request");
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //

  }
}
