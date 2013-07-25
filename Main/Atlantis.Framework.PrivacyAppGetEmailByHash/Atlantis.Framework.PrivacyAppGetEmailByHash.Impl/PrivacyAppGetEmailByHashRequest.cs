using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.PrivacyAppGetEmailByHash.Interface;
using Atlantis.Framework.PrivacyAppGetEmailByHash.Impl.privacyWS;
using System.Security.Cryptography.X509Certificates;

namespace Atlantis.Framework.PrivacyAppGetEmailByHash.Impl
{
  public class PrivacyAppGetEmailByHashRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData result = null;

      string responseXml = string.Empty;
      string emailAddress = string.Empty;
      wscgdPrivacyAppService service = null;

      try
      {
        PrivacyAppGetEmailByHashRequestData request = (PrivacyAppGetEmailByHashRequestData)oRequestData;

        service = new wscgdPrivacyAppService();
        service.Url = ((WsConfigElement)oConfig).WSURL;
        AddClientCertificate(service, oConfig);
        service.Timeout = (int)request.RequestTimeout.TotalMilliseconds;
        emailAddress = service.GetEmailAddressByHash(request.EmailHashKey, out responseXml);

        result = new PrivacyAppGetEmailByHashResponseData(responseXml, emailAddress);

      }
      catch (AtlantisException exAtlantis)
      {
        result = new PrivacyAppGetEmailByHashResponseData(responseXml,emailAddress, exAtlantis);
      }
      catch (Exception ex)
      {
        result = new PrivacyAppGetEmailByHashResponseData(responseXml,emailAddress, oRequestData, ex);
      }
      finally
      {
        if (service != null)
        {
          service.Dispose();
        }
      }
      
      return result;
    }

    private void AddClientCertificate(wscgdPrivacyAppService service, ConfigElement oConfig)
    {
      X509Certificate cert = GetCertificate(oConfig);
      if (cert != null)
        service.ClientCertificates.Add(cert);
    }

    private X509Certificate GetCertificate(ConfigElement oConfig)
    {
      X509Certificate cert = null;
      string certificateName = oConfig.GetConfigValue("CertificateName");
      if (!string.IsNullOrEmpty(certificateName))
      {
        X509Store certStore = new X509Store(StoreLocation.LocalMachine);
        certStore.Open(OpenFlags.ReadOnly);
        X509CertificateCollection certs = certStore.Certificates.Find(X509FindType.FindBySubjectName, certificateName, true);
        if (certs.Count > 0)
          cert = certs[0];
      }
      return cert;
    }

    #endregion
  }
}
