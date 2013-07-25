﻿using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BPBlogSubscriberQuery.Interface
{
  public class BPBlogSubscriberQueryRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }
    public string Email { get; private set; }

    public BPBlogSubscriberQueryRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, string email)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      Email = email;
      RequestTimeout = TimeSpan.FromSeconds(4);
    }

    public override string GetCacheMD5()
    {
      // The number of email address vs how many will be re-requested would
      // make caching this just take up memory (not a lot of cache-hits)
      throw new NotImplementedException("BPBlogSubscriberQuery is not a cacheable request.");
    }

  }
}
