using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DataProvider.Interface
{
  public class DataProviderRequestData : RequestData
  {
    public DataProviderRequestData(string sShopperID,
                             string sSourceURL,
                             string sOrderID,
                             string sPathway,
                             int iPageCount)
                             : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount) 
    {
    }

    public DataProviderRequestData(string sShopperID,
                             string sSourceURL,
                             string sOrderID,
                             string sPathway,
                             int iPageCount,
                             string requestName,
                             Dictionary<string, object> parameters)
                             : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      RequestName = requestName;
      Params = parameters;
    }

    public string RequestName { get; set; }
    public Dictionary<string, object> Params { get; set; }
    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    [Obsolete("Use RequestTimeout instead. Get will always return ms. Set will set as seconds if < 100 otherwise ms.")]
    public int Timeout
    {
      get { return (int)_requestTimeout.TotalMilliseconds; }
      set
      {
        if (value < 100)
        {
          RequestTimeout = TimeSpan.FromSeconds(value);
        }
        else
        {
          RequestTimeout = TimeSpan.FromMilliseconds(value);
        }
      }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    #region NimtizProperties

    private string _dsn = string.Empty;
    private string _appName = string.Empty;
    private string _certName = string.Empty;

    public string DataSourceName
    {
      get { return _dsn; }
      set { _dsn = value; }
    }

    public string ApplicationName
    {
      get { return _appName; }
      set { _appName = value; }
    }

    public string CertificateName
    {
      get { return _certName; }
      set { _certName = value; }
    }

    #endregion

    #region RequestData Members

    public override string GetCacheMD5()
    {
      throw new Exception("DataProviderRequestData is not a cacheable request");
    }

    public override string ToXML()
    {
      return string.Empty;
    }

    #endregion

  }
}
