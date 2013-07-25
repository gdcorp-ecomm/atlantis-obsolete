using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SessionCache;

namespace Atlantis.Framework.DCCGetRenewingDomains.Interface
{
  [Obsolete("Use Atlantis.Framework.DCCGetDomainByShopper instead, using expiration sorting")]
  public class DCCGetRenewingDomainsResponseData : IResponseData, ISessionSerializableResponse
  {
    private string ResponseXml { get; set; }
    private DateTime ExpirationDateCutOff { get; set; }
    private AtlantisException Exception { get; set; }

    internal int ResultCount { get; private set; }
    internal DateTime LastExpirationDate { get; private set; }

    public IDictionary<string, RenewalDomainAttributes> Domains { get; private set; }

    private bool _isSuccess;
    public bool IsSuccess
    {
      get { return (Exception == null && _isSuccess); }
    }

    public DCCGetRenewingDomainsResponseData()
    { }

    internal DCCGetRenewingDomainsResponseData(string responseXml, TimeSpan daysFromExpiration)
    {
      ResponseXml = responseXml;
      ExpirationDateCutOff = DateTime.Today.Add(daysFromExpiration);
      Domains = new Dictionary<string, RenewalDomainAttributes>();
      PopulateFromXML(responseXml);
    }

    internal DCCGetRenewingDomainsResponseData(string responseXml)
    {
      ResponseXml = responseXml;
      ExpirationDateCutOff = DateTime.Today.AddYears(10);
      Domains = new Dictionary<string, RenewalDomainAttributes>();
      PopulateFromXML(responseXml);
    }

    internal DCCGetRenewingDomainsResponseData(string responseXml, RequestData requestData, Exception ex)
    {
      ResponseXml = responseXml;
      Exception = new AtlantisException(requestData,
                                         "DCCGetRenewingDomainsResponseData",
                                         ex.Message,
                                         requestData.ToXML());
    }

    /* Example responseXml
    <results>
      <method>GetDCCDomainList</method>
      <success>1</success>
      <searchsummary resultcount="378" firstdomain="0kajsdhfjkahsdf.com" lastdomain="yourcarinapro.com"></searchsummary>
      <domains>
        <domain id="1664532" domainname="ADSLJKFHASLD.COM" expirationdate="05/15/2010 15:39:03" sortexpirationdate="05/15/2010 00:00:00" status="0" parent_bundle_id="" islocked="1" isproxied="1" islimited="0" tldid="1" guid="{628A20F2-4190-11DE-BAA9-005056956427}" extendedwhoistype="0" isexpirationprotected="0" istransferprotected="0" isregistrarhold="" autorenewflag="1" deletedate="" renewperiod="0" profileid="" vendorid="" issmartdomain="0" billingresourceid="367943" profilename="" invalidwhois="" certifieddomainstatus="" dscor_resultoverall=""></domain>
      </domains>
    </results>
    */
    private void PopulateFromXML(string responseXml)
    {
      XmlDocument responseXmlDoc = new XmlDocument();

      try
      {
        responseXmlDoc.LoadXml(responseXml);

        XmlElement xnSuccess = (XmlElement)responseXmlDoc.SelectSingleNode("/results/success");
        if (xnSuccess != null)
        {
          if (xnSuccess.InnerText == "1")
          {
            _isSuccess = true;
          }
        }

        XmlElement xnSummary = (XmlElement)responseXmlDoc.SelectSingleNode("/results/searchsummary");
        if (xnSuccess != null)
        {
          ResultCount = Convert.ToInt32(xnSummary.Attributes["resultcount"].Value);
        }

        AddDomainsToList(responseXmlDoc);
      }
      catch (Exception ex)
      {
        LogException(ex, responseXml);
        _isSuccess = false;
      }
    }

    internal void AddDomainsToList(string responseXml)
    {
      XmlDocument responseXmlDoc = new XmlDocument();

      try
      {
        responseXmlDoc.LoadXml(responseXml);
        AddDomainsToList(responseXmlDoc);
      }
      catch(Exception ex)
      {
        LogException(ex, responseXml);
      }
    }

    private void AddDomainsToList(XmlDocument responseXmlDoc)
    {
      XmlNodeList domainNodeList = responseXmlDoc.SelectNodes("/results/domains/domain");

      if (domainNodeList != null)
      {
        for (int i = 0; i < domainNodeList.Count; i++)
        {
          RenewalDomainAttributes renewalDomainAttributes = new RenewalDomainAttributes(domainNodeList[i]);

          if (renewalDomainAttributes.ExpirationDate < ExpirationDateCutOff && renewalDomainAttributes.Status == 0)
          {
            Domains.Add(domainNodeList[i].Attributes["domainname"].Value.ToUpperInvariant(), renewalDomainAttributes);
          }

          if(i == (domainNodeList.Count - 1))
          {
            LastExpirationDate = renewalDomainAttributes.ExpirationDate;
          }
        }
      }
    }

    private void LogException(Exception ex, string responseXml)
    {
      string sourceUrl = string.Empty;
      string clientIp = string.Empty;

      if (HttpContext.Current != null)
      {
        sourceUrl = HttpContext.Current.Request.Url.ToString();
        clientIp = HttpContext.Current.Request.UserHostAddress;
      }

      Exception = new AtlantisException("DCCGetRenewingDomainsResponseData",
                                           sourceUrl,
                                           "0",
                                           sourceUrl,
                                           string.Format("{0} | {1}", ex.Message, ex.StackTrace),
                                           string.Format("Error parsing response xml: {0}",
                                           responseXml),
                                           string.Empty,
                                           clientIp,
                                           string.Empty,
                                           0);
    }

    public string ToXML()
    {
      return ResponseXml;
    }

    public AtlantisException GetException()
    {
      return Exception;
    }

    #region ISessionSerializableResponse Members

    public string SerializeSessionData()
    {
      return ToXML();
    }

    public void DeserializeSessionData(string sessionData)
    {
      if (!string.IsNullOrEmpty(sessionData))
      {
        ResponseXml = sessionData;
        Domains = new Dictionary<string, RenewalDomainAttributes>();
        PopulateFromXML(sessionData);
      }
    }
    #endregion
  }
}
