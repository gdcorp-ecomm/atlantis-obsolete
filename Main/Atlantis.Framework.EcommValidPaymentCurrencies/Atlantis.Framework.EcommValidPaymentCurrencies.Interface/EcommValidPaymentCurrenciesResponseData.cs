using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommValidPaymentCurrencies.Interface
{
  public class EcommValidPaymentCurrenciesResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    private HashSet<string> _validPaymentCurrencies = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);

    public string ResultXml { get; private set; }

    private readonly bool _isSuccess;
    public bool IsSuccess
    {
      get { return _isSuccess && _atlantisException == null; }
    }

    public EcommValidPaymentCurrenciesResponseData(RequestData requestData, string responseXml, int resultCode)
    {
      ResultXml = responseXml;
      _isSuccess = ParseResponseXml(responseXml);
      if(!_isSuccess)
      {
        _atlantisException = new AtlantisException(requestData,
                                                   MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                   string.Format("Unable to parse response Xml. Result code: {0}", resultCode),
                                                   string.Empty);
      }
    }

    public EcommValidPaymentCurrenciesResponseData(RequestData requestData, Exception ex)
    {
      _isSuccess = false;
      _atlantisException = new AtlantisException(requestData,
                                                 MethodBase.GetCurrentMethod().DeclaringType.FullName,
                                                 ex.Message + " | " + ex.StackTrace,
                                                 string.Empty);
    }

    
    // <ActivePaymentCurrencies><Currency type="EUR"/><Currency type="GBP"/><Currency type="USD"/></ActivePaymentCurrencies>
    private bool ParseResponseXml(string responseXml)
    {
      XmlDocument activePaymentTypesXml = new XmlDocument();
      activePaymentTypesXml.LoadXml(responseXml);

      XmlNodeList activePaymentCurrencies = activePaymentTypesXml.SelectNodes("//ActivePaymentCurrencies/Currency");

      if (activePaymentCurrencies != null)
      {
        foreach (XmlElement currencyType in activePaymentCurrencies)
        {
          string type = currencyType.GetAttribute("type");
          _validPaymentCurrencies.Add(type);
        }
      }

      return _validPaymentCurrencies.Count > 0;
    }

    public bool IsValidPaymentCurrency(string currencyType)
    {
      bool result = false;
      if (!string.IsNullOrEmpty(currencyType))
      {
        result = _validPaymentCurrencies.Contains(currencyType);
      }
      return result;
    }

    public string ToXML()
    {
      return ResultXml;
    }

    public AtlantisException GetException()
    {
      return _atlantisException;
    }
  }
}
