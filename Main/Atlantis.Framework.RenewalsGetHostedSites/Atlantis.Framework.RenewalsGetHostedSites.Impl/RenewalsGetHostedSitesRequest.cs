using System;
using System.Data;
using System.Data.SqlClient;

using netConnect;

using Atlantis.Framework.Interface;
using Atlantis.Framework.RenewalsGetHostedSites.Interface;

namespace Atlantis.Framework.RenewalsGetHostedSites.Impl
{
  public class RenewalsGetHostedSitesRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      DataSet ds = null;

      try
      {
        RenewalsGetHostedSitesRequestData request = (RenewalsGetHostedSitesRequestData)oRequestData;

        string connectionString = LookupConnectionString(request, oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_SHOPPERID, request.ShopperID));
            command.Parameters.Add(new SqlParameter(_PAGENO, request.PageNumber));
            command.Parameters.Add(new SqlParameter(_ROWSPERPAGE, request.RowsPerPage));
            command.Parameters.Add(new SqlParameter(_SORTCOL, request.SortColumn));
            command.Parameters.Add(new SqlParameter(_SORTDIR, request.SortDirection));
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;

            connection.Open();
            ds = new DataSet(Guid.NewGuid().ToString());
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(ds);
          }
        }

        oResponseData = new RenewalsGetHostedSitesResponseData(ds);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new RenewalsGetHostedSitesResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new RenewalsGetHostedSitesResponseData(ds, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    #region Private Methods

    private const string _PROCNAME = "MyRenewalsGetHostedSites_sp";
    private const string _SHOPPERID = "s_shopper_id";
    private const string _PAGENO = "pageno";
    private const string _ROWSPERPAGE = "rowsperpage";
    private const string _SORTCOL = "sortcol";
    private const string _SORTDIR = "sortdir";

    private string LookupConnectionString(RenewalsGetHostedSitesRequestData request, ConfigElement config)
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
