﻿using System;
using Atlantis.Framework.Interface;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace Atlantis.Framework.RegGetDotTypeRegistrar.Interface
{
  public class RegGetDotTypeRegistrarRequestData : RequestData
  {
    #region Properties

    private int _timeout = 2500;
    public int Timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }

    public bool IsValid
    {
      get { return (_dotTypes != null) && (_dotTypes.Count > 0); }
    }

    private List<string> _dotTypes = new List<string>();
    public List<string> DotTypes
    {
      get { return _dotTypes; }
      set { _dotTypes = value;  }
    }

    #endregion Properties

    #region Constructors

    public RegGetDotTypeRegistrarRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         string dotType)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._dotTypes.Add(dotType);
    }

    public RegGetDotTypeRegistrarRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         List<string> dotTypes)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._dotTypes = dotTypes;
    }

    #endregion Constructors

    #region Public Methods

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));
      xtwRequest.WriteStartElement("request");

      foreach (string dotType in this._dotTypes)
      {
        xtwRequest.WriteStartElement("tldname");
        xtwRequest.WriteAttributeString("type", "register");
        xtwRequest.WriteString(dotType);
        xtwRequest.WriteEndElement();
        xtwRequest.WriteStartElement("tldname");
        xtwRequest.WriteAttributeString("type", "transfer");
        xtwRequest.WriteString(dotType);
        xtwRequest.WriteEndElement();
      }

      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

    #endregion Public Methods
  }
}
