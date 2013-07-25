using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.BundleResourceBillingInfo.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BundleResourceBillingInfo.Impl
{
  public class BundleResourceBillingInfoRequest : IRequest
  {
    #region Parameter Constants

    private const string STORED_PROCEDURE = "dbo.gdshop_bundle_billingGetByID_sp";
    private const string RECURRING_ID_PARAM = "@n_recurring_id";

    #endregion

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      BundleResourceBillingInfoResponseData responseData = null;

      try
      {
        BundleResourceBillingInfoRequestData request = (BundleResourceBillingInfoRequestData)requestData;

        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          using (SqlCommand cmd = new SqlCommand(STORED_PROCEDURE, cn))
          {
            cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter(RECURRING_ID_PARAM, request.BundleResourceId));

            BillingInfo billingInfo = null;

            cn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                billingInfo = GetBillingInfo(reader);
                if (billingInfo != null)
                {
                  break;
                }
              }
              responseData = new BundleResourceBillingInfoResponseData(billingInfo);
            }
          }
          cn.Close();
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new BundleResourceBillingInfoResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new BundleResourceBillingInfoResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Populate Billing Info
    private BillingInfo GetBillingInfo(IDataReader reader)
    {
      BillingInfo billingInfo = null;

      if (reader.FieldCount > 0)
      {
        IDictionary<string, object> productProperties = new Dictionary<string, object>();

        for (int i = 0; i < reader.FieldCount; i++)
        {
          if (!productProperties.ContainsKey(reader.GetName(i)))
          {
            productProperties.Add(reader.GetName(i), reader.GetValue(i));
          }
        }
        billingInfo = new BillingInfo(productProperties);
      }

      return billingInfo;
    }
    #endregion
  }
}
