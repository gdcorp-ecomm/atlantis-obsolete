﻿using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetDurationHash.Interface;

namespace Atlantis.Framework.GetDurationHash.Impl
{
  public class GetDurationHashRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      string sHash = null;

      try
      {
        GetDurationHashRequestData oGetDurationHashRequestData 
          = (GetDurationHashRequestData)oRequestData;

        object oHash = null;
        using (OverrideDurationWrapper price = new OverrideDurationWrapper())
        {
          oHash = price.Duration.GetHash(oGetDurationHashRequestData.PrivateLabelID,
                                         oGetDurationHashRequestData.UnifiedPFID,
                                         oGetDurationHashRequestData.Duration);
        }

        sHash = Convert.ToString(oHash);

        oResponseData = new GetDurationHashResponseData(sHash);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetDurationHashResponseData(sHash, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetDurationHashResponseData(sHash, oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

  }
}
