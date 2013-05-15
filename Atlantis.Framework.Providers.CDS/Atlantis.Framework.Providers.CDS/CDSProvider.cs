using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using Atlantis.Framework.CDS.Interface;
using Atlantis.Framework.CDS.Tokenizer;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Providers.Interface.CDS;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using Atlantis.Framework.Render.Pipeline.Interface;

namespace Atlantis.Framework.Providers.CDS
{
  public class CDSProvider : ProviderBase, ICDSProvider
  {
    private static readonly RenderPipelineManager _cdsWidgetRenderPipelineManager = new RenderPipelineManager();
    private static readonly Regex _validMongoObjectIdRegex = new Regex(@"^[0-9a-fA-F]{24}$", RegexOptions.Compiled);

    private readonly ISiteContext _siteContext;
    private readonly IShopperContext _shopperContext;

    static CDSProvider()
    {
      _cdsWidgetRenderPipelineManager.AddRenderHandler(new CDSWidgetConditionRenderHandler());
      _cdsWidgetRenderPipelineManager.AddRenderHandler(new CDSWidgetPlaceHolderRenderHandler());
      _cdsWidgetRenderPipelineManager.AddRenderHandler(new CDSWidgetConditionRenderHandler());
      _cdsWidgetRenderPipelineManager.AddRenderHandler(new CDSWidgetTokenRenderHandler());
    }

    public CDSProvider(IProviderContainer container) : base(container)
    {
      _siteContext = container.Resolve<ISiteContext>();
      _shopperContext = container.Resolve<IShopperContext>();
    }

    private bool IsValidMongoObjectId(string text)
    {
      bool result = false;
      if (text != null)
      {
        result = _validMongoObjectIdRegex.IsMatch(text);
      }
      return result;
    }

    private string ToQueryString(NameValueCollection nameValuePairs)
    {
      string queryString = string.Empty;
      
      if (nameValuePairs != null)
      {
        StringBuilder queryStringBuilder = new StringBuilder();

        for (int i = 0; i < nameValuePairs.Count; i++)
        {
          queryStringBuilder.AppendFormat(i == 0 ? "{0}={1}" : "&{0}={1}", nameValuePairs.Keys[i], nameValuePairs.Get(i));
        }

        queryString = queryStringBuilder.ToString();
      }

      return queryString;
    }

    private string ParseLegacyTokens(string cdsContent, Dictionary<string, string> customTokens)
    {
      CDSTokenizer tokenizer = new CDSTokenizer();
      return customTokens != null ? tokenizer.Parse(cdsContent, customTokens) : tokenizer.Parse(cdsContent);
    }

    private string ProcessQueryOverrides(string query, out bool bypassCache)
    {
      string finalQuery = query;
      bypassCache = false;

      if (HttpContext.Current != null)
      {
        DateTime activeDate;
        NameValueCollection queryString = HttpContext.Current.Request.QueryString;
        string docId = queryString["docid"];
        string qsDate = queryString["activedate"];
        if ((DateTime.TryParse(qsDate, out activeDate) || IsValidMongoObjectId(docId)) && _siteContext.IsRequestInternal)
        {
          bypassCache = true;
          NameValueCollection queryParams = new NameValueCollection();
          if (activeDate != default(DateTime))
          {
            queryParams.Add("activedate", activeDate.ToString("O"));
          }
          if (IsValidMongoObjectId(docId))
          {
            queryParams.Add("docid", docId);
          }
          if (queryParams.Count > 0)
          {
            string appendChar = finalQuery.Contains("?") ? "&" : "?";
            finalQuery += string.Concat(appendChar, ToQueryString(queryParams));
          }
        }
      }

      return finalQuery;
    }

    private string ProcessAndRenderRequest(string query, bool bypassCache, Dictionary<string, string> customTokens)
    {
      CDSRequestData requestData = new CDSRequestData(_shopperContext.ShopperId, string.Empty, string.Empty, _siteContext.Pathway, _siteContext.PageCount, query);

      string finalContent = string.Empty;

      CDSResponseData responseData = bypassCache ? (CDSResponseData)Engine.Engine.ProcessRequest(requestData, CDSProviderEngineRequests.CDSRequestType) : (CDSResponseData)DataCache.DataCache.GetProcessRequest(requestData, CDSProviderEngineRequests.CDSRequestType);

      if (responseData.IsSuccess)
      {
        string content = ParseLegacyTokens(responseData.ResponseData, customTokens);

        IRenderContent renderContent = new CDSWidgetRenderContent(content);

        IProcessedRenderContent processedRenderContent = _cdsWidgetRenderPipelineManager.RenderContent(renderContent, Container);

        finalContent = processedRenderContent.Content;
      }

      return finalContent;
    }

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    public T GetModel<T>(string query) where T : new()
    {
      return GetModel<T>(query, null);
    }

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    public T GetModel<T>(string query, Dictionary<string, string> customTokens) where T : new()
    {
      T model = new T();
      var serializer = new JavaScriptSerializer();

      try
      {
        string finalContent = ProcessAndRenderRequest(query, false, customTokens);
        model = serializer.Deserialize<T>(finalContent);
      }
      catch (Exception ex)
      {
        Engine.Engine.LogAtlantisException(new AtlantisException(ex.Source, string.Empty, ErrorEnums.GeneralError.ToString(), ex.Message, query, _shopperContext.ShopperId, string.Empty, string.Empty, _siteContext.Pathway, _siteContext.PageCount));
      }

      return model;
    }

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    public string GetJson(string query)
    {
      return GetJson(query, null);
    }

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    public string GetJson(string query, Dictionary<string, string> customTokens)
    {
      string finalContent = string.Empty;

      bool bypassCache;
      query = ProcessQueryOverrides(query, out bypassCache);

      try
      {
        finalContent = ProcessAndRenderRequest(query, bypassCache, customTokens);
      }
      catch (Exception ex)
      {
        Engine.Engine.LogAtlantisException(new AtlantisException(ex.Source, string.Empty, ErrorEnums.GeneralError.ToString(), ex.Message, query, string.Empty, string.Empty, string.Empty, string.Empty, 0));
      }

      return finalContent;
    }
  }
}