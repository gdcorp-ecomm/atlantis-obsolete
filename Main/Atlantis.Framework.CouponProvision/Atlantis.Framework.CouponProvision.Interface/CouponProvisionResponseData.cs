using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.CouponProvision.Interface
{
  public class CouponProvisionResponseData : IResponseData
  {
    private AtlantisException AtlantisException { get; set; }
    private string Response { get; set; }

    public CouponProvisionResponseData(string response)
    {
      this.Response = response;
    }

    public CouponProvisionResponseData(AtlantisException atlantisException)
    {
      this.AtlantisException = atlantisException;
    }

    public CouponProvisionResponseData(RequestData requestData, Exception exception)
    {
      this.AtlantisException = new AtlantisException(
        requestData, 
        "CouponProvisionResponseData",
        exception.Message, 
        requestData.ToXML());
    }

    public string ToXML()
    {
      return this.Response;
    }

    public AtlantisException GetException()
    {
      return this.AtlantisException;
    }
  }
}
