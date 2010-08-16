using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DataCache;
using Atlantis.Framework.ProductGroup.Interface;

namespace Atlantis.Framework.ProductGroup.Impl
{
  public class ProductGroupRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      DataTable dtResult = null;

      try
      {
        ProductGroupRequestData oProductGroupRequestData = (ProductGroupRequestData)oRequestData;
        dtResult = DataCache.DataCache.GetCacheDataTable(oProductGroupRequestData.ToXML());

        oResponseData = new ProductGroupResponseData(dtResult);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new ProductGroupResponseData(dtResult, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new ProductGroupResponseData(dtResult, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion
  }
}
