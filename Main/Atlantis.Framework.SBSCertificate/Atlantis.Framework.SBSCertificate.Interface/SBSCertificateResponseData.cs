using System;
using Atlantis.Framework.Interface;
using System.Data;

namespace Atlantis.Framework.SBSCertificate.Interface
{
  public class SBSCertificateResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    public DataTable ResultData { get; private set; }

    public SBSCertificateResponseData(DataTable resultData)
    {
      _exception = null;
      ResultData = resultData;
    }

    public bool HasCertificate
    {
      get { return ((ResultData != null) && (ResultData.Rows.Count > 0)); }
    }

    public SBSCertificateResponseData(RequestData requestData, Exception exception)
    {
      string domain = string.Empty;
      string requestType = string.Empty;
      SBSCertificateRequestData sbsRequest = requestData as SBSCertificateRequestData;
      if (sbsRequest != null)
      {
        domain = sbsRequest.Domain;
        requestType = sbsRequest.RequestType;
      }

      string data = requestData.ShopperID + ":domain=" + domain + ":" + requestType;
      string description = exception.Message;
      _exception = new AtlantisException("SBSCertificateRequest", requestData.SourceURL, "0", description, data,
        requestData.ShopperID, requestData.OrderID, string.Empty, requestData.Pathway, requestData.PageCount);
    }

    #region IResponseData Members

    public string ToXML()
    {
      return "<SBSCertificate HasCertificate=\"" + HasCertificate.ToString() + "\" />";
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion
  }
}
