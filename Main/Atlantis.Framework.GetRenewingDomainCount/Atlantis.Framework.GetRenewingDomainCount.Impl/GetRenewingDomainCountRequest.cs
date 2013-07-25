using System;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.GetRenewingDomainCount.Interface;
using Atlantis.Framework.Interface;
using netConnect;

namespace Atlantis.Framework.GetRenewingDomainCount.Impl
{

  public class GetRenewingDomainCountRequest : IRequest
  {
    private const string ProcName = "gdshop_MyRenewalsRenewingDomainListByShopperCount_sp";
   
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      GetRenewingDomainCountResponseData responseData = null;

      try
      {
        GetRenewingDomainCountRequestData domainCountRequestData = (GetRenewingDomainCountRequestData)requestData;
        
        using (SqlConnection connection = new SqlConnection(LookupConnectionString(config)))
        {
          using (SqlCommand command = new SqlCommand(ProcName, connection))
          {
            command.CommandTimeout  = (int)domainCountRequestData.RequestTimeout.TotalSeconds;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("shopper_id", domainCountRequestData.ShopperID));
            command.Parameters.Add(new SqlParameter("DaysFromExp", domainCountRequestData.DaysFromExpire));
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
              if (reader.Read())
              {
                int expiring = reader["ExpiringDomains"] == DBNull.Value ? 0 : Convert.ToInt32(reader["ExpiringDomains"]);
                int expired = reader["AlreadyExpiredDomains"] == DBNull.Value ? 0 : Convert.ToInt32(reader["AlreadyExpiredDomains"]);
                responseData = new GetRenewingDomainCountResponseData(expiring, expired);
              }
            }
          }
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new GetRenewingDomainCountResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new GetRenewingDomainCountResponseData(requestData, ex);
      }

      return responseData;
    }


    private string LookupConnectionString(ConfigElement config)
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

  }
}
