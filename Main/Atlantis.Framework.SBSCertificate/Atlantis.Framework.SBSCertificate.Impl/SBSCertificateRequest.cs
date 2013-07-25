using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SBSCertificate.Interface;
using System.Data.SqlClient;
using System.Data;

namespace Atlantis.Framework.SBSCertificate.Impl
{
  public class SBSCertificateRequest : IRequest
  {
    private const string _PROCNAME = "sbs_certificateRequestGet_sp";
    private const string _SHOPPERIDPARAM = "s_shopper_id";
    private const string _REQUESTTYPEPARAM = "s_requestType";
    private const string _DOMAINPARAM = "s_domain";

    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;

      try
      {
        SBSCertificateRequestData request = (SBSCertificateRequestData)oRequestData;
        DataTable resultTable = null;

        string connectionString = LookupConnectionString(request, oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            command.Parameters.Add(new SqlParameter(_DOMAINPARAM, request.Domain));
            command.Parameters.Add(new SqlParameter(_REQUESTTYPEPARAM, request.RequestType));
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;

            DataSet dataSet = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
              adapter.Fill(dataSet);
            }

            if (dataSet.Tables.Count > 0)
            {
              resultTable = dataSet.Tables[0];
            }

          }
        }

        oResponseData = new SBSCertificateResponseData(resultTable);
      }
      catch (Exception ex)
      {
        oResponseData = new SBSCertificateResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    private string LookupConnectionString(SBSCertificateRequestData request, ConfigElement oConfig)
    {
      string dsnName = oConfig.GetConfigValue("DataSourceName");
      string certName = oConfig.GetConfigValue("CertificateName");
      string appName = oConfig.GetConfigValue("ApplicationName");

      string result = string.Empty;

      DateTime startNimitz = DateTime.Now;
      netConnect.Info oNetConnect = new netConnect.Info();
      result = oNetConnect.Get(dsnName, appName, certName, netConnect.ConnectTypeEnum.CONNECT_TYPE_NET);
      DateTime endNimitz = DateTime.Now;

      if (endNimitz > startNimitz.AddSeconds(2))
      {
        TimeSpan nimitzTime = endNimitz.Subtract(startNimitz);
        string message = "Timer Exception: Nimitz Get took longer than 2 seconds.";
        string data = dsnName + ":" + appName + ":" + certName + ":" + nimitzTime.TotalSeconds.ToString();
        AtlantisException exception = new AtlantisException(request, "SBSCertificateRequest.LookupConnectionString", message, data);
        Engine.Engine.LogAtlantisException(exception);
      }

      //when an error occurs a ';' is returned not a valid connection string or empty
      if (result.Length <= 1)
      {
        string message = "Nimitz database connection string lookup failed.";
        string data = "No ConnectionFound For:" + dsnName + ":" + appName + ":" + certName;
        AtlantisException exception = new AtlantisException(request, "SBSCertificateRequest.LookupConnectionString", message, data);
        throw exception;
      }

      return result;
    }

  }
}
