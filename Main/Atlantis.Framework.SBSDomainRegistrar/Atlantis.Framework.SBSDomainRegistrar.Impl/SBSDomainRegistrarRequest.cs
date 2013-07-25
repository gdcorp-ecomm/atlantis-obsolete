using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SBSDomainRegistrar.Interface;

namespace Atlantis.Framework.SBSDomainRegistrar.Impl
{
  public class SBSDomainRegistrarRequest : IRequest
  {
    private const string _PROCNAME = "gdshop_domain_registration_getByDomainName_sp";
    private const string _DOMAINPARAM = "s_Domain";

    #region IRequest Members

    public IResponseData RequestHandler(RequestData requestData, ConfigElement oConfig)
    {
      IResponseData response = null;

      try
      {
        SBSDomainRegistrarRequestData request = (SBSDomainRegistrarRequestData)requestData;
        DataTable resultTable = null;
        string connectionString = LookupConnectionString(request, oConfig);

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_DOMAINPARAM, request.Domain));
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

        response = new SBSDomainRegistrarResponseData(resultTable);
      }
      catch (Exception ex)
      {
        response = new SBSDomainRegistrarResponseData(requestData, ex);
      }

      return response;
    }

    #endregion IRequest Members

    private string LookupConnectionString(SBSDomainRegistrarRequestData request, ConfigElement oConfig)
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
        AtlantisException exception = new AtlantisException(request, 
          "SBSCertificateRequest.LookupConnectionString", message, data);
        Engine.Engine.LogAtlantisException(exception);
      }

      if (result.Length <= 1)
      {
        string message = "Nimitz database connection string lookup failed.";
        string data = "No ConnectionFound For:" + dsnName + ":" + appName + ":" + certName;
        AtlantisException exception = new AtlantisException(request, 
          "SBSCertificateRequest.LookupConnectionString", message, data);
        throw exception;
      }

      return result;
    }
  }
}
