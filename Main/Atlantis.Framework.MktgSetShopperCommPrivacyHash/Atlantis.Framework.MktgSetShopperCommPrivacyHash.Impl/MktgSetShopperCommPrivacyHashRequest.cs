using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MktgSetShopperCommPrivacyHash.Interface;
using System.Data.SqlClient;
using System.Data;
using Atlantis.Framework.Nimitz;

namespace Atlantis.Framework.MktgSetShopperCommPrivacyHash.Impl
{
  public class MktgSetShopperCommPrivacyHashRequest : IRequest
  {
    private const string _PROCNAME = "gdshop_shopper_mtm_gdshop_shopperCommunicationTypeAddUpdate_sp";
    private const string _SHOPPERIDPARAM = "shopper_id";
    private const string _COMMUNICATIONTYPEID = "gdshop_shopperCommunicationTypeID";
    private const string _PRIVACYHASH = "privacyHash";


    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      IResponseData oResponseData = null;
      MktgSetShopperCommPrivacyHashRequestData request = null;
      try
      {
        request = (MktgSetShopperCommPrivacyHashRequestData)requestData;
         string connectionString=string.Empty;
        if (string.IsNullOrEmpty(config.GetConfigValue("CertificateName")))
        {
           connectionString = Nimitz.NetConnect.LookupConnectInfo(request.DataSourceName,request.CertificateName,request.ApplicationName,config.ProgID,ConnectLookupType.NetConnectionString);
        }
        else
        {
         connectionString = Nimitz.NetConnect.LookupConnectInfo(config);
        }
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
          using (SqlCommand command = new SqlCommand(_PROCNAME, connection))
          {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter(_SHOPPERIDPARAM, request.ShopperID));
            command.Parameters.Add(new SqlParameter(_COMMUNICATIONTYPEID, request.CommunicationTypeID));
            command.Parameters.Add(new SqlParameter(_PRIVACYHASH, request.PrivacyHash));
            command.CommandTimeout = (int)request.RequestTimeout.TotalSeconds;
            connection.Open();
            command.ExecuteNonQuery();
          }
        }
        oResponseData = new MktgSetShopperCommPrivacyHashResponseData();
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new MktgSetShopperCommPrivacyHashResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new MktgSetShopperCommPrivacyHashResponseData(request, ex);
      }

      return oResponseData;
    }
  }
}
