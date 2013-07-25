﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCIsDomainAlertCancellable.Interface
{
  public class DCCIsDomainAlertCancellableRequestData : RequestData
  {
    #region Properties
    public string AppName { get; private set; }
    public List<int> BillingResourceIds { get; private set; }

    private TimeSpan _timeout = new TimeSpan(0, 0, 10);
    public TimeSpan RequestTimeout 
    {
      get { return _timeout; }
      set { _timeout = value; }
    }
    #endregion

    public DCCIsDomainAlertCancellableRequestData(string shopperId
      , string sourceUrl
      , string orderId
      , string pathway
      , int pageCount
      , string appName
      , List<int> billingResourceIds)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      AppName = appName;
      BillingResourceIds = billingResourceIds;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in DCCIsDomainAlertCancellableRequestData");     
    }

    public override string ToXML()
    {
      XElement root = new XElement("request");
      root.Add(new XElement("username", AppName));

      XElement domainAlerts = new XElement("domainAlerts");

      foreach (int rid in BillingResourceIds)
      {
        XElement domainAlert = new XElement("domainalert",
          new XAttribute("billingid", rid.ToString()));
        domainAlerts.Add(domainAlert);
      }

      root.Add(domainAlerts);

      return root.ToString();
    }

  }
}
