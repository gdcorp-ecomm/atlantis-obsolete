using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using System.Data.SqlClient;
using Atlantis.Framework.MyaProductGetByRid.Interface;
using System.Data;

namespace Atlantis.Framework.MyaProductGetByRid.Impl
{
  public class MyaProductGetByRidRequest : IRequest
  {
    #region Parameter Constants

    private const string CONFIG_STORED_PROCEDURE = "gdshop_product_typeGetAccountForPodConfigList_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string BILLING_RESOURCE_ID_PARAM = "@resource_id";
    private const string BILLING_NAMESPACE_PARAM = "@namespace";

    #endregion

    private static ConfigElement _config;

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MyaProductGetByRidResponseData responseData = null;

      try
      {
        _config = config;

        MyaProductGetByRidRequestData request = (MyaProductGetByRidRequestData)requestData;

        //Get proc to execute
        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          cn.Open();

          ProcConfigItem configItem = MyaProductGetByRidRequest.ProcConfigList[request.ProductTypeId];
          if (configItem != null)
          {
            using (SqlCommand cmd = new SqlCommand(configItem.StoredProcedure, cn))
            {
              cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddRange(SetSqlParameters(request, configItem));

              MyaProductAccount productAccount = null;

              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                if (reader.Read())
                {
                  productAccount = GetProductAccount(reader, request);
                }
              }

              responseData = new MyaProductGetByRidResponseData(productAccount);
            }
            cn.Close();
          }
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaProductGetByRidResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaProductGetByRidResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Populate Server  Hosting Product
    private MyaProductAccount GetProductAccount(IDataReader reader, MyaProductGetByRidRequestData request)
    {
      MyaProductAccount productAccount = null;

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

        productAccount = new MyaProductAccount(request.PrivateLabelId, productProperties);
      }

      return productAccount;
    }
    #endregion

    #region SQL Parameter Handling
    
    private SqlParameter[] SetSqlParameters(MyaProductGetByRidRequestData request, ProcConfigItem configItem)
    {
      List<SqlParameter> paramColl = new List<SqlParameter>();

      paramColl.Add(new SqlParameter(SHOPPER_ID_PARAM, request.ShopperID));
      paramColl.Add(new SqlParameter(BILLING_RESOURCE_ID_PARAM, request.BillingResourceId));
      paramColl.Add(new SqlParameter(BILLING_NAMESPACE_PARAM, configItem.BillingNamespace));

      SqlParameter[] paramArray = new SqlParameter[paramColl.Count];
      paramColl.CopyTo(paramArray, 0);

      return paramArray;
    }

    #endregion

    #region ProcConfigList DataCached

    internal static Dictionary<int, ProcConfigItem> GetProcConfigList(string key)
    {
      var procConfigList = new Dictionary<int, ProcConfigItem>();
      using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(_config)))
      {
        cn.Open();

        using (SqlCommand cmd = new SqlCommand(CONFIG_STORED_PROCEDURE, cn))
        {
          cmd.CommandType = CommandType.StoredProcedure;

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            while (reader.Read())
            {
              procConfigList.Add(reader.GetInt32(0), new ProcConfigItem(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
          }
        }

        cn.Close();
      }

      return procConfigList;
    }

    private static Dictionary<int, ProcConfigItem> ProcConfigList
    {
      get
      {
        return DataCache.DataCache.GetCustomCacheData<Dictionary<int, ProcConfigItem>>("{myaProducConfigItems}", GetProcConfigList);
      }
    }

    #endregion ProcConfigList DataCached
  }
}
