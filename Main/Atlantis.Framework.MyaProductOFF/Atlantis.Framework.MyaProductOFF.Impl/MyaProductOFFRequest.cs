using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;
using Atlantis.Framework.MyaProductOFF.Interface;
using netConnect;

namespace Atlantis.Framework.MyaProductOFF.Impl
{
  public class MyaProductOFFRequest : IRequest
  {
    #region Parameters

    private const string STORED_PROCEDURE = "dbo.mya_GetActiveUnifiedList_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string PAGE_NUMBER_PARAM = "@pageno";
    private const string ROWS_PER_PAGE_PARAM = "@rowsperpage";
    private const string RETURN_ALL_PARAM = "@returnAllFlag";
    private const string TOTAL_RECORDS_OUT_PARAM = "@totalrecords";
    private const string TOTAL_PAGES_OUT_PARAM = "@totalpages";
    private const string PRODUCT_TYPE_ID_PARAM = "@product_typeID";

    #endregion

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      MyaProductOFFRequestData requestData = null;
      MyaProductOFFResponseData responseData;

      try
      {
        requestData = (MyaProductOFFRequestData)oRequestData;

        using (SqlConnection connection = new SqlConnection(LookupConnectionString(oConfig)))
        {
          using (SqlCommand command = new SqlCommand(STORED_PROCEDURE, connection))
          {
            command.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(SHOPPER_ID_PARAM, requestData.ShopperID));
            command.Parameters.Add(new SqlParameter(PRODUCT_TYPE_ID_PARAM, MyaProductType.OnlineFileFolder));
            command.Parameters.Add(new SqlParameter(RETURN_ALL_PARAM, requestData.PagingInfo.ReturnAll));

            if (!requestData.PagingInfo.ReturnAll)
            {
              command.Parameters.Add(new SqlParameter(PAGE_NUMBER_PARAM, requestData.PagingInfo.CurrentPage));
              command.Parameters.Add(new SqlParameter(ROWS_PER_PAGE_PARAM, requestData.PagingInfo.RowsPerPage));
            }

            SqlParameter totalPagesParam = new SqlParameter(TOTAL_PAGES_OUT_PARAM, SqlDbType.Int);
            totalPagesParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(totalPagesParam);

            SqlParameter totalRecordsParam = new SqlParameter(TOTAL_RECORDS_OUT_PARAM, SqlDbType.Int);
            totalRecordsParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(totalRecordsParam);

            connection.Open();

            IList<OFFProduct> OFFProductList = new List<OFFProduct>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
              if (reader != null && reader.HasRows)
              {
                while (reader.Read())
                {
                  OFFProduct OFFProduct = GetOFFProduct(reader, requestData);
                  if (OFFProduct != null)
                  {
                    OFFProductList.Add(OFFProduct);
                  }
                }
              }
            }

            int totalRecords = 0;
            int totalPages = 0;

            if (totalRecordsParam.Value != null)
            {
              totalRecords = (int)totalRecordsParam.Value;
            }

            if (totalPagesParam.Value != null)
            {
              totalPages = (int)totalPagesParam.Value;
            }

            responseData = new MyaProductOFFResponseData(OFFProductList, totalRecords, totalPages);
          }
        }
      }
      catch (Exception ex)
      {
        responseData = new MyaProductOFFResponseData(requestData, ex);
      }

      return responseData;
    }

    private static OFFProduct GetOFFProduct(SqlDataReader reader, MyaProductOFFRequestData requestData)
    {
      OFFProduct OFFProduct = null;

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

        OFFProduct = new OFFProduct(requestData.PrivateLabelId, productProperties);
      }

      return OFFProduct;
    }

    private static string LookupConnectionString(ConfigElement config)
    {
      string result = new Info().Get(config.GetConfigValue("DataSourceName"),
                                     config.GetConfigValue("ApplicationName"),
                                     config.GetConfigValue("CertificateName"),
                                     ConnectTypeEnum.CONNECT_TYPE_NET);

      if (string.IsNullOrEmpty(result) || result.Length <= 2)
      {
        throw new Exception("Invalid Connection String");
      }

      return result;
    }
  }
}
