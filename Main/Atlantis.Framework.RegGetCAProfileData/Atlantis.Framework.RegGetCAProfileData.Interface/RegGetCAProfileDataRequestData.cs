using System;
using System.Text;
using System.Xml;
using System.IO;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.RegGetCAProfileData.Interface
{
  public class RegGetCAProfileDataRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }

    public RegGetCAProfileDataRequestData(
      string shopperID,
      string sourceURL,
      string orderID,
      string pathway,
      int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      RequestTimeout = TimeSpan.FromSeconds(4);
    }

    #region RequestData Members

    public override string GetCacheMD5()
    {
      return string.Empty;
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("profile");
      xtwRequest.WriteAttributeString("shopperid", ShopperID);
      xtwRequest.WriteEndElement();

      return sbRequest.ToString();
    }

    #endregion
  }
}
