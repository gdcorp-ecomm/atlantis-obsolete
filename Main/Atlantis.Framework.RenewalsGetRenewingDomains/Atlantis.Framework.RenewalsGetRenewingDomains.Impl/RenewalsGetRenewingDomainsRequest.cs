using System;
using System.Data;
using System.Data.SqlClient;

using netConnect;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RenewalsGetRenewingDomains.Interface;

namespace Atlantis.Framework.RenewalsGetRenewingDomains.Impl
{
  public class RenewalsGetRenewingDomainsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      DataSet ds = null;

      try
      {
        RenewalsGetRenewingDomainsRequestData request = (RenewalsGetRenewingDomainsRequestData)oRequestData;

        string connectionString = LookupConnectionString(request, oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            command.Parameters.Add(new SqlParameter(_DAYSTOEXPPARAM, request.DaysToExpiration));
            command.Parameters.Add(new SqlParameter(_DOMAINSTORETPARAM, request.DomainsToReturn));
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;

            connection.Open();
            ds = new DataSet(Guid.NewGuid().ToString());
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(ds);
          }
        }

        oResponseData = new RenewalsGetRenewingDomainsResponseData(ds);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new RenewalsGetRenewingDomainsResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new RenewalsGetRenewingDomainsResponseData(ds, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    #region Private Methods

    private const string _PROCNAME = "gdshop_getExpiringDomainDetail_sp";
    private const string _SHOPPERIDPARAM = "shopper_ID";
    private const string _DAYSTOEXPPARAM = "daysToExpiration";
    private const string _DOMAINSTORETPARAM = "domainsToReturn";

    private string LookupConnectionString(RenewalsGetRenewingDomainsRequestData request, ConfigElement config)
    {
      Info oNetConnect = new Info();
      string dataSource = config.GetConfigValue("DataSourceName");
      string applicationName = config.GetConfigValue("ApplicationName");
      string certificateName = config.GetConfigValue("CertificateName");

      string result = string.Empty;
      if (!string.IsNullOrEmpty(dataSource) && !string.IsNullOrEmpty(applicationName) && !string.IsNullOrEmpty(certificateName))
      {
        result = oNetConnect.Get(dataSource, applicationName, certificateName, ConnectTypeEnum.CONNECT_TYPE_NET);
      }

      //when an error occurs a ';' is returned not a valid connection string or empty
      if (result.Length <= 1)
      {
        throw new AtlantisException(request, "LookupConnectionString",
                "Database connection string lookup failed", "No ConnectionFound For:"
                + dataSource + ":"
                + applicationName
                + ":" + certificateName);
      }

      return result;
    }

    #endregion
  }
}
