using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.BazaarLinks.Interface
{
  public class BazaarLinksResponseData : IResponseData
  {
    private bool _success = false;
    private AtlantisException _ex;
    private List<BazaarResponseLink> _resourceLinks = new List<BazaarResponseLink>();
    private List<BazaarResponseLink> _discussionLinks = new List<BazaarResponseLink>();

    public BazaarLinksResponseData(IEnumerable<BazaarResponseLink> resourceLinks, IEnumerable<BazaarResponseLink> discussionLinks)
    {
      if (resourceLinks != null)
      {
        _resourceLinks.AddRange(resourceLinks);
      }

      if (discussionLinks != null)
      {
        _discussionLinks.AddRange(discussionLinks);
      }

      _success = true;
    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public int ResourceLinkTotal
    {
      get { return _resourceLinks.Count; }
    }

    public int DiscussionLinkTotal
    {
      get { return _discussionLinks.Count; }
    }

    public IEnumerable<BazaarResponseLink> ResourceLinks
    {
      get { return _resourceLinks; }
    }

    public IEnumerable<BazaarResponseLink> DiscussionLinks
    {
      get {return _discussionLinks;}
    }

    public BazaarLinksResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public BazaarLinksResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "BazaarLinksResponseData", ex.Message, oRequestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion
  }
}
