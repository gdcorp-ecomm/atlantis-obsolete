using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.CMSCreditAccounts.Interface;

namespace Atlantis.Framework.CMSCreditAccounts.Impl
{
  public class CMSCreditAccountsRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      IResponseData result = null;
      string responseText = string.Empty;

      try
      {
        CMSCreditAccountsRequestData cmsRequest = (CMSCreditAccountsRequestData)requestData;
        ActivationService.ActivationWizardSupport service = new ActivationService.ActivationWizardSupport();
        service.Url = ((WsConfigElement)config).WSURL;
        service.Timeout = (int)cmsRequest.RequestTimeout.TotalMilliseconds;
        responseText = service.DomainLists(cmsRequest.ToXML());
        result = new CMSCreditAccountsResponseData(responseText);
      }
      catch (AtlantisException aex)
      {
        result = new CMSCreditAccountsResponseData(aex);
      }
      catch (Exception ex)
      {
        result = new CMSCreditAccountsResponseData(requestData, ex);
      }

      return result;
    }
  }
}
