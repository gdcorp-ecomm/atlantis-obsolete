using System;
using System.Data;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYARenewalDomains.Interface
{
  public class MYARenewalDomainsResponseData : IResponseData
  {
    private DataSet _ds = null;
    private AtlantisException _atlException = null;

    public MYARenewalDomainsResponseData(DataSet ds)
    {
      _ds = ds;
      _isSuccess = true;
    }

    public MYARenewalDomainsResponseData(AtlantisException exAtlantis)
    {
      _atlException = exAtlantis;
    }

    public MYARenewalDomainsResponseData(DataSet ds, RequestData oRequestData, Exception ex)
    {
      _ds = ds;
      _atlException = new AtlantisException(oRequestData, "MYARenewalDomainsResponseData", ex.Message, string.Empty);
    }

    private bool _isSuccess = false;
    public bool IsSuccess
    {
      get
      {
        return _isSuccess;
      }
    }

    public DataSet RenewalDomains
    {
      get
      {
        return _ds;
      }
    }

    #region IResponseData Members

    public AtlantisException GetException()
    {
      return _atlException;
    }

    public string ToXML()
    {
      return string.Empty;
    }

    #endregion
  }
}
