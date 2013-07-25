using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SocialMediaContestGetVideoIDS.Interface;
using netConnect;

namespace Atlantis.Framework.SocialMediaContestGetVideoIDS.Impl
{
  public class SocialMediaContestGetVideoIDSRequest : IRequest
  {

    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      SocialMediaContestGetVideoIDSResponseData responseData = null;
      List<int> mediaIds = new List<int>();

      try
      {
        SocialMediaContestGetVideoIDSRequestData mediaIdsRequestData = (SocialMediaContestGetVideoIDSRequestData)requestData;
        mediaIds = GetMediaIds(mediaIdsRequestData, config);

        responseData = new SocialMediaContestGetVideoIDSResponseData(mediaIds);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new SocialMediaContestGetVideoIDSResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new SocialMediaContestGetVideoIDSResponseData(requestData, ex);
      }

      return responseData;
    }

    public List<int> GetMediaIds(SocialMediaContestGetVideoIDSRequestData requestData, ConfigElement config)
    {
      List<int> mediaIds = new List<int>();
      string procName = "dbo.gdshop_socialMediaVideoGetID";

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(requestData, config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, cn))
        {
          cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@gdshop_socialMediaCompetitionID", requestData.CompetitionId));
          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              mediaIds.Add(Convert.ToInt32(dr["gdshop_socialMediaVideoID"]));
            }
          }
        }
      }
      return mediaIds;
    }

    #region Nimitz
    private string LookupConnectionString(SocialMediaContestGetVideoIDSRequestData requestData, ConfigElement config)
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
