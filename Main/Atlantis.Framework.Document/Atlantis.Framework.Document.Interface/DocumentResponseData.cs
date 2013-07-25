using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using System.Xml;
using System.Text.RegularExpressions;
using System.IO;

namespace Atlantis.Framework.Document.Interface
{
  public class DocumentResponseData : IResponseData
  {
    private string _html = string.Empty;
    private Regex _styleEx;
    private Regex _bodyEx;
    private Regex _classEx;
    private string _body = null;
    private string _bodyClass = null;
    private string _styles = null;
    AtlantisException _exception;

    public DocumentResponseData(string html)
    {
      if (!string.IsNullOrEmpty(html))
      {
        _html = html;
      }
      _body = String.Empty;
      _styles = String.Empty;
      _bodyClass = String.Empty;
      _styleEx = new Regex("<style.*?>(?<styles>.*?)</style>", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
      _bodyEx = new Regex("<body(?<bodyattributes>.*?)>(?<body>.*?)</body>", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
      _classEx = new Regex("class.*?=.*?\"(?<bodyclass>.*?)\"", RegexOptions.Singleline | RegexOptions.IgnoreCase | RegexOptions.Compiled);
      ParseDocument();
    }

    public DocumentResponseData(string html, AtlantisException exAtlantis)
      : this(html)
    {
      _html = html;
      _exception = exAtlantis;
    }

    public DocumentResponseData(string html, RequestData requestData, Exception ex)
      : this(html)
    {
      _html = html;
      _exception = new AtlantisException(requestData, "DocumentResponseData", ex.Message, requestData.ToXML());
    }

    private void ParseDocument()
    {
      Match styleMatch = _styleEx.Match(_html);
      if (styleMatch.Success)
      {
        _styles = styleMatch.Value;
      }
      else
      {
        _styles = String.Empty;
      }

      Match bodyMatch = _bodyEx.Match(_html);

      if (bodyMatch.Success)
      {
        _body = bodyMatch.Groups[2].Captures[0].Value;
        string bodyAttributes = bodyMatch.Groups[1].Captures[0].Value;

        Match classMatch = _classEx.Match(bodyAttributes);
        if (classMatch.Success)
        {
          _bodyClass = classMatch.Groups[1].Captures[0].Value;
        }
        else
        {
          _bodyClass = String.Empty;
        }
      }
      else
      {
        if (_styles.Length > 0)
          _body = _html.Replace(_styles, "");
        else
          _body = _html;

        _bodyClass = String.Empty;
      }
    }

    public string Html
    {
      get { return _html; }
    }

    public string Styles
    {
      get { return _styles; }
    }

    public string Body
    {
      get { return _body; }
    }

    public string BodyStyle
    {
      get { return _bodyClass; }
    }

    #region IResponseData Members

    public AtlantisException GetException()
    {
      return _exception;
    }

    public string ToXML()
    {
      StringBuilder sbResult = new StringBuilder();
      XmlTextWriter xtwResult = new XmlTextWriter(new StringWriter(sbResult));
      xtwResult.WriteElementString("Html", _html);
      return sbResult.ToString();
    }

    #endregion
  }
}
