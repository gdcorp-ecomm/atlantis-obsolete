using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetPlanFeatures.Interface
{
	/// <summary>
	/// Requests Plan Feature data.  Cacheable.
	/// </summary>
  public class GetPlanFeaturesRequestData : RequestData
  {
    /*******************************************************************************/
    
    int m_iUnifiedPFID;

    /*******************************************************************************/
    
    public GetPlanFeaturesRequestData(string sShopperID, 
                                      string sSourceURL, 
                                      string sOrderID, 
                                      string sPathway, 
                                      int iPageCount,
                                      int iUnifiedPFID)
                                      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = iUnifiedPFID;
    }
   
    /*******************************************************************************/
    
    public int UnifiedPFID
    {
      get 
      {
        return m_iUnifiedPFID;
      }
    }
    
    /*******************************************************************************/
        
    override public string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("PlanFeatureGet");
      xtwRequest.WriteAttributeString("ID", ShopperID);
      xtwRequest.WriteAttributeString("UnifiedProductID", m_iUnifiedPFID.ToString());
      xtwRequest.WriteEndElement(); // PlanFeatureGet
      return sbRequest.ToString();
    }

    /*******************************************************************************/

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(m_iUnifiedPFID.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

    /*******************************************************************************/
  }                     
}
