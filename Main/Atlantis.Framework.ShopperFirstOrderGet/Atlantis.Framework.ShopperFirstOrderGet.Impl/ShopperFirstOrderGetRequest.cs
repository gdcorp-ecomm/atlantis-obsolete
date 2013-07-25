using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.ShopperFirstOrderGet.Interface;
using netConnect;

namespace Atlantis.Framework.ShopperFirstOrderGet.Impl
{
  public class ShopperFirstOrderGetRequest : IRequest
  {
    private const string _PROCNAMESCHEDULEGET = "gdshop_shopperAffiliateIsFirstOrder_sp";
    private const string _SHOPPERIDPARAM = "ShopperId";
    private const string _ORDERIDPARAM = "OrderID";
    private const string _ISFIRSTORDERPARAM = "IsFirstOrder";
    
   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      ShopperFirstOrderGetResponseData responseData = null;
       bool IsCustomerNew = false;
       var request = (ShopperFirstOrderGetRequestData)requestData;


      try
      {
        
        string connectionString = LookupConnectionString(request,config);
        using (var connection = new SqlConnection(connectionString))
        {
          using (var command = new SqlCommand(_PROCNAMESCHEDULEGET, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            command.Parameters.Add(new SqlParameter(_ORDERIDPARAM, request.OrderID));
            var firstOrderParam = new SqlParameter(_ISFIRSTORDERPARAM, SqlDbType.Bit);
            firstOrderParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(firstOrderParam);
    
            connection.Open();

              command.ExecuteNonQuery();
              IsCustomerNew = (bool)firstOrderParam.Value;
            
              responseData = new ShopperFirstOrderGetResponseData(IsCustomerNew);
          }
        }
      }
      catch (AtlantisException exAtlantis)
      {
          responseData = new ShopperFirstOrderGetResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
          responseData = new ShopperFirstOrderGetResponseData(request, ex);
      }

      return responseData;
    }

    private string LookupConnectionString(ShopperFirstOrderGetRequestData request, ConfigElement config)
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
