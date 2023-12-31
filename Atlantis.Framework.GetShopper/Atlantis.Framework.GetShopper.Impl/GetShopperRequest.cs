using System;
using System.Threading.Tasks;
using Atlantis.Framework.GetShopper.Interface;
using Atlantis.Framework.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Atlantis.Framework.GetShopper.Impl
{
  public class GetShopperRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetShopperResponseData oResponseData = null;
      string sResultXML = string.Empty;

      try
      {
        GetShopperRequestData oShopperData = (GetShopperRequestData)oRequestData;

        using (WSCgdShopper.WSCgdShopperService oShopperWS = new WSCgdShopper.WSCgdShopperService())
        {
          oShopperWS.Url = ((WsConfigElement)oConfig).WSURL;
          oShopperWS.Timeout = (int)oShopperData.RequestTimeout.TotalMilliseconds;
          
          X509Certificate2 clientCert = null;
          clientCert = ((WsConfigElement)oConfig).GetClientCertificate();
          if (clientCert != null) 
          {
              oShopperWS.ClientCertificates.Add(clientCert);
          }
          
          string sRequestXML = oShopperData.ToXML();
          sResultXML = oShopperWS.GetShopper(sRequestXML);
        }

        if (sResultXML.IndexOf("<error>", StringComparison.OrdinalIgnoreCase) > -1)
        {
          AtlantisException exAtlantis = new AtlantisException((RequestData)oRequestData,
                                                               "GetShopperRequest.RequestHandler",
                                                               sResultXML,
                                                               oRequestData.ToXML());

          oResponseData = new GetShopperResponseData(sResultXML, exAtlantis);
        }
        else
          oResponseData = new GetShopperResponseData(sResultXML);
      }
      catch (Exception ex)
      {
        oResponseData = new GetShopperResponseData(sResultXML, (GetShopperRequestData)oRequestData, ex);
      }
 
      return oResponseData;
    }

    #endregion

  }
}
