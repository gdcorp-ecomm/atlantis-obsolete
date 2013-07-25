using System;
using System.Security.Cryptography;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAGetUpgradeDomain.Interface
{
  public class MYAGetUpgradeDomainRequestData : RequestData
  {
    #region Properties


    private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
    private int _numRows = 10;
    private bool _returnAll = false;

    public TimeSpan RequestTimeout
    {
      get { return _requestTimeout; }
      set { _requestTimeout = value; }
    }

    public int NumRows
    {
      get { return _numRows; }
      set { _numRows = value; }
    }

    public bool ReturnAll
    {
      get { return _returnAll; }
      set { _returnAll = value; }
    }
    #endregion

    #region Constructor
    public MYAGetUpgradeDomainRequestData(string shopperId,
                                  string sourceUrl,
                                  string orderId,
                                  string pathway,
                                  int pageCount,
                                  int numRows,
                                  bool returnAll)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _numRows = numRows;
      _returnAll = returnAll;
    }
    #endregion

    public override string GetCacheMD5()
    {
      throw new NotImplementedException("GetCacheMD5 not implemented in MYAGetUpgradeDomainRequestData");
    }
  }
}
