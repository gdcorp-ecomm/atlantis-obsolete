using System;
using System.Security.Cryptography.X509Certificates;
using Atlantis.Framework.GetNetGiroMerchantData.Interface;
using Atlantis.Framework.Interface;
using System.Net;
using System.Security.Principal;

namespace Atlantis.Framework.GetNetGiroMerchantData.Impl
{
  public class GetNetGiroMerchantDataRequest:IRequest
  {
    #region IRequest Members

    private X509Certificate2 GetNimitzCertificate(GetNetGiroMerchantRequestData getNetGiroRequest)
    {
      X509Store ostore = new X509Store(StoreName.My, StoreLocation.LocalMachine);
      X509Certificate2 nimitzCert = null;
      try
      {
        ostore.Open(OpenFlags.ReadOnly);
        X509Certificate2Collection results = ostore.Certificates.Find(X509FindType.FindBySubjectName, getNetGiroRequest.CertificateName, false);
        if (results.Count > 0)
        {
          nimitzCert = results[0];
        }
      }
      finally
      {
        ostore.Close();
      }
      return nimitzCert;
    }


    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetNetGiroMerchantRequestData getNetGiroRequest = (GetNetGiroMerchantRequestData)oRequestData;
      GetNetGiroMerchantResponseData oResponseData = null;

      try
      {
        X509Certificate nimitZCert = GetNimitzCertificate(getNetGiroRequest);
        if (nimitZCert != null)
        {
          
          WsEcommrestricted.Service1 wsEcomm = new WsEcommrestricted.Service1();
          wsEcomm.Url = ((WsConfigElement)oConfig).WSURL;
          wsEcomm.Timeout = (int)getNetGiroRequest.RequestTimeout.TotalMilliseconds;
          wsEcomm.ClientCertificates.Add(nimitZCert);
          string sResponseXML = wsEcomm.GetNetGiroMerchantData(getNetGiroRequest.PaymentType, getNetGiroRequest.CompanyID, getNetGiroRequest.CurrencyCode, getNetGiroRequest.BillingCountry);

          if (sResponseXML.IndexOf("Error", StringComparison.OrdinalIgnoreCase) != -1)
          {
            AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                                 "GetNetGiroMerchantData.RequestHandler",
                                                                 sResponseXML,
                                                                 string.Empty);
            oResponseData = new GetNetGiroMerchantResponseData(oRequestData, exAtlantis);
          }
          else
          {
            oResponseData = new GetNetGiroMerchantResponseData(sResponseXML);
          }
        }
        else
        {
          AtlantisException exAtlantis = new AtlantisException(oRequestData,
                                                               "GetNetGiroMerchantData.RequestHandler",
                                                               "Could Not Find Nimitz Cert",
                                                               getNetGiroRequest.CertificateName);
          oResponseData = new GetNetGiroMerchantResponseData(oRequestData, exAtlantis);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetNetGiroMerchantResponseData(oRequestData, exAtlantis);
      }

      return oResponseData;
    }

    #endregion

  }
}
