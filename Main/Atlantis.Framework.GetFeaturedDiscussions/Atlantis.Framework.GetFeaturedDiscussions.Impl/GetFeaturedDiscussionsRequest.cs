using System;
using System.Collections.Generic;
using Atlantis.Framework.GetFeaturedDiscussions.Interface;
using Atlantis.Framework.GetFeaturedDiscussions.Impl.ForumWS;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetFeaturedDiscussions.Impl
{
  public class GetFeaturedDiscussionsRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetFeaturedDiscussionsResponseData oResponseData = null;

      try
      {
        GetFeaturedDiscussionsRequestData request = (GetFeaturedDiscussionsRequestData)oRequestData;
        ForumWS.Administration service = new Administration();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        ForumWS.WsFeaturedDiscussion[] discussions = service.GetFeaturedDiscussions(request.ForumID);

        GetFeaturedDiscussionsLink[] discussionLinks = null;
        
        if (discussions != null)
        {
          discussionLinks = Array.ConvertAll<WsFeaturedDiscussion, GetFeaturedDiscussionsLink>(
            discussions, new Converter<WsFeaturedDiscussion, GetFeaturedDiscussionsLink>(ConvertFeaturedDiscussionsLink));

        }
        oResponseData = new GetFeaturedDiscussionsResponseData(discussionLinks);
        

      }
      catch (Exception ex)
      {

        oResponseData = new GetFeaturedDiscussionsResponseData(oRequestData, ex);
      }

      return oResponseData;
      
    }

    #endregion

    private static GetFeaturedDiscussionsLink ConvertFeaturedDiscussionsLink(WsFeaturedDiscussion link)
    {
      GetFeaturedDiscussionsLink result = null;
      if (link != null)
      {
        result = new GetFeaturedDiscussionsLink(link.ForumId, link.DiscussionId, link.Title, link.DiscussionCreateDate);
      }
      return result;
    }
  }
}
