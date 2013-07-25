using System;
using System.Text;
using System.Xml;
using System.IO;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.RegGetDotTypeProductIdList.Interface
{
  public class RegGetDotTypeProductIdListRequestData : RequestData
  {
    #region Properties

    private string _dotTypeName;
    public string DotTypeName
    {
      get { return _dotTypeName; }
      set { _dotTypeName = value; }
    }

    private int _timeout = 2500;
    public int Timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }

    #endregion Properties

    #region Constructors

    public RegGetDotTypeProductIdListRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         string dotTypeName)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._dotTypeName = dotTypeName;
    }

    #endregion Constructors

    #region Public Methods

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));
      xtwRequest.WriteStartElement("request");
      xtwRequest.WriteAttributeString("tldname", this._dotTypeName);
      xtwRequest.WriteAttributeString("plgrouptype", "0");
      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

    #endregion Public Methods

    #region Private Methods

    #endregion Private Methods
  }
}
