using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.ResourceSslBillingInfo.Interface;

namespace Atlantis.Framework.ResourceSslBillingInfo.Impl
{
  public class ResourceSslBillingInfoRequest : IRequest
  {
    #region SQL Proc Constants

    private const string PROC_NAME = "dbo.mya_GetSSLByResourceID_sp";
    private const string RESOURCE_ID_PARAM = "@resource_id";

    #endregion

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      ResourceSslBillingInfoResponseData responseData = null;

      try
      {
        ResourceSslBillingInfoRequestData request = (ResourceSslBillingInfoRequestData)requestData;
        ResourceBillingInfo sslBillingInfo = GetBillingInfo(request, config);

        responseData = new ResourceSslBillingInfoResponseData(sslBillingInfo);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new ResourceSslBillingInfoResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new ResourceSslBillingInfoResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Private Helpers
    private ResourceBillingInfo GetBillingInfo(ResourceSslBillingInfoRequestData request, ConfigElement config)
    {
      ResourceBillingInfo sslBillingInfo = null;

      using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
      {
        using (SqlCommand cmd = new SqlCommand(PROC_NAME, cn))
        {
          cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(RESOURCE_ID_PARAM, request.BillingResourceId);

          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            if (dr != null & dr.HasRows)
            {
              while (dr.Read())
              {
                sslBillingInfo = GetResourceBillingInfoFromDB(dr);
                if (sslBillingInfo != null)
                {
                  break;
                }
              }
            }
          }
        }
        cn.Close();
      }

      return sslBillingInfo;
    }

    private ResourceBillingInfo GetResourceBillingInfoFromDB(IDataReader idr)
    {
      ResourceBillingInfo rbi = null;

      if (idr.FieldCount > 0)
      {
        IDictionary<string, object> billingPropertiesDictionary = new Dictionary<string, object>();

        for (int i = 0; i < idr.FieldCount; i++)
        {
          if (!billingPropertiesDictionary.ContainsKey(idr.GetName(i)))
          {
            billingPropertiesDictionary.Add(idr.GetName(i), idr.GetValue(i));
          }
        }
        rbi = new ResourceBillingInfo(billingPropertiesDictionary);
      }

      return rbi;
    }
    #endregion
  }
}
