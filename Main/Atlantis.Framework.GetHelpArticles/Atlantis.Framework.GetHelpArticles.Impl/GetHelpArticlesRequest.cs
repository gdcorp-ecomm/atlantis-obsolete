using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.GetHelpArticles.Interface;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GetHelpArticles.Impl.HelpWS;
using System.Xml;

namespace Atlantis.Framework.GetHelpArticles.Impl
{
  public class GetHelpArticlesRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetHelpArticlesResponseData oResponseData = null;

      try
      {
        GetHelpArticlesRequestData request = (GetHelpArticlesRequestData)oRequestData;
        HelpWS.HelpCenter service = new HelpCenter();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        HelpWS.Article[] articles = service.get_articles(request.ArticleIds, "GoDaddy", new ArticleOptions());

        GetHelpArticlesResult[] articleResults = null;

        if (articles != null)
        {
          articleResults = Array.ConvertAll<Article, GetHelpArticlesResult>(
            articles, new Converter<Article, GetHelpArticlesResult>(ConvertGetHelpAritclesResult));
        }

        oResponseData = new GetHelpArticlesResponseData(articleResults);

      }
      catch (Exception ex)
      {
        oResponseData = new GetHelpArticlesResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    private static GetHelpArticlesResult ConvertGetHelpAritclesResult(Article article)
    {
      GetHelpArticlesResult result = null;

      if (article != null)
      {
        result = new GetHelpArticlesResult(article.id, article.title, article.tags, article.description, article.content, article.topic_ids);
      }

      return result;
    }

    #endregion
  }
}
