﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetOffersWithPlId.Interface;

namespace Atlantis.Framework.GetOffersWithPlId.Impl
{
  public class GetOffersWithPlIdRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      GetOffersWithPlIdResponseData responseData = null;

      try
      {
        GetOffersWithPlIdRequestData getOffersRequestData = (GetOffersWithPlIdRequestData)requestData;

        SmartOffersService.SmartOffers ws = new Atlantis.Framework.GetOffersWithPlId.Impl.SmartOffersService.SmartOffers();

        ws.Url = (((WsConfigElement)config).WSURL);
        ws.Timeout = (int)getOffersRequestData.RequestTimeout.TotalMilliseconds;

        XmlNode responseNode = ws.GetOffersWithPlid(getOffersRequestData.ShopperID, getOffersRequestData.ApplicationId, getOffersRequestData.PrivateLabelId);


        responseData = new GetOffersWithPlIdResponseData(responseNode);
      }

      catch (TimeoutException exTimeout)
      {
        responseData = new GetOffersWithPlIdResponseData(requestData, exTimeout);
      }

      catch (AtlantisException exAtlantis)
      {
        responseData = new GetOffersWithPlIdResponseData(exAtlantis);
      }

      catch (Exception ex)
      {
        responseData = new GetOffersWithPlIdResponseData(requestData, ex);
      }
       
      return responseData;
    }
  }
}
