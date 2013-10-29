﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;
using Atlantis.Framework.MyaProductSiteAnalytics.Interface;

namespace Atlantis.Framework.MyaProductSiteAnalytics.Impl
{
  public class MyaProductSiteAnalyticsRequest : IRequest
  {
    #region Sort Column Constants

    private const string EXPIRATION_DATE_SORT_COLUMN = "account_expiration_date";
    private const string COMMON_NAME_SORT_COLUMN = "commonName";

    #endregion

    #region Parameter Constants

    private const string STORED_PROCEDURE = "mya_getActiveUnifiedListDeluxeStat_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string PRODUCT_TYPE_ID_PARAM = "@product_typeID";
    private const string PAGE_NUMBER_PARAM = "@pageno";
    private const string ROWS_PER_PAGE_PARAM = "@rowsperpage";
    private const string SORT_COLUMN_PARAM = "@sortcol";
    private const string SORT_DIR_PARAM = "@sortdir";
    private const string RETURN_ALL_PARAM = "@returnAllFlag";
    private const string TOTAL_RECORDS_OUT_PARAM = "@totalrecords";
    private const string TOTAL_PAGES_OUT_PARAM = "@totalpages";
    private const string PRODUCT_TYPE_ID = "82";

    #endregion

   public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
   {
      MyaProductSiteAnalyticsResponseData responseData = null;

      try
      {
        MyaProductSiteAnalyticsRequestData request = (MyaProductSiteAnalyticsRequestData)requestData;

        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          using (SqlCommand cmd = new SqlCommand(STORED_PROCEDURE, cn))
          {
            cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SetSqlParameters(request));

            IList<SiteAnalyticsProduct> siteAnalyticsProductList = new List<SiteAnalyticsProduct>();

            cn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                SiteAnalyticsProduct siteAnalyticsProduct = GetSiteAnalyticsProduct(reader, request);
                if (siteAnalyticsProduct != null)
                {
                  siteAnalyticsProductList.Add(siteAnalyticsProduct);
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

            responseData = new MyaProductSiteAnalyticsResponseData(siteAnalyticsProductList, totalRecords, totalPages);
          }
          cn.Close();
        }             
      } 
    
      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaProductSiteAnalyticsResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaProductSiteAnalyticsResponseData(requestData, ex);
      }
       
      return responseData;
    }

   #region Populate SafeSite Product
   private SiteAnalyticsProduct GetSiteAnalyticsProduct(IDataReader reader, MyaProductSiteAnalyticsRequestData request)
   {
     SiteAnalyticsProduct siteAnalyticsProduct = null;

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

       siteAnalyticsProduct = new SiteAnalyticsProduct(request.PrivateLabelId, productProperties);
     }

     return siteAnalyticsProduct;
   }
   #endregion

   #region SQL Parameter Handling
   private SqlParameter[] SetSqlParameters(MyaProductSiteAnalyticsRequestData request)
   {
     List<SqlParameter> paramColl = new List<SqlParameter>();

     paramColl.Add(new SqlParameter(SHOPPER_ID_PARAM, request.ShopperID));
     paramColl.Add(new SqlParameter(PRODUCT_TYPE_ID_PARAM, PRODUCT_TYPE_ID));
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

   private string GetSortColumnValue(MyaProductSiteAnalyticsRequestData.SortColumnType sortColumnType)
   {
     string sortColumn = string.Empty;

     switch (sortColumnType)
     {
       case MyaProductSiteAnalyticsRequestData.SortColumnType.AccountExpirationDate:
         sortColumn = EXPIRATION_DATE_SORT_COLUMN;
         break;
       case MyaProductSiteAnalyticsRequestData.SortColumnType.CommonName:
         sortColumn = COMMON_NAME_SORT_COLUMN;
         break;
     }

     return sortColumn;
   }
   #endregion
  }
}