using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

using Atlantis.Framework.Interface;
using Atlantis.Framework.GetPlanFeatures.Interface;

namespace Atlantis.Framework.GetPlanFeatures.Impl
{
  class GetPlanFeaturesBonsai
  {
    /*******************************************************************************/

    public static GetPlanFeaturesResponseData GetPlanFeatures(string sBonsaiNamespace, 
                                                             GetPlanFeaturesRequestData oPlanFeatureRequest,
                                                             WsConfigElement oConfig)
    {
      GetPlanFeaturesResponseData oResponseData = null;
      devgdbonsai.CommerceHelper oWs           = null;
      string sPlanFeatureXML  = "";
      int iUnifiedPFID        = 0;
      
      try
      {
        oWs                 = new devgdbonsai.CommerceHelper();
        oWs.Url             = ((WsConfigElement)oConfig).WSURL;
        iUnifiedPFID        = oPlanFeatureRequest.UnifiedPFID;

        if (sBonsaiNamespace.Length == 0)
        {
          throw new AtlantisException(oPlanFeatureRequest,
                                      "GetPlanFeaturesBonsai.GetPlanFeaturesBonsai",
                                      "Product does not exist in Bonsai",
                                      "UnifiedPFID: " + iUnifiedPFID.ToString());
        }

        string sRequestXml  = "<BaseUnifiedProductID UnifiedProductID=\"" + 
                                iUnifiedPFID.ToString() +
                                "\" IsFree=\"0\"></BaseUnifiedProductID>";
        sPlanFeatureXML     = oWs.GetPlanFeatureOverridesXml(sBonsaiNamespace, sRequestXml);
        oResponseData       = new GetPlanFeaturesResponseData(oPlanFeatureRequest.UnifiedPFID, sPlanFeatureXML);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new GetPlanFeaturesResponseData(iUnifiedPFID, sPlanFeatureXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new GetPlanFeaturesResponseData(iUnifiedPFID, sPlanFeatureXML, oPlanFeatureRequest, ex);
      }

      return oResponseData;
    }

    /*******************************************************************************/
    
    public static string GetBonsaiNamespace( int iUnifiedPFID )
    {
      string sResult = "";
      DataTable dt = DataCache.DataCache.GetCacheDataTable(GenerateNamespaceRequestXML(iUnifiedPFID));

      if (dt.Rows.Count > 0)
        sResult = dt.Rows[0][0].ToString();

      return sResult;
    }
        
    /*******************************************************************************/

    protected static string GenerateNamespaceRequestXML( int iUnifiedPFID )
    {
      StringBuilder sbResult  = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("GetBonsaiType");

      xtwResult.WriteStartElement("param");
      xtwResult.WriteAttributeString("name", "gdshop_product_unifiedProductID");
      xtwResult.WriteAttributeString("value", iUnifiedPFID.ToString());
      xtwResult.WriteEndElement(); // param

      xtwResult.WriteEndElement(); // ProcName

      return sbResult.ToString();
    }

    /*******************************************************************************/
  }
}
