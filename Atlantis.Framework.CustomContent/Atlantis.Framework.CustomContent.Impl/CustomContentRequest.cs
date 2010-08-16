using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using Atlantis.Framework.Interface;
using Atlantis.Framework.CustomContent.Interface;
using Atlantis.Framework.DataCache;

namespace Atlantis.Framework.CustomContent.Impl
{
  public class CustomContentRequest : IRequest
  {
    // **************************************************************** //

    #region IRequest Members

    // **************************************************************** //

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      Dictionary<string, byte> dictResult = new Dictionary<string, byte>();

      try
      {
        CustomContentRequestData oBCRequestData = (CustomContentRequestData)oRequestData;

        if (oBCRequestData.ISCCodeValue == null)
          throw new AtlantisException(oRequestData, "CustomContentRequest.RequestHandler", "Value cannot be null. Parameter name: ISCCodeValue", "");
        if (oBCRequestData.IPAddress == null)
          throw new AtlantisException(oRequestData, "CustomContentRequest.RequestHandler", "Value cannot be null. Parameter name: IPAddress", "");

        DataTable dtCustomContentIDs
          = DataCache.DataCache.GetCacheDataTable(oBCRequestData.CustomContentFilterRequestXML());
        foreach (DataRow row in dtCustomContentIDs.Rows)
        {
          string sContentID = (string)row["contentControl_customContentID"];
          dictResult[sContentID] = 0;
        }

        DataTable dtCustomContentIDsRegEx
          = DataCache.DataCache.GetCacheDataTable(oBCRequestData.CustomContentFilterRegExRequestXML());
        foreach (DataRow row in dtCustomContentIDsRegEx.Rows)
        {
          if (Regex.IsMatch(oBCRequestData.ISCCodeValue, (string)row["regularExpression"]))
          {
            string sContentID = (string)row["contentControl_customContentID"];
            dictResult[sContentID] = 0;
          }
        }

        DataTable dtCustomContentIDsIPAddress
          = DataCache.DataCache.GetCacheDataTable(oBCRequestData.CustomContentFilterIPAddressRequestXML());
        foreach (DataRow row in dtCustomContentIDsIPAddress.Rows)
        {
          IPAddressRange range = null;

          if (IPAddressRange.TryParse((string)row["IPAddressValue"], out range)
                && range.WithinRange(oBCRequestData.IPAddress))
          {
            string sContentID = (string)row["contentControl_customContentID"];
            dictResult[sContentID] = 0;
          }
        }

        oResponseData = new CustomContentResponseData(dictResult);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new CustomContentResponseData(dictResult, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new CustomContentResponseData(dictResult, oRequestData, ex);
      }

      return oResponseData;
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
