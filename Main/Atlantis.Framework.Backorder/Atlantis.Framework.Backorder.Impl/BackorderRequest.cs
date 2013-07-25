using System;
using System.Collections.Generic;
using System.Text;

using Atlantis.Framework.Interface;
using Atlantis.Framework.Backorder.Interface;

namespace Atlantis.Framework.Backorder.Impl
{
  public class BackorderRequest : IRequest
  {
    /******************************************************************************/

    #region IRequest Members

    /******************************************************************************/

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      string sResponseXML = "";

      try
      {
        BackorderRequestData oBackOrderRequestData = (BackorderRequestData)oRequestData;
        
        RegChkIsBackorder.RegChkIsBackorderService oRequest
          = new Atlantis.Framework.Backorder.Impl.RegChkIsBackorder.RegChkIsBackorderService();
        oRequest.Url = ((WsConfigElement)oConfig).WSURL;

        sResponseXML = oRequest.IsMultipleDomainBackorderAllowed(oBackOrderRequestData.ToXML());

        if (sResponseXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "BackorderRequest.RequestHandler",
                                                               sResponseXML,
                                                               oRequestData.ToXML());

          oResponseData = new BackorderResponseData(sResponseXML, exAtlantis);
        }
        else
          oResponseData = new BackorderResponseData(sResponseXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new BackorderResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new BackorderResponseData(sResponseXML, oRequestData, ex);
      }

      return oResponseData;
    }

    /******************************************************************************/

    #endregion

    /******************************************************************************/
  }
}
