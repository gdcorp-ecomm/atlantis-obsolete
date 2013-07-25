using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAGetDBPProductInfoData.Interface;
using netConnect;

namespace Atlantis.Framework.MYAGetDBPProductInfoData.Impl
{
	public class GetDBPProductInfoDataRequest :IRequest
	{

		#region Database Request Method
		private List<DBPProductInfo> GetProducts(GetDBPProductInfoRequestData dbpProductInfoRequestData, ConfigElement config)
		{
			List<DBPProductInfo> dbpProducts = new List<DBPProductInfo>();
			PagingInfo pagingInfo = new PagingInfo(dbpProductInfoRequestData.PagingInfo);

			string procName = string.Empty;
			SqlParameter parm2 = new SqlParameter();
			SqlParameter[] parmArray;

			SetProcInfo(dbpProductInfoRequestData, pagingInfo, out procName, out parmArray);

			using (SqlConnection cn = new SqlConnection(LookupConnectionString(config)))
			{
				using (SqlCommand cmd = new SqlCommand(procName, cn))
				{
					cmd.CommandTimeout = (int)dbpProductInfoRequestData.RequestTimeout.TotalSeconds;
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
							dbpProducts.Add(PopulateObjectFromDB(dr, dbpProductInfoRequestData, config));
						}
					}
					HandlePreliminaryResultSets(dbpProductInfoRequestData, pagingInfo, dbpProducts);
						
				}
			}
		
			return dbpProducts;
		}

		private void HandlePreliminaryResultSets(GetDBPProductInfoRequestData request,PagingInfo pagingInfo, List<DBPProductInfo> dbp)
    {
			pagingInfo.NumberOfPages = dbp.Count/ request.PagingInfo.RowsPerPage;
			pagingInfo.NumberOfRecords = dbp.Count;

			request.PagingInfo.NumberOfPages = pagingInfo.NumberOfPages;
			request.PagingInfo.NumberOfRecords = pagingInfo.NumberOfRecords;
		}
    
		private DBPProductInfo PopulateObjectFromDB(SqlDataReader dr, GetDBPProductInfoRequestData data, ConfigElement config)
		{
			
			DBPProductInfo dbpInfo = new DBPProductInfo(data.PrivateLabelId);
			return dbpInfo.PopulateObjectFromDB(dr, data, false, config);
		}

		private static void SetProcInfo(GetDBPProductInfoRequestData data, PagingInfo pagingInfo, out string procName, out SqlParameter[] parmArray)
		{
			{
				procName = "dbo.mya_upgradeInfoDomains_sp";
				parmArray = new SqlParameter[3];
				parmArray[0] = new SqlParameter("@shopper_id", data.ShopperID);
				parmArray[1] = new SqlParameter("@numRows", 200);
				parmArray[2] = new SqlParameter("@returnAll",0 );
			}
		}

		#endregion


		public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
		{
			
			GetDBPProductInfoResponseData responseData = null;
			List<DBPProductInfo>dbpProductInfoLites = new List<DBPProductInfo>();

			try
			{
				GetDBPProductInfoRequestData dbpProductInfoRequestData = (GetDBPProductInfoRequestData)oRequestData;
				dbpProductInfoLites = GetProducts(dbpProductInfoRequestData, oConfig);

				responseData = new GetDBPProductInfoResponseData(dbpProductInfoLites);
			}

			catch (AtlantisException exAtlantis)
			{
				responseData = new GetDBPProductInfoResponseData(exAtlantis);
			}

			catch (Exception ex)
			{
				responseData = new GetDBPProductInfoResponseData(oRequestData, ex);
			}

			return responseData;
		}

		#region Nimitz
		private string LookupConnectionString(ConfigElement config)
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