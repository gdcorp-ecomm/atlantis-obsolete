using System;
using System.Collections.Generic;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DomainsBotTypo.Interface
{
  public class DomainsBotTypoResponseData : IResponseData
  {
    #region Properties

    private AtlantisException _exception = null;

    private List<string> _domains = new List<string>();
    public List<string> Domains
    {
      get
      {
        return _domains;
      }
    }

    private int _availableResultsCount = 0;
    public int AvailableResults
    {
      get { return _availableResultsCount; }
    }

    #endregion

    #region Constructors

    public DomainsBotTypoResponseData(int availableResultsCount)
    {
      this._availableResultsCount = availableResultsCount;
    }

    public DomainsBotTypoResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public DomainsBotTypoResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "DomainsBotTypoResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }

    #endregion

    #region Public Methods
    
    public void AddDomain(string domain)
    {
      this._domains.Add(domain);
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
