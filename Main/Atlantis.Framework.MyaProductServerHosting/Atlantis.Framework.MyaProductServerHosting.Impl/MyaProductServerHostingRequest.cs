﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProductServerHosting.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductServerHosting.Impl
{
  public class MyaProductServerHostingRequest : IRequest
  {
    #region Sort Column Constants

    private const string EXPIRATION_DATE_SORT_COLUMN = "account_expiration_date";
    private const string COMMON_NAME_SORT_COLUMN = "commonName";

    #endregion

    #region Parameter Constants

    private const string DED_STORED_PROCEDURE = "mya_getActiveUnifiedListDedHost_sp";
    private const string VDED_STORED_PROCEDURE = "mya_getActiveUnifiedListVirtualHosting_sp";
    private const string DED_VDED_STORED_PROCEDURE = "mya_getActiveUnifiedListVirtualAndDedicatedHosting_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string PAGE_NUMBER_PARAM = "@pageno";
    private const string ROWS_PER_PAGE_PARAM = "@rowsperpage";
    private const string SORT_COLUMN_PARAM = "@sortcol";
    private const string SORT_DIR_PARAM = "@sortdir";
    private const string RETURN_ALL_PARAM = "@returnAllFlag";
    private const string TOTAL_RECORDS_OUT_PARAM = "@totalrecords";
    private const string TOTAL_PAGES_OUT_PARAM = "@totalpages";
    private const string RETURN_PEND_SETUP_PARAM = "@returnPendSetup";
    private const string DED_PRODUCT_TYPE_ID = "98";
    private const string VDED_PRODUCT_TYPE_ID = "222";

    #endregion

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MyaProductServerHostingResponseData responseData = null;

      try
      {
        MyaProductServerHostingRequestData request = (MyaProductServerHostingRequestData)requestData;

        string storedProcedure = null;
        switch (request.Type)
        {
          case MyaProductServerHostingRequestData.ServerType.DedHosting:
            storedProcedure = DED_STORED_PROCEDURE;
            break;
          case MyaProductServerHostingRequestData.ServerType.VDedHosting:
            storedProcedure = VDED_STORED_PROCEDURE;
            break;
          case MyaProductServerHostingRequestData.ServerType.Ded_And_VDedHosting:
            storedProcedure = DED_VDED_STORED_PROCEDURE;
            break;
        }
        
        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
         {
           using (SqlCommand cmd = new SqlCommand(storedProcedure, cn))
           {
             cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.Parameters.AddRange(SetSqlParameters(request));

             IList<ServerHostingProduct> serverHostingProductList = new List<ServerHostingProduct>();

            cn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                ServerHostingProduct serverHostingProduct = GetServerHostingProduct(reader, request);
                if (serverHostingProduct != null)
                {
                  serverHostingProductList.Add(serverHostingProduct);
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

            responseData = new MyaProductServerHostingResponseData(serverHostingProductList, totalRecords, totalPages);
          }
          cn.Close();
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaProductServerHostingResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaProductServerHostingResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Populate Server  Hosting Product
    private ServerHostingProduct GetServerHostingProduct(IDataReader reader, MyaProductServerHostingRequestData request)
    {
      ServerHostingProduct serverHostingProduct = null;

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

        serverHostingProduct = new ServerHostingProduct(request.PrivateLabelId, productProperties);
      }

      return serverHostingProduct;
    }
    #endregion

    #region SQL Parameter Handling
    private SqlParameter[] SetSqlParameters(MyaProductServerHostingRequestData request)
    {
      List<SqlParameter> paramColl = new List<SqlParameter>();

      paramColl.Add(new SqlParameter(SHOPPER_ID_PARAM, request.ShopperID));
      paramColl.Add(new SqlParameter(SORT_COLUMN_PARAM, GetSortColumnValue(request.SortColumn)));
      paramColl.Add(new SqlParameter(SORT_DIR_PARAM, GetSortDirectionValue(request.SortDirection)));
      paramColl.Add(new SqlParameter(RETURN_ALL_PARAM, request.PagingInfo.ReturnAll));
      paramColl.Add(new SqlParameter(RETURN_PEND_SETUP_PARAM, request.IncludePendingSetupAccounts));

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

    private string GetSortColumnValue(MyaProductServerHostingRequestData.SortColumnType sortColumnType)
    {
      string sortColumn = string.Empty;

      switch (sortColumnType)
      {
        case MyaProductServerHostingRequestData.SortColumnType.AccountExpirationDate:
          sortColumn = EXPIRATION_DATE_SORT_COLUMN;
          break;
        case MyaProductServerHostingRequestData.SortColumnType.CommonName:
          sortColumn = COMMON_NAME_SORT_COLUMN;
          break;
      }

      return sortColumn;
    }

    #endregion

  }
}
