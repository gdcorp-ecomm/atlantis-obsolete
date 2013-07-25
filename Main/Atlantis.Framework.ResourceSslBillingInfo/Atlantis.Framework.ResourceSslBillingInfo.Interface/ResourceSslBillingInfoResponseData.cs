using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ResourceSslBillingInfo.Interface
{
  public class ResourceSslBillingInfoResponseData : IResponseData
  {
    #region Properties
    private AtlantisException _exception = null;
    public ResourceBillingInfo ResourceBillingInfo { get; private set; }
    public bool IsSuccess { get { return _exception == null; } }
    #endregion

    public ResourceSslBillingInfoResponseData(ResourceBillingInfo rbi)
    {
      ResourceBillingInfo = rbi;
    }

    public ResourceSslBillingInfoResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public ResourceSslBillingInfoResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData
        , "ResourceSslBillingInfoResponseData"
        , exception.Message
        , requestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException("ToXML not implemented in ResourceSslBillingInfoResponseData");
    }

    public AtlantisException GetException()
    {
      return _exception;
    }
    #endregion
  }
}
