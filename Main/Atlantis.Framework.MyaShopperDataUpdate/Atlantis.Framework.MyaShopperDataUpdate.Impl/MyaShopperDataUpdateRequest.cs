using System;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaShopperDataUpdate.Interface;

namespace Atlantis.Framework.MyaShopperDataUpdate.Impl
{
  public class MyaShopperDataUpdateRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MyaShopperDataUpdateResponseData responseData = null;

      try
      {
        MyaShopperDataUpdateRequestData shopperDataUpdateRequestData = (MyaShopperDataUpdateRequestData)requestData;
        bool result = UpdateShopperData(shopperDataUpdateRequestData, config);
        responseData = new MyaShopperDataUpdateResponseData(result);
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new MyaShopperDataUpdateResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new MyaShopperDataUpdateResponseData(requestData, ex);
      }

      return responseData;
    }

    #endregion

    private bool UpdateShopperData(MyaShopperDataUpdateRequestData requestData, ConfigElement config)
    {
      string procName = "dbo.mya_ShopperDataUpdate_sp";
      bool successful = false;

      using (SqlConnection conn = new SqlConnection(Nimitz.NetConnect.LookupConnectInfo(config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, conn))
        {
          cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@Category", requestData.Category));
          cmd.Parameters.Add(new SqlParameter("@Shopper_id", requestData.ShopperID));
          cmd.Parameters.Add(new SqlParameter("@Data", requestData.Data));
          conn.Open();
          cmd.ExecuteNonQuery();

          successful = true;
        }
      }

      return successful;
    }
  }
}
