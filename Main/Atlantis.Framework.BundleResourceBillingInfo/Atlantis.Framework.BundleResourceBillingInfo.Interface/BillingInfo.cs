using System;
using System.Collections.Generic;

namespace Atlantis.Framework.BundleResourceBillingInfo.Interface
{
  public class BillingInfo
  {
    #region Database Column Keys
    private string BillingAttemptKey { get { return "billing_attempt"; } }
    private string BillingDateKey { get { return "billing_date"; } }
    private string BillingStatusKey { get { return "billing_status"; } }
    private string CommonNameKey { get { return "commonName"; } }
    private string PfIdKey { get { return "pf_id"; } }
    private string PrivateLabelIdKey { get { return "privateLabelID"; } }
    private string PurchasedDurationKey { get { return "purchasedDuration"; } }
    private string UnifiedProductIdKey { get { return "catalog_productUnifiedProductID"; } }
    #endregion

    #region Properties
    public IDictionary<string, object> PropertiesDictionary { get; protected set; }

    private int? _billingAttempt;
    public int BillingAttempt
    {
      get
      {
        if (!_billingAttempt.HasValue)
        {
          _billingAttempt = 0;
          if (IsPropertyInDictionary(BillingAttemptKey))
          {
            _billingAttempt = Convert.ToInt32(PropertiesDictionary[BillingAttemptKey]);
          }
        }
        return _billingAttempt.Value;
      }
    }

    private DateTime? _billingDate;
    public DateTime BillingDate
    {
      get
      {
        if (!_billingDate.HasValue)
        {
          _billingDate = DateTime.MinValue;
          if (IsPropertyInDictionary(BillingDateKey))
          {
            _billingDate = Convert.ToDateTime(PropertiesDictionary[BillingDateKey]);
          }
        }
        return _billingDate.Value;
      }
    }

    private string _billingStatus = string.Empty;
    public string BillingStatus
    {
      get
      {
        if (string.IsNullOrEmpty(_billingStatus))
        {
          if (IsPropertyInDictionary(BillingStatusKey))
          {
            _billingStatus = Convert.ToString(PropertiesDictionary[BillingStatusKey]);
          }
        }
        return _billingStatus;
      }
    }

    private string _commonName = string.Empty;
    public string CommonName
    {
      get
      {
        if (string.IsNullOrEmpty(_commonName))
        {
          if (IsPropertyInDictionary(CommonNameKey))
          {
            _commonName = Convert.ToString(PropertiesDictionary[CommonNameKey]);
          }
        }
        return _commonName;
      }
    }

    private int? _pfId;
    public int PfId
    {
      get
      {
        if (!_pfId.HasValue)
        {
          _pfId = 0;
          if (IsPropertyInDictionary(PfIdKey))
          {
            _pfId = Convert.ToInt32(PropertiesDictionary[PfIdKey]);
          }
        }
        return _pfId.Value;
      }
    }

    private int? _plId;
    public int PrivateLabelId
    {
      get
      {
        if (!_plId.HasValue)
        {
          _plId = -1;
          if (IsPropertyInDictionary(PrivateLabelIdKey))
          {
            _plId = Convert.ToInt32(PropertiesDictionary[PrivateLabelIdKey]);
          }
        }
        return _plId.Value;
      }
    }

    private decimal? _purchasedDuration;
    public decimal PurchasedDuration
    {
      get
      {
        if (!_purchasedDuration.HasValue)
        {
          if (IsPropertyInDictionary(PurchasedDurationKey))
          {
            _purchasedDuration = Convert.ToDecimal(PropertiesDictionary[PurchasedDurationKey]);
          }
        }
        return _purchasedDuration.Value;
      }
    }

    private int? _unifiedProductId;
    public int UnifiedProductId
    {
      get
      {
        if (!_unifiedProductId.HasValue)
        {
          if (IsPropertyInDictionary(UnifiedProductIdKey))
          {
            _unifiedProductId = Convert.ToInt32(PropertiesDictionary[UnifiedProductIdKey]);
          }
          else
          {
            throw new Exception(string.Format("UnifiedProductId is null for this account.  Key: {0}", UnifiedProductIdKey));
          }
        }
        return _unifiedProductId.Value;
      }
    }
    #endregion 

    public BillingInfo(IDictionary<string, object> propertiesDictionary)
    {
      PropertiesDictionary = propertiesDictionary;
    }

    private bool IsPropertyInDictionary(string key)
    {
      return PropertiesDictionary.ContainsKey(key) && PropertiesDictionary[key] != null && !(PropertiesDictionary[key] is DBNull);
    }
  }
}
