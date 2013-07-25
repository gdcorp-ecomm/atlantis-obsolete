using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetNetGiroMerchantData.Interface
{
  public class GetNetGiroMerchantRequestData:RequestData
  {
    private string _paymentType = string.Empty;
    private long _companyID = 0;
    private string _currencyCode = string.Empty;
    private string _billingCountry = string.Empty;
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(2);
    private string _certSubjectDistinguishedName = string.Empty;

    public GetNetGiroMerchantRequestData(string sShopperID,
								  string sSourceURL,
								  string sOrderID,
								  string sPathway,
								  int iPageCount,
                  string paymentType,
                  long companyID,
                  string currencyCode,
                  string billingCountry,
                  string certificateName)
			: base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
		{
      _paymentType = paymentType;
      _companyID = companyID;
      _currencyCode = currencyCode;
      _billingCountry = billingCountry;
      _certSubjectDistinguishedName = certificateName;
		}

    public string CertificateName
    {
      get { return _certSubjectDistinguishedName; }
      set { _certSubjectDistinguishedName = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public string PaymentType
    {
      get { return _paymentType; }
      set { _paymentType = value; }
    }

    public long CompanyID
    {
      get { return _companyID; }
      set { _companyID = value; }
    }

    public string CurrencyCode
    {
      get { return _currencyCode; }
      set { _currencyCode = value; }
    }

    public string BillingCountry
    {
      get { return _billingCountry; }
      set { _billingCountry = value; }
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_paymentType + ":" + _companyID.ToString()+":"+_currencyCode+":"+_billingCountry);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }
  }
}
