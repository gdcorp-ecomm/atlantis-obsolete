using System;
using System.Text;
using System.Xml;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainContactCheck.Interface;

namespace Atlantis.Framework.DomainContactCheck.Impl
{
  public class DomainContactCheckRequest : IRequest
  {
    #region IRequest Members

    /******************************************************************************/

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        DomainContactCheckRequestData oDomainContactCheckRequestData = (DomainContactCheckRequestData)oRequestData;

        ContactValidationService.ContactValidationService oContactValidationService = new ContactValidationService.ContactValidationService();
        WsConfigElement oWsConfigElement = (WsConfigElement)oConfig;
        oContactValidationService.Url = oWsConfigElement.WSURL;
        string sRequestXML = oRequestData.ToXML();

        sResponseXML = oContactValidationService.Validate(sRequestXML);
        if (sResponseXML != null && sResponseXML.Length > 0 )
        {
          oResponseData = new DomainContactCheckResponseData(sResponseXML);
        }
        if (oResponseData == null) // Bad request yields a null string
        {
          throw new AtlantisException((RequestData)oRequestData,
                                      "DomainContactCheckRequest.RequestHandler",
                                      "Invalid request, (null) string returned",
                                      string.Empty);
        }

      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new DomainContactCheckResponseData( exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new DomainContactCheckResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
    /******************************************************************************/

  }
}
