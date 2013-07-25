using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetFeaturedDiscussions.Interface
{
  public class GetFeaturedDiscussionsResponseData : IResponseData
  {

    private bool _success = false;
    private AtlantisException _ex;
    private List<GetFeaturedDiscussionsLink> _wsFeaturedDiscussionLinks = new List<GetFeaturedDiscussionsLink>();

    public GetFeaturedDiscussionsResponseData(IEnumerable<GetFeaturedDiscussionsLink> wsFeaturedDiscussionLinks)
    {
      if (wsFeaturedDiscussionLinks != null)
        _wsFeaturedDiscussionLinks.AddRange(wsFeaturedDiscussionLinks);

      _success = true;
    }

    public bool IsSuccess
    {
      get { return _success; }
    }

    public int DiscussionCount
    {
      get { return _wsFeaturedDiscussionLinks.Count; }
    }

    public IEnumerable<GetFeaturedDiscussionsLink> FeaturedDiscussionLinks
    {
      get { return _wsFeaturedDiscussionLinks; }
    }

    public GetFeaturedDiscussionsResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public GetFeaturedDiscussionsResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "GetFeaturedDiscussionsResponseData", ex.Message, oRequestData.ToXML());
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
