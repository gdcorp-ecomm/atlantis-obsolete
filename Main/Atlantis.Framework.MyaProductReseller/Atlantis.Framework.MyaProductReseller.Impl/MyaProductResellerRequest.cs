﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;
using Atlantis.Framework.MyaProductReseller.Interface;

namespace Atlantis.Framework.MyaProductReseller.Impl
{
  public class MyaProductResellerRequest : IRequest
  {
    #region Sort Column Constants

    private const string BILLING_DATE_SORT_COLUMN = "billing_date";
    private const string ENTITY_NAME_SORT_COLUMN = "entityName";

    #endregion 

    #region Parameter Constants

    private const string STORED_PROCEDURE = "dbo.mya_getActiveResellerList_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
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
      MyaProductResellerResponseData responseData = null;

      try
      {
        var request = (MyaProductResellerRequestData)requestData;

        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          using (SqlCommand cmd = new SqlCommand(STORED_PROCEDURE, cn))
          {
            cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SetSqlParameters(request));

            IList<ResellerProduct> resellerProductList = new List<ResellerProduct>();

            cn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                ResellerProduct resellerProduct = GetResellerProduct(reader, request);
                if (resellerProduct != null)
                {
                  resellerProductList.Add(resellerProduct);
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

            responseData = new MyaProductResellerResponseData(resellerProductList, totalRecords, totalPages);
          }
          cn.Close();
        }       
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaProductResellerResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaProductResellerResponseData(requestData, ex);
      }
       
      return responseData;
    }

   #region Populate Reseller Product
   private ResellerProduct GetResellerProduct(IDataReader reader, MyaProductResellerRequestData request)
   {
     ResellerProduct premiumDNSProduct = null;

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

       premiumDNSProduct = new ResellerProduct(request.PrivateLabelId, productProperties);
     }

     return premiumDNSProduct;
   }
   #endregion

   #region SQL Parameter Handling
   private SqlParameter[] SetSqlParameters(MyaProductResellerRequestData request)
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

   private string GetSortColumnValue(MyaProductResellerRequestData.SortColumnType sortColumnType)
   {
     string sortColumn = string.Empty;

     switch (sortColumnType)
     {
       case MyaProductResellerRequestData.SortColumnType.AccountExpirationDate:
         sortColumn = BILLING_DATE_SORT_COLUMN;
         break;
       case MyaProductResellerRequestData.SortColumnType.CommonName:
         sortColumn = ENTITY_NAME_SORT_COLUMN;
         break;
     }

     return sortColumn;
   }
   #endregion
  }
}
