using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.Collections.Generic;

namespace Atlantis.Framework.DomainContactCheck.Interface
{

  public class DomainContact : XmlDocument, ICloneable
  {
    private XmlElement _contactElement;

    public enum DomainContactType
    {
      Registrant = 0,
      Technical = 1,
      Administrative = 2,
      Billing = 3,
      RegistrantUnicode = 4,
      TechnicalUnicode = 5,
      AdministrativeUnicode = 6,
      BillingUnicode= 7,
    }

    public const string _CONTACTELEMENTNAME = "contact"; 

    #region Properties

    private List<DomainContactError> _errors = new List<DomainContactError>();
    public List<DomainContactError> Errors
    {
      get { return _errors; }
    }

    private Dictionary<string, string> _addlContactAttributes = new Dictionary<string, string>();
    public Dictionary<string, string> AdditionalContactAttributes
    {
      get
      {
        return _addlContactAttributes;
      }
    }
    
    private Dictionary<string, string> _trusteeVendorIds = new Dictionary<string, string>();
    public Dictionary<string, string> TrusteeVendorIds
    {
      get
      {
        return _trusteeVendorIds;
      }
    }

    public void AddAdditionalContactAttributes(XmlAttributeCollection addlContactAttributes)
    {
      if (addlContactAttributes != null)
      {
        foreach (XmlAttribute attr in addlContactAttributes)
        {
          switch (attr.Name)
          {
            case DomainContactAttributes.FirstName:
            case DomainContactAttributes.LastName:
            case DomainContactAttributes.Email:
            case DomainContactAttributes.Organization:
            case DomainContactAttributes.CheckedOrganization:
            case DomainContactAttributes.Address1:
            case DomainContactAttributes.Address2:
            case DomainContactAttributes.City:
            case DomainContactAttributes.State:
            case DomainContactAttributes.Zip:
            case DomainContactAttributes.Country:
            case DomainContactAttributes.Phone:
            case DomainContactAttributes.Fax:
            case DomainContactAttributes.Tlds:
            case DomainContactAttributes.PrivateLabelId:
            case DomainContactAttributes.DomainContactType:
            case DomainContactAttributes.Type:
            case DomainContactAttributes.PreferredLanguage:
            case DomainContactAttributes.CanadianPresence:
              break;
            default:
              _addlContactAttributes[attr.Name] = attr.Value;
              break;
          }
        }
      }
    }

    public void AddTrusteeVendorIds(string key, string value)
    {
      this._trusteeVendorIds[key] = value;
    }

    public bool IsValid
    {
      get { return (_errors.Count == 0); }
    }

    public string FirstName
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.FirstName); }
      set { _contactElement.SetAttribute(DomainContactAttributes.FirstName, value); }
    }

    public string LastName
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.LastName); }
      set { _contactElement.SetAttribute(DomainContactAttributes.LastName, value); }
    }

    public string Email
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Email); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Email, value); }
    }

    public string Company
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Organization); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Organization, value); }
    }

    public bool IsLegalRegistrant
    {
      get 
      {
        bool result = false;
        if (Company.Length > 0)
        {
          result = _contactElement.GetAttribute(DomainContactAttributes.CheckedOrganization).Equals("1");
        }
        return result;
      }
      set { _contactElement.SetAttribute(DomainContactAttributes.CheckedOrganization, value ? "1" : string.Empty); }
    }

    public string Address1
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Address1); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Address1, value); }
    }

    public string Address2
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Address2); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Address2, value); }
    }

    public string City
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.City); }
      set { _contactElement.SetAttribute(DomainContactAttributes.City, value); }
    }

    public string Country
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Country); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Country, value); }
    }

    public string State
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.State); }
      set { _contactElement.SetAttribute(DomainContactAttributes.State, value); }
    }

    public string Zip
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Zip); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Zip, value); }
    }

    public string Phone
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Phone); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Phone, value); }
    }

    public string Fax
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.Fax); }
      set { _contactElement.SetAttribute(DomainContactAttributes.Fax, value); }
    }

    public string CanadianPresence
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.CanadianPresence); }
      set { _contactElement.SetAttribute(DomainContactAttributes.CanadianPresence, value); }
    }

    public string PreferredLanguage
    {
      get { return _contactElement.GetAttribute(DomainContactAttributes.PreferredLanguage); }
      set { _contactElement.SetAttribute(DomainContactAttributes.PreferredLanguage, value); }
    }

    #endregion

    public string GetContactXml(DomainContactType contactType)
    {
      _contactElement.SetAttribute(DomainContactAttributes.DomainContactType, ((int)contactType).ToString());
      StringBuilder errorXml = new StringBuilder();

      foreach (DomainContactError error in Errors)
      {
        errorXml.Append(error.InnerXml);
      }

      _contactElement.InnerXml = errorXml.ToString();

      // remove attr. that are not valid for cart post
      XmlDocument doc = new XmlDocument();
      doc.LoadXml(InnerXml);
      XmlElement contactElement = doc.DocumentElement;
      contactElement.RemoveAttribute(DomainContactAttributes.CanadianPresence);

      return contactElement.OwnerDocument.InnerXml;
    }

    public string GetContactXmlForSession(DomainContactType contactType)
    {
      _contactElement.SetAttribute(DomainContactAttributes.DomainContactType, ((int)contactType).ToString());

      foreach (KeyValuePair<string, string> attr in _addlContactAttributes)
      {
        _contactElement.SetAttribute(attr.Key, attr.Value);
      }

      StringBuilder errorXml = new StringBuilder();
      foreach (DomainContactError error in Errors)
      {
        errorXml.Append(error.InnerXml);
      }

      StringBuilder trusteeXml = new StringBuilder();
      foreach (KeyValuePair<string, string> trustee in TrusteeVendorIds)
      {
        trusteeXml.Append("<trustee tld=\"" + trustee.Key + "\" vendorid=\"" + trustee.Value + "\"/>");
      }

      _contactElement.InnerXml = errorXml.ToString() + trusteeXml.ToString();

      return InnerXml;
    }

    public override XmlNode Clone()
    {
      DomainContact result = new DomainContact(FirstName, LastName,
        Email, Company, IsLegalRegistrant, Address1, Address2, City, 
        State, Zip, Country, Phone, Fax, CanadianPresence, PreferredLanguage);
      
      foreach (KeyValuePair<string, string> attr in _addlContactAttributes)
      {
        result.AdditionalContactAttributes[attr.Key] = attr.Value;
      }

      foreach (DomainContactError error in Errors)
      {
        result.Errors.Add(error.Clone() as DomainContactError);
      }

      foreach (KeyValuePair<string, string> pair in _trusteeVendorIds)
      {
        result.AddTrusteeVendorIds(pair.Key, pair.Value);
      }

      return result;
    }

    public DomainContact()
    {
      _contactElement = this.CreateElement(_CONTACTELEMENTNAME);
      this.AppendChild(_contactElement);
    }

    public DomainContact(XmlDocument contactDoc) : this()
    {
      XmlElement root = contactDoc.SelectSingleNode("//" + _CONTACTELEMENTNAME) as XmlElement;
      if (root != null)
      {
        LoadContactFromElement(root);
      }
    }

    public DomainContact(XmlElement xmlElement) : this()
    {
      LoadContactFromElement(xmlElement);
    }

    public DomainContact( string firstName, string lastName, 
                          string email,     string company,   bool isLegalRegistrant, 
                          string address1,  string address2,  string city,
                          string state,     string zip,       string country,              
                          string phone,     string fax,       string canadianPresence,
                          string preferredLanguage)
      : this()
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      IsLegalRegistrant = isLegalRegistrant;
      Company = company;
      Address1 = address1;
      Address2 = address2;
      City = city;
      State = state;
      Zip = zip;
      Country = country;
      Phone = phone;
      Fax = fax;
      CanadianPresence = canadianPresence;
      PreferredLanguage = preferredLanguage;
    }

    public DomainContact(string firstName, string lastName,
                          string email, string company, bool isLegalRegistrant,
                          string address1, string address2, string city,
                          string state, string zip, string country,
                          string phone, string fax)
      : this()
    {
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      IsLegalRegistrant = isLegalRegistrant;
      Company = company;
      Address1 = address1;
      Address2 = address2;
      City = city;
      State = state;
      Zip = zip;
      Country = country;
      Phone = phone;
      Fax = fax;
      CanadianPresence = string.Empty;
    }

    public void InvalidateContact(DomainContactError error)
    {
      this._errors.Clear();
      this._errors.Add(error);
    }

    public void InvalidateContact(List<DomainContactError> errors)
    {
      this._errors = errors;
    }

    private void LoadContactFromElement(XmlElement element)
    {
      foreach (XmlAttribute attr in element.Attributes)
      {
        switch (attr.Name)
        {
          case DomainContactAttributes.FirstName:
            FirstName = attr.Value;
            break;
          case DomainContactAttributes.LastName:
            LastName = attr.Value;
            break;
          case DomainContactAttributes.Email:
            Email = attr.Value;
            break;
          case DomainContactAttributes.CheckedOrganization:
            IsLegalRegistrant = attr.Value.Equals("1");
            break;
          case DomainContactAttributes.Organization:
            Company = attr.Value;
            break;
          case DomainContactAttributes.Address1:
            Address1 = attr.Value;
            break;
          case DomainContactAttributes.Address2:
            Address2 = attr.Value;
            break;
          case DomainContactAttributes.City:
            City = attr.Value;
            break;
          case DomainContactAttributes.State:
            State = attr.Value;
            break;
          case DomainContactAttributes.Zip:
            Zip = attr.Value;
            break;
          case DomainContactAttributes.Country:
            Country = attr.Value;
            break;
          case DomainContactAttributes.Phone:
            Phone = attr.Value;
            break;
          case DomainContactAttributes.Fax:
            Fax = attr.Value;
            break;
          case DomainContactAttributes.PreferredLanguage:
              string preferredLang = attr.Value;

              if (!string.IsNullOrEmpty(preferredLang))
              {
                PreferredLanguage = preferredLang;
              }

              break;
          case DomainContactAttributes.CanadianPresence:
              string canadianPresence = attr.Value;

              if (!string.IsNullOrEmpty(canadianPresence))
              {
                CanadianPresence = canadianPresence;
              }

              break;
          default:
            _addlContactAttributes[attr.Name] = attr.Value;
            break;
        }
      }

      XmlNodeList errorNodes = element.SelectNodes("./" + DomainContactError.ErrorElementName);

      foreach (XmlNode errorNode in errorNodes)
      {
        XmlElement errorNodeElement = errorNode as XmlElement;
        if (errorNodeElement != null)
        {
          DomainContactError error = new DomainContactError(errorNodeElement);
          Errors.Add(error);
        }
      }

      XmlNodeList trusteeNodes = element.SelectNodes("./trustee");

      foreach (XmlElement trustee in trusteeNodes)
      {
        string dotType = trustee.GetAttribute("tld");
        string vendorId = trustee.GetAttribute("vendorid");
        this._trusteeVendorIds[dotType] = vendorId;
      }
    }
  }
}
