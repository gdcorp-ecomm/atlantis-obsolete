using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaResourceReverseQty.Interface;

namespace Atlantis.Framework.MyaResourceReverseQty.Impl
{
  public class MyaResourceReverseQtyRequest : IRequest
  {
    #region Parameter Constants

    private const string STORED_PROCEDURE = "dbo.mya_getResourceReverseQuantity_sp";
    private const string BILLING_RESOURCE_ID_PARAM = "@n_resource_id";

    #endregion

    private static ConfigElement _config;

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MyaResourceReverseQtyResponseData responseData = null;

      try
      {
        _config = config;

        MyaResourceReverseQtyRequestData request = (MyaResourceReverseQtyRequestData)requestData;

        //Get proc to execute
        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          cn.Open();

          using (SqlCommand cmd = new SqlCommand(STORED_PROCEDURE, cn))
          {
            cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SetSqlParameters(request));

            List<ResourceReverseQty> results = new List<ResourceReverseQty>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                results.Add(new ResourceReverseQty(reader));
              }
            }

            responseData = new MyaResourceReverseQtyResponseData(results);
          }
          cn.Close();
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaResourceReverseQtyResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaResourceReverseQtyResponseData(requestData, ex);
      }

      return responseData;
    }

    #region SQL Parameter Handling
    
    private SqlParameter[] SetSqlParameters(MyaResourceReverseQtyRequestData request)
    {
      List<SqlParameter> paramColl = new List<SqlParameter>();

      paramColl.Add(new SqlParameter(BILLING_RESOURCE_ID_PARAM, request.BillingResourceId));

      SqlParameter[] paramArray = new SqlParameter[paramColl.Count];
      paramColl.CopyTo(paramArray, 0);

      return paramArray;
    }

    #endregion

  }
}
