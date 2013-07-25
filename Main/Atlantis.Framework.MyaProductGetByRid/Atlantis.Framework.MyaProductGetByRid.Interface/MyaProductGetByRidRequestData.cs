﻿using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MyaProductGetByRid.Interface
{
  public class MyaProductGetByRidRequestData : RequestData
  {
    #region Properties
    
    public TimeSpan RequestTimeout { get; set; }

    public int PrivateLabelId { get; set; }

    public int BillingResourceId { get; set; }

    public int ProductTypeId { get; set; }

    #endregion Properties

    public MyaProductGetByRidRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount
      , int privateLabelId
      , int billingResourceId
      , int productTypeId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(5);
      PrivateLabelId = privateLabelId;
      BillingResourceId = billingResourceId;
      ProductTypeId = productTypeId;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MyaProductGetByRidRequestData");
    }

  }
}
