using System;
using System.Collections.Generic;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DomainsBotSemantic.Interface
{
  public class DomainsBotSemanticResponseData : IResponseData
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
    public int AvailableResultsCount
    {
      get { return _availableResultsCount; }
    }

    #endregion

    #region Constructors

    public DomainsBotSemanticResponseData(int availableResultsCount)
    {
      this._availableResultsCount = availableResultsCount;
    }

    public DomainsBotSemanticResponseData(AtlantisException atlantisException)
    {
      this._exception = atlantisException;
    }

    public DomainsBotSemanticResponseData(RequestData requestData, Exception exception)
    {
      this._exception = new AtlantisException(requestData,
                                   "DomainsBotSemanticResponseData",
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
