using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.IsShopperInOptoutList.Interface
{
  public class ShopperInOptoutListResponseData : IResponseData
  {
    private AtlantisException _ex;

    private string _isInOptOutList;
    public string IsInOptOutList
    {
      get { return _isInOptOutList; }
    }

    public ShopperInOptoutListResponseData()
    {
    }

    public ShopperInOptoutListResponseData(string strInOptOutList)
    {
      _isInOptOutList = strInOptOutList;
    }

    public ShopperInOptoutListResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public ShopperInOptoutListResponseData(RequestData requestData, Exception ex)
    {
      _ex = new AtlantisException(
        requestData, "ShopperInOptoutListResponseData", ex.Message, string.Empty);
    }

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion
  }
}
