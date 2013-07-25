using System;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAResourceStatus.Interface;
using netConnect;

namespace Atlantis.Framework.MYAResourceStatus.Impl
{
  public class MYAResourceStatusRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MYAResourceStatusResponseData responseData = null;
      ResourceStatusInfo resourceStatusInfo = new ResourceStatusInfo();

      try
      {
        MYAResourceStatusRequestData request = (MYAResourceStatusRequestData)requestData;
        GetResourceStatusInfo(request, config, out resourceStatusInfo);

        responseData = new MYAResourceStatusResponseData(resourceStatusInfo);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MYAResourceStatusResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MYAResourceStatusResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Private Helpers

    private void GetResourceStatusInfo(MYAResourceStatusRequestData request, ConfigElement config, out ResourceStatusInfo rsi)
    {
      rsi = new ResourceStatusInfo();
      const string procName = "dbo.gdshop_resourceStatusUnified_sp";
      string sqlQuery = string.Format("select * from dbo.gdshop_dependent_resource (NOLOCK) where childResourceID = {0}", request.BillingResourceId);

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(request, config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, cn))
        {
          cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@resource_id", request.BillingResourceId));
          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            if (dr.Read())
            {
              rsi.IsFree = GetValue(dr["isFree"]) == 0 ? false : true;
              rsi.IsPastDue = GetValue(dr["isPastDue"]) == 0 ? false : true;
              rsi.GdShopBillingStatusId = GetValue(dr["gdshop_billing_statusID"]);
            }
          }
        }
        cn.Close();
      }
    }   

    private string LookupConnectionString(MYAResourceStatusRequestData requestData, ConfigElement config)
    {
      string result = string.Empty;

      netConnect.Info nc = new netConnect.Info();
      result = nc.Get(config.GetConfigValue("DataSourceName")
        , config.GetConfigValue("ApplicationName")
        , config.GetConfigValue("CertificateName")
        , ConnectTypeEnum.CONNECT_TYPE_NET);

      if (string.IsNullOrEmpty(result) || result.Length <= 2)
      {
        throw new Exception("Invalid Connection String");
      }
      return result;
    }

    private int GetValue(object i)
    {
      if (i == System.DBNull.Value)
        return 0;
      else
        return Convert.ToInt32(i);
    }
    #endregion
  }
}
