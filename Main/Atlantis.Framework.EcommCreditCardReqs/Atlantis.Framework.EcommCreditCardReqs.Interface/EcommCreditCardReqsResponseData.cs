﻿using System;
using System.Collections.Generic;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommCreditCardReqs.Interface
{
  public class EcommCreditCardReqsResponseData : IResponseData
  {
    private readonly AtlantisException _exception;
    private readonly bool _isSuccess;
    private readonly string _responseXml = string.Empty;
    private Dictionary<string, string> requirementAttributes = new Dictionary<string, string>();
    private bool attributesParsed = false;
    
    public EcommCreditCardReqsResponseData(string responseXml, bool requirementsResult)
    {
      _responseXml = responseXml;
      _isSuccess = requirementsResult;
    }

    public EcommCreditCardReqsResponseData(AtlantisException exception)
    {
      _exception = exception;
    }

    public EcommCreditCardReqsResponseData(RequestData requestData, Exception ex)
    {
      _exception = new AtlantisException(requestData, "EcommCreditCardReqsResponseData", ex.Message, ex.StackTrace);
    }

    public bool IsSuccess
    {
      get { return _isSuccess; }
    }

    public Dictionary<string, string> CreditCardRequirementAttributes
    {
      get {
        if (!attributesParsed)
        {
          parseAttributes();
          attributesParsed = true;
        }
        return requirementAttributes;
      }
    }

    private void parseAttributes()
    {
      if (!String.IsNullOrEmpty(_responseXml))
      {
        XmlDocument oDoc = new XmlDocument();
        oDoc.LoadXml(_responseXml);
        XmlNodeList requirements = oDoc.SelectNodes("CardRequirements");
        if (requirements != null && requirements.Count > 0 &&
            requirements[0].Attributes != null)
        {
          foreach (XmlAttribute xmlAttribute in requirements[0].Attributes)
          {
            requirementAttributes.Add(xmlAttribute.Name, xmlAttribute.Value);
          }
        }
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
