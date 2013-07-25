using System;
using Atlantis.Framework.Interface;
using System.Text;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Atlantis.Framework.RegDomainsDbsCheck.Interface
{
  public class RegDomainsDbsCheckRequestData : RequestData
  {
    #region Properties

    private int _timeout = 2500;
    public int Timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }

    private HashSet<string> _domainNames = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

    #endregion Properties

    #region Constructors

    public RegDomainsDbsCheckRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
    }

    public RegDomainsDbsCheckRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         string domainName)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      AddDomainName(domainName);
    }

    public RegDomainsDbsCheckRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         IEnumerable<string> domainNames)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      AddDomainNames(domainNames);
    }

    #endregion Constructors

    #region Public Methods

    public void AddDomainName(string domainName)
    {
      if (!this._domainNames.Contains(domainName))
      {
        this._domainNames.Add(domainName);
      }
    }

    public void AddDomainNames(IEnumerable<string> domainNames)
    {
      foreach (string name in domainNames)
      {
        AddDomainName(name);
      }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));
      xtwRequest.WriteStartElement("domains");

      foreach (string name in this._domainNames)
      {
        xtwRequest.WriteStartElement("domain");
        xtwRequest.WriteString(name);
        xtwRequest.WriteEndElement();
      }

      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods
  }
}
