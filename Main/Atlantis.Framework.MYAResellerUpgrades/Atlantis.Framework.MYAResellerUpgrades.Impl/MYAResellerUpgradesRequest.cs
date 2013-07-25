using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAResellerUpgrades.Interface;
using netConnect;
using System.Data.SqlClient;
using System.Data;

namespace Atlantis.Framework.MYAResellerUpgrades.Impl
{
  public class MYAResellerUpgradesRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MYAResellerUpgradesResponseData responseData = null;
      List<ResellerUpgrade> resellerUpgrades = new List<ResellerUpgrade>();

      try
      {
        MYAResellerUpgradesRequestData myaResellerUpgradeRequestData = (MYAResellerUpgradesRequestData)requestData;
        resellerUpgrades = GetUpgrades(myaResellerUpgradeRequestData, config);

        responseData = new MYAResellerUpgradesResponseData(resellerUpgrades);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MYAResellerUpgradesResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MYAResellerUpgradesResponseData(requestData, ex);
      }

      return responseData;
    }

    private List<ResellerUpgrade> GetUpgrades(MYAResellerUpgradesRequestData requestData, ConfigElement config)
    {
      List<ResellerUpgrade> resellerUpgrades = new List<ResellerUpgrade>();
      string procName = "gdshop_resellerUpgradeByRecurringID_sp";

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, cn))
        {
          cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@n_recurring_id", requestData.BillingResourceId));
          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              resellerUpgrades.Add(PopulateObjectFromDB(dr));
            }
          }
        }
      }
      return resellerUpgrades;
    }

    private ResellerUpgrade PopulateObjectFromDB(IDataReader dr)
    {
      ResellerUpgrade resellerUpgrade = new ResellerUpgrade();

      resellerUpgrade.ProductId = Convert.ToInt32(dr["upgrade_pf_id"]);
      resellerUpgrade.Description = dr["name"] == DBNull.Value ? string.Empty : Convert.ToString(dr["name"].ToString());

      return resellerUpgrade;
    }

    #region Nimitz
    private string LookupConnectionString(ConfigElement config)
    {
      string result = string.Empty;

      netConnect.Info nc = new netConnect.Info();
      result = nc.Get(config.GetConfigValue("DataSourceName")
        , config.GetConfigValue("ApplicationName")
        , config.GetConfigValue("CertificateName")
        , ConnectTypeEnum.CONNECT_TYPE_NET);

      if (string.IsNullOrEmpty(result) || result.Length <= 2)
      {
        throw new Exception("Invalid Connection String");
      }
      return result;
    }
    #endregion
  }
}
