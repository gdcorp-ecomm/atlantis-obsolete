using System;
using System.Collections.Generic;
using Atlantis.Framework.CreateIncidentInIRIS.Interface;
using Atlantis.Framework.CreateIncidentInIRIS.Impl.IrisWS;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CreateIncidentInIRIS.Impl
{
  public class CreateIncidentInIRISRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      CreateIncidentInIRISResponseData oResponseData = null;

      try
      {
        CreateIncidentInIRISRequestData request = (CreateIncidentInIRISRequestData)oRequestData;
        IrisWS.IrisWebService service = new IrisWebService();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        long irisResult = service.CreateIncidentInIRIS(request.SubscriberId,
                                                       request.Subject,
                                                       request.Note,
                                                       request.CustomerEmailAddress,
                                                       request.OriginalIPAddress,
                                                       request.GroupId,
                                                       request.ServiceId,
                                                       request.PrivateLabelId,
                                                       request.ShopperId,
                                                       request.CreatedBy);


        oResponseData = new CreateIncidentInIRISResponseData(irisResult);

      }
      catch (Exception ex)
      {
        oResponseData = new CreateIncidentInIRISResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
    
  }
}
