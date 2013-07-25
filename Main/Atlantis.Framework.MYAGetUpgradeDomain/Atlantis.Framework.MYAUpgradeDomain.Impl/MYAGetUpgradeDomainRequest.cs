using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAGetUpgradeDomain.Interface;
using netConnect;

namespace Atlantis.Framework.MYAGetUpgradeDomain.Impl
{
  public class MYAGetUpgradeDomainRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MYAGetUpgradeDomainResponseData responseData = null;
      List<MyaUpgradeDomain> myaUpgradeDomains = new List<MyaUpgradeDomain>();

      try
      {
        MYAGetUpgradeDomainRequestData myaProductsRequestData = (MYAGetUpgradeDomainRequestData)requestData;
        myaUpgradeDomains = GetDomains(myaProductsRequestData, config);

        responseData = new MYAGetUpgradeDomainResponseData(myaUpgradeDomains);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MYAGetUpgradeDomainResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MYAGetUpgradeDomainResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Database Request Method
    private List<MyaUpgradeDomain> GetDomains(MYAGetUpgradeDomainRequestData myaGetUpgradeDomainRequestData, ConfigElement config)
    {
      List<MyaUpgradeDomain> myaUpgradeDomains = new List<MyaUpgradeDomain>();
      string procName = string.Empty;
      SqlParameter parm2 = new SqlParameter();
      SqlParameter[] parmArray;

      SetProcInfo(myaGetUpgradeDomainRequestData, out procName, out parmArray);

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(myaGetUpgradeDomainRequestData, config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, cn))
        {
          cmd.CommandTimeout = (int)myaGetUpgradeDomainRequestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          if (parmArray.Length > 0)
          {
            cmd.Parameters.AddRange(parmArray);
          }

          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              myaUpgradeDomains.Add(PopulateObjectFromDB(dr, myaGetUpgradeDomainRequestData));
            }
          }          
        }
      }

      return myaUpgradeDomains;
    }
    #endregion
       

    #region Database Response Methods
    private MyaUpgradeDomain PopulateObjectFromDB(IDataReader dr, MYAGetUpgradeDomainRequestData myaGetUpgradeDomainRequestData)
    {
      MyaUpgradeDomain ud = new MyaUpgradeDomain();

      try
      {        
        ud = new MyaUpgradeDomain();
        return ud.PopulateObjectFromDB(dr, myaGetUpgradeDomainRequestData);
      }
      catch (IndexOutOfRangeException ex)
      {
        string className = ud.GetType().ToString();
        throw new AtlantisException(myaGetUpgradeDomainRequestData, "MYAGetUpgradeDomainRequestData::PopulateObjectFromDB", "Database Column Does Not Exist", string.Format("Class: {0} | Missing Column: {1}", className, ex.Message));
      }
      catch (Exception ex)
      {
        string className = ud.GetType().ToString();
        throw new AtlantisException(myaGetUpgradeDomainRequestData, "MYAGetUpgradeDomainRequestData::PopulateObjectFromDB", "Error populating object from DataReader", string.Format("Class: {0} | ErrorMsg: {1} | StackTrace: {2}", className, ex.Message, ex.StackTrace));
      }
    }

    //private void HandlePreliminaryResultSets(SqlDataReader dr)
    //{
    //  if (dr.Read())
    //  {
    //    pagingInfo.NumberOfRecords = Convert.ToInt32(dr[0]);
    //  }

    //  if (dr.NextResult() && dr.Read())
    //  {
    //    pagingInfo.NumberOfPages = Convert.ToInt32(dr[0]);
    //  }
    //  dr.NextResult();
    //}
    #endregion

    #region Stored Procedure Setup
    private void SetProcInfo(MYAGetUpgradeDomainRequestData myaGetUpgradeDomainRequestData, out string procName, out SqlParameter[] parmArray)
    {
      procName = "mya_upgradeInfoDomains_sp";
      parmArray = new SqlParameter[3];
      parmArray[0] = new SqlParameter("@shopper_id", myaGetUpgradeDomainRequestData.ShopperID);
      parmArray[1] = new SqlParameter("@numRows", myaGetUpgradeDomainRequestData.NumRows);
      parmArray[2] = new SqlParameter("@returnAll", myaGetUpgradeDomainRequestData.ReturnAll);
      
    }    
    #endregion

    #region Nimitz
    private string LookupConnectionString(MYAGetUpgradeDomainRequestData myaGetUpgradeDomainRequestData, ConfigElement config)
    {
      string result;     
      LookupConnectionString(config, config.GetConfigValue("GD_DataSourceName"), out result);
      return result;
    }

    private static void LookupConnectionString(ConfigElement config, string dsn, out string result)
    {
      result = string.Empty;

      netConnect.Info nc = new netConnect.Info();
      result = nc.Get(dsn
        , config.GetConfigValue("ApplicationName")
        , config.GetConfigValue("CertificateName")
        , ConnectTypeEnum.CONNECT_TYPE_NET);

      if (string.IsNullOrEmpty(result) || result.Length <= 2)
      {
        throw new Exception("Invalid Connection String");
      }
    }
    #endregion
  }
}
