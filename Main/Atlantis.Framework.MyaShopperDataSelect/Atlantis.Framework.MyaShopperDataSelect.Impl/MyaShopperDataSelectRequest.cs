using System;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaShopperDataSelect.Interface;

namespace Atlantis.Framework.MyaShopperDataSelect.Impl
{
  public class MyaShopperDataSelectRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MyaShopperDataSelectResponseData responseData = null;

      try
      {
        MyaShopperDataSelectRequestData shopperDataRequestData = (MyaShopperDataSelectRequestData)requestData;
        string data = GetShopperData(shopperDataRequestData, config);
        responseData = new MyaShopperDataSelectResponseData(data);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaShopperDataSelectResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new MyaShopperDataSelectResponseData(requestData, ex);
      }

      return responseData;
    }

    #endregion

    private string GetShopperData(MyaShopperDataSelectRequestData requestData, ConfigElement config)
    {
      string procName = "dbo.mya_ShopperDataSelectbyCategoryandShopper_sp";
      string data = null;

      using (SqlConnection conn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, conn))
        {
          cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@Category", requestData.Category));
          cmd.Parameters.Add(new SqlParameter("@Shopper_id", requestData.ShopperID));
          conn.Open();

          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              data = dr["Data"] == DBNull.Value ? null : dr["Data"].ToString();
              break;
            }
          }
        }
      }
      return data;
    }
  }
}
