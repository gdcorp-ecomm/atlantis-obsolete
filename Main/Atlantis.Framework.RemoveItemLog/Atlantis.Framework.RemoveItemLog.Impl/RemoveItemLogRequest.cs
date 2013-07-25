using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Atlantis.Framework.Interface;
using Atlantis.Framework.RemoveItemLog.Interface;


namespace Atlantis.Framework.RemoveItemLog.Impl
{
  public class RemoveItemLogRequest : IRequest
  {
    private const string _PROCNAME = "gdshop_receipt_cartRemovalInsert_sp";
    private const string _ORDERIDPARAM = "s_order_id";
    private const string _ROWIDPARAM = "n_row_id";
    private const string _PFIDPARAM = "n_pf_id";
    private const string _DATEENTEREDPARAM = "d_date_entered";
    private const string _SVISITGUIDPARAM = "s_visitGuid";
    private const string _PAGECOUNTPARAM = "n_pageCount";
    private const string _ISGROUPPARAM = "n_isGroup";
    private const string _ITEMTRACKINGCODE = "s_itc";
    private const string _ADJUSTEDPRICE = "n_adjustedPrice";
    private const string _DISCOUNTEDPRICE = "n_discountedPrice";
    private const string _QUANTITYT = "n_quantity";
    private const string _DURATION = "n_duration";

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;

      try
      {
        RemoveItemLogRequestData request = (RemoveItemLogRequestData)oRequestData;

        string connectionString = LookupConnectionString(request,oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            command.Parameters.Add(new SqlParameter(_ORDERIDPARAM, request.OrderID));
            command.Parameters.Add(new SqlParameter(_ROWIDPARAM, request.RowId));
            command.Parameters.Add(new SqlParameter(_PFIDPARAM, request.ProductId));
            command.Parameters.Add(new SqlParameter(_SVISITGUIDPARAM, request.Pathway));
            command.Parameters.Add(new SqlParameter(_PAGECOUNTPARAM, request.PageCount));
            command.Parameters.Add(new SqlParameter(_ITEMTRACKINGCODE, request.ItemTrackingCode));
            command.Parameters.Add(new SqlParameter(_ADJUSTEDPRICE, request.AdjustedPrice));
            command.Parameters.Add(new SqlParameter(_DISCOUNTEDPRICE, request.DiscountedPrice));
            command.Parameters.Add(new SqlParameter(_QUANTITYT, request.Quantity));
            if (request.Duration > 0)
            {
              command.Parameters.Add(new SqlParameter(_DURATION, request.Duration));
            }
            int groupValue = 0;
            if (request.IsGroup)
            {
              groupValue = 1;

            }
            command.Parameters.Add(new SqlParameter(_ISGROUPPARAM, groupValue));

            connection.Open();
            int result = command.ExecuteNonQuery();
            bool success = (result == -1);
            oResponseData = new RemoveItemLogResponseData(success);
          }
        }
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new RemoveItemLogResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new RemoveItemLogResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    private string LookupConnectionString(RemoveItemLogRequestData request, ConfigElement config)
    {
      string result = string.Empty;
      netConnect.Info oNetConnect = new netConnect.Info();
      string dataSourceName = config.GetConfigValue("DataSourceName");
      string applicationName = config.GetConfigValue("ApplicationName");
      string certificateName = config.GetConfigValue("CertificateName");

      result = oNetConnect.Get(dataSourceName, applicationName, certificateName, netConnect.ConnectTypeEnum.CONNECT_TYPE_NET);
      //when an error occurs a ';' is returned not a valid connection string or empty
      if (result.Length <= 1)
      {
        throw new AtlantisException(request, "LookupConnectionString",
                "Database connection string lookup failed", "No ConnectionFound For:" + dataSourceName + ":" + applicationName + ":" + certificateName);
      }

      return result;
    }
    #endregion

  }
}
