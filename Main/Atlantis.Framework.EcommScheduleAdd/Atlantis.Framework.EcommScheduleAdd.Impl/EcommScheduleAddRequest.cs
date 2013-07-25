using System;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.EcommScheduleAdd.Interface;
using netConnect;

namespace Atlantis.Framework.EcommScheduleAdd.Impl
{
    public class EcommScheduleAddRequest : IRequest
    {
    
    private const string _PROCNAMESCHEDULEGET = "gdshop_outreachScheduleGetByShopper_sp";
    private const string _PROCNAMESCHEDULEINSERT = "outreach_insertSchedule_sp";
    private const string _SHOPPERIDPARAM = "shopper_id";
    private const string _SCHEDULED_DATE = "scheduled_date";
    private const string _SCHEDULED_HOUR = "scheduled_hour";
    private const string _DISCUSSION_TEXT = "discussion_text";
    private const string _RAW_HOUR = "raw_hour";
    
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData;

      try
      {
        var request = (EcommScheduleAddRequestData)oRequestData;

        string connectionString = LookupConnectionString(request,oConfig);
        using (var connection = new SqlConnection(connectionString))
        {
          using (var command = new SqlCommand(_PROCNAMESCHEDULEGET, connection))
          {
            bool shopperHasSchedule = false;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
              if (reader != null && reader.HasRows)
              {
                  shopperHasSchedule = true;
              }
            }

            int rowsChanged = 0;
            if (!shopperHasSchedule)
            {
                command.Parameters.Clear();
                command.CommandText = _PROCNAMESCHEDULEINSERT;
                command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
                command.Parameters.Add(new SqlParameter(_SCHEDULED_DATE, request.ScheduledDate));
                command.Parameters.Add(new SqlParameter(_SCHEDULED_HOUR, request.ScheduledHour));
                command.Parameters.Add(new SqlParameter(_DISCUSSION_TEXT, request.DiscussionText));
                command.Parameters.Add(new SqlParameter(_RAW_HOUR, request.RawHour));
                command.ExecuteNonQuery();
            }
              oResponseData = new EcommScheduleAddResponseData(shopperHasSchedule);
          }
        }
      }
      catch (AtlantisException exAtlantis)
      {
          oResponseData = new EcommScheduleAddResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
          oResponseData = new EcommScheduleAddResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    private string LookupConnectionString(EcommScheduleAddRequestData request, ConfigElement config)
    {
        string result = string.Empty;
        netConnect.Info oNetConnect = new netConnect.Info();
        string dataSource = config.GetConfigValue("DataSourceName");
        string applicationName = config.GetConfigValue("ApplicationName");
        string certificateName = config.GetConfigValue("CertificateName");
        if (!String.IsNullOrEmpty(dataSource) && !String.IsNullOrEmpty(applicationName) &&
          !String.IsNullOrEmpty(certificateName))
        {
            result = oNetConnect.Get(dataSource, applicationName, certificateName,
               ConnectTypeEnum.CONNECT_TYPE_NET);
        }

        //when an error occurs a ';' is returned not a valid connection string or empty
        if (result.Length <= 1)
        {
            throw new AtlantisException(request, "LookupConnectionString",
                    "Database connection string lookup failed", "No ConnectionFound For:"
                    + dataSource + ":"
                    + applicationName
                    + ":" + certificateName);
        }

        return result;
    }
    #endregion

  }
}

