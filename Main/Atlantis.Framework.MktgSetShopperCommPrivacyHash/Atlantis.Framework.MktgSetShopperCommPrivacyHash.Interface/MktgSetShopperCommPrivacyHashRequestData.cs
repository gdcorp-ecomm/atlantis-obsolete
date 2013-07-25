using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MktgSetShopperCommPrivacyHash.Interface
{
  public class MktgSetShopperCommPrivacyHashRequestData : RequestData
  {
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    public string DataSourceName { get; set; }
    public string CertificateName { get; set; }
    public string ApplicationName { get; set; }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public int CommunicationTypeID { get; set; }
    public string PrivacyHash { get; set; }

    public MktgSetShopperCommPrivacyHashRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount,
      int communicationTypeID,
      string privacyHash)
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      CommunicationTypeID = communicationTypeID;
      PrivacyHash = privacyHash;
    }


    public override string GetCacheMD5()
    {
      throw new NotImplementedException("MktgSetShopperCommPrivacyHashRequestData is not a cacheable request.");

    }
  }
}
