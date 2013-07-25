using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ManagerGetProductDetail.Interface
{
  public class ManagerGetProductDetailRequestData: RequestData
  {
    public ManagerGetProductDetailRequestData(
      string shopperId,
      string sourceURL,
      string orderId,
      string pathway,
      int pageCount,
      decimal pfid,
      int privateLabelId,
      int adminFlag,
      int mgrUserId) 
      : base(shopperId, sourceURL, orderId, pathway, pageCount)
    {
      Pfid = pfid;
      PrivateLabelId = privateLabelId;
      AdminFlag = adminFlag;
      ManagerUserId = mgrUserId;
    }

    public decimal Pfid { get; private set; }
    public int PrivateLabelId { get; private set; }
    public int AdminFlag { get; private set; }
    public int ManagerUserId { get; private set; }

    private TimeSpan _requestTimeout = TimeSpan.FromSeconds(5);

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }
  }
}
