using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetMobileToken.Interface;
using System.Xml;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using netConnect;

namespace Atlantis.Framework.GetMobileToken.Impl
{
  public class GetMobileTokenRequest : IRequest
  {

    private const int _MINUTES_TILL_SESSION_EXPIRE = 20;
    private const string _PROCNAME = "mobile_deviceSessionInsert_sp";
    private const string _SHOPPERIDPARAM = "@s_shopper_id";
    private const string _DEVICEIDPARAM = "@s_deviceID";
    private const string _EXPIRATIONDATEPARAM = "@d_expirationDate";

    private string GetNewSessionToken(GetMobileTokenRequestData request)
    {
      string sessionToken = "";

      TimeSpan dtTimeSpan = new TimeSpan(0, _MINUTES_TILL_SESSION_EXPIRE, 0);
      DateTime dtExpire = DateTime.Now + dtTimeSpan;

      string connectionString = LookupConnectionString(request);
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
          command.Parameters.Add(new SqlParameter(_DEVICEIDPARAM, request.DeviceGUID));
          command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
          command.Parameters.Add(new SqlParameter(_EXPIRATIONDATEPARAM, dtExpire));
          connection.Open();
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              object sessionTokenObj = reader[0];
              sessionToken = Convert.ToString(sessionTokenObj);
              break;
            }
          }
        }
      }
      return sessionToken;
    }

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetMobileTokenRequestData getMobileTokenRequest = oRequestData as GetMobileTokenRequestData;
      GetMobileTokenResponseData getMobileTokenResponse = null;

      try
      {
        String sessionToken = GetNewSessionToken(getMobileTokenRequest);
        getMobileTokenResponse = new GetMobileTokenResponseData(sessionToken);
      }
      catch (AtlantisException exAtlantis)
      {
        getMobileTokenResponse = new GetMobileTokenResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        getMobileTokenResponse = new GetMobileTokenResponseData(oRequestData, ex);
      }

      return getMobileTokenResponse;
    }

    private string LookupConnectionString(GetMobileTokenRequestData request)
    {
      string result = string.Empty;
      netConnect.Info oNetConnect = new netConnect.Info();
      result = oNetConnect.Get(request.DataSourceName, request.ApplicationName, request.CertificateName, netConnect.ConnectTypeEnum.CONNECT_TYPE_NET);
      //when an error occurs a ';' is returned not a valid connection string or empty
      if (result.Length <= 1)
      {
        throw new AtlantisException(request, "LookupConnectionString",
                "Database connection string lookup failed", "No ConnectionFound For:" + request.DataSourceName + ":" + request.ApplicationName + ":" + request.CertificateName);
      }

      return result;
    }

  }
}

