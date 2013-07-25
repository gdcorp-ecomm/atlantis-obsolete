using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;
using System.Xml;
using System.IO;

namespace Atlantis.Framework.Document.Interface
{
  public class DocumentRequestData : RequestData
  {
    private int _privateLabelId;
    private string _name;
    private bool _showError = false;
    private bool _fullDocument = true;
    private int _marginWidth = 100;
    private string _title = string.Empty;
    private string _backColor = "#fff";
    private string _foreColor = "#000";

    public DocumentRequestData(
      string sShopperID,
      string sSourceURL,
      string sOrderID,
      string sPathway,
      int iPageCount,
      int privateLabelId,
      string documentName)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      _privateLabelId = privateLabelId;
      _name = documentName;
    }

    public int PrivateLabelId
    {
      get { return _privateLabelId; }
    }

    public string Name
    {
      get { return _name; }
    }

    public bool ShowError
    {
      get { return _showError; }
      set { _showError = value; }
    }

    public bool FullDocument
    {
      get { return _fullDocument; }
      set { _fullDocument = value; }
    }

    public int MarginWidth
    {
      get { return _marginWidth; }
      set { _marginWidth = value; }
    }

    public string Title
    {
      get { return _title; }
      set { _title = value; }
    }

    public string ForeColor
    {
      get { return _foreColor; }
      set { _foreColor = value; }
    }

    public string BackColor
    {
      get { return _backColor; }
      set { _backColor = value; }
    }

    #region RequestData Members

    public override string ToXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));

      xtwResult.WriteStartElement("d3s");
      xtwResult.WriteAttributeString("privateLabelID", _privateLabelId.ToString());
      
      xtwResult.WriteStartElement("document");
      xtwResult.WriteAttributeString("name", _name);
      xtwResult.WriteAttributeString("showError", _showError.ToString().ToLowerInvariant());
      xtwResult.WriteAttributeString("fullDocument", _fullDocument.ToString().ToLowerInvariant());
      xtwResult.WriteAttributeString("marginWidth", _marginWidth.ToString());
      xtwResult.WriteAttributeString("title", _title.ToString());

      xtwResult.WriteStartElement("format");
      xtwResult.WriteAttributeString("backColor", _backColor);
      xtwResult.WriteAttributeString("foreColor", _foreColor);
      xtwResult.WriteEndElement(); // format

      xtwResult.WriteEndElement(); // document
      xtwResult.WriteEndElement(); // d3s

      return sbResult.ToString();
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(ToXML());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", "");
    }

    #endregion
  }
}
