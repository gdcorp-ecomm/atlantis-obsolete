using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.UserAddNebula.Interface;
using Atlantis.Framework.UserAddNebula.Impl.StorageWS;

namespace Atlantis.Framework.UserAddNebula.Impl
{
  public class UserAddNebulaRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;

      GoDaddy_Storage_Service_User_Management_v_0_1 service = null;

      try
      {
        UserAddNebulaRequestData request = (UserAddNebulaRequestData)oRequestData;
        service = new GoDaddy_Storage_Service_User_Management_v_0_1();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;

        UserAdd userAdd = new UserAdd();
        userAdd.ServiceManagerAccessKeyId = request.ManagerAccessKey;
        userAdd.ServiceManagerSignature = request.SecretKey;
        userAdd.UserUniqueId = request.UserUniqueId;
        userAdd.Quota = request.Quota;
        UserAddResponse userResponse;
        userResponse = service.UserAdd(userAdd);
        result = new UserAddNebulaResponseData(userResponse.UserAccessKeyId, userResponse.SecretKey, userResponse.Code); 
      }
      catch (AtlantisException exAtlantis)
      {
        result = new UserAddNebulaResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        result = new UserAddNebulaResponseData(oRequestData, ex);
      }

      return result;
    }

  }
}
