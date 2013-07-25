using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.OrionGetAccountTransition.Interface
{
  public class OrionGetAccountTransitionRequestData : RequestData
  {
    public string MessageId { get; private set; }
    public string AccountUid { get; private set; }
    public string TransitionUid { get; private set; }
    public string[] StatusList { get; private set; }

    /// <summary>
    /// Default of 5 seconds
    /// </summary>
    public TimeSpan RequestTimeout { get; set; }

    public OrionGetAccountTransitionRequestData(string shopperId
      , string sourceUrl
      , string orderId 
      , string pathway
      , int pageCount
      , string messageId
      , string accountUid
      , string transitionId
      , string[] statusList)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      MessageId = messageId;
      AccountUid = accountUid;
      TransitionUid = transitionId;
      StatusList = statusList;
      RequestTimeout = TimeSpan.FromSeconds(5);
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in OrionGetAccountTransitionRequestData");     
    }
  }
}
