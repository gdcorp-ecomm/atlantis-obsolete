using System;
using System.Data;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.RenewalsGetRenewingDomains.Interface
{
  public class RenewalsGetRenewingDomainsResponseData : IResponseData
  {
    private DataSet _ds = null;
    private AtlantisException _atlException = null;

    public RenewalsGetRenewingDomainsResponseData(DataSet ds)
    {
      _ds = ds;
      _isSuccess = true;
    }

    public RenewalsGetRenewingDomainsResponseData(AtlantisException exAtlantis)
    {
      _atlException = exAtlantis;
    }

    public RenewalsGetRenewingDomainsResponseData(DataSet ds, RequestData oRequestData, Exception ex)
    {
      _ds = ds;
      _atlException = new AtlantisException(oRequestData, "RenewalsGetRenewingDomainsResponseData", ex.Message, string.Empty);
    }

    private bool _isSuccess = false;
    public bool IsSuccess
    {
      get
      {
        return _isSuccess;
      }
    }

    public DataSet RenewingDomainListSet
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
