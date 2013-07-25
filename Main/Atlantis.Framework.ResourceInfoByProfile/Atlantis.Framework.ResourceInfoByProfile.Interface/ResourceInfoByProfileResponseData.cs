using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ResourceInfoByProfile.Interface
{
  public class ResourceInfoByProfileResponseData : IResponseData
  {
    #region Properties
    private AtlantisException _exception = null;
    private bool _success = false;
    private bool _returnAll = false;
    private List<ResourceInfo> _resourceInfos;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public bool ReturnAll
    {
      get { return _returnAll; }
    }

    public List<ResourceInfo> ResourceInfos
    {
      get { return _resourceInfos; }
    }
    #endregion

    public ResourceInfoByProfileResponseData(List<ResourceInfo> resourceInfos, bool returnAll)
    {
      _resourceInfos = resourceInfos;
      _returnAll = returnAll;
      _success = true;
    }

    public ResourceInfoByProfileResponseData(string xml)
    {
      _resourceInfos = new List<ResourceInfo>();
      DateTime workerOutTime = new DateTime();
      int workerOutInt = 0;

      if (!string.IsNullOrEmpty(xml))
      {
        XmlDocument xdoc = new XmlDocument();
        xdoc.LoadXml(xml);
        XmlNodeList resourceNodes = xdoc.SelectNodes("resources/resource");
        if (resourceNodes != null)
        {
          foreach (XmlNode node in resourceNodes)
          {
            int? workId = null;
            int? recordToKeep = null;
            int? gdshopProductTypeId = null;
          
            if (!ReturnAll)
            {
              workId = int.TryParse(node.Attributes["workID"].Value, out workerOutInt) ? (int?)workerOutInt : null;
              recordToKeep = int.TryParse(node.Attributes["recordToKeep"].Value, out workerOutInt) ? (int?)workerOutInt : null;
              gdshopProductTypeId = int.TryParse(node.Attributes["gdshop_product_typeID"].Value, out workerOutInt) ? (int?)workerOutInt : null;
            }

            int? resourceId = int.TryParse(node.Attributes["resourceID"].Value, out workerOutInt) ? (int?)workerOutInt : null;
            string nameSpace = node.Attributes["nameSpace"].Value == null ? null : Convert.ToString(node.Attributes["nameSpace"].Value);
            int? ppShopperProfileID = int.TryParse(node.Attributes["pp_shopperProfileID"].Value, out workerOutInt) ? (int?)workerOutInt : null;
            string productDescription = node.Attributes["product_description"].Value == null ? null : Convert.ToString(node.Attributes["product_description"].Value);
            string info = node.Attributes["info"].Value == null ? null : Convert.ToString(node.Attributes["info"].Value);
            DateTime? billingDate = DateTime.TryParse(node.Attributes["billing_date"].Value, out workerOutTime) ? (DateTime?)workerOutTime : null;
            string renewalSku = node.Attributes["renewal_sku"].Value == null ? null : Convert.ToString(node.Attributes["renewal_sku"].Value);
            bool? isLimited = int.TryParse(node.Attributes["isLimited"].Value, out workerOutInt) ? (bool?)Convert.ToBoolean(workerOutInt) : null;
            string orderId = node.Attributes["order_id"].Value == null ? null : Convert.ToString(node.Attributes["order_id"].Value);
            int? pfId = int.TryParse(node.Attributes["pf_id"].Value, out workerOutInt) ? (int?)workerOutInt : null;
            bool? autoRenewFlag = int.TryParse(node.Attributes["autoRenewFlag"].Value, out workerOutInt) ? (bool?)Convert.ToBoolean(workerOutInt) : null;
            bool? allowRenewals = int.TryParse(node.Attributes["allowRenewals"].Value, out workerOutInt) ? (bool?)Convert.ToBoolean(workerOutInt) : null;
            string recurringPayment = node.Attributes["recurring_payment"].Value == null ? null : Convert.ToString(node.Attributes["recurring_payment"].Value);
            int? numberOfPeriods = int.TryParse(node.Attributes["numberOfPeriods"].Value, out workerOutInt) ? (int?)workerOutInt : null;
            int? renewalPfId = int.TryParse(node.Attributes["renewal_pf_id"].Value, out workerOutInt) ? (int?)workerOutInt : null;
            bool? isPastDue = int.TryParse(node.Attributes["isPastDue"].Value, out workerOutInt) ? (bool?)Convert.ToBoolean(workerOutInt) : null;
            DateTime? usageStartDate = DateTime.TryParse(node.Attributes["usageStartDate"].Value, out workerOutTime) ? (DateTime?)workerOutTime : null;
            DateTime? usageEndDate = DateTime.TryParse(node.Attributes["usageEndDate"].Value, out workerOutTime) ? (DateTime?)workerOutTime : null;
            string externalResourceID = node.Attributes["externalResourceID"].Value == null ? null : Convert.ToString(node.Attributes["externalResourceID"].Value);

            ResourceInfo ri = new ResourceInfo();
            if (!ReturnAll)
            {
              ri = new ResourceInfo(workId,
                  resourceId, nameSpace, ppShopperProfileID, productDescription, info, billingDate, orderId,
                  renewalSku, isLimited, pfId, recordToKeep, autoRenewFlag, allowRenewals, recurringPayment,
                  numberOfPeriods, renewalPfId, gdshopProductTypeId, isPastDue, usageStartDate,
                  usageEndDate, externalResourceID);
            }
            else
            {
              ri = new ResourceInfo(resourceId,
                  nameSpace, ppShopperProfileID, productDescription, info, billingDate, orderId,
                  renewalSku, isLimited, pfId, autoRenewFlag, allowRenewals, recurringPayment,
                  numberOfPeriods, renewalPfId, isPastDue, usageStartDate,
                  usageEndDate, externalResourceID);
            }
            _resourceInfos.Add(ri);
          }
        }
      }
      _success = true;
    }

     public ResourceInfoByProfileResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public ResourceInfoByProfileResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "ResourceInfoByProfileResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      StringBuilder sb = new StringBuilder();

      using (XmlWriter writer = XmlWriter.Create(sb))
      {
        writer.WriteStartElement("resources");

        foreach (ResourceInfo r in ResourceInfos)
        {
          writer.WriteStartElement("resource");

          writer.WriteAttributeString("workID", r.WorkId.HasValue ? r.WorkId.ToString() : null);
          writer.WriteAttributeString("resourceID", r.ResourceId.HasValue ? r.ResourceId.ToString() : null);
          writer.WriteAttributeString("nameSpace", r.NameSpace);
          writer.WriteAttributeString("pp_shopperProfileID", r.PpShopperProfileId.HasValue ? r.PpShopperProfileId.ToString() : null);
          writer.WriteAttributeString("product_description", r.ProductDescription);
          writer.WriteAttributeString("info", r.Info);
          writer.WriteAttributeString("billing_date", r.BillingDate.HasValue ? r.BillingDate.ToString() : null);
          writer.WriteAttributeString("order_id", r.OrderId);
          writer.WriteAttributeString("renewal_sku", r.RenewalSku);
          writer.WriteAttributeString("isLimited", r.IsLimited.HasValue ? Convert.ToInt32(r.IsLimited).ToString() : null);
          writer.WriteAttributeString("pf_id", r.PfId.HasValue ? r.PfId.ToString() : null);
          writer.WriteAttributeString("recordToKeep", r.RecordToKeep.HasValue ? r.RecordToKeep.ToString() : null);
          writer.WriteAttributeString("autoRenewFlag", r.AutoRenewFlag.HasValue ? Convert.ToInt32(r.AutoRenewFlag).ToString() : null);
          writer.WriteAttributeString("allowRenewals", r.AllowRenewals.HasValue ? Convert.ToInt32(r.AllowRenewals).ToString() : null);
          writer.WriteAttributeString("recurring_payment", r.RecurringPayment);
          writer.WriteAttributeString("numberOfPeriods", r.NumberOfPeriods.HasValue ? r.NumberOfPeriods.ToString() : null);
          writer.WriteAttributeString("renewal_pf_id", r.RenewalPfId.HasValue ? r.RenewalPfId.ToString() : null);
          writer.WriteAttributeString("gdshop_product_typeID", r.GdshopProductTypeId.HasValue ? r.GdshopProductTypeId.ToString() : null);
          writer.WriteAttributeString("isPastDue", r.IsPastDue.HasValue ? Convert.ToInt32(r.IsPastDue).ToString() : null);
          writer.WriteAttributeString("usageStartDate", r.UsageStartDate.HasValue ? r.UsageStartDate.ToString() : null);
          writer.WriteAttributeString("usageEndDate", r.UsageEndDate.HasValue ? r.UsageEndDate.ToString() : null);
          writer.WriteAttributeString("externalResourceID", r.ExternalResourceId);

          writer.WriteEndElement();
        }
        writer.WriteEndElement();
      }
      return sb.ToString();
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
