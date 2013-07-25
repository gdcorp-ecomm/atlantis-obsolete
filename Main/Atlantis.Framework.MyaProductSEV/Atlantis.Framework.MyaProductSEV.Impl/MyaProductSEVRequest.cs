using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface.Enums;
using Atlantis.Framework.MyaProductSEV.Interface;
using Atlantis.Framework.SEVGetWebsiteId.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductSEV.Impl
{
  public class MyaProductSEVRequest : IRequest
  {
    #region Sort Column Constants

    private const string EXPIRATION_DATE_SORT_COLUMN = "expiration_date";
    private const string COMMON_NAME_SORT_COLUMN = "commonName";

    #endregion

    #region Parameter Constants

    private const string STORED_PROCEDURE = "mya_accountListGetTrafficBlazer_sp";
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
      MyaProductSEVResponseData responseData = null;

      try
      {
        MyaProductSEVRequestData request = (MyaProductSEVRequestData)requestData;

        using (SqlConnection cn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
        {
          using (SqlCommand cmd = new SqlCommand(STORED_PROCEDURE, cn))
          {
            cmd.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(SetSqlParameters(request));

            IList<SEVProduct> sevProductList = new List<SEVProduct>();

            cn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
              while (reader.Read())
              {
                SEVProduct sevProduct = GetSEVOrAdSpaceProduct(reader, request, config);
                if (sevProduct != null)
                {
                  sevProductList.Add(sevProduct);
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

            responseData = new MyaProductSEVResponseData(sevProductList, totalRecords, totalPages);
          }
          cn.Close();
        }
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaProductSEVResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MyaProductSEVResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Populate SEV Product
    private SEVProduct GetSEVOrAdSpaceProduct(IDataReader reader, MyaProductSEVRequestData request, ConfigElement config)
    {
      SEVProduct sevProduct = null;
      string currentProductType = reader["gdshop_product_typeID"].ToString();

      switch ((MyaProductType)Enum.Parse(typeof(MyaProductType), currentProductType))
      {
        case MyaProductType.AdSpace:
          sevProduct = GetAdSpaceProduct(reader, request, config);
          break;
        case MyaProductType.SearchEngineVisibility:
          sevProduct = GetSEVProduct(reader, request, config);
          break;
      }

      return sevProduct;
    }

    private SEVProduct GetAdSpaceProduct(IDataReader reader, MyaProductSEVRequestData request, ConfigElement config)
    {
      SEVProduct sevProduct = null;

      if (reader.FieldCount > 0)
      {
        IDictionary<string, object> productProperties = new Dictionary<string, object>();
        for (int i = 0; i < reader.FieldCount; i++)
        {
          if (!productProperties.ContainsKey(reader.GetName(i)))
          {
            productProperties.Add(reader.GetName(i), reader.GetValue(i));
          }
          sevProduct = new SEVProduct(request.PrivateLabelId, productProperties);
        }
      }
      return sevProduct;   
    }

    private SEVProduct GetSEVProduct(IDataReader reader, MyaProductSEVRequestData request, ConfigElement config)
    {
      SEVProduct sevProduct = null;

      if (reader.FieldCount > 0)
      {
        IDictionary<string, object> productProperties = new Dictionary<string, object>();

        Dictionary<int, SEVReplacementData> srdDictionary = GetSEVAccountListReplacementData(request, config);
        SEVReplacementData srd;
        srdDictionary.TryGetValue(Convert.ToInt32(reader["resource_id"]), out srd);

        for (int i = 0; i < reader.FieldCount; i++)
        {
          if (!productProperties.ContainsKey(reader.GetName(i)))
          {
            switch (reader.GetName(i))
            {
              case "commonName":
                if (srd == null)
                {
                  productProperties.Add(reader.GetName(i), reader.GetValue(i));
                }
                else
                {
                  productProperties.Add(reader.GetName(i), srd.WebsiteUrl);
                }
                break;
              case "externalResourceID":
                if (srd == null)
                {
                  productProperties.Add(reader.GetName(i), "new");
                }
                else
                {
                  productProperties.Add(reader.GetName(i), srd.UserWebsiteId);
                }
                break;
              default:
                productProperties.Add(reader.GetName(i), reader.GetValue(i));
                break;
            }
          }
        }

        sevProduct = new SEVProduct(request.PrivateLabelId, productProperties);
      }

      return sevProduct;
    }
    #endregion

    #region SQL Parameter Handling
    private SqlParameter[] SetSqlParameters(MyaProductSEVRequestData request)
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

    private string GetSortColumnValue(MyaProductSEVRequestData.SortColumnType sortColumnType)
    {
      string sortColumn = string.Empty;

      switch (sortColumnType)
      {
        case MyaProductSEVRequestData.SortColumnType.AccountExpirationDate:
          sortColumn = EXPIRATION_DATE_SORT_COLUMN;
          break;
        case MyaProductSEVRequestData.SortColumnType.CommonName:
          sortColumn = COMMON_NAME_SORT_COLUMN;
          break;
      }

      return sortColumn;
    }
    #endregion

    #region Get Replacement Data from TrafficBlazer App
    private Dictionary<int, SEVReplacementData> GetSEVAccountListReplacementData(MyaProductSEVRequestData request, ConfigElement config)
    {
      Dictionary<int, SEVReplacementData> srd = new Dictionary<int, SEVReplacementData>();

      var sevRequest = new SEVGetWebsiteIdRequestData(request.ShopperID
        , request.SourceURL
        , request.OrderID
        , request.Pathway
        , request.PageCount);

      int requestType = request.OverrideSEVWebsiteIdRequestType.HasValue ? request.OverrideSEVWebsiteIdRequestType.Value : sevRequest.SEVGetWebsiteIdRequestType;
      var response = Engine.Engine.ProcessRequest(sevRequest, requestType) as SEVGetWebsiteIdResponseData;

      if (response.IsSuccess)
      {
        srd = response.ReplacementDataDictionary;
      }

      return srd;
    }
    #endregion
  }
}
