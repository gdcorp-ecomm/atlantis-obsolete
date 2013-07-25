using System;

namespace Atlantis.Framework.BillingOrionUpgradeInfo.Interface
{
  public class UpgradeInfo
  {
    private string _attributeDescription;       // DB nullable
    private bool _customerOwns;
    private string _familyDescription;
    private string _familyDescriptionExtended;  // DB nullable
    private int? _familyGroupId;                // DB nullable
    private int _orionAttributeFamilyId;
    private int _orionAttributeTypeId;
    private int _orionValue;
    private int _pfId;
    private int _rank;
    private int? _renewalPfId;                  // DB nullable
    private bool _transitionAware;
    private int _upgradeOption;

    public string AttributeDescription
    {
      get { return _attributeDescription; }
      set { _attributeDescription = value; }
    }

    public bool CustomerOwns
    {
      get { return _customerOwns; }
      set { _customerOwns = value; }
    }

    public string FamilyDescription
    {
      get { return _familyDescription; }
      set { _familyDescription = value; }
    }

    public string FamilyDescriptionExtended
    {
      get { return _familyDescriptionExtended; }
      set { _familyDescriptionExtended = value; }
    }

    public int? FamilyGroupId
    {
      get { return _familyGroupId; }
      set { _familyGroupId = value; }
    }

    public int OrionAttributeFamilyId
    {
      get { return _orionAttributeFamilyId; }
      set { _orionAttributeFamilyId = value; }
    }

    public int OrionAttributeTypeId
    {
      get { return _orionAttributeTypeId; }
      set { _orionAttributeTypeId = value; }
    }

    public int OrionValue
    {
      get { return _orionValue; }
      set { _orionValue = value; }
    }

    public int PfId
    {
      get { return _pfId; }
      set { _pfId = value; }
    }

    public int Rank
    {
      get { return _rank; }
      set { _rank = value; }
    }

    public int? RenewalPfId
    {
      get { return _renewalPfId; }
      set { _renewalPfId = value; }
    }

    public bool TransitionAware 
    {
      get { return _transitionAware; }
      set { _transitionAware = value; }
    }

    public int UpgradeOption
    {
      get { return _upgradeOption; }
      set { _upgradeOption = value; }
    }
  }
}
