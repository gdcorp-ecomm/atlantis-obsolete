using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.BillingOrionUpgradeInfo.Interface;
using Atlantis.Framework.Interface;
using netConnect;

namespace Atlantis.Framework.BillingOrionUpgradeInfo.Impl
{
  public class BillingOrionUpgradeInfoRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      BillingOrionUpgradeInfoResponseData responseData = null;
      List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>();

      try
      {
        BillingOrionUpgradeInfoRequestData billingOrionUpgradeRequestData = (BillingOrionUpgradeInfoRequestData)requestData;
        upgradeInfos = GetBillingOrionUpgrades(billingOrionUpgradeRequestData, config);

        responseData = new BillingOrionUpgradeInfoResponseData(upgradeInfos);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new BillingOrionUpgradeInfoResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new BillingOrionUpgradeInfoResponseData(requestData, ex);
      }

      return responseData;
    }

    private List<UpgradeInfo> GetBillingOrionUpgrades(BillingOrionUpgradeInfoRequestData requestData, ConfigElement config)
    {
      List<UpgradeInfo> upgradeInfos = new List<UpgradeInfo>();
      string procName = "dbo.gdshop_billingOrionGetUpgradeInfo_sp";

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(requestData, config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, cn))
        {
          cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@resource_id", requestData.ResourceId));
          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              upgradeInfos.Add(PopulateObjectFromDB(dr));
            }
          }
        }
      }
      return upgradeInfos;
    }

    private UpgradeInfo PopulateObjectFromDB(IDataReader dr)
    {
      UpgradeInfo upgradeInfo = new UpgradeInfo();

      upgradeInfo.AttributeDescription = dr["attributeDescription"] == DBNull.Value ? string.Empty : Convert.ToString(dr["attributeDescription"]);
      upgradeInfo.CustomerOwns = Convert.ToBoolean(dr["customerOwns"]);
      upgradeInfo.FamilyDescription = Convert.ToString(dr["familyDescription"]);
      upgradeInfo.FamilyDescriptionExtended = dr["familyDescriptionExtended"] == DBNull.Value ? string.Empty : Convert.ToString(dr["familyDescriptionExtented"]);
      upgradeInfo.FamilyGroupId = dr["familyGroupId"] == DBNull.Value ? null : (int?)Convert.ToInt32(dr["familyGroupId"]);
      upgradeInfo.OrionAttributeFamilyId = Convert.ToInt32(dr["gdshop_orionAttributeFamilyID"]);
      upgradeInfo.OrionAttributeTypeId = Convert.ToInt32(dr["gdshop_orionAttributeTypeID"]);
      upgradeInfo.OrionValue = Convert.ToInt32(dr["orionValue"]);
      upgradeInfo.PfId = Convert.ToInt32(dr["pf_id"]);
      upgradeInfo.Rank = Convert.ToInt32(dr["rank"]);
      upgradeInfo.RenewalPfId = dr["renewal_pf_id"] == DBNull.Value ? null : (int?)Convert.ToInt32(dr["renewal_pf_id"]);
      upgradeInfo.TransitionAware = Convert.ToBoolean(dr["transitionAware"]);
      upgradeInfo.UpgradeOption = Convert.ToInt32(dr["upgradeOption"]);

      return upgradeInfo;
    }

    #region Nimitz
    private string LookupConnectionString(BillingOrionUpgradeInfoRequestData requestData, ConfigElement config)
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
