using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAGetHostingCredits.Interface;
using netConnect;

namespace Atlantis.Framework.MYAGetHostingCredits.Impl
{
  public class MYAGetHostingCreditsRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      MYAGetHostingCreditsResponseData responseData = null;
      List<HostingCredit> hostingCredits = new List<HostingCredit>();

      try
      {
        MYAGetHostingCreditsRequestData hostingCreditsRequestData = (MYAGetHostingCreditsRequestData)requestData;
        hostingCredits = GetHostingCredits(hostingCreditsRequestData, config);

        responseData = new MYAGetHostingCreditsResponseData(hostingCredits);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new MYAGetHostingCreditsResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new MYAGetHostingCreditsResponseData(requestData, ex);
      }

      return responseData;
    }

    public List<HostingCredit> GetHostingCredits(MYAGetHostingCreditsRequestData requestData, ConfigElement config)
    {
      List<HostingCredit> hostingCredits = new List<HostingCredit>();
      string procName = "dbo.gdshop_getUnifiedResourceByTypeID_sp";

      string procXml = CreateProcInputXml(requestData.ProductTypeIds);

      using (SqlConnection cn = new SqlConnection(LookupConnectionString(requestData, config)))
      {
        using (SqlCommand cmd = new SqlCommand(procName, cn))
        {
          cmd.CommandTimeout = (int)requestData.RequestTimeout.TotalSeconds;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add(new SqlParameter("@s_shopper_id", requestData.ShopperID));
          cmd.Parameters.Add(new SqlParameter("@xmldoc", procXml));
          cn.Open();
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
              hostingCredits.Add(PopulateObjectFromDB(dr));
            }
          }
        }
      }
      return hostingCredits;
    }

    private HostingCredit PopulateObjectFromDB(IDataReader dr)
    {
      HostingCredit hostingCredit = new HostingCredit();

      hostingCredit.Id = Convert.ToInt32(dr["gdshop_product_typeId"]);
      hostingCredit.Count = Convert.ToInt32(dr["Credits"]);

      return hostingCredit;
    }

    private string CreateProcInputXml(List<int> productTypeIds)
    {
      XDocument requestDoc = new XDocument();
      XElement requestRoot = new XElement("credits");
      requestDoc.Add(requestRoot);

      foreach (int id in productTypeIds)
      {
        requestRoot.Add(new XElement("type", new XAttribute("id", id)));
      }
      return requestDoc.ToString();
    }

    #region Nimitz
    private string LookupConnectionString(MYAGetHostingCreditsRequestData requestData, ConfigElement config)
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
