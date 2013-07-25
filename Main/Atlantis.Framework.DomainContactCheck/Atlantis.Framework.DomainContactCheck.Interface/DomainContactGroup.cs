using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

using Atlantis.Framework.DataCache;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;

namespace Atlantis.Framework.DomainContactCheck.Interface
{
  public class DomainContactGroup : ICloneable
  {
    public const string ContactInfoElementName = "contactInfo";
    private const int IDOMAINCONTACTCHECK = 31;
    private const string _LinkIdAttributeName = "link_id";
    private const string _ContactGroupInfoElementName = "contactGroupInfo";
    private const string _TldElementName = "tld";
    private const string _PrivateLabelIdAttributeName = "privateLabelId";
    private const string _ContactTypeAttributeName = "contactType";

    private Dictionary<DomainContact.DomainContactType, DomainContact> _domainContactGroup =
      new Dictionary<DomainContact.DomainContactType, DomainContact>();
    private HashSet<string> _tlds = new HashSet<string>();
    private int _privateLabelId;
    private string _contactGroupId;

    private bool? _skipValidation = null;
    private bool SkipValidation
    {
      get
      {
        if (_skipValidation == null)
        {
          _skipValidation = false;
          bool skip;
          if (bool.TryParse(DataCache.DataCache.GetAppSetting("AVAIL_NO_VALIDATE_CONTACT"), out skip))
          {
            _skipValidation = skip;
          }
        }
        return (bool)_skipValidation;
      }
    }

    #region Constructors

    private HashSet<string> CleanTlds(IEnumerable<string> tlds)
    {
      HashSet<string> result = new HashSet<string>();
      foreach (string sTld in tlds)
      {
        if (sTld[0] != '.')
        {
          result.Add(sTld.ToUpperInvariant().Insert(0, "."));
        }
        else
        {
          result.Add(sTld.ToUpperInvariant());
        }
      }
      return result;
    }

    public DomainContactGroup(IEnumerable<string> tlds, int privateLabelId)
    {
      _tlds = CleanTlds(tlds);

      if (_tlds.Count == 0)
      {
        throw new Exception("TLD collection for Domain Contact Group cannot be empty.");
      }

      _privateLabelId = privateLabelId;
      _contactGroupId = Guid.NewGuid().ToString();
    }

    public DomainContactGroup(string contactGroupXml)
    {
      XmlDocument xmlContactGroupDoc = new XmlDocument();
      xmlContactGroupDoc.LoadXml(contactGroupXml);

      XmlElement xmlContactGroupElement = (XmlElement)xmlContactGroupDoc.SelectSingleNode("//" + _ContactGroupInfoElementName);

      string privateLabelId = xmlContactGroupElement.GetAttribute(_PrivateLabelIdAttributeName);
      int.TryParse(privateLabelId, out _privateLabelId);
      _contactGroupId = xmlContactGroupElement.GetAttribute(_LinkIdAttributeName);

      XmlNodeList xmlTldNodes = xmlContactGroupDoc.SelectNodes("//" + _TldElementName);

      foreach (XmlNode sTldNode in xmlTldNodes)
      {
        string sTld = sTldNode.InnerText;
        _tlds.Add(sTld);
      }

      XmlNodeList xmlContactNodes = xmlContactGroupDoc.SelectNodes("//" + DomainContact._CONTACTELEMENTNAME);
      foreach (XmlNode xmlContactNode in xmlContactNodes)
      {
        XmlElement xmlContactElement = (XmlElement)xmlContactNode;
        string sContactType = xmlContactElement.GetAttribute(_ContactTypeAttributeName);
        DomainContact oDomainContact = new DomainContact(xmlContactElement);
        DomainContact.DomainContactType contactType = (DomainContact.DomainContactType)Enum.Parse(typeof(DomainContact.DomainContactType), sContactType);

        _domainContactGroup[contactType] = oDomainContact;

      }
    }

    #endregion

    /************************************************************************************/
    /// <summary>
    /// The clone function duplicates the contents of an existing domain group.  Since
    /// the existing domain contacts have been validated, this step is skipped when cloning.
    /// A deep-copy operation is performed, with the exception of the Guid, which will be unqiue.
    /// </summary>
    /// <returns>a near-deep copy of the existing DomainContactGroup</returns>
    public object Clone()
    {
      DomainContactGroup newDomainContactGroup = new DomainContactGroup(_tlds, _privateLabelId);

      foreach (KeyValuePair<DomainContact.DomainContactType, DomainContact> pair in _domainContactGroup)
      {
        newDomainContactGroup._domainContactGroup[pair.Key] = (DomainContact)pair.Value.Clone();
      }

      return newDomainContactGroup;
    }

    #region Properties

    public HashSet<string> GetTlds()
    {
      HashSet<string> result = new HashSet<string>(Tlds);
      return result;
    }

    private HashSet<string> Tlds
    {
      get
      {
        return _tlds;
      }
    }

    public int PrivateLabelId
    {
      get
      {
        return _privateLabelId;
      }
    }

    public string ContactGroupId
    {
      get { return _contactGroupId; }
    }

    #endregion

    public string GetContactXml()
    {

      if (!HasExplicitDomainContact(DomainContact.DomainContactType.Registrant))
      {
        string sText = "Cannot generate contact XML, no " + DomainContact.DomainContactType.Registrant.ToString() + " defined.";
        throw new Exception(sText);
      }

      XmlDocument xmlContactInfoDoc = new XmlDocument();
      XmlElement xmlContactInfo = xmlContactInfoDoc.CreateElement(ContactInfoElementName);
      xmlContactInfoDoc.AppendChild(xmlContactInfo);
      xmlContactInfo.SetAttribute(_LinkIdAttributeName, _contactGroupId);

      XmlDocument xmlContactDoc = new XmlDocument();

      foreach (DomainContact.DomainContactType DomainContactType in Enum.GetValues(typeof(DomainContact.DomainContactType)))
      {
        DomainContact oDomainContact = GetContactInt(DomainContactType);
        if (oDomainContact != null)
        {
          string sContactXml = oDomainContact.GetContactXml(DomainContactType);
          xmlContactDoc.LoadXml(sContactXml);
          XmlNode xmlContactNode = xmlContactDoc.SelectSingleNode("//" + DomainContact._CONTACTELEMENTNAME);
          xmlContactNode = xmlContactInfoDoc.ImportNode(xmlContactNode, true);
          xmlContactInfo.AppendChild(xmlContactNode);
        }
      }

      return xmlContactInfoDoc.InnerXml;
    }

    /// <summary>
    /// This function identifies whether the contact type is explicity defined or dependant 
    /// on the default value.
    /// </summary>
    /// <param name="ContactType"></param>
    /// <returns>true of explicity defined, false otherrwise</returns>
    public bool HasExplicitDomainContact(DomainContact.DomainContactType DomainContactType)
    {
      return _domainContactGroup.ContainsKey(DomainContactType);
    }

    private bool SetContactInt(DomainContact.DomainContactType contactType, DomainContact domainContact, bool onlySetIfValid)
    {
      if (!SkipValidation)
      {
        ValidateContact(domainContact, GetTldString(Tlds), DomainContactCheckRequestData.DomainCheckType.Other, contactType, true);
      }

      if (!onlySetIfValid || domainContact.IsValid)
      {
        // if there is a registrant already acting as default, copy it to other types that are
        // inheriting it first before overwriting it.
        if (DomainContact.DomainContactType.Registrant == contactType)
        {
          if (_domainContactGroup.ContainsKey(contactType))
          {
            DomainContact oOldDomainContact = _domainContactGroup[DomainContact.DomainContactType.Registrant];

            if (!_domainContactGroup.ContainsKey(DomainContact.DomainContactType.Administrative))
              _domainContactGroup[DomainContact.DomainContactType.Administrative] = oOldDomainContact.Clone() as DomainContact;
            if (!_domainContactGroup.ContainsKey(DomainContact.DomainContactType.Billing))
              _domainContactGroup[DomainContact.DomainContactType.Billing] = oOldDomainContact.Clone() as DomainContact;
            if (!_domainContactGroup.ContainsKey(DomainContact.DomainContactType.Technical))
              _domainContactGroup[DomainContact.DomainContactType.Technical] = oOldDomainContact.Clone() as DomainContact;
          }
        }

        _domainContactGroup[contactType] = domainContact;
      }

      return domainContact.IsValid;
    }

    public bool TrySetContact(DomainContact.DomainContactType contactType, DomainContact domainContact)
    {
      return SetContactInt(contactType, domainContact, true);
    }

    /// <summary>
    /// The SetContact function performs a validation of the contact against the existing
    /// set of tlds.
    /// </summary>
    /// <param name="DomainContactType">Type of contact to be added</param>
    /// <param name="oDomainContact">Domain Contact</param>
    public bool SetContact(DomainContact.DomainContactType contactType, DomainContact domainContact)
    {
      return SetContactInt(contactType, domainContact, false);
    }

    /************************************************************************************/
    /// <summary>
    /// The SetContact (overloaded) function performs a validation of the contact against
    /// the existing set of tlds for all DomainContactTypes.
    /// </summary>
    /// <param name="oDomainContact">Domain Contact</param>
    /// <param name="Errors">List of errors generated if function fails</param>
    public bool SetContact(DomainContact oDomainContact)
    {
      _domainContactGroup[DomainContact.DomainContactType.Registrant] = oDomainContact;

      if (!SkipValidation)
      {
        DomainContact.DomainContactType[] contactTypes = { DomainContact.DomainContactType.Registrant,
                                                         DomainContact.DomainContactType.Technical,
                                                         DomainContact.DomainContactType.Administrative,
                                                         DomainContact.DomainContactType.Billing };
        ValidateGroupForTLDs(Tlds, DomainContactCheckRequestData.DomainCheckType.Other, contactTypes, true);
      }

      return oDomainContact.IsValid;
    }

    /************************************************************************************/
    /// <summary>
    /// The SetInvalidContact function sets Invalid contact bypassing
    /// Contact validation. For proper Contact Group validation use SetContact method.
    /// </summary>
    /// <param name="oDomainContact">Domain Contact</param>
    /// <param name="DomainContactType">Domain Contact Type</param>
    /// <param name="tlds">Enumerable of Selected DotTypes</param>
    /// <param name="domainContactError">Domain Contact Error</param>
    public void SetInvalidContact(DomainContact oDomainContact, 
      DomainContact.DomainContactType DomainContactType, IEnumerable<string> tlds, DomainContactError domainContactError)
    {
      this._tlds = CleanTlds(tlds);
      oDomainContact.InvalidateContact(domainContactError);      
      this._domainContactGroup[DomainContactType] = oDomainContact;
    }

    /// <summary>
    /// The SetInvalidContact function sets Invalid contact bypassing
    /// Contact validation. For proper Contact Group validation use SetContact method.
    /// </summary>
    /// <param name="oDomainContact">Domain Contact</param>
    /// <param name="DomainContactType">Domain Contact Type</param>
    /// <param name="tlds">Enumerable of Selected DotTypes</param>
    /// <param name="domainContactError">List of Domain Contact Errors</param>
    public void SetInvalidContact(DomainContact oDomainContact,
      DomainContact.DomainContactType DomainContactType, IEnumerable<string> tlds, List<DomainContactError> domainContactErrors)
    {
      this._tlds = CleanTlds(tlds);
      oDomainContact.InvalidateContact(domainContactErrors);
      this._domainContactGroup[DomainContactType] = oDomainContact;
    }

    /************************************************************************************/
    /// <summary>
    /// This function clears the domain contact by type.  Attempting to clear the default (registrant)
    /// contact will raise an exception.
    /// </summary>
    /// <param name="DomainContactType">Type of domain contact to clear</param>
    public void ClearContact(DomainContact.DomainContactType DomainContactType)
    {
      if (DomainContactType == DomainContact.DomainContactType.Registrant)
      {
        throw new Exception("Cannot delete the default (Registrant) DomainContact.");
      }
      else if (DomainContactType == DomainContact.DomainContactType.RegistrantUnicode)
      {
        throw new Exception("Cannot delete the default (RegistrantUnicode) DomainContact.");
      }
      else
      {
        if (_domainContactGroup.ContainsKey(DomainContactType))
        {
          _domainContactGroup.Remove(DomainContactType);
        }
      }
    }

    /************************************************************************************/
    /// <summary>
    /// This function returns the domain contact that should be used as  the designated contact type.
    /// It may be an explicitly assigned contact or will default to the Registrant for utf-8 or utf-16
    /// This function returns a clone of the contact in the collection.
    /// </summary>
    /// <param name="ContactType">Desired type of domain contact</param>
    /// <returns>Domain contact (may be null)</returns>
    public DomainContact GetContact(DomainContact.DomainContactType contactType)
    {
      DomainContact result = null;
      DomainContact contact = GetContactInt(contactType);
      if (contact != null)
      {
        result = contact.Clone() as DomainContact;
      }
      return result;
    }

    private DomainContact GetContactInt(DomainContact.DomainContactType contactType)
    {
      DomainContact result = null;
      if (_domainContactGroup.ContainsKey(contactType))
      {
        result = _domainContactGroup[contactType];
      }
      else
      {
        if (contactType <= DomainContact.DomainContactType.Billing)  // utf-8 contact
        {
          if (_domainContactGroup.ContainsKey(DomainContact.DomainContactType.Registrant))
          {
            result = _domainContactGroup[DomainContact.DomainContactType.Registrant];
          }
        }
        else // The contact is a Unicode contact
        {
          if (_domainContactGroup.ContainsKey(DomainContact.DomainContactType.RegistrantUnicode))
          {
            result = _domainContactGroup[DomainContact.DomainContactType.RegistrantUnicode];
          }
        }
      }
      return result;
    }

    /************************************************************************************/
    /// <summary>
    /// This function constructs a string in the format .Com.Net.JP.etc  
    /// </summary>
    /// <returns></returns>

    private string GetTldString(IEnumerable<string> tlds)
    {
      string result = String.Join("|", tlds.ToArray());
      if (result.Length == 0)
      {
        throw new ArgumentException("TLD collection for Domain Contact Group cannot be empty.");
      }
      return result;
    }

    private string RemoveDotFromTldString(string tlds)
    {
      string retTlds = tlds;
      if (retTlds.Length > 0)
      {
        retTlds = retTlds.Replace("|.", "|");
        if (retTlds.StartsWith("."))
        {
          retTlds = retTlds.Remove(0, 1);
        }
      }

      return retTlds;
    }

    /******************************************************************************/
    /// <summary>
    /// This function returns an xml string that can be used to copy the object.  It contains
    /// all the explicit domain contacts, the list of tld nodes, the GUID and the private label id.
    /// </summary>
    /// <returns></returns>

    public override string ToString()
    {
      XmlDocument xmlContactInfoDoc = new XmlDocument();
      XmlElement xmlContactInfo = xmlContactInfoDoc.CreateElement(_ContactGroupInfoElementName);
      xmlContactInfoDoc.AppendChild(xmlContactInfo);

      XmlDocument xmlContactDoc = new XmlDocument();

      foreach (DomainContact.DomainContactType DomainContactType in Enum.GetValues(typeof(DomainContact.DomainContactType)))
      {
        if (HasExplicitDomainContact(DomainContactType))
        {
          DomainContact oDomainContact = GetContactInt(DomainContactType);

          string sContactXml = oDomainContact.GetContactXmlForSession(DomainContactType);
          xmlContactDoc.LoadXml(sContactXml);
          XmlNode xmlContactNode = xmlContactDoc.SelectSingleNode("//" + DomainContact._CONTACTELEMENTNAME);
          XmlElement xmlContactElement = (XmlElement)xmlContactInfoDoc.ImportNode(xmlContactNode, true);
          xmlContactElement.SetAttribute(_ContactTypeAttributeName, DomainContactType.ToString());
          xmlContactInfo.AppendChild(xmlContactElement);
        }
      }

      foreach (string sTld in _tlds)
      {
        XmlElement xmlTldElement = xmlContactInfoDoc.CreateElement(_TldElementName);
        xmlTldElement.InnerText = sTld;
        xmlContactInfo.AppendChild(xmlTldElement);
      }

      xmlContactInfo.SetAttribute(_PrivateLabelIdAttributeName, _privateLabelId.ToString());
      xmlContactInfo.SetAttribute(_LinkIdAttributeName, _contactGroupId);

      return xmlContactInfoDoc.InnerXml;
    }

    public bool IsValid
    {
      get
      {
        bool isValid = false;
        if ((Tlds.Count > 0) && (_domainContactGroup.Count > 0))
        {
          isValid = true;
          foreach (DomainContact.DomainContactType contactType in Enum.GetValues(typeof(DomainContact.DomainContactType)))
          {
            if (HasExplicitDomainContact(contactType))
            {
              DomainContact contact = GetContactInt(contactType);
              if (!contact.IsValid)
              {
                isValid = false;
                break;
              }
            }
          }
        }
          
        return isValid;
      }
    }

    private void ValidateGroupForTLDs(
      IEnumerable<string> tlds, 
      DomainContactCheckRequestData.DomainCheckType checkType,
      IEnumerable<DomainContact.DomainContactType> contactTypes,
      bool clearExistingErrors)
    {
      string tldString = GetTldString(tlds);

      if (clearExistingErrors)
      {
        foreach (DomainContact.DomainContactType contactType in contactTypes)
        {
          if (HasExplicitDomainContact(contactType))
          {
            DomainContact oDomainContact = GetContactInt(contactType);
            oDomainContact.Errors.Clear();
          }
        }
      }

      foreach (DomainContact.DomainContactType contactType in contactTypes)
      {
        DomainContact oDomainContact = GetContactInt(contactType);
        if (null != oDomainContact)
        {
          ValidateContact(oDomainContact, tldString, checkType, contactType, false);
        }
      }
    }

    private void ValidateContact(DomainContact contact, 
                                  string tldString, 
                                  DomainContactCheckRequestData.DomainCheckType checkType, 
                                  DomainContact.DomainContactType contactType, 
                                  bool clearErrors)
    {
      DomainContactCheckRequestData request = new DomainContactCheckRequestData(checkType, contactType, 
        contact, RemoveDotFromTldString(tldString), _privateLabelId, "Unknown", "Unknown", 
        string.Empty, string.Empty, 0);

      DomainContactCheckResponseData response =
            (DomainContactCheckResponseData)Engine.Engine.ProcessRequest(request, IDOMAINCONTACTCHECK);

      if (clearErrors)
      {
        contact.Errors.Clear();
      }

      contact.Errors.AddRange(response.Errors);

      if (contact.IsValid)
      {
        contact.AddAdditionalContactAttributes(response.ResponseAttributes);
      }

      if (response.TrusteeVendorIds.Count > 0)
      {
        foreach (KeyValuePair<string, string> trustee in response.TrusteeVendorIds)
        {
          contact.AddTrusteeVendorIds(trustee.Key,trustee.Value);
        }
      }
    }

    #region TLDs

    /// <summary>
    /// Resets the Tlds into the ContactGroup
    /// </summary>
    /// <param name="tlds">A non list of tlds</param>
    /// <returns>true if revalidation occurred</returns>
    public bool SetTlds(IEnumerable<string> tlds)
    {
      bool isValid = IsValid;

      HashSet<string> existingTlds = Tlds;
      HashSet<string> newTlds = CleanTlds(tlds);
      HashSet<string> newlyAddedTlds = new HashSet<string>();

      foreach (string tld in newTlds)
      {
        if (!existingTlds.Contains(tld))
        {
          newlyAddedTlds.Add(tld);
        }
      }

      bool doNewValidation = (newlyAddedTlds.Count > 0);
      bool doReValidation = false;

      // If removing Tlds and group was invalid, group could become valid again.
      if (!isValid)
      {
        int diff = existingTlds.Count - (newTlds.Count - newlyAddedTlds.Count);
        doReValidation = (diff > 0);
      }

      // Finally replace our Tlds and revalidate contacts
      _tlds = newTlds;

      if (doNewValidation || doReValidation)
      {
        HashSet<string> validationTlds;
        bool clearExistingErrors = false;
        if (doReValidation)
        {
          validationTlds = _tlds;
          clearExistingErrors = true;
        }
        else
        {
          validationTlds = newlyAddedTlds;
          clearExistingErrors = false;
        }

        ValidateGroupForTLDs(
          validationTlds, 
          DomainContactCheckRequestData.DomainCheckType.Other, 
          AllContactTypes,
          clearExistingErrors);
      }

      return (doNewValidation || doReValidation);
    }

    private List<DomainContact.DomainContactType> _allContactTypes = null;
    private IEnumerable<DomainContact.DomainContactType> AllContactTypes
    {
      get
      {
        if (_allContactTypes == null)
        {
          _allContactTypes = new List<DomainContact.DomainContactType>(8);
          foreach (DomainContact.DomainContactType contactType in Enum.GetValues(typeof(DomainContact.DomainContactType)))
          {
            _allContactTypes.Add(contactType);
          }
        }
        return _allContactTypes;
      }
    }

    #endregion

    public List<DomainContactError> GetAllErrors()
    {
      List<DomainContactError> result = new List<DomainContactError>();
      foreach (DomainContact.DomainContactType contactType in AllContactTypes)
      {
        if (HasExplicitDomainContact(contactType))
        {
          DomainContact contact = GetContactInt(contactType);
          result.AddRange(contact.Errors);
        }
      }
      return result;
    }

    public Dictionary<int, List<DomainContactError>> GetAllErrorsByContactType()
    {
      Dictionary<int, List<DomainContactError>> result = new Dictionary<int, List<DomainContactError>>();
      foreach (DomainContact.DomainContactType contactType in AllContactTypes)
      {
        List<DomainContactError> typeErrors = new List<DomainContactError>();

        if (HasExplicitDomainContact(contactType))
        {
          DomainContact contact = GetContactInt(contactType);
          typeErrors.AddRange(contact.Errors);
          result.Add((int)contactType, typeErrors);
        }
      }
      return result;
    }

    /// <summary>
    /// The SetContactPreferredlanguage function updates an existing contact's preferred language
    /// </summary>
    /// <param name="contactType">Type of contact to be updated</param>
    /// <param name="language">Language string</param>
    public bool SetContactPreferredlanguage(DomainContact.DomainContactType contactType, string language)
    {
      bool bRet = false;

      if (HasExplicitDomainContact(contactType))
      {
        _domainContactGroup[contactType].PreferredLanguage = language;
        bRet = true;
      }
      return bRet;
    }

  }
  
}
