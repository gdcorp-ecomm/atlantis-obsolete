using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAGetProduct.Interface.PageHelper;

namespace Atlantis.Framework.MYAGetProduct.Interface
{
  public class MYAGetProductRequestData : RequestData
  {
    #region Properties

    private PagingInfo _pagingInfo;
    private int _productTypeId;
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public PagingInfo PagingInfo
    {
      get { return _pagingInfo; }
    }

    public int ProductTypeId
    {
      get { return _productTypeId; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    #endregion

    #region Constructor
    public MYAGetProductRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  PagingInfo pagingInfo,
                                  int productTypeId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _pagingInfo = pagingInfo;
      _productTypeId = productTypeId;
    }
    #endregion

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MYAGetProductRequestData");
    }
  }
}