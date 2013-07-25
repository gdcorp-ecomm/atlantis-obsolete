using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetPlanFeatures.Interface;
using System.ComponentModel;

namespace Atlantis.Framework.GetPlanFeatures.Impl
{
  public class GetPlanFeatures : IRequest
  {
    /*******************************************************************************/
  
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetPlanFeaturesResponseData oResponseData = null;
      string sPlanFeatureXML  = "";
      int iUnifiedPFID        = 0;
      
      try
      {
        GetPlanFeaturesRequestData oPlanFeatureRequest = (GetPlanFeaturesRequestData)oRequestData;
        
        object oCheck = oConfig as WsConfigElement;        
        if ( oCheck != null )
        {
          string sBonsaiNamespace = GetPlanFeaturesBonsai.GetBonsaiNamespace(oPlanFeatureRequest.UnifiedPFID);

          if (sBonsaiNamespace.Length > 0)
          {
            oResponseData = GetPlanFeaturesBonsai.GetPlanFeatures(sBonsaiNamespace,
                                                                  oPlanFeatureRequest,
                                                                  (WsConfigElement)oConfig);
          }
          else
          {
            oResponseData = GetPlanFeaturesOrion.GetPlanFeatures(oPlanFeatureRequest);
          }
        }
        else
        {
          //LPC Get
          throw new Exception("Non-Bonsai/LPC Plan Feature Get not yet Implemented");
        }
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetPlanFeaturesResponseData(iUnifiedPFID, sPlanFeatureXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetPlanFeaturesResponseData(iUnifiedPFID, sPlanFeatureXML, (GetPlanFeaturesRequestData)oRequestData, ex);
      }

      return oResponseData;
    }

    /*******************************************************************************/  
  }
}
