using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.SocialMediaContestGetVideoIDS.Interface
{
  public class SocialMediaContestGetVideoIDSResponseData : IResponseData
  {

    private AtlantisException _exception = null;
    private bool _success = false;
    private List<int> _socialMediaIds;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public List<int> SocialMediaIds
    {
      get { return _socialMediaIds; }
    }

    public SocialMediaContestGetVideoIDSResponseData(List<int> mediaIds)
    {
      _socialMediaIds = mediaIds;
      _success = true;
    }

    public SocialMediaContestGetVideoIDSResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public SocialMediaContestGetVideoIDSResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "SocialMediaContestGetVideoIDSResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }

}
