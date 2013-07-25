using System;
using System.Security.Cryptography.X509Certificates;
using Atlantis.Framework.AuthRetrieve.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuthRetrieve.Impl
{
  public class AuthRetrieveRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData requestData, ConfigElement config)
    {
      AuthRetrieveResponseData responseData;

      try
      {
        var authData = (AuthRetrieveRequestData)requestData;
        string responseXml;
        string errorXml;
        using (var svc = new RetrieveAuthSvc.RetrieveAuth())
        {
          svc.Url = ((WsConfigElement)config).WSURL;
          svc.Timeout = (int)authData.RequestTimeout.TotalMilliseconds;
          
          var cert = GetClientCertificate(StoreLocation.LocalMachine, StoreName.My, X509FindType.FindBySubjectName, config.GetConfigValue("CertificateName"));
          cert.Verify();

          svc.ClientCertificates.Add(cert);
          responseXml = svc.GetAuthData(authData.SPKey, authData.Artifact, out  errorXml);
        }

        if (!string.IsNullOrEmpty(errorXml))
        {
          var exAtlantis = new AtlantisException(requestData
            , "AuthRetrieveRequest.RequestHandler"
            , errorXml
            , requestData.ToXML());

          responseData = new AuthRetrieveResponseData(requestData, exAtlantis);
        }
        else
        {
          responseData = new AuthRetrieveResponseData(responseXml);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new AuthRetrieveResponseData(requestData, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new AuthRetrieveResponseData(requestData, ex);
      }

      return responseData;
    }

    #region Get Certificate
    public static X509Certificate2 GetClientCertificate(StoreLocation location, StoreName name, X509FindType findType, string findValue)
    {
      var store = new X509Store(name, location);

      try
      {
        // create and open store for read-only access
        store.Open(OpenFlags.ReadOnly);

        // search store
        var col = store.Certificates.Find(findType, findValue, true);

        // return first certificate found
        return col[0];
      }
      // always close the store
      finally
      {
        store.Close();
      }
    }
    #endregion
  }
}