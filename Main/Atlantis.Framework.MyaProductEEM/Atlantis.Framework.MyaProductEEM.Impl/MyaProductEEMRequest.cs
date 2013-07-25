using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;
using Atlantis.Framework.MyaProductEEM.Interface;
using Atlantis.Framework.EEMGetCustomerSummary.Interface;

namespace Atlantis.Framework.MyaProductEEM.Impl
{
  public class MyaProductEEMRequest : IRequest
  {
    #region Sort Column Constants

    private const string EXPIRATION_DATE_SORT_COLUMN = "expiration_date";
    private const string COMMON_NAME_SORT_COLUMN = "commonName";

    #endregion

    #region Parameter Constants

    private const string STORED_PROCEDURE = "mya_accountListGetCampaignBlazer_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string PRODUCT_TYPE_ID_PARAM = "@product_typeID";
    private const string PAGE_NUMBER_PARAM = "@pageno";
    private const string ROWS_PER_PAGE_PARAM = "@rowsperpage";
    private const string SORT_COLUMN_PARAM = "@sortcol";
    private const string SORT_DIR_PARAM = "@sortdir";
    private const string RETURN_ALL_PARAM = "@returnAllFlag";
    private const string TOTAL_RECORDS_OUT_PARAM = "@totalrecords";
    private const string TOTAL_PAGES_OUT_PARAM = "@totalpages";

    #endregion

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MyaProductEEMResponseData responseData = null;

      try
      {
        MyaProductEEMRequestData request = (MyaProductEEMRequestData)requestData;

        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          using (SqlCommand cmd = new SqlCommand(STORED_PROCEDURE, cn))
          {
            cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SetSqlParameters(request));

            IList<EEMProduct> eemProductList = new List<EEMProduct>();

            cn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                EEMProduct eemProduct = GetEEMProduct(reader, request, config);
                if (eemProduct != null)
                {
                  eemProductList.Add(eemProduct);
                }
              }
            }

            int totalRecords = 0;
            int totalPages = 0;

            if (cmd.Parameters[TOTAL_RECORDS_OUT_PARAM].Value != null)
            {
              totalRecords = (int)cmd.Parameters[TOTAL_RECORDS_OUT_PARAM].Value;
            }

            if (cmd.Parameters[TOTAL_PAGES_OUT_PARAM].Value != null)
            {
              totalPages = (int)cmd.Parameters[TOTAL_PAGES_OUT_PARAM].Value;
            }

            responseData = new MyaProductEEMResponseData(eemProductList, totalRecords, totalPages);
          }
          cn.Close();
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaProductEEMResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaProductEEMResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Populate SafeSite Product
    private EEMProduct GetEEMProduct(IDataReader reader, MyaProductEEMRequestData request, ConfigElement config)
    {
      EEMProduct eemProduct = null;

      if (reader.FieldCount > 0)
      {
        IDictionary<string, object> productProperties = new Dictionary<string, object>();

        Dictionary<int, EEMCustomerSummary> erdDictionary = GetEEMAccountListReplacementData(request, config, reader);
        EEMCustomerSummary erd = null;
        if (erdDictionary.Count > 0)
        {
          erdDictionary.TryGetValue(Convert.ToInt32(reader["externalResourceID"]), out erd);
        }

        for (int i = 0; i < reader.FieldCount; i++)
        {
          if (!productProperties.ContainsKey(reader.GetName(i)))
          {
            switch (reader.GetName(i))
            {
              case "commonName":
                if (erd == null)
                {
                  productProperties.Add(reader.GetName(i), "New Account");
                }
                else
                {
                  productProperties.Add(reader.GetName(i), erd.companyName);
                }
                break;
              default:
                productProperties.Add(reader.GetName(i), reader.GetValue(i));
                break;
            }
          }
        }

        eemProduct = new EEMProduct(request.PrivateLabelId, productProperties);
      }

      return eemProduct;
    }
    #endregion

    #region SQL Parameter Handling
    private SqlParameter[] SetSqlParameters(MyaProductEEMRequestData request)
    {
      List<SqlParameter> paramColl = new List<SqlParameter>();

      paramColl.Add(new SqlParameter(SHOPPER_ID_PARAM, request.ShopperID));
      paramColl.Add(new SqlParameter(SORT_COLUMN_PARAM, GetSortColumnValue(request.SortColumn)));
      paramColl.Add(new SqlParameter(SORT_DIR_PARAM, GetSortDirectionValue(request.SortDirection)));
      paramColl.Add(new SqlParameter(RETURN_ALL_PARAM, request.PagingInfo.ReturnAll));

      if (!request.PagingInfo.ReturnAll)
      {
        paramColl.Add(new SqlParameter(PAGE_NUMBER_PARAM, request.PagingInfo.CurrentPage));
        paramColl.Add(new SqlParameter(ROWS_PER_PAGE_PARAM, request.PagingInfo.RowsPerPage));
      }

      SqlParameter totalPagesParam = new SqlParameter(TOTAL_PAGES_OUT_PARAM, SqlDbType.Int);
      totalPagesParam.Direction = ParameterDirection.Output;

      SqlParameter totalRecordsParam = new SqlParameter(TOTAL_RECORDS_OUT_PARAM, SqlDbType.Int);
      totalRecordsParam.Direction = ParameterDirection.Output;

      paramColl.Add(totalPagesParam);
      paramColl.Add(totalRecordsParam);

      SqlParameter[] paramArray = new SqlParameter[paramColl.Count];
      paramColl.CopyTo(paramArray, 0);

      return paramArray;
    }

    private string GetSortDirectionValue(SortDirectionType sortDirectionType)
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

    private string GetSortColumnValue(MyaProductEEMRequestData.SortColumnType sortColumnType)
    {
      string sortColumn = string.Empty;

      switch (sortColumnType)
      {
        case MyaProductEEMRequestData.SortColumnType.AccountExpirationDate:
          sortColumn = EXPIRATION_DATE_SORT_COLUMN;
          break;
        case MyaProductEEMRequestData.SortColumnType.CommonName:
          sortColumn = COMMON_NAME_SORT_COLUMN;
          break;
      }

      return sortColumn;
    }
    #endregion

    #region Get Replacement Data from EEM Web Service
    private Dictionary<int, EEMCustomerSummary> GetEEMAccountListReplacementData(MyaProductEEMRequestData request, ConfigElement config, IDataReader reader)
    {
      Dictionary<int, EEMCustomerSummary> erd = new Dictionary<int, EEMCustomerSummary>();
      int custId;

      List<int> customerIds = new List<int>();

      for (int i = 0; i < reader.FieldCount; i++)
      {
        if (reader.GetName(i).Equals("externalResourceID"))
        {
          if (int.TryParse(reader.GetValue(i).ToString(), out custId))
          {
            customerIds.Add(custId);
          }
        }
      }

      if (customerIds.Count > 0)
      {
        var eemRequest = new EEMGetCustomerSummaryRequestData(request.ShopperID
          , request.SourceURL
          , request.OrderID
          , request.Pathway
          , request.PageCount
          , customerIds);

        int requestType = request.OverrideEEMCustomerSummaryRequestType.HasValue ? request.OverrideEEMCustomerSummaryRequestType.Value : eemRequest.EEMGetCustomerSummaryRequestType;
        var response = Engine.Engine.ProcessRequest(eemRequest, requestType) as EEMGetCustomerSummaryResponseData;

        if (response.IsSuccess)
        {
          erd = response.ReplacementDataDictionary;
        }
      }

      return erd;
    }
    #endregion
  }
}
