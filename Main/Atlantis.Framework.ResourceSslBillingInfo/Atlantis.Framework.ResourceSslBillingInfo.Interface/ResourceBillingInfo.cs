using System;
using System.Collections.Generic;

namespace Atlantis.Framework.ResourceSslBillingInfo.Interface
{
  public class ResourceBillingInfo
  {
    #region Column Keys
    private const string BillingResourceIdColumnKey = "resource_id";
    private const string CommonNameColumnKey = "commonName";
    private const string EntityNameColumnKey = "entityName";
    private const string ExpireDateColumnKey = "expireDate";
    private const string LastExpirationDateColumnKey = "last_expiration_date";
    private const string NextAttemptDateColumnKey = "next_attempt_date";
    private const string OrionResourceIdColumnKey = "externalResourceID";
    private const string ParentBundleIdColumnKey = "parent_bundle_id";
    private const string PfIdColumnKey = "pf_id";
    #endregion

    #region Properties

    // Database Properties
    public int BillingResourceId { get; private set; }
    public string CommonName { get; private set; }
    public string EntityName { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public DateTime? LastExpirationDate { get; private set; }
    public DateTime? NextAttemptDate { get; private set; }
    public string OrionResourceId { get; private set; }
    public int? ParentBundleResourceId { get; private set; }
    public int? PfId { get; private set; }

    // Derived Properties from Database Results
    public bool IsFree { get; private set; }    // True if ParentBundleResourceId != null

    private IDictionary<string, object> BillingPropertiesDictionary { get; set; }

    #endregion

    #region Constructors
    public ResourceBillingInfo(IDictionary<string, object> billingPropertiesDictionary)
    {
      BillingPropertiesDictionary = billingPropertiesDictionary;
      BillingResourceId = IsPropertyInDictionary(BillingResourceIdColumnKey) ? Convert.ToInt32(BillingPropertiesDictionary[BillingResourceIdColumnKey]) : 0;
      CommonName = IsPropertyInDictionary(CommonNameColumnKey) ? Convert.ToString(BillingPropertiesDictionary[CommonNameColumnKey]) : null;
      EntityName = IsPropertyInDictionary(EntityNameColumnKey) ? Convert.ToString(BillingPropertiesDictionary[EntityNameColumnKey]) : null;
      ExpirationDate = IsPropertyInDictionary(ExpireDateColumnKey) ? (DateTime?)Convert.ToDateTime(BillingPropertiesDictionary[ExpireDateColumnKey]) : null;
      LastExpirationDate = IsPropertyInDictionary(LastExpirationDateColumnKey) ? (DateTime?)Convert.ToDateTime(BillingPropertiesDictionary[LastExpirationDateColumnKey]) : null;
      NextAttemptDate = IsPropertyInDictionary(NextAttemptDateColumnKey) ? (DateTime?)Convert.ToDateTime(BillingPropertiesDictionary[NextAttemptDateColumnKey]) : null;
      OrionResourceId = IsPropertyInDictionary(OrionResourceIdColumnKey) ? Convert.ToString(BillingPropertiesDictionary[OrionResourceIdColumnKey]) : null;
      ParentBundleResourceId = IsPropertyInDictionary(ParentBundleIdColumnKey) ? (int?)Convert.ToInt32(BillingPropertiesDictionary[ParentBundleIdColumnKey]) : null;
      PfId = IsPropertyInDictionary(PfIdColumnKey) ? (int?)Convert.ToInt32(BillingPropertiesDictionary[PfIdColumnKey]) : null;
      IsFree = (ParentBundleResourceId != null);
    }
    #endregion

    #region Helper Methods

    private bool IsPropertyInDictionary(string key)
    {
      return BillingPropertiesDictionary.ContainsKey(key) && BillingPropertiesDictionary[key] != null && !(BillingPropertiesDictionary[key] is DBNull);
    }
    #endregion
  }
}