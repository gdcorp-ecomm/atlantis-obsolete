using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SessionCache;

namespace Atlantis.Framework.BundleResourceBillingInfo.Interface
{
  public class BundleResourceBillingInfoResponseData : IResponseData, ISessionSerializableResponse
  {
    private readonly AtlantisException _atlantisException;
    public BillingInfo BillingInfo { get; private set; }
    public bool IsSuccess { get; private set; }

    public BundleResourceBillingInfoResponseData()
    { }

    public BundleResourceBillingInfoResponseData(BillingInfo billingInfo)
    {
      IsSuccess = true;
      BillingInfo = billingInfo;
    }

    public BundleResourceBillingInfoResponseData(AtlantisException atlantisException)
    {
      _atlantisException = atlantisException;
    }

    public BundleResourceBillingInfoResponseData(RequestData requestData, Exception ex)
    {
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductBundleChildren Error: {0}", ex.Message)
        , ex.Data.ToString()
        , ex);  
    }

    #region IResponseData Members

    public string ToXML()
    {
      XDocument xDoc = new XDocument();
      XElement root = new XElement("billingInfo",
        new XAttribute("billing_attempt", BillingInfo.BillingAttempt.ToString()),
        new XAttribute("billing_date", BillingInfo.BillingDate.ToString()),
        new XAttribute("billing_status", BillingInfo.BillingStatus),
        new XAttribute("commonName", BillingInfo.CommonName),
        new XAttribute("pf_id", BillingInfo.PfId.ToString()),
        new XAttribute("privateLabelID", BillingInfo.PrivateLabelId.ToString()),
        new XAttribute("purchasedDuration", BillingInfo.PurchasedDuration.ToString()),
        new XAttribute("catalog_productUnifiedProductID", BillingInfo.UnifiedProductId.ToString()));

      xDoc.Add(root);

      return xDoc.ToString();
    }

    public AtlantisException GetException()
    {
      return _atlantisException;
    }

    #endregion

    #region ISessionSerializableResponse Members

    public string SerializeSessionData()
    {
      return ToXML();
    }

    public void DeserializeSessionData(string sessionData)
    {
      BillingInfo billingInfo = null;

      if (!string.IsNullOrEmpty(sessionData))
      {
        XmlDocument xdoc = new XmlDocument();
        xdoc.LoadXml(sessionData);
        XmlNode billingInfoNode = xdoc.SelectSingleNode("billingInfo");

        if (billingInfoNode != null)
        {
          IDictionary<string, object> productProperties = new Dictionary<string, object>();

          foreach (XmlAttribute attribute in billingInfoNode.Attributes)
          {
            if (!productProperties.ContainsKey(attribute.Name))
            {
              productProperties.Add(attribute.Name, attribute.Value);
            }
          }
          
          billingInfo = new BillingInfo(productProperties);
        }
      }

      if (billingInfo != null)
      {
        IsSuccess = true;
        BillingInfo = billingInfo;
      }
    }
    #endregion
  }
}
