using System;
using System.Diagnostics;

namespace Atlantis.Framework.ResourceInfoByProfile.Interface
{
  public class ResourceInfo
  {
    #region Properties

    private int? _workId = null;
    private int? _resourceId;
    private string _nameSpace;
    private int? _ppShopperProfileId;
    private string _productDescription;
    private string _info;
    private DateTime? _billingDate;
    private string _orderId;
    private string _renewalSku;
    private bool? _isLimited;
    private int? _pfId;
    private int? _recordToKeep = null;
    private bool? _autoRenewFlag;
    private bool? _allowRenewals;
    private string _recurringPayment;
    private int? _numberOfPeriods;
    private int? _renewalPfId;
    private int? _gdshopProductTypeId = null;
    private bool? _isPastDue;
    private DateTime? _usageStartDate;
    private DateTime? _usageEndDate;
    private string _externalResourceId;

    public int? WorkId
    {
      [DebuggerStepThrough]
      get { return _workId; }
      set { _workId = value; }
    }
    
    public int? ResourceId 
    {
      [DebuggerStepThrough]
      get { return _resourceId; }
      set { _resourceId = value; }
    }

    public string NameSpace 
    {
      [DebuggerStepThrough]
      get { return _nameSpace; }
      set { _nameSpace = value; }
    }

    public int? PpShopperProfileId 
    {
      [DebuggerStepThrough]
      get { return _ppShopperProfileId; }
      set { _ppShopperProfileId = value; }
    }
    
    public string ProductDescription 
    {
      [DebuggerStepThrough]
      get { return _productDescription; }
      set { _productDescription = value; }
    }
    
    public string Info 
    {
      [DebuggerStepThrough]
      get { return _info; }
      set { _info = value; }
    }
    
    public DateTime? BillingDate 
    {
      [DebuggerStepThrough]
      get { return _billingDate; }
      set { _billingDate = value; }
    }
    
    public string OrderId 
    {
      [DebuggerStepThrough]
      get { return _orderId; }
      set { _orderId = value; }
    }
    
    public string RenewalSku 
    {
      [DebuggerStepThrough]
      get { return _renewalSku; }
      set { _renewalSku = value; }
    }
    
    public bool? IsLimited 
    {
      [DebuggerStepThrough]
      get { return _isLimited; }
      set { _isLimited = value; }
    }
    
    public int? PfId 
    {
      [DebuggerStepThrough]
      get { return _pfId; }
      set { _pfId = value; }
    }
    
    public int? RecordToKeep 
    {
      [DebuggerStepThrough]
      get { return _recordToKeep; }
      set { _recordToKeep = value; }
    }
    
    public bool? AutoRenewFlag 
    {
      [DebuggerStepThrough]
      get { return _autoRenewFlag; }
      set { _autoRenewFlag = value; }
    }
    
    public bool? AllowRenewals 
    {
      [DebuggerStepThrough]
      get { return _allowRenewals; }
      set { _allowRenewals = value; }
    }
    
    public string RecurringPayment 
    {
      [DebuggerStepThrough]
      get { return _recurringPayment; }
      set { _recurringPayment = value; }
    }
    
    public int? NumberOfPeriods 
    {
      [DebuggerStepThrough]
      get { return _numberOfPeriods; }
      set { _numberOfPeriods = value; }
    }
    
    public int? RenewalPfId 
    {
      [DebuggerStepThrough]
      get { return _renewalPfId; }
      set { _renewalPfId = value; }
    }
    
    public int? GdshopProductTypeId 
    {
      [DebuggerStepThrough]
      get { return _gdshopProductTypeId; }
      set { _gdshopProductTypeId = value; }
    }
    
    public bool? IsPastDue 
    {
      [DebuggerStepThrough]
      get { return _isPastDue; }
      set { _isPastDue = value; }
    }
    
    public DateTime? UsageStartDate 
    {
      [DebuggerStepThrough]
      get { return _usageStartDate; }
      set { _usageStartDate = value; }
    }
    
    public DateTime? UsageEndDate 
    {
      [DebuggerStepThrough]
      get { return _usageEndDate; }
      set { _usageEndDate = value; }
    }
    
    public string ExternalResourceId 
    {
      [DebuggerStepThrough]
      get { return _externalResourceId; }
      set { _externalResourceId = value; }
    }

    #endregion

    #region Constructor
    public ResourceInfo(int? workId,
      int? resourceId,
      string nameSpace,
      int? ppShopperProfileId,
      string productDescription,
      string info,
      DateTime? billingDate,
      string orderId,
      string renewalSku,
      bool? isLimited,
      int? pfId,
      int? recordToKeep,
      bool? autoRenewFlag,
      bool? allowRenewals,
      string recurringPayment,
      int? numberOfPeriods,
      int? renewalPfId,
      int? gdshopProductTypeId,
      bool? isPastDue,
      DateTime? usageStartDate,
      DateTime? usageEndDate,
      string externalResourceId)
    {
      _workId = workId;
      _resourceId = resourceId;
      _nameSpace = nameSpace;
      _ppShopperProfileId = ppShopperProfileId;
      _productDescription = productDescription;
      _info = info;
      _billingDate = billingDate;
      _orderId = orderId;
      _renewalSku = renewalSku;
      _isLimited = isLimited;
      _pfId = pfId;
      _recordToKeep = recordToKeep;
      _autoRenewFlag = autoRenewFlag;
      _allowRenewals = allowRenewals;
      _recurringPayment = recurringPayment;
      _numberOfPeriods = numberOfPeriods;
      _renewalPfId = renewalPfId;
      _gdshopProductTypeId = gdshopProductTypeId;
      _isPastDue = isPastDue;
      _usageStartDate = usageStartDate;
      _usageEndDate = usageEndDate;
      _externalResourceId = externalResourceId;
    }

    //@ReturnAll = 1 constructor
    public ResourceInfo(int? resourceId,
      string nameSpace,
      int? ppShopperProfileId,
      string productDescription,
      string info,
      DateTime? billingDate,
      string orderId,
      string renewalSku,
      bool? isLimited,
      int? pfId,
      bool? autoRenewFlag,
      bool? allowRenewals,
      string recurringPayment,
      int? numberOfPeriods,
      int? renewalPfId,
      bool? isPastDue,
      DateTime? usageStartDate,
      DateTime? usageEndDate,
      string externalResourceId)
    {
      _resourceId = resourceId;
      _nameSpace = nameSpace;
      _ppShopperProfileId = ppShopperProfileId;
      _productDescription = productDescription;
      _info = info;
      _billingDate = billingDate;
      _orderId = orderId;
      _renewalSku = renewalSku;
      _isLimited = isLimited;
      _pfId = pfId;
      _autoRenewFlag = autoRenewFlag;
      _allowRenewals = allowRenewals;
      _recurringPayment = recurringPayment;
      _numberOfPeriods = numberOfPeriods;
      _renewalPfId = renewalPfId;
      _isPastDue = isPastDue;
      _usageStartDate = usageStartDate;
      _usageEndDate = usageEndDate;
      _externalResourceId = externalResourceId;
    }

    public ResourceInfo()
    { }
    #endregion
  }
}
