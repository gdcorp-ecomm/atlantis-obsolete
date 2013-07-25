using System;
using System.Collections.Generic;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.KiwiLogger.Interface;

namespace Atlantis.Framework.EcommPaymentProfile.Interface
{
  public class EcommPaymentProfileResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _responseXml;
    private RequestData _request;
    private PaymentProfile _profile = new PaymentProfile();
    bool _isSuccess = false;
    
    public EcommPaymentProfileResponseData(RequestData request, string responseXml)
    {
      _request = request;
      _responseXml = responseXml;
      PopulateProfile();
      _isSuccess = true;
    }

    public EcommPaymentProfileResponseData(string responseXml, AtlantisException exAtlantis)
    {
      _responseXml = responseXml;
      _exception = exAtlantis;
    }

    public EcommPaymentProfileResponseData(string responseXml, RequestData oRequestData, Exception ex)
    {
      _responseXml = responseXml;
      _exception = new AtlantisException(oRequestData, oRequestData.GetType().ToString(), ex.Message, ex.StackTrace, ex);
    }

    #region Access Payment Profile

    /// <summary>
    /// This function only accesses by index because you're using a triplet that provides a list of profiles.  If you need a specific profile, call EcommPaymentProfile
    /// </summary>
    /// <param name="shopperId"></param>
    /// <param name="managerUserId"></param>
    /// <param name="managerName"></param>
    /// <param name="sourceFunction"></param>
    /// <returns></returns>
    public PaymentProfile AccessProfile(string shopperId, string managerUserId, string managerName, string sourceFunction)
    {
      PaymentProfile profile = null;
      string user = string.IsNullOrEmpty(managerUserId) ? shopperId : string.Format("{0}-{1}", managerUserId, managerName);

      try
      {
        profile = _profile;

        KiwiLoggerRequestData kiwiRequest = new KiwiLoggerRequestData(shopperId
          , _request.SourceURL
          , _request.OrderID
          , _request.Pathway
          , _request.PageCount);

        List<KiwiLoggerParameters> logParameters = new List<KiwiLoggerParameters>();
        logParameters.Add(new KiwiLoggerParameters("profile", profile.ProfileID));
        logParameters.Add(new KiwiLoggerParameters("user", user));
        logParameters.Add(new KiwiLoggerParameters("origin", string.Format("{0}/{1}", Environment.MachineName, sourceFunction)));

        kiwiRequest.MessagePrefix = "ACCESS(masked) success";
        kiwiRequest.MessageSuffix = string.Empty;
        kiwiRequest.AddItems(logParameters);

        KiwiLoggerResponseData kiwiResponse = (KiwiLoggerResponseData)Engine.Engine.ProcessRequest(kiwiRequest, EngineRequests.KiwiLogger);
      }
      catch (Exception ex)
      {
        _exception = new AtlantisException(_request
          , "EcommPaymentProfileResponseData::AccessProfile"
          , ex.Message
          , _request.ToXML());
      }

      return profile;
    }
    #endregion

    private void PopulateProfile()
    {
      XmlDocument oDoc = new XmlDocument();
      oDoc.LoadXml(_responseXml);

      XmlNodeList dataNodes = oDoc.SelectNodes("./profiles/profile");
      foreach (XmlNode dataNode in dataNodes)
      {
        XmlElement dataElement = dataNode as XmlElement;
        if (dataElement != null)
        {
          PaymentProfile profile = new PaymentProfile();
          foreach (XmlAttribute currentAtt in dataElement.Attributes)
          {
            profile[currentAtt.Name] = currentAtt.Value;
          }
          _profile = profile;
        }
      }
    }

    public bool IsSuccess
    {
      get
      {
        return _isSuccess;
      }
    }

    #region IResponseData Members

    public string ToXML()
    {
      return _responseXml;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
