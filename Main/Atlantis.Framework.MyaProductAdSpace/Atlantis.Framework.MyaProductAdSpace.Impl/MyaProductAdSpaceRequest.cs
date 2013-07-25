using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;
using Atlantis.Framework.MyaProductAdSpace.Interface;
using netConnect;

namespace Atlantis.Framework.MyaProductAdSpace.Impl
{
  public class MyaProductAdSpaceRequest : IRequest
  {
    private const string EXPIRATION_DATE_SORT_COLUMN = "account_expiration_date";
    private const string COMMON_NAME_SORT_COLUMN = "commonName";

    #region Parameters

    private const string STORED_PROCEDURE = "dbo.mya_getActiveUnifiedListAdSpace_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string PRODUCT_TYPE_ID_PARAM = "@product_typeID";
    private const string PAGE_NUMBER_PARAM = "@pageno";
    private const string ROWS_PER_PAGE_PARAM = "@rowsperpage";
    private const string SORT_COLUMN_PARAM = "@sortcol";
    private const string SORT_DIR_PARAM = "@sortdir";
    private const string RETURN_ALL_PARAM = "@returnAllFlag";
    private const string TOTAL_RECORDS_OUT_PARAM = "@totalrecords";
    private const string TOTAL_PAGES_OUT_PARAM = "@totalpages";

    private const string PRODUCT_TYPE_ID = "390";

    #endregion

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      MyaProductAdSpaceRequestData requestData = null;
      MyaProductAdSpaceResponseData responseData;

      try
      {
        requestData = (MyaProductAdSpaceRequestData)oRequestData;

        using (SqlConnection connection = new SqlConnection(LookupConnectionString(oConfig)))
        {
          using (SqlCommand command = new SqlCommand(STORED_PROCEDURE, connection))
          {
            command.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(SHOPPER_ID_PARAM, requestData.ShopperID));
            command.Parameters.Add(new SqlParameter(PRODUCT_TYPE_ID_PARAM, PRODUCT_TYPE_ID));
            command.Parameters.Add(new SqlParameter(SORT_COLUMN_PARAM, GetSortColumnValue(requestData.SortColumn)));
            command.Parameters.Add(new SqlParameter(SORT_DIR_PARAM, GetSortDirectionValue(requestData.SortDirection)));
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

            IList<AdSpaceProduct> adSpaceProductList = new List<AdSpaceProduct>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
              if (reader != null && reader.HasRows)
              {
                while (reader.Read())
                {
                  AdSpaceProduct adSpaceProduct = GetAdSpaceProduct(reader, requestData);
                  if (adSpaceProduct != null)
                  {
                    adSpaceProductList.Add(adSpaceProduct);
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

            responseData = new MyaProductAdSpaceResponseData(adSpaceProductList, totalRecords, totalPages);
          }
        }
      }
      catch (Exception ex)
      {
        responseData = new MyaProductAdSpaceResponseData(requestData, ex);
      }

      return responseData;
    }

    private static AdSpaceProduct GetAdSpaceProduct(SqlDataReader reader, MyaProductAdSpaceRequestData requestData)
    {
      AdSpaceProduct adSpaceProduct = null;

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

        adSpaceProduct = new AdSpaceProduct(requestData.PrivateLabelId, productProperties);
      }

      return adSpaceProduct;
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

    private static string GetSortDirectionValue(SortDirectionType sortDirectionType)
    {
      string sortDirection = string.Empty;

      switch (sortDirectionType)
      {
        case SortDirectionType.Ascending:
          sortDirection = "ASC";
          break;
        case SortDirectionType.Descending:
          sortDirection = "DESC";
          break;
      }

      return sortDirection;
    }

    private static string GetSortColumnValue(MyaProductAdSpaceRequestData.SortColumnType sortColumnType)
    {
      string sortColumn = string.Empty;

      switch (sortColumnType)
      {
        case MyaProductAdSpaceRequestData.SortColumnType.AccountExpirationDate:
          sortColumn = EXPIRATION_DATE_SORT_COLUMN;
          break;
        case MyaProductAdSpaceRequestData.SortColumnType.CommonName:
          sortColumn = COMMON_NAME_SORT_COLUMN;
          break;
      }

      return sortColumn;
    }
  }
}
