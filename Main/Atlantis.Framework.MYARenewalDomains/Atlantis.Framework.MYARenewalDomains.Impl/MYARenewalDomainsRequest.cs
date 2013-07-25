using System;
using System.Data;
using System.Data.SqlClient;

using netConnect;

using Atlantis.Framework.Interface;
using Atlantis.Framework.MYARenewalDomains.Interface;

namespace Atlantis.Framework.MYARenewalDomains.Impl
{
  public class MYARenewalDomainsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      DataSet ds = null;

      try
      {
        MYARenewalDomainsRequestData request = (MYARenewalDomainsRequestData)oRequestData;

        string connectionString = LookupConnectionString(request, oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            command.Parameters.Add(new SqlParameter(_DAYSTOEXPPARAM, request.DaysToExpiration));
            command.Parameters.Add(new SqlParameter(_CONTAINSPARAM, request.Contains));
            command.Parameters.Add(new SqlParameter(_DOMAINSTORETPARAM, request.DomainsToReturn));
            command.Parameters.Add(new SqlParameter(_PAGENUMBERPARAM, request.PageNumber));
            command.Parameters.Add(new SqlParameter(_SORTCOLPARAM, GetSortColumnValue(request.SortColumn)));
            command.Parameters.Add(new SqlParameter(_SORTDIRPARAM, GetSortDirectionValue(request.SortDirection)));
            
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;

            connection.Open();
            ds = new DataSet(Guid.NewGuid().ToString());
            SqlDataAdapter adp = new SqlDataAdapter(command);
            adp.Fill(ds);
          }
        }

        oResponseData = new MYARenewalDomainsResponseData(ds);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new MYARenewalDomainsResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new MYARenewalDomainsResponseData(ds, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    #region Private Methods

    private const string _PROCNAME = "mya_getExpiringDomainDetail_sp";
    private const string _SHOPPERIDPARAM = "shopper_ID";
    private const string _DAYSTOEXPPARAM = "daysToExpiration";
    private const string _CONTAINSPARAM = "contains";
    private const string _DOMAINSTORETPARAM = "domainsToReturn";
    private const string _PAGENUMBERPARAM = "pageno";
    private const string _SORTCOLPARAM = "sortcol";
    private const string _SORTDIRPARAM = "sortdir";

    private const string EXPIRATION_DATE_SORT_COLUMN = "expirationDate";
    private const string DOMAIN_NAME_SORT_COLUMN = "domain";

    private string LookupConnectionString(MYARenewalDomainsRequestData request, ConfigElement config)
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

    private static string GetSortDirectionValue(MYARenewalDomainsRequestData.SortDirectionType sortDirectionType)
    {
      string sortDirection = string.Empty;

      switch (sortDirectionType)
      {
        case MYARenewalDomainsRequestData.SortDirectionType.Ascending:
          sortDirection = "ASC";
          break;
        case MYARenewalDomainsRequestData.SortDirectionType.Descending:
          sortDirection = "DESC";
          break;
      }

      return sortDirection;
    }

    private static string GetSortColumnValue(MYARenewalDomainsRequestData.SortColumnType sortColumnType)
    {
      string sortColumn = string.Empty;

      switch (sortColumnType)
      {
        case MYARenewalDomainsRequestData.SortColumnType.ExpirationDate:
          sortColumn = EXPIRATION_DATE_SORT_COLUMN;
          break;
        case MYARenewalDomainsRequestData.SortColumnType.Domain:
          sortColumn = DOMAIN_NAME_SORT_COLUMN;
          break;
      }

      return sortColumn;
    }
    #endregion
  }
}
