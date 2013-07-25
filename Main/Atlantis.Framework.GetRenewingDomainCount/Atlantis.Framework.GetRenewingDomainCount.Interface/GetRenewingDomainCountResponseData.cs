using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using System.IO;

namespace Atlantis.Framework.GetRenewingDomainCount.Interface
{
  public class GetRenewingDomainCountResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;

    #region Properties

    private bool _success = false;
    private int _expiringDomains;
    private int _expiredDomains;

    public bool IsSuccess 
    {
      get {return _success; } 
    }

    public int ExpiringDomains 
    {
      get { return _expiringDomains; } 
    }

    public int ExpiredDomains
    {
      get { return _expiredDomains; }
    }

    #endregion
    
    public GetRenewingDomainCountResponseData(int expiringDomains, int expiredDomains )
    {      
      _expiringDomains = expiringDomains;
      _expiredDomains = expiredDomains;
      _success = true;
    }

    public GetRenewingDomainCountResponseData(string xml)
    {
       if (!string.IsNullOrEmpty(xml))
       {
          using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
          {
             if (reader.Read())
             {
                reader.ReadStartElement("Domains");
                reader.ReadStartElement("ExpiringDomainsCount");
                if (int.TryParse(reader.Value, out _expiringDomains))
                {
                   reader.ReadToFollowing("ExpiredDomains");
                   reader.ReadStartElement("ExpiredDomains");
                   if (int.TryParse(reader.Value, out _expiredDomains))
                   {
                      _success = true;
                   }
                }
             }
          }
       }
    }

    public GetRenewingDomainCountResponseData(RequestData requestData, TimeoutException timeoutException)
    {
      this._exception = new AtlantisException(requestData,
                                   "GetRenewingDomainCountResponseData",
                                   timeoutException.Message,
                                   requestData.ToXML());
    }

    public GetRenewingDomainCountResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public GetRenewingDomainCountResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "GetRenewingDomainCountResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      return string.Format("<Domains><ExpiringDomainsCount>{0}</ExpiringDomainsCount><ExpiredDomains>{1}</ExpiredDomains></Domains>", _expiringDomains, _expiredDomains );
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
