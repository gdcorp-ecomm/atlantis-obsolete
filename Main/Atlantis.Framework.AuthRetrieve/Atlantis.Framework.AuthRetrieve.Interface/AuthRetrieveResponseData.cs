using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuthRetrieve.Interface
{
  public class AuthRetrieveResponseData : IResponseData
  {
    #region Properties    
    private readonly AtlantisException _exception = null;

    private readonly string _resultXml = string.Empty;
    public string ResultXml
    {
      get { return _resultXml; }
    }

    private readonly bool _success;
    public bool IsSuccess
    {
      get { return _success; }
    }

    private readonly string _shopperId = string.Empty;
    public string ShopperId
    {
      get { return _shopperId; }
    }

    private readonly XDocument _artifactDoc = new XDocument();
    public XDocument ArtifactDoc
    {
      get { return _artifactDoc; }
    }

    private readonly string _ipid = string.Empty;
    public string IpId
    {
      get { return _ipid; }
    }

    private readonly string _spid = string.Empty;
    public string SpId
    {
      get { return _spid; }
    }
    #endregion

    public AuthRetrieveResponseData(string xml)
    {
      _success = true;
      _resultXml = xml;
      _artifactDoc = XDocument.Load(new StringReader(xml));
      foreach (var currentElement in _artifactDoc.Descendants("Request"))
      {
        foreach (var currAttrib in currentElement.Nodes().OfType<XElement>().Where(currAttrib => currAttrib.Name == "ShopperID"))
        {
          _shopperId = currAttrib.Value;
          break;
        }

      }
      var rootNode = _artifactDoc.Root;
      if (rootNode != null)
      {
        if (rootNode.Attribute("idpid") != null)
        {
          _ipid = rootNode.Attribute("idpid").Value;
        }
        if (rootNode.Attribute("spid") != null)
        {
          _spid = rootNode.Attribute("spid").Value;
        }        
      }
    }

    public AuthRetrieveResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public AuthRetrieveResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData
        , "AuthRetrieveResponseData"
        , exception.Message
        , requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      return _resultXml;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
