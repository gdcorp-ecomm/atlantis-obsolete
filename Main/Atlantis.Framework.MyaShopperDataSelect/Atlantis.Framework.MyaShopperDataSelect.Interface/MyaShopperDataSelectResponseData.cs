using System;
using System.Xml;
using System.Xml.Linq;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SessionCache;

namespace Atlantis.Framework.MyaShopperDataSelect.Interface
{
  public class MyaShopperDataSelectResponseData : IResponseData, ISessionSerializableResponse
  {
    #region Properties

    private AtlantisException _ex;
    private string _resultXML;
    public string Data { get; set; }

    #endregion

    #region Constructors

    public MyaShopperDataSelectResponseData()
    { }

    public MyaShopperDataSelectResponseData(string data)
    {
      Data = data;
      _resultXML = new XElement("data", data).ToString();
    }

    public MyaShopperDataSelectResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public MyaShopperDataSelectResponseData(RequestData requestData, Exception ex)
    {
      _ex = new AtlantisException(requestData, "MyaShopperDataSelectResponseData", ex.Message, requestData.ToXML());
    }

    #endregion

    #region IResponseData Members

    public string ToXML()
    {
      return _resultXML;
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion

    #region ISessionSerializableResponse Members

    public string SerializeSessionData()
    {
      return ToXML();
    }

    public void DeserializeSessionData(string sessionData)
    {
      _resultXML = sessionData;
      XmlDocument result = new XmlDocument();
      result.LoadXml(sessionData);

      Data = result.SelectSingleNode("data").LastChild.Value;
    }

    #endregion

  }
}
