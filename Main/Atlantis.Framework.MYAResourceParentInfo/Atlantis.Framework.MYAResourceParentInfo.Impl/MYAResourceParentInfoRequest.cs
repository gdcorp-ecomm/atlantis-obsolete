using System;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAResourceParentInfo.Interface;
using netConnect;

namespace Atlantis.Framework.MYAResourceParentInfo.Impl
{
  public class MYAResourceParentInfoRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MYAResourceParentInfoResponseData responseData = null;
      ResourceParentInfo resourceParentInfo = new ResourceParentInfo();

      try
      {
        MYAResourceParentInfoRequestData request = (MYAResourceParentInfoRequestData)requestData;
        GetResourceParentInfo(request, config, out resourceParentInfo);

        responseData = new MYAResourceParentInfoResponseData(resourceParentInfo);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MYAResourceParentInfoResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MYAResourceParentInfoResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Private Helpers

    private void GetResourceParentInfo(MYAResourceParentInfoRequestData request, ConfigElement config, out ResourceParentInfo rpi)
    {
      rpi = new ResourceParentInfo();
      string sqlQuery = string.Format("select * from dbo.gdshop_dependent_resource (NOLOCK) where childResourceID = {0}", request.BillingResourceId);

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(request, config)))
      {
        using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
        {
          cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.Text;
          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            if (dr.Read())
            {
              rpi.ParentBillingResourceId = Convert.ToInt32(dr["parentResourceID"]);
              rpi.ParentResourceTypeId = Convert.ToInt32(dr["parentResourceTypeID"]);
            }
          }
        }
        cn.Close();
      }
    }

    private string LookupConnectionString(MYAResourceParentInfoRequestData requestData, ConfigElement config)
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
    #endregion
  }
}
