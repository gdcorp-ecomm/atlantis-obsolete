﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.ManagerUser.Interface;
using Atlantis.Framework.ManagerUser.Impl.ManagerLookupWS;

namespace Atlantis.Framework.ManagerUser.Impl
{
  public class ManagerUserLookupRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      ManagerUserLookupResponseData oResponseData = null;
      string responseXml = string.Empty;

      try
      {
        ManagerUserLookupRequestData request = (ManagerUserLookupRequestData)oRequestData;
        LookupService lookupService = new LookupService();
        lookupService.Url = ((WsConfigElement)oConfig).WSURL;
        responseXml = lookupService.GetUserMappingXml(request.Domain, request.UserId);
        oResponseData = new ManagerUserLookupResponseData(responseXml);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new ManagerUserLookupResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new ManagerUserLookupResponseData(responseXml, (ManagerUserLookupRequestData)oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
