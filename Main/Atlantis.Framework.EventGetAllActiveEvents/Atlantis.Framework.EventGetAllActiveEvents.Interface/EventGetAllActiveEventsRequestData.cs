using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EventGetAllActiveEvents.Interface
{
  public class EventGetAllActiveEventsRequestData : RequestData
  {
    private string _clientName = string.Empty;

    public TimeSpan RequestTimeout { get; set; }

    public EventGetAllActiveEventsRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, string clientName)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _clientName = clientName;
      RequestTimeout = TimeSpan.FromSeconds(3);
    }

    [Obsolete("Please use RequestTimeout instead.")]
    public TimeSpan ServiceTimeout
    {
      get { return RequestTimeout; }
      set { RequestTimeout = value; }
    }

    public string ClientName
    {
      get { return _clientName; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("EventGetAllActiveEventsRequestData is not a cacheable request");
    }
  }
}
