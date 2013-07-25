using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCDeleteDNS.Interface
{
  public class DCCDeleteDNSRequestData: RequestData
  {
    string _domainName;
    int _privateLabelID;
    bool _isManagerOrigin;

    List<DnsRecordType> _records;

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(20);

    public DCCDeleteDNSRequestData( string shopperId,
                                    string sourceUrl,
                                    string orderId,
                                    string pathway,
                                    int pageCount,
                                    int privateLabelID,
                                    bool isManagerOrigin,
                                    string domainName)
            : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _records = new List<DnsRecordType>();
      _domainName = domainName;
      _privateLabelID = privateLabelID;
      _isManagerOrigin = isManagerOrigin;
    }

    public void addRecord( DnsRecordType record )
    {
      _records.Add(record);
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public String DomainName
    {
      get { return _domainName; }
    }

    public int PrivateLabelID
    {
      get { return _privateLabelID; }
    }

    public string Origin
    {
      get 
      {
        string sRetVal = "Customer";
        if (_isManagerOrigin)
          sRetVal = "Manager";
        return sRetVal; 
      }
    }

    public List<DnsRecordType> Records
    {
      get { return _records; }
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      throw new Exception("DCCCreateDNS is not a cacheable request.");
    }

    #endregion
  }
}
