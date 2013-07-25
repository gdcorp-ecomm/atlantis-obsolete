using System;
using System.Collections.Generic;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DomainsBotSemantic.Interface
{
  public class DomainsBotSemanticRequestData : RequestData
  {
    #region Properties

    private string _domainNameToSearch = String.Empty;
    public string DomainNameToSearch
    {
      get { return _domainNameToSearch; }
      set { _domainNameToSearch = value; }
    }

    private List<string> _dotTypesToSearch = new List<string>();
    public List<string> DotTypesToSearch
    {
      get { return _dotTypesToSearch; }
      set { _dotTypesToSearch = value; }
    }

    private bool _addDashes = false;
    public bool AddDashes
    {
      get { return _addDashes; }
      set { _addDashes = value; }
    }

    private bool _addRelated = false;
    public bool AddRelated
    {
      get { return _addRelated; }
      set { _addRelated = value; }
    }

    private bool _addCompound = false;
    public bool AddCompound
    {
      get { return _addCompound; }
      set { _addCompound = value; }
    }

    private bool _addVariations = false;
    public bool AddVariations
    {
      get { return _addVariations; }
      set { _addVariations = value; }
    }

    private bool _removeKeys = false;
    public bool RemoveKeys
    {
      get { return _removeKeys; }
      set { _removeKeys = value; }
    }

    private int _maxResults = 10;
    public int MaxResults
    {
      get { return _maxResults; }
      set { _maxResults = value; }
    }

    private int _timeout = 2500;
    public int Timeout
    {
      get { return _timeout; }
      set { _timeout = value; }
    }

    #endregion 

    #region Constructors

    public DomainsBotSemanticRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
    }

    public DomainsBotSemanticRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         string domainNameToSearch,
                                         IEnumerable<string> dotTypesToSearch,
                                         int maxResults)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._domainNameToSearch = domainNameToSearch;
      AddDotTypes(dotTypesToSearch);
      this._maxResults = maxResults;
    }

    public DomainsBotSemanticRequestData(string sShopperID,
                                         string sSourceURL,
                                         string sOrderID,
                                         string sPathway,
                                         int iPageCount,
                                         string domainNameToSearch,
                                         string dotTypeToSearch,
                                         int maxResults)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._domainNameToSearch = domainNameToSearch;
      AddDotType(dotTypeToSearch);
      this._maxResults = maxResults;
    }

    #endregion

    #region Public Methods

    public void AddDotType(string dotType)
    {
      if (!String.IsNullOrEmpty(dotType))
      {
        this._dotTypesToSearch.Add(dotType.Trim().ToLowerInvariant());
      }
    }

    public void AddDotTypes(IEnumerable<string> dotTypes)
    {
      if (dotTypes != null)
      {
        foreach (string dotType in dotTypes)
        {
          AddDotType(dotType);
        }
      }
    }

    public string GetDotTypesString()
    {
      string result = String.Empty;
      int itemsCount = this._dotTypesToSearch.Count;
      if (itemsCount > 0)
      {
        int lastItem = itemsCount > 0 ? itemsCount - 1 : 0;
        for (int i = 0; i < itemsCount; i++)
        {
          result += this._dotTypesToSearch[i];
          if (i < lastItem)
          {
            result += ",";
          }
        }
      }
      return result;
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Private Methods
    #endregion
  }
}
