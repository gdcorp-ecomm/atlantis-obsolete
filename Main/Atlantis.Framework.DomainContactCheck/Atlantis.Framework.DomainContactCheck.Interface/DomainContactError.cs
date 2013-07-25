﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Atlantis.Framework.DomainContactCheck.Interface
{
  public class DomainContactError : XmlDocument, ICloneable
  {
    public const string ErrorElementName = "error";
    private XmlElement _errorElement;

    public DomainContactError()
    {
      _errorElement = this.CreateElement(ErrorElementName);
      this.AppendChild(_errorElement);
    }

    public DomainContactError(string sAttribute, int iCode, string sDescription, int contactType)
      : this()
    {
      _errorElement.SetAttribute(DomainContactErrorAttributes.Attribute, sAttribute);
      _errorElement.SetAttribute(DomainContactErrorAttributes.Code, iCode.ToString());
      _errorElement.SetAttribute(DomainContactErrorAttributes.Description, sDescription);
      _errorElement.SetAttribute(DomainContactErrorAttributes.ContactType, contactType.ToString());
    }

    public DomainContactError(XmlElement errorXml)
      : this()
    {
      _errorElement.SetAttribute(DomainContactErrorAttributes.Attribute, errorXml.GetAttribute(DomainContactErrorAttributes.Attribute));
      _errorElement.SetAttribute(DomainContactErrorAttributes.Code, errorXml.GetAttribute(DomainContactErrorAttributes.Code));
      _errorElement.SetAttribute(DomainContactErrorAttributes.Description, errorXml.GetAttribute(DomainContactErrorAttributes.Description));
      _errorElement.SetAttribute(DomainContactErrorAttributes.ContactType, errorXml.GetAttribute(DomainContactErrorAttributes.ContactType));
    }

    #region Properties

    public string Attribute
    {
      get { return _errorElement.GetAttribute(DomainContactErrorAttributes.Attribute); }
    }

    public int Code
    {
      get 
      {
        int result = 0;
        Int32.TryParse(_errorElement.GetAttribute(DomainContactErrorAttributes.Code), out result);
        return result;
      }
    }

    public string Description
    {
      get { return _errorElement.GetAttribute(DomainContactErrorAttributes.Description); }
    }

    public int ContactType
    {
      get 
      {
        int result = 0;
        Int32.TryParse(_errorElement.GetAttribute(DomainContactErrorAttributes.ContactType), out result);
        return result;
      }
    }

    #endregion

    #region ICloneable Members

    public override XmlNode Clone()
    {
      DomainContactError result = new DomainContactError(Attribute, Code, Description, ContactType);
      return result;
    }

    #endregion
  }
}
