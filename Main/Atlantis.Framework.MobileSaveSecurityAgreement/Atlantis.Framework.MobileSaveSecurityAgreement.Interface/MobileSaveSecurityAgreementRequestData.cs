using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MobileSaveSecurityAgreement.Interface
{
  public enum MobileSaveSecurityAgreementType
  {
    Username = 1,
    UsernameAndPassword = 2,
  }

  public enum MobileApplicationType
  {
    GDShopper = 1,
    Email = 2,
    UserPass = 3,
  }

  public enum AppId
  {
    Iphone = 1,
    Blackberry = 2,
    Android = 3,
    Ipad = 4,
  }

  public class MobileSaveSecurityAgreementRequestData : RequestData
  {
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }


    public AppId AppId { get; set; }
    public string DeviceId { get; set; }
    public MobileApplicationType MobileAppType { get; set; }
    public MobileSaveSecurityAgreementType AgreementType { get; set; }

    public MobileSaveSecurityAgreementRequestData(string shopperID,
                                           string sourceUrl,
                                           string orderID,
                                           string pathway,
                                           int pageCount,
                                           AppId appId,
                                           string deviceId,
                                           MobileSaveSecurityAgreementType agreementType,
                                           MobileApplicationType mobileAppType)
      : base(shopperID, sourceUrl, orderID, pathway, pageCount)
    {
      AgreementType = agreementType;
      AppId = appId;
      MobileAppType = mobileAppType;
      DeviceId = deviceId;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("MobileSaveSecurityAgreementRequestData is not a cacheable request");
    }
  }
}
