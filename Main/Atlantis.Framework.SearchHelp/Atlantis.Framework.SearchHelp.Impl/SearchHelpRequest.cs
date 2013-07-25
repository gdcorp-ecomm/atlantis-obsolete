using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.SearchHelp.Interface;
using Atlantis.Framework.Interface;
using System.Xml;

namespace Atlantis.Framework.SearchHelp.Impl
{
  public class SearchHelpRequest : IRequest
  {

    #region IRequest Members
  
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      SearchHelpResponseData oResponseData = null;

      try
      {
        SearchHelpRequestData request = (SearchHelpRequestData)oRequestData;

        string baseUrl = ((WsConfigElement)oConfig).WSURL;
        SearchHelpResults[] result = GetHelpReults(request, baseUrl);

        oResponseData = new SearchHelpResponseData(result);
       
      }
      catch (Exception ex)
      {
        oResponseData = new SearchHelpResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    private static SearchHelpResults[] GetHelpReults(SearchHelpRequestData request, string baseUrl)
    {
      XmlDocument xml = new XmlDocument();

      string searchUrl = GetSearchURL(request, baseUrl);
      XmlTextReader reader = new XmlTextReader(searchUrl);

      xml.Load(reader);

      List<SearchHelpResults> results = new List<SearchHelpResults>();
      XmlNodeList nodes = xml.SelectNodes("//GSP/RES/R");

      if (nodes != null)
      {
        string articleNode;
        bool success;
        bool validHelpId;
        uint helpArticleId;
        string title;
        string description;
        SearchHelpResults result;
        foreach (XmlNode node in nodes)
        {
          try
          {
            success = false;
            title = null;
            description = null;
            articleNode = node.SelectSingleNode("U").InnerXml.Replace("http://help.godaddy.com/article/", string.Empty);

            validHelpId = UInt32.TryParse(articleNode, out helpArticleId);

            if (!string.IsNullOrEmpty(node.SelectSingleNode("T").InnerXml))
            {
              title = node.SelectSingleNode("T").InnerXml;
            }
            
            if (!string.IsNullOrEmpty(node.SelectSingleNode("S").InnerXml))
            {
              description = node.SelectSingleNode("S").InnerXml;
            }

            if (validHelpId &&
              !string.IsNullOrEmpty(title) &&
              !string.IsNullOrEmpty(description))
            {
              success = true;
            }
            
            if (success)
            {
              result = new SearchHelpResults(helpArticleId, title, description);
              results.Add(result);
            }
          }
          catch 
          {
          }
        }
      }

      return results.ToArray();
    }

    private static string GetSearchURL(SearchHelpRequestData request, string baseUrl)
    {
      StringBuilder searchUrl = new StringBuilder();
      searchUrl.Append(baseUrl);
      searchUrl.Append("?");
      searchUrl.Append("site=" + request.Site);
      searchUrl.Append("&output=" + request.Output);
      searchUrl.Append("&oe=" + request.Oe);
      searchUrl.Append("&ie=" + request.Ie);
      searchUrl.Append("&client=" + request.Client);
      searchUrl.Append("&filter=" + request.Filter);
      searchUrl.Append("&q=" + request.SearchWords);
      searchUrl.Append("&start=" + request.StartIndex.ToString());
      searchUrl.Append("&num=" + request.MaxRecords.ToString());
      return searchUrl.ToString();
    }

    #endregion
  }
}
