using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Atlantis.Framework.Interface;
using Atlantis.Framework.ResourceInfoByProfile.Interface;
using Atlantis.Framework.Nimitz;

namespace Atlantis.Framework.ResourceInfoByProfile.Impl
{
  public class ResourceInfoByProfileRequest : IRequest
  {
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
   {
      List<ResourceInfo> resourceInfos = new List<ResourceInfo>();
      ResourceInfoByProfileResponseData responseData = null;
      bool returnAll = false;

      try
      {
        ResourceInfoByProfileRequestData resourceInfoRequestData = (ResourceInfoByProfileRequestData)requestData;
        resourceInfos = GetResourceInfoByProfile(resourceInfoRequestData, config, out returnAll);

        responseData = new ResourceInfoByProfileResponseData(resourceInfos, returnAll);      
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new ResourceInfoByProfileResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new ResourceInfoByProfileResponseData(requestData, ex);
      }
       
      return responseData;
    }

   private List<ResourceInfo> GetResourceInfoByProfile(ResourceInfoByProfileRequestData requestData, ConfigElement config, out bool returnAll)
   {
     List<ResourceInfo> resourceInfos = new List<ResourceInfo>();
     string procName = "dbo.mya_ResourceInfoByProfile_sp";

     using (SqlConnection cn = new SqlConnection(LookupConnectionString(requestData, config)))
     {
       using (SqlCommand cmd = new SqlCommand(procName, cn))
       {
         cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
         cmd.CommandType = CommandType.StoredProcedure;
         cmd.Parameters.AddRange(GetParameters(requestData.Parms, out returnAll));
         cn.Open();
         using (SqlDataReader dr = cmd.ExecuteReader())
         {
           // If not returning all records, SQL sproc will return 3 tables - skip to last
           if (!returnAll)
           {
             dr.NextResult();
             dr.NextResult();
           }
           while (dr.Read())
           {
             resourceInfos.Add(PopulateObjectFromDB(dr, requestData, returnAll));
           }
         }
       }
     }
     return resourceInfos;
   }

   private ResourceInfo PopulateObjectFromDB(IDataReader idr, ResourceInfoByProfileRequestData requestData, bool returnAll)
   {
     int? workId = 0;
     int? recordToKeep = 0;
     int? gdshopProductTypeId = 0;

     if (!returnAll)
     {
       workId = idr["workID"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["workID"], CultureInfo.CurrentCulture);
       recordToKeep = idr["recordToKeep"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["recordToKeep"], CultureInfo.CurrentCulture);
       gdshopProductTypeId = idr["gdshop_product_typeID"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["gdshop_product_typeID"], CultureInfo.CurrentCulture);
     }

     int? resourceId = idr["resourceID"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["resourceID"], CultureInfo.CurrentCulture);
     string nameSpace = idr["nameSpace"] == DBNull.Value ? null : Convert.ToString(idr["nameSpace"], CultureInfo.CurrentCulture);
     int? ppShopperProfileID = idr["pp_shopperProfileID"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["pp_shopperProfileID"], CultureInfo.CurrentCulture);
     string productDescription = idr["product_description"] == DBNull.Value ? null : Convert.ToString(idr["product_description"], CultureInfo.CurrentCulture);
     string info = idr["info"] == DBNull.Value ? null : Convert.ToString(idr["info"], CultureInfo.CurrentCulture);
     DateTime? billingDate = idr["billing_date"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(idr["billing_date"], CultureInfo.CurrentCulture);
     string orderId = idr["order_id"] == DBNull.Value ? null : Convert.ToString(idr["order_id"], CultureInfo.CurrentCulture);
     string renewalSku = idr["renewal_sku"] == DBNull.Value ? null : Convert.ToString(idr["renewal_sku"], CultureInfo.CurrentCulture);
     bool? isLimited = idr["isLimited"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(idr["isLimited"], CultureInfo.CurrentCulture);
     int? pfId = idr["pf_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["pf_id"], CultureInfo.CurrentCulture);
     bool? autoRenewFlag = idr["autoRenewFlag"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(idr["autoRenewFlag"], CultureInfo.CurrentCulture);
     bool? allowRenewals = idr["allowRenewals"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(idr["allowRenewals"], CultureInfo.CurrentCulture);
     string recurringPayment = idr["recurring_payment"] == DBNull.Value ? null : Convert.ToString(idr["recurring_payment"], CultureInfo.CurrentCulture);
     int? numberOfPeriods = idr["numberOfPeriods"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["numberOfPeriods"], CultureInfo.CurrentCulture);
     int? renewalPfId = idr["renewal_pf_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(idr["renewal_pf_id"], CultureInfo.CurrentCulture);
     bool? isPastDue = idr["isPastDue"] == DBNull.Value ? null : (bool?)Convert.ToBoolean(idr["isPastDue"], CultureInfo.CurrentCulture);
     DateTime? usageStartDate = idr["usageStartDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(idr["usageStartDate"], CultureInfo.CurrentCulture);
     DateTime? usageEndDate = idr["usageEndDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(idr["usageEndDate"], CultureInfo.CurrentCulture);
     string externalResourceID = idr["externalResourceID"] == DBNull.Value ? null : Convert.ToString(idr["externalResourceID"], CultureInfo.CurrentCulture);

     ResourceInfo ri = new ResourceInfo();
     if (!returnAll)
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
     return ri;
   }

   private SqlParameter[] GetParameters (List<SqlParameter> parms, out bool returnAll)
   {
     SqlParameter[] parmArray = new SqlParameter[parms.Count];

     returnAll = false;
     int i = 0;
     foreach (SqlParameter p in parms)
     {
       if (p.ParameterName.Equals("@returnAll") && p.Value != null && p.Value.ToString() != "0")
         returnAll = true;
       parmArray[i++] = p;
     }
     return parmArray;
   }
       
   private string LookupConnectionString(ResourceInfoByProfileRequestData requestData, ConfigElement config)
   {
     string result = string.Empty;

     result = NetConnect.LookupConnectInfo(config.GetConfigValue("DataSourceName"), config.GetConfigValue("CertificateName"), config.GetConfigValue("ApplicationName"), "ResourceInfoByProfileRequest.LookupConnectionString",
                                           ConnectLookupType.NetConnectionString);

     //netConnect.Info nc = new netConnect.Info();
     //result = nc.Get(config.GetConfigValue("DataSourceName")
     //  , config.GetConfigValue("ApplicationName")
     //  , config.GetConfigValue("CertificateName")
     //  , ConnectTypeEnum.CONNECT_TYPE_NET);

     if (string.IsNullOrEmpty(result) || result.Length <= 2)
     {
       throw new Exception("Invalid Connection String");
     }
     return result;
   }
  }
}
