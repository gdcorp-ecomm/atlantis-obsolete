using System;
using System.Collections.Generic;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DomainsBotTypo.Interface
{
  public class DomainsBotTypoRequestData : RequestData
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

    private bool _doCharacterReplacement = false;
    public bool DoCharacterReplacement
    {
      get { return _doCharacterReplacement; }
      set { _doCharacterReplacement = value; }
    }

    private bool _doCharacterPermutation = false;
    public bool DoCharacterPermutation
    {
      get { return _doCharacterPermutation; }
      set { _doCharacterPermutation = value; }
    }

    private bool _doCharacterOmission = false;
    public bool DoCharacterOmission
    {
      get { return _doCharacterOmission; }
      set { _doCharacterOmission = value; }
    }

    private bool _useDoubledCharacter = false;
    public bool UseDoubledCharacter
    {
      get { return _useDoubledCharacter; }
      set { _useDoubledCharacter = value; }
    }

    private bool _useMissingDot = false;
    public bool UseMissingDot
    {
      get { return _useMissingDot; }
      set { _useMissingDot = value; }
    }

    private bool _excludeNumbers = true;
    public bool ExcludeNumbers
    {
      get { return _excludeNumbers; }
      set { _excludeNumbers = value; }
    }

    private int _maxResults = 10;
    public int MaxResults
    {
      get { return _maxResults; }
      set { _maxResults = value; }
    }

    #endregion

    #region Constructors

    public DomainsBotTypoRequestData(string sShopperID,
                                     string sSourceURL,
                                     string sOrderID,
                                     string sPathway,
                                     int iPageCount) : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
    }

    public DomainsBotTypoRequestData(string sShopperID,
                                     string sSourceURL,
                                     string sOrderID,
                                     string sPathway,
                                     int iPageCount,
                                     string domainNameToSearch,
                                     IEnumerable<string> dotTypesToSearch,
                                     int maxResults) : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      this._domainNameToSearch = domainNameToSearch;
      AddDotTypes(dotTypesToSearch);
      this._maxResults = maxResults;
    }

    public DomainsBotTypoRequestData(string sShopperID,
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
      if(!String.IsNullOrEmpty(dotType))
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
      if(itemsCount > 0)
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
