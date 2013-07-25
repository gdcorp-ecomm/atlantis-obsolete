using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.IO;

namespace Atlantis.Framework.IrisGetIncidentsByShopper.Interface
{
  public class IrisGetIncidentsByShopperRequestData: RequestData
  {
    public TimeSpan RequestTimeout { get; set; }
    public int DaysBack { get; set; }

    public IrisGetIncidentsByShopperRequestData(string shopperId, string sourceUrl, string orderId, string pathway, int pageCount)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(20);
      DaysBack = 30;
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(ShopperID + DaysBack);
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));
      
      xtwRequest.WriteStartElement("Iris");
      xtwRequest.WriteStartElement("Incident");
      xtwRequest.WriteStartElement("InputFields");
      
      xtwRequest.WriteStartElement("Field");
      xtwRequest.WriteAttributeString("Name", "shopperID");
      xtwRequest.WriteString(ShopperID);
      xtwRequest.WriteEndElement(); //Field ShopperID

      xtwRequest.WriteStartElement("Field");
      xtwRequest.WriteAttributeString("Name", "daysBack");
      xtwRequest.WriteString(DaysBack.ToString());      
      xtwRequest.WriteEndElement(); //Field daysBack

      xtwRequest.WriteEndElement(); //InputFields
      xtwRequest.WriteEndElement(); //Incident
      xtwRequest.WriteEndElement(); //Iris

      return sbRequest.ToString();

    }
  }
}