using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAGetHostingCredits.Interface
{
  public class MYAGetHostingCreditsRequestData : RequestData
  {
    #region Properties
    private List<int> _productTypeIds;
    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);

    public List<int> ProductTypeIds
    {
      get { return _productTypeIds; }
      set { _productTypeIds = value; }
    }

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }
    #endregion

    public MYAGetHostingCreditsRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderIo,
                                  string pathway,
                                  int pageCount,
                                  List<int> productTypeIds)
      : base(shopperId, sourceUrl, orderIo, pathway, pageCount)
    {
      _productTypeIds = productTypeIds;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MYAGetHostingCreditsRequestData");     
    }
  }
}
