using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProductPhotoAlbum.Interface;
using netConnect;

namespace Atlantis.Framework.MyaProductPhotoAlbum.Impl
{
  public class MyaProductPhotoAlbumRequest : IRequest
  {
    #region Parameters

    private const string STORED_PROCEDURE = "dbo.mya_getActiveUnifiedListbyProductTypeList_sp";
    private const string SHOPPER_ID_PARAM = "@shopper_id";
    private const string PAGE_NUMBER_PARAM = "@pageno";
    private const string ROWS_PER_PAGE_PARAM = "@rowsperpage";
    private const string RETURN_ALL_PARAM = "@returnAllFlag";
    private const string TOTAL_RECORDS_OUT_PARAM = "@totalrecords";
    private const string TOTAL_PAGES_OUT_PARAM = "@totalpages";
    private const string PRODUCT_TYPE_ID_PARAM = "@product_typeIDList";

    private const string PRODUCT_TYPE = "176";

    #endregion

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      MyaProductPhotoAlbumRequestData requestData = null;
      MyaProductPhotoAlbumResponseData responseData;

      try
      {
        requestData = (MyaProductPhotoAlbumRequestData)oRequestData;

        using (SqlConnection connection = new SqlConnection(LookupConnectionString(oConfig)))
        {
          using (SqlCommand command = new SqlCommand(STORED_PROCEDURE, connection))
          {
            command.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(SHOPPER_ID_PARAM, requestData.ShopperID));
            command.Parameters.Add(new SqlParameter(PRODUCT_TYPE_ID_PARAM, PRODUCT_TYPE));
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

            IList<PhotoAlbumProduct> PhotoAlbumProductList = new List<PhotoAlbumProduct>();

            using (SqlDataReader reader = command.ExecuteReader())
            {
              if (reader != null && reader.HasRows)
              {
                while (reader.Read())
                {
                  PhotoAlbumProduct PhotoAlbumProduct = GetPhotoAlbumProduct(reader, requestData);
                  if (PhotoAlbumProduct != null)
                  {
                    PhotoAlbumProductList.Add(PhotoAlbumProduct);
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

            responseData = new MyaProductPhotoAlbumResponseData(PhotoAlbumProductList, totalRecords, totalPages);
          }
        }
      }
      catch (Exception ex)
      {
        responseData = new MyaProductPhotoAlbumResponseData(requestData, ex);
      }

      return responseData;
    }

    private static PhotoAlbumProduct GetPhotoAlbumProduct(SqlDataReader reader, MyaProductPhotoAlbumRequestData requestData)
    {
      PhotoAlbumProduct PhotoAlbumProduct = null;

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

        PhotoAlbumProduct = new PhotoAlbumProduct(requestData.PrivateLabelId, productProperties);
      }

      return PhotoAlbumProduct;
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
