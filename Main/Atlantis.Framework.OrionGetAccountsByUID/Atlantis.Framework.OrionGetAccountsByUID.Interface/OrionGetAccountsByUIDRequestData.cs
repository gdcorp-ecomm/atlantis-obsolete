using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.OrionGetAccountsByUID.Interface
{
  public class OrionGetAccountsByUIDRequestData : RequestData
  {
    public string AppName { get; private set; }
    public string MessageId { get; private set; }
    public string[] AccountUid { get; private set; }
    public string[] ReturnAttributeList { get; private set; }

    public OrionGetAccountsByUIDRequestData(string shopperId
                                , string sourceUrl
                                , string orderIo
                                , string pathway
                                , int pageCount
                                , string appName
                                , string messageId
                                , string[] accountUid
                                , string[] returnAttributeList)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      AppName = appName;
      MessageId = messageId;
      AccountUid = accountUid;
      ReturnAttributeList = returnAttributeList;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in OrionGetAccountsByUIDRequestData");
    }


  }
}
