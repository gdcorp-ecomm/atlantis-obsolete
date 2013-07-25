using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SiteAdminRoles.Interface;
using Atlantis.Framework.Nimitz;
using System.Data.SqlClient;
using System.Data;

namespace Atlantis.Framework.SiteAdminRoles.Impl
{
  public class SiteAdminRolesRequest : IRequest
  {
    private const string _PROCNAME = "siteAdmin_getActiveDirectoryEntityByRoleID_sp";
    #region IRequest Members          

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      SiteAdminRolesResponseData result;
      
      try
      {
        SiteAdminRolesRequestData rolesRequestData = (SiteAdminRolesRequestData)oRequestData;
        HashSet<string> activeDirectoryEntities = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

        string connectionString = NetConnect.LookupConnectInfo(oConfig);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = (int)rolesRequestData.RequestTimeout.TotalSeconds;
            command.Parameters.Add(new SqlParameter("@siteAdmin_roleID", rolesRequestData.RoleId));
            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.Default))
            {
              while (reader.Read())
              {
                if (reader["activeDirectoryEntity"] != DBNull.Value)
                {
                  string activeDirectoryEntity = reader["activeDirectoryEntity"].ToString();
                  activeDirectoryEntities.Add(activeDirectoryEntity);
                }
              }
            }
          }
        }

        result = new SiteAdminRolesResponseData(rolesRequestData.RoleId, activeDirectoryEntities);
      }
      catch (Exception ex)
      {
        result = new SiteAdminRolesResponseData(oRequestData, ex);
      }

      return result;
    }

    #endregion
  }
}
