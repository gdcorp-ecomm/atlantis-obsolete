using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DataCache;
using Atlantis.Framework.BannerContent.Interface;

namespace Atlantis.Framework.BannerContent.Impl
{
  public class BannerContentRequest : IRequest
  {
    // **************************************************************** //

    #region IRequest Members

    // **************************************************************** //

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      Dictionary<string, string> dictResult = new Dictionary<string, string>();

      try
      {
        BannerContentRequestData oBCRequestData = (BannerContentRequestData)oRequestData;

        DataTable dtBanners 
          = DataCache.DataCache.GetCacheDataTable(oBCRequestData.DisplayBannerFilterRequestXML());
        foreach (DataRow row in dtBanners.Rows)
        {
          string sContentID = (string)row["displayBanner_bannerContentID"];
          dictResult[sContentID] = (string)row["bannerContent"];
        }

        DataTable dtBannersRegEx
          = DataCache.DataCache.GetCacheDataTable(oBCRequestData.DisplayBannerFilterRegExRequestXML());
        foreach (DataRow row in dtBannersRegEx.Rows)
        {
          if (Regex.IsMatch(oBCRequestData.ISCCodeValue, (string)row["regularExpression"]))
          {
            string sContentID = (string)row["displayBanner_bannerContentID"];
            dictResult[sContentID] = (string)row["bannerContent"];
          }
        }

        DataTable dtBannersIPAddress
          = DataCache.DataCache.GetCacheDataTable(oBCRequestData.DisplayBannerFilterIPAddressRequestXML());
        foreach (DataRow row in dtBannersIPAddress.Rows)
        {
          IPAddressRange range = null;

          if (IPAddressRange.TryParse((string)row["IPAddressValue"], out range)
                && range.WithinRange(oBCRequestData.IPAddress))
          {
            string sContentID = (string)row["displayBanner_bannerContentID"];
            dictResult[sContentID] = (string)row["bannerContent"];
          }
        }

        oResponseData = new BannerContentResponseData(new List<string>(dictResult.Values));
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new BannerContentResponseData(new List<string>(dictResult.Values), exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new BannerContentResponseData(new List<string>(dictResult.Values), oRequestData, ex);
      }

      return oResponseData;
    }
    
    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
