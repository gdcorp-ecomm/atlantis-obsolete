using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetPlanFeatures.Interface
{
  public class GetPlanFeaturesResponseData : IResponseData
  {
    /*******************************************************************************/  
  
    int m_iUnifiedProductID;
    Dictionary<string, string> m_oDicPlanFeatures;
    string m_sPlanFeatureXML;
    AtlantisException m_ex;

    /*******************************************************************************/
    
    public GetPlanFeaturesResponseData(int iUnifiedProductID,
                                      string sPlanFeatureXML)
    {
      m_oDicPlanFeatures = new Dictionary<string,string>();
      m_iUnifiedProductID = iUnifiedProductID;
      m_sPlanFeatureXML   = sPlanFeatureXML;
      XmlDocument oDoc    = new XmlDocument();
      
      oDoc.LoadXml("<root>" + sPlanFeatureXML + "</root>");
      XmlNodeList oList   = oDoc.SelectNodes("/root/AccountElement");
      foreach (XmlNode oNode in oList)
      {
        string sName  = oNode.SelectSingleNode("Name").InnerXml;
        string sValue = oNode.SelectSingleNode("Value").InnerXml;
        m_oDicPlanFeatures.Add(sName, sValue);
      }
      m_ex = null;
    }

    public GetPlanFeaturesResponseData(int iUnifiedProductID,
                                      DataTable dtPlanFeatures)
    {
      m_oDicPlanFeatures = new Dictionary<string, string>();
      m_iUnifiedProductID = iUnifiedProductID;

      m_sPlanFeatureXML = PlanFeaturesDataTableToXML(dtPlanFeatures);

      foreach (DataRow row in dtPlanFeatures.Rows)
        m_oDicPlanFeatures.Add((string)row["attributeName"], (string)row["orionValue"]);
      m_ex = null;
    }

    public GetPlanFeaturesResponseData(int iUnifiedProductID,
                                      DataTable dtPlanFeatures,
                                      RequestData oRequestData,
                                      Exception ex)
    {
      m_iUnifiedProductID = iUnifiedProductID;
      m_sPlanFeatureXML   = PlanFeaturesDataTableToXML(dtPlanFeatures);
      m_ex = new AtlantisException(oRequestData,
                                   "GetPlanFeatureResponseData",
                                   ex.Message.ToString(),
                                   oRequestData.ToXML());
    }

    public GetPlanFeaturesResponseData(int iUnifiedProductID,
                                      DataTable dtPlanFeatures,
                                      AtlantisException ex)
    {
      m_iUnifiedProductID = iUnifiedProductID;
      m_sPlanFeatureXML   = PlanFeaturesDataTableToXML(dtPlanFeatures);
      m_ex = ex;
    }

    public GetPlanFeaturesResponseData(int iUnifiedProductID,
                                      string sPlanFeatureXML, 
                                      RequestData oRequestData,
                                      Exception ex)
    {
      m_iUnifiedProductID = iUnifiedProductID;
      m_sPlanFeatureXML   = sPlanFeatureXML;
      m_ex = new AtlantisException(oRequestData,
                                   "GetPlanFeatureResponseData", 
                                   ex.Message.ToString(), 
                                   oRequestData.ToXML());
    }

    public GetPlanFeaturesResponseData(int iUnifiedProductID, 
                                      string sPlanFeatureXML, 
                                      AtlantisException ex)
    {
      m_iUnifiedProductID = iUnifiedProductID;
      m_sPlanFeatureXML   = sPlanFeatureXML;
      m_ex = ex;
    }

    /*******************************************************************************/
    
    public Dictionary<string, string> PlanFeatures
    {
      get
      {
        return m_oDicPlanFeatures;
      }
    }

    public int UnifiedPFID
    {
      get
      {
        return m_iUnifiedProductID;
      }
    }

    public bool IsSuccess
    {
      get { return m_sPlanFeatureXML.IndexOf("success", StringComparison.OrdinalIgnoreCase) > -1; }
    }
    
    /*******************************************************************************/

    #region IResponseData Members

    public string ToXML()
    {
      return m_sPlanFeatureXML;
    }

    public AtlantisException GetException()
    {
      return m_ex;
    }

    #endregion

    /*******************************************************************************/

    protected string PlanFeaturesDataTableToXML(DataTable dtPlanFeatures)
    {
      DataSet dsPlanFeatures = new DataSet("PlanFeatures");
      dsPlanFeatures.Tables.Add(dtPlanFeatures);
      dtPlanFeatures.TableName = "Attributes";
      StringBuilder sbPlanFeatures = new StringBuilder();
      dsPlanFeatures.WriteXml(new StringWriter(sbPlanFeatures));
      dsPlanFeatures.Tables.Remove(dtPlanFeatures);
      return sbPlanFeatures.ToString();
    }

    /*******************************************************************************/
  }
}

