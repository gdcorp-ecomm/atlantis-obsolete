using System;
using Atlantis.Framework.Interface;
using System.Data;

namespace Atlantis.Framework.SBSDomainRegistrar.Interface
{
  public class SBSDomainRegistrarResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    public DataTable ResultData { get; private set; }

    public SBSDomainRegistrarResponseData(DataTable resultData)
    {
      _exception = null;
      ResultData = resultData;

      if ((ResultData != null) && (ResultData.Rows.Count >0))
      {
        foreach (DataRow dr in ResultData.Rows)
        {
          _privateLabelId = dr["PrivateLabelID"].ToString();
          _status = dr["status"].ToString();
          break;
        }
      }
    }

    private string _privateLabelId = string.Empty;
    public string PrivateLabelId
    {
      get { return _privateLabelId; }
    }

    private string _status = string.Empty;
    public string Status
    {
      get { return _status; }
    }

    private bool? _isActive;
    public bool IsActive
    {
      get
      {
        if (!_isActive.HasValue)
        {
          _isActive = this._status.Equals("active", StringComparison.InvariantCultureIgnoreCase);
        }

        return _isActive.Value;
      }
    }

    public SBSDomainRegistrarResponseData(RequestData requestData, Exception exception)
    {
      string domain = string.Empty;
      string requestType = string.Empty;
      SBSDomainRegistrarRequestData request = requestData as SBSDomainRegistrarRequestData;

      if (request != null)
      {
        domain = request.Domain;
      }

      string data = requestData.ShopperID + ":domain=" + domain + ":" + requestType;
      string description = exception.Message;
      _exception 
        = new AtlantisException("SBSDomainRegistrarRequest", requestData.SourceURL, "0", description, data,
        requestData.ShopperID, requestData.OrderID, string.Empty, 
        requestData.Pathway, requestData.PageCount);
    }

    #region IResponseData Members

    public string ToXML()
    {
      return "<SBSDomainRegistrar PrivateLabelId=\"" + PrivateLabelId + "\" />";
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion
  }
}
