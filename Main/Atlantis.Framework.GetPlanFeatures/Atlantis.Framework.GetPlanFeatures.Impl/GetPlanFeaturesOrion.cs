using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DataCache;
using Atlantis.Framework.GetPlanFeatures.Interface;

namespace Atlantis.Framework.GetPlanFeatures.Impl
{
  class GetPlanFeaturesOrion
  {
    /*******************************************************************************/

    public static GetPlanFeaturesResponseData GetPlanFeatures(GetPlanFeaturesRequestData oPlanFeatureRequest)
    {
      GetPlanFeaturesResponseData oResponseData = null;
      DataTable dtPlanFeatures = null;
      int iUnifiedPFID = 0;

      try
      {
        iUnifiedPFID = oPlanFeatureRequest.UnifiedPFID;

        dtPlanFeatures = DataCache.DataCache.GetCacheDataTable(GenerateGetOrionAttributesXML(iUnifiedPFID));
        oResponseData = new GetPlanFeaturesResponseData(oPlanFeatureRequest.UnifiedPFID, dtPlanFeatures);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetPlanFeaturesResponseData(iUnifiedPFID, dtPlanFeatures, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetPlanFeaturesResponseData(iUnifiedPFID, dtPlanFeatures, oPlanFeatureRequest, ex);
      }

      return oResponseData;
    }

    /*******************************************************************************/

    protected static string GenerateGetOrionAttributesXML(int iUnifiedPFID)
    {
      StringBuilder sbResult  = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("GetOrionAttributes");

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "pf_id");
      xtwResult.WriteAttributeString("value", iUnifiedPFID.ToString());
      xtwResult.WriteEndElement(); // param

      xtwResult.WriteEndElement(); // ProcName

      return sbResult.ToString();
    }

    /*******************************************************************************/
  }
}
