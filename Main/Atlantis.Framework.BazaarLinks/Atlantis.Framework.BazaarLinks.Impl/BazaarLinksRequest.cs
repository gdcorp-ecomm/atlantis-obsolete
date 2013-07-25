using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.BazaarLinks.Interface;
using Atlantis.Framework.BazaarLinks.Impl.BazaarWS;
using System.Collections.Generic;

namespace Atlantis.Framework.BazaarLinks.Impl
{
  public class BazaarLinksRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      BazaarLinksResponseData oResponseData = null;

      try
      {
        BazaarLinksRequestData request = (BazaarLinksRequestData)oRequestData;
        BazaarWebService service = new BazaarWebService();
        service.Url = ((WsConfigElement)oConfig).WSURL;

        BazaarWS.BazaarLinks links = service.GetBazaarLinks(request.ResourceCount, request.DiscussionCount);
        if (links.BazaarState.Status == StatusCode.Success)
        {
          BazaarResponseLink[] resourceLinks = null;
          if (links.ResourceLinks != null)
          {
            resourceLinks = Array.ConvertAll<BazaarLink, BazaarResponseLink>(
              links.ResourceLinks, new Converter<BazaarLink, BazaarResponseLink>(ConvertBazaarLink));
          }

          BazaarResponseLink[] discussionLinks = null;
          if (links.DiscussionLinks != null)
          {
            discussionLinks = Array.ConvertAll<BazaarLink, BazaarResponseLink>(
              links.DiscussionLinks, new Converter<BazaarLink, BazaarResponseLink>(ConvertBazaarLink));
          }

          oResponseData = new BazaarLinksResponseData(resourceLinks, discussionLinks);
        }
        else
        {
          string message = "Bazaar Status: " + links.BazaarState.Status.ToString() + ": " +
            links.BazaarState.Message;
          string stack = string.Empty;
          if (links.BazaarState.StackTrace != null)
          {
            stack = links.BazaarState.StackTrace;
          }
          AtlantisException atlEx = new AtlantisException(request, "BazaarLinksRequest.RequestHandler", message, stack);
          oResponseData = new BazaarLinksResponseData(atlEx);
        }

        
      }
      catch (Exception ex)
      {
        oResponseData = new BazaarLinksResponseData(oRequestData, ex);
      }

      return oResponseData;

    }

    #endregion

    private static BazaarResponseLink ConvertBazaarLink(BazaarLink link)
    {
      BazaarResponseLink result = null;
      if (link != null)
      {
        result = new BazaarResponseLink(link.TitleText, link.TitleUrl);
      }
      return result;
    }
  }
}
