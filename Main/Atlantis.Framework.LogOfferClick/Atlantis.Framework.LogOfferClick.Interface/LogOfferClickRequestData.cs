using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.LogOfferClick.Interface
{
  public class LogOfferClickRequestData : RequestData
  {
    private string _fbiOfferID;
    private string _visitGuid;
    private DateTime _clickDate;
    private short _applicationID;
    private TimeSpan _wsRequestTimeout;

    public LogOfferClickRequestData(
      string shopperID, string sourceURL, string orderID, string pathway,
      int pageCount, string fbiOfferID, string visitGuid, DateTime clickDate, short applicationID)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      _fbiOfferID = fbiOfferID;
      _visitGuid = visitGuid;
      _clickDate = clickDate;
      _applicationID = applicationID;
      _wsRequestTimeout = new TimeSpan(0, 0, 2);
    }

    #region Properties
    public string FbiOfferID
    {
      get { return _fbiOfferID; }
      set { _fbiOfferID = value; }
    }

    public string VisitGuid
    {
      get { return _visitGuid; }
      set { _visitGuid = value; }
    }

    public DateTime ClickDate
    {
      get { return _clickDate; }
      set { _clickDate = value; }
    }

    public short ApplicationID
    {
      get { return _applicationID; }
      set { _applicationID = value; }
    }
    
    public TimeSpan RequestTimeout
    {
      get { return _wsRequestTimeout; }
      set { _wsRequestTimeout = value; }
    }
    
    #endregion


    public override string GetCacheMD5()
    {
      throw new Exception("LogOfferClick is not a cacheable request.");
    }
  }
}
