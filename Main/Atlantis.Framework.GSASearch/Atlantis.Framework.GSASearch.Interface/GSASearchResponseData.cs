using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Web;
using System.Xml;
using Atlantis.Framework.Interface;
using System.IO;
using System.Text;

namespace Atlantis.Framework.GSASearch.Interface
{
  public class GSASearchResponseData : IResponseData
  {
    private string _response;
    private bool _isSuccess = false;
    private AtlantisException _exception;

    public bool IsSuccess
    {
      get { return _isSuccess; }
    }

    public string Response
    {
      get { return _response; }
    }

    #region Helpers

    private static AtlantisException BuildException(RequestData requestData, string sourceFunction, Exception ex, string response)
    {
      return new AtlantisException(requestData, "GSASearchResponseData." + sourceFunction, ex.Message + Environment.NewLine + ex.StackTrace, response, ex);
    }

    #endregion

    #region Constructors

    public GSASearchResponseData(string response)
    {
      _response = response;
      _isSuccess = !String.IsNullOrEmpty(_response);
    }

    public GSASearchResponseData(GSASearchRequestData requestData, Exception ex)
      : this(BuildException(requestData, "Constructor", ex, String.Concat("requestData.GSABaseURL=", requestData.GSABaseURL, ", requestData.RequestTimeout=", requestData.RequestTimeout, ", requestData.SearchQueryMap=" , requestData.SearchQueryMap.ToString())))
    {
    }

    public GSASearchResponseData(RequestData requestData, Exception ex)
      : this(BuildException(requestData, "Constructor", ex, null))
    {
    }

    public GSASearchResponseData(AtlantisException ex)
    {
      _exception = ex;
    }

    #endregion

    #region IResponseData Members

    public string ToXML()
    {
      if (_response.StartsWith("<?xml"))
      {
        return _response;
      }
      else // in case JSON or other format is returned
      {
        XmlDocument xmldoc = new XmlDocument();
        var xmlDeclaration = xmldoc.CreateXmlDeclaration("1.0", "utf-8", null);
        var rootNode = xmldoc.CreateElement("r");
        xmldoc.InsertBefore(xmlDeclaration, xmldoc.DocumentElement);
        xmldoc.AppendChild(rootNode);
        var responseNode = xmldoc.CreateTextNode(_response);
        rootNode.AppendChild(responseNode);

        var sb = new StringBuilder(_response.Length + 500);
        var xw = XmlWriter.Create(sb);
        xmldoc.Save(xw);
        return sb.ToString();
      }
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

/*
    private void ParseResponse(RequestData requestData)
    {
      try
      {
        if (String.IsNullOrEmpty(_response))
        {
        }
        _isSuccess = true;

        var xml = new XmlDocument();
        xml.LoadXml(_response);

        int totalCount;
        var countNode = xml.SelectSingleNode("/gsa/count");
        int.TryParse(countNode != null ? countNode.InnerXml : String.Empty, out totalCount);

        var resultNodes = xml.SelectNodes("/gsa/r");

        var tempResults = new SearchResult()
        {
          results = new List<QueryResults>(resultNodes.Count),
          count = totalCount
        };

        foreach (var row in resultNodes)
        {
          XmlNode xmlRow = (XmlNode)row;
          var hdr = HttpUtility.HtmlDecode(xmlRow.SelectSingleNode("t").InnerXml);
          var src = HttpUtility.HtmlDecode(xmlRow.SelectSingleNode("s").InnerXml);
          var url = HttpUtility.HtmlDecode(xmlRow.SelectSingleNode("u").InnerXml);

          tempResults.results.Add(new QueryResults() { hdr = hdr, src = src, url = url });
        }

        _results = tempResults;
      }
      catch (Exception ex)
      {
        _exception = BuildException(requestData, "ParseResponse", ex, _responseXml);
      }
    }
*/

/*
    #region Return Data

    private SearchResult _results;
    public SearchResult Results { get { return _results; } }

    [DataContract()]
    public class SearchResult
    {
      [DataMember()]
      public int count { get; set; }

      [DataMember()]
      public List<QueryResults> results { get; set; }
    }

    [DataContract()]
    public class QueryResults
    {
      [DataMember()]
      public string hdr { get; set; }

      [DataMember()]
      public string src { get; set; }

      [DataMember()]
      public string url { get; set; }
    }

    #endregion
*/
  }
}
