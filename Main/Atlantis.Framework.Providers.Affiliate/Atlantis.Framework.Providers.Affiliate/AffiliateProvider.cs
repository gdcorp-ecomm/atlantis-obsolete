﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using Atlantis.Framework.AffiliateMetaData.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Providers.Affiliate.Interface;

namespace Atlantis.Framework.Providers.Affiliate
{
  public class AffiliateProvider : ProviderBase, IAffiliateProvider
  {
    #region Private Properties & Constants

    private static int _affiliateMetaDataRequestType = 532;
    public static int AffiliateMetaDataRequestType
    {
      get { return _affiliateMetaDataRequestType; }
      set { _affiliateMetaDataRequestType = value; }
    }

    private const int MADDOG_PL = 1941;
    private const string COOKIENAMEFORMAT = "Affiliates{0}";

    ISiteContext _siteContext;
    private string _cookieName;
    private string CookieName
    {
      get
      {
        if (string.IsNullOrEmpty(_cookieName))
        {
          _cookieName = string.Format(CultureInfo.InvariantCulture, COOKIENAMEFORMAT, _siteContext.PrivateLabelId.ToString());
        }
        return _cookieName;
      }
    }

    private AffiliateMetaDataResponseData _affiliateMetaDataResponse;
    private AffiliateMetaDataResponseData AffiliateMetaDataResponse
    {
      get
      {
        if (_affiliateMetaDataResponse == null)
        {
          _affiliateMetaDataResponse = BuildAffiliateMetaData();
        }
        return _affiliateMetaDataResponse;
      }
    }

    private bool _isCookieValid = false;
    private bool _valuesLoaded = false;
    private DateTime _affiliateStartDate;
    private string _affiliateType = string.Empty;

    #endregion

    #region Constructor & Private Methods

    public AffiliateProvider(IProviderContainer container)
      : base(container)
    {
      _siteContext = Container.Resolve<ISiteContext>();
      _affiliateStartDate = DateTime.Now;
    }

    private AffiliateMetaDataResponseData BuildAffiliateMetaData()
    {
      AffiliateMetaDataResponseData response = null;

      try
      {
        AffiliateMetaDataRequestData request = new AffiliateMetaDataRequestData(string.Empty
          , HttpContext.Current.Request.Url.ToString()
          , string.Empty
          , _siteContext.Pathway
          , _siteContext.PageCount
          , _siteContext.PrivateLabelId);

        response = DataCache.DataCache.GetProcessRequest(request, AffiliateMetaDataRequestType) as AffiliateMetaDataResponseData;
      }
      catch (Exception ex)
      {
        AtlantisException aex = new AtlantisException(
          "A.F.P.Affiliate.BuildAffiliateMetaData",
          HttpContext.Current.Request.Url.ToString(),
          "0",
          ex.Message,
          ex.StackTrace,
          string.Empty, string.Empty, HttpContext.Current.Request.UserHostAddress,
          _siteContext.Pathway, _siteContext.PageCount);
        Engine.Engine.LogAtlantisException(aex);
      }

      return response;
    }

    private void ExpireAffiliateCookie()
    {
      HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
      if (cookie != null)
      {
        HttpCookie expireCookie = _siteContext.NewCrossDomainMemCookie(CookieName);
        expireCookie.Expires = DateTime.Now.AddDays(-7);
        expireCookie.Value = string.Empty;
        HttpContext.Current.Response.Cookies.Set(expireCookie);
      }
    }

    private bool GetAffiliateCookieData()
    {
      try
      {
        string tempCookieValue = null;
        string tempAffiliateType = string.Empty;
        HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
        if (cookie != null)
        {
          if (!string.IsNullOrEmpty(cookie.Value))
          {
            {
              tempCookieValue = HttpUtility.UrlDecode(cookie.Value);

              if (tempCookieValue != null)
              {
                tempAffiliateType = GetAffiliateType(tempCookieValue);

                if (IsValidAffiliate(tempAffiliateType))
                {
                  DateTime startDate = GetStartDate(tempCookieValue);
                  if (startDate != DateTime.MinValue)
                  {
                    _affiliateStartDate = startDate;
                    _affiliateType = tempAffiliateType;
                    _isCookieValid = true;
                  }
                }
              }
            }
          }
        }
      }
      catch
      {
        _isCookieValid = false;
      }
      return _isCookieValid;
    }

    private string GetAffiliateType(string cookieValue)
    {
      string affiliateType = string.Empty;

      if (!string.IsNullOrEmpty(cookieValue) &&
        cookieValue.Length > 2 &&
        IsValidAffiliate(cookieValue.ToLowerInvariant().Substring(0, 3)))
      {
        affiliateType = cookieValue.ToLowerInvariant().Substring(0, 3);
      }

      return affiliateType;
    }

    private DateTime GetStartDate(string cookieValue)
    {
      DateTime startDate = DateTime.MinValue;
      DateTime cookieStartDate;

      if (!string.IsNullOrEmpty(cookieValue) && cookieValue.Length > 4 &&
        DateTime.TryParse(cookieValue.Substring(4), out cookieStartDate))
      {
        startDate = cookieStartDate;
      }

      return startDate;
    }

    private int GetCookieExpirationDays()
    {
      string cjcDaySetting = DataCache.DataCache.GetAppSetting("CJC_DAYS");
      int cjcDays;
      if (!int.TryParse(cjcDaySetting, out cjcDays))
      {
        cjcDays = 45;
        AtlantisException ex = new AtlantisException(
          "A.F.P.Affiliate.GetCookieExpirationDays",
          HttpContext.Current.Request.Url.ToString(),
          "0",
          "CJC_DAYS AppSetting is not numeric.",
          "Setting=" + cjcDaySetting,
          string.Empty, string.Empty, HttpContext.Current.Request.UserHostAddress,
          _siteContext.Pathway, _siteContext.PageCount);
        Engine.Engine.LogAtlantisException(ex);
      }

      return cjcDays;
    }

    private void SetCookie()
    {
      HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[CookieName];
      int _cookieExpirationDays = GetCookieExpirationDays();
      cookie = _siteContext.NewCrossDomainCookie(CookieName, _affiliateStartDate.AddDays(_cookieExpirationDays));
      cookie.Value = HttpUtility.UrlEncode(string.Format("{0}|{1}", _affiliateType.ToLowerInvariant(), _affiliateStartDate.ToString("M/d/yyyy")));
      HttpContext.Current.Response.Cookies.Set(cookie);
    }

    private string DetermineAffiliateType(string isc)
    {
      string affiliateType = string.Empty;
      if (ValidContext)
      {
        if ((!string.IsNullOrEmpty(isc)) && (isc.Length > 2))
        {
          if (MatchAffiliateType(isc.ToUpperInvariant().Substring(0, 3)))
          {
            affiliateType = isc.ToUpperInvariant().Substring(0, 3);
          }
        }
      }
      return affiliateType;
    }

    private bool? _validContext;
    private bool ValidContext
    {

      get
      {
        _validContext = false;
        if (_siteContext.ContextId == ContextIds.GoDaddy)
        {
          _validContext = true;
        }
        if ((_siteContext.PrivateLabelId == MADDOG_PL) && (_siteContext.ISC.ToLowerInvariant().StartsWith("cjm")))
        {
          _validContext = true;
        }
        if ((_siteContext.ContextId == ContextIds.WildWestDomains) && (_siteContext.ISC.ToLowerInvariant().StartsWith("cjw")))
        {
          _validContext = true;
        }

        return _validContext.Value;

      }
    }

    private bool GetAffiliateInfo()
    {
      bool validAffiliateInfo = false;
      try
      {
        validAffiliateInfo = GetAffiliateCookieData();
      }
      catch (Exception ex)
      {
        string data = ex.Message + Environment.NewLine + ex.StackTrace;

        AtlantisException aex = new AtlantisException(
          "A.F.P.Affiliate.GetAffiliateInfo()",
          HttpContext.Current.Request.Url.ToString(),
          "0",
          "Error getting affiliate info",
          data,
          string.Empty, string.Empty, HttpContext.Current.Request.UserHostAddress,
          _siteContext.Pathway, _siteContext.PageCount);
        Engine.Engine.LogAtlantisException(aex);

        _affiliateType = string.Empty;
        _affiliateStartDate = DateTime.MinValue;
      }

      _valuesLoaded = true;
      return validAffiliateInfo;
    }

    private void SetAffiliate(string affiliateType)
    {
      try
      {
        int cookieExpirationDays = GetCookieExpirationDays();
        if (GetAffiliateInfo())
        {
          if (IsValidAffiliate(affiliateType))
          {
            if (string.Compare(_affiliateType, affiliateType, true) != 0)
            {
              _affiliateType = affiliateType;
              _affiliateStartDate = DateTime.Now;
              SetCookie();
              _valuesLoaded = true;
            }
          }
        }
        else
        {
          if (IsValidAffiliate(affiliateType))
          {
            _affiliateType = affiliateType;
            _affiliateStartDate = DateTime.Now;
            SetCookie();
            _valuesLoaded = true;
          }
        }
      }
      catch (Exception ex)
      {
        string data = ex.Message + Environment.NewLine + ex.StackTrace;

        AtlantisException aex = new AtlantisException(
          "A.F.P.Affiliate.SetAffiliate()",
          HttpContext.Current.Request.Url.ToString(),
          "0",
          "Error setting affiliate info",
          data,
          string.Empty, string.Empty, HttpContext.Current.Request.UserHostAddress,
          _siteContext.Pathway, _siteContext.PageCount);
        Engine.Engine.LogAtlantisException(aex);

        _valuesLoaded = false;
      }
    }

    private bool MatchAffiliateType(string affiliateType)
    {
      bool matchFound = false;

      if (AffiliateMetaDataResponse != null && AffiliateMetaDataResponse.IsSuccess)
      {
        matchFound = AffiliateMetaDataResponse.AffiliateItemsContains(affiliateType);
      }

      return matchFound;
    }
    #endregion

    #region Public Properties & Methods

    public int? UpdatedAffiliateMetaDataRequest { get; set; }

    public bool IsValidAffiliate(string affiliateType)
    {
      bool isValid = false;

      if (!string.IsNullOrEmpty(affiliateType))
      {
        if (MatchAffiliateType(affiliateType.ToUpperInvariant()))
        {
          isValid = true;
        }
      }
      return isValid;
    }

    public bool ProcessAffiliateSourceCode(string isc, out string affiliateType, out DateTime affiliateStartDate)
    {
      string tempAffiliateType = DetermineAffiliateType(isc);

      if (GetAffiliateInfo())
      {
        if (!_affiliateType.Equals(tempAffiliateType))
        {
          SetAffiliate(tempAffiliateType);
        }
      }
      else
      {
        SetAffiliate(tempAffiliateType);
      }

      affiliateStartDate = _affiliateStartDate;
      affiliateType = _affiliateType;

      return !string.IsNullOrEmpty(affiliateType);
    }
    #endregion
  }
}
