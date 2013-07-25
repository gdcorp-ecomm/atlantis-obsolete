using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.EcommInstantPurchaseGet.Interface;
using System.Threading;
using netConnect;
using System.Data.SqlClient;
using System.Data;

namespace Atlantis.Framework.EcommInstantPurchaseGet.Impl
{
  public class EcommInstantPurchaseGetRequest : IRequest
  {
    private const string _PROCNAME = "gdshop_shopperInstantPurchaseProfileGet_sp";
    private const string _SHOPPERIDPARAM = "s_shopper_id";

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      int instantPurchaseProfileId = 0;

      try
      {
        EcommInstantPurchaseGetRequestData request = (EcommInstantPurchaseGetRequestData)oRequestData;

        string connectionString = LookupConnectionString(request, oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
              while (reader.Read())
              {
                object instantPurchaseProfileIdObj = reader[0];
                instantPurchaseProfileId = Convert.ToInt32(instantPurchaseProfileIdObj);
                break;
              }
            }
          }
        }

        oResponseData = new EcommInstantPurchaseGetResponseData(instantPurchaseProfileId);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new EcommInstantPurchaseGetResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new EcommInstantPurchaseGetResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    private string LookupConnectionString(EcommInstantPurchaseGetRequestData request, ConfigElement config)
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
  }
}
