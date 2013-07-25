using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.NebulaUserAdd.Interface;
using Atlantis.Framework.NebulaUserAdd.Impl.StorageWS;

namespace Atlantis.Framework.NebulaUserAdd.Impl
{
  public class NebulaUserAddRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;

      GoDaddy_Storage_Service_User_Management_v_0_1 service = null;

      try
      {
        NebulaUserAddRequestData request = (NebulaUserAddRequestData)oRequestData;
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
        result = new NebulaUserAddResponseData(userResponse.UserAccessKeyId, userResponse.SecretKey, userResponse.Code);
      }
      catch (AtlantisException exAtlantis)
      {
        result = new NebulaUserAddResponseData(exAtlantis);
      }
      catch (Exception ex)
      {
        result = new NebulaUserAddResponseData(oRequestData, ex);
      }

      return result;
    }

  }
}
