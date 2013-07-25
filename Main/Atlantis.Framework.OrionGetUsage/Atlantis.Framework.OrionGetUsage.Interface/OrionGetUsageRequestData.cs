using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OrionGetUsage.Interface
{
  public class OrionGetUsageRequestData : RequestData
  {
    public const string BANDWIDTH_USAGETYPE = "BANDWIDTH";
    public const string DISKSPACE_USAGETYPE = "DISK_SPACE";
    public const string MINUTES_USAGETYPE = "minutes";

    #region Private Members
    string _orionResourceId;
    string _usageType;
    DateTime _startDate;
    DateTime _endDate;
    TimeSpan _timeout;
    #endregion
    #region Ctrs
    public OrionGetUsageRequestData(string shopperId
      , string sourceUrl
      , string orderIo
      , string pathway
      , int pageCount
      , string orionResourceId
      , string usageType
      , DateTime startDate
      , DateTime endDate
      , TimeSpan requestTimeout)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _orionResourceId = orionResourceId;
      _usageType = usageType;
      _startDate = startDate;
      _endDate = endDate;
      _timeout = requestTimeout;

    }
    public OrionGetUsageRequestData(string shopperId
      , string sourceUrl
      , string orderIo
      , string pathway
      , int pageCount
      , string orionResourceId
      , string usageType
      , DateTime startDate
      , DateTime endDate)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _orionResourceId = orionResourceId;
      _usageType = usageType;
      _startDate = startDate;
      _endDate = endDate;
      _timeout = new TimeSpan(0, 0, 30);

    }
    #endregion
    #region Properties
    public string OrionResourceId
    {
      get { return _orionResourceId; }
      set { _orionResourceId = value; }
    }
    public string UsageType
    {
      get { return _usageType; }
      set { _usageType = value; }
    }
    public DateTime StartDate
    {
      get { return _startDate; }
      set { _startDate = value; }
    }
    public DateTime EndDate
    {
      get { return _endDate; }
      set { _endDate = value; }
    }
    public TimeSpan Timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }
    #endregion

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in OrionGetUsageRequestData");
    }
  }
}
