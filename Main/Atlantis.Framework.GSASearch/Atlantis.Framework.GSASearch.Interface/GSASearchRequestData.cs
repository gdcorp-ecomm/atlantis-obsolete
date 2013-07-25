using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DataCache;
using System.Collections;

namespace Atlantis.Framework.GSASearch.Interface
{
  public class GSASearchRequestData : RequestData
  {
    #region Constants

    private const string DEFAULT_GSA_BASE_URL = "http://10.6.7.102/search";
    private const int DEFAULT_GSA_TIMEOUT = 5;

    #endregion

    #region Properties

    /// <summary>
    /// Partitions were adopted as a naming convention to manage the single GSA web garden 
    /// being a shared resource between DEV, TEST and PROD.  Partitioning facilitates applications
    /// being aware of ONE name for an entity, but in this triplet, and on GSAs, that ONE name is
    /// actually 3.  Which of the 3 is chosen is depends on the partition set for each 
    /// environment (DEV, TEST, PROD, OTE, or staging).
    /// 
    /// The following GSA entities are partitioned, and throughout 
    /// this code will be refered to as 'partitioned entities':
    /// 
    ///   1. Site query param (aka Collection)
    ///   2. Client query param (aka Front-End)
    ///   3. ProxyStyleSheet query param (aka XSLT in the Front-End)
    /// 
    /// Example: every application will create 3 collections with the following naming convention:
    /// 
    ///  1. &lt;collection name&gt;-dev
    ///  2. &lt;collection name&gt;-test
    ///  3. &lt;collection name&gt;-prod
    ///  
    ///  The same applies to Front-Ends:
    /// 
    ///  1. &lt;front-end name&gt;-dev
    ///  2. &lt;front-end name&gt;-test
    ///  3. &lt;front-end name&gt;-prod
    ///  
    /// </summary>
    public class Partition
    {
      public string Name;
      public string Suffix;
    }
    /// <summary>
    /// List of Partitions that are supported
    /// </summary>
    private static List<Partition> PartitionList = new List<Partition>()
    {
      new Partition() { Name = "dev", Suffix = "-dev" },
      new Partition() { Name = "test", Suffix = "-test" },
      new Partition() { Name = "prod", Suffix = "-prod" },
      new Partition() { Name = "ote", Suffix = "-prod" }
    };

    private string _applianceKey = "HelpGSA";
    public string ApplianceKey
    {
      get { return _applianceKey; }
      set { _applianceKey = value; }
    }

    /// <summary>
    /// The SearchQueryMap allows you to define and override URL query parameters that are passed to the GSA.
    /// The get operation returns a copy of the map.  You can change the values returned in the copy, and
    /// use the set operation to update the SearchQueryMap for your request.
    /// </summary>
    private NameValueCollection _searchQueryMap = new NameValueCollection();
    public NameValueCollection SearchQueryMap
    {
      get
      {
        return new NameValueCollection(_searchQueryMap); // return a copy, so that validation can be done on the set
      }
      set
      {
        ValidateSearchQueryMap(value);
        _searchQueryMap = value;
      }
    }

    /// <summary>
    /// This is the base URL that points to the GSA.  You can modify it for your particular request should you not 
    /// be using the same GSA as all other GoDaddy applications.  If you modify it, you take on the responsibility of
    /// providing your own failover mechanism, should your GSA goes down.
    /// </summary>
    private string _gSABaseURL;
    public string GSABaseURL
    {
      get
      {
        if (_gSABaseURL == null)
        {
          _gSABaseURL = (DataCache.DataCache.GetAppSetting("GSA_BASE_QUERY_URL") ?? String.Empty).Trim();
          if (_gSABaseURL.Equals(String.Empty))
          {
            var aex = new AtlantisException(this, "GSASearchRequestData.GSABaseURL", "GSA_BASE_QUERY_URL is empty. Using default: \"" + DEFAULT_GSA_BASE_URL + "\"", _gSABaseURL);
            Engine.Engine.LogAtlantisException(aex);

            _gSABaseURL = DEFAULT_GSA_BASE_URL;
          }
        }
        return _gSABaseURL;
      }

      set
      {
        try
        {
          var u = new Uri(value); // validate as basic URL
        }
        catch (Exception ex)
        {
          throw new AtlantisException(this, "GSASearchRequestData.GSABaseURL", "Invalid URL", value, ex);
        }

        _gSABaseURL = value;
      }
    }

    /// <summary>
    /// This is the time that the request will wait for the GSA to complete the query request.
    /// It must always be larger than 1 second.
    /// </summary>
    private TimeSpan _requestTimeout = TimeSpan.MinValue;
    public TimeSpan RequestTimeout
    {
      get
      {
        if (_requestTimeout == TimeSpan.MinValue)
        {
          int temp;
          string val = DataCache.DataCache.GetAppSetting("GSA_TIMEOUT_IN_SEC") ?? String.Empty;
          int.TryParse(val, out temp);
          if ( temp < 1 )
          {
            var aex = new AtlantisException(this, "GSASearchRequestData.RequestTimeout", "GSA_TIMEOUT_IN_SEC must be greater than 0. Using default: \"" + DEFAULT_GSA_TIMEOUT + "\"", val);
            Engine.Engine.LogAtlantisException(aex);

            temp = DEFAULT_GSA_TIMEOUT;
          }
          _requestTimeout = new TimeSpan(0, 0, temp);
        }
        return _requestTimeout;
      }

      set
      {
        _requestTimeout = value;
      }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Constructs a GSA search request given a collection name and client.  The output value will be set to "xml_no_dtd".
    /// </summary>
    /// <param name="shopperId">atlantis request data shopperId</param>
    /// <param name="sourceUrl">atlantis request data sourceUrl</param>
    /// <param name="orderId">atlantis request data orderId</param>
    /// <param name="pathway">atlantis request data pathway</param>
    /// <param name="pageCount">atlantis request data page count</param>
    /// <param name="searchQuery">Query syntax, supplied to the GSA via &q=searchQuery</param>
    /// <param name="startIndex">Starting index of the search results, supplied to the GSA via &start=startIndex.  Must be greater than or equal to 0.</param>
    /// <param name="pageSize">Number of search results to return, supplied to the GSA via &num=pageSize.  Must be greater than 0.</param>
    /// <param name="collections">GSA collection names, WITHOUT the GoDaddy partitioning suffix. Will be supplied to the GSA via &site=collections.  The collections can be the form:
    /// 1. collectionname
    /// 2. collectionname0|collectionname1|collectionnameN
    /// 3. collectionname0.collectionname1.collectionnameN 
    /// 
    /// #1 is for a single collection
    /// #2 is for searching for results occurring in ANY of the N collections
    /// #3 is for searching for results occurring in ALL of the N collections</param>
    /// <param name="client">GSA front-end name, WITHOUT the GoDaddy partitioning suffix. Will be supplied to the GSA via &client=client-partition.name</param>
    public GSASearchRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string searchQuery, int startIndex, int pageSize, 
      string collections, string client
      ) : this(shopperId, sourceUrl, orderId, pathway, pageCount,
               searchQuery, startIndex, pageSize, 
               collections, client, "xml_no_dtd", null)
    {
    }

    /// <summary>
    /// Constructs a GSA search request given a collection name, client, and output
    /// Many applications will call this constructor
    /// </summary>
    /// <param name="shopperId">atlantis request data shopperId</param>
    /// <param name="sourceUrl">atlantis request data sourceUrl</param>
    /// <param name="orderId">atlantis request data orderId</param>
    /// <param name="pathway">atlantis request data pathway</param>
    /// <param name="pageCount">atlantis request data page count</param>
    /// <param name="searchQuery">Query syntax, supplied to the GSA via &q=searchQuery</param>
    /// <param name="startIndex">Starting index of the search results, supplied to the GSA via &start=startIndex.  Must be greater than or equal to 0.</param>
    /// <param name="pageSize">Number of search results to return, supplied to the GSA via &num=pageSize.  Must be greater than 0.</param>
    /// <param name="collections">GSA collection names, WITHOUT the GoDaddy partitioning suffix. Will be supplied to the GSA via &site=collections.  The collections can be the form:
    /// 1. collectionname
    /// 2. collectionname0|collectionname1|collectionnameN
    /// 3. collectionname0.collectionname1.collectionnameN 
    /// 
    /// #1 is for a single collection
    /// #2 is for searching for results occurring in ANY of the N collections
    /// #3 is for searching for results occurring in ALL of the N collections</param>
    /// <param name="client">GSA front-end name, WITHOUT the GoDaddy partitioning suffix. Will be supplied to the GSA via &client=client-partition.name</param>
    /// <param name="output">Supplied to the GSA via &output=output.  If null, the value will default to "xml_no_dtd".</param>
    public GSASearchRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string searchQuery, int startIndex, int pageSize, 
      string collections, string client, string output
      ) : this(shopperId, sourceUrl, orderId, pathway, pageCount,
               searchQuery, startIndex, pageSize, 
               collections, client, output, null)
    {
    }

    /// <summary>
    /// Constructs a GSA search request given a collection name, client, output, and proxystylesheet
    /// Many applications will call this constructor
    /// </summary>
    /// <param name="shopperId">atlantis request data shopperId</param>
    /// <param name="sourceUrl">atlantis request data sourceUrl</param>
    /// <param name="orderId">atlantis request data orderId</param>
    /// <param name="pathway">atlantis request data pathway</param>
    /// <param name="pageCount">atlantis request data page count</param>
    /// <param name="searchQuery">Query syntax, supplied to the GSA via &q=searchQuery</param>
    /// <param name="startIndex">Starting index of the search results, supplied to the GSA via &start=startIndex.  Must be greater than or equal to 0.</param>
    /// <param name="pageSize">Number of search results to return, supplied to the GSA via &num=pageSize.  Must be greater than 0.</param>
    /// <param name="collections">GSA collection names, WITHOUT the GoDaddy partitioning suffix. Will be supplied to the GSA via &site=collections.  The collections can be the form:
    /// 1. collectionname
    /// 2. collectionname0|collectionname1|collectionnameN
    /// 3. collectionname0.collectionname1.collectionnameN 
    /// 
    /// #1 is for a single collection
    /// #2 is for searching for results occurring in ANY of the N collections
    /// #3 is for searching for results occurring in ALL of the N collections</param>
    /// <param name="client">GSA front-end name, WITHOUT the GoDaddy partitioning suffix. Will be supplied to the GSA via &client=client-partition.name</param>
    /// <param name="output">Supplied to the GSA via &output=output.  If null, the value will default to "xml_no_dtd".</param>
    /// <param name="proxystylesheet">Supplied to the GSA via &proxystylesheet=proxystylesheet.  Note this must equal what is supplied to &client.</param>
    public GSASearchRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string searchQuery, int startIndex, int pageSize, 
      string collections, string client, string output, string proxystylesheet
      ) : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      var sqm = new NameValueCollection(){
        { GSAQueryTerms.Client, client },
        { GSAQueryTerms.Site, collections },
        { GSAQueryTerms.Query, searchQuery },
        { GSAQueryTerms.Start, startIndex.ToString() },
        { GSAQueryTerms.ResultsPerPage, pageSize.ToString() },
        { GSAQueryTerms.Output, output }
      };
      if (proxystylesheet != null)
      {
        sqm.Add(GSAQueryTerms.ProxyStyleSheet, proxystylesheet);
      }

      SearchQueryMap = sqm; // asign w/Validation & Correction
    }

    #endregion

    #region Validation functions

    private bool _validateStringGreaterThanOrEqualTo(string s, int min)
    {
      int iVal;
      bool b = int.TryParse(s, out iVal);
      return b && iVal >= min;
    }

    private bool _validateStringGreaterThanOrEqualToZero(string s)
    {
      return _validateStringGreaterThanOrEqualTo(s, 0);
    }

    private bool _validateStringGreaterThanOrEqualToOne(string s)
    {
      return _validateStringGreaterThanOrEqualTo(s, 1);
    }

    private bool _validateStringNotEmpty(string s)
    {
      return !((s ?? String.Empty).Trim().Equals(String.Empty));
    }

    /// <summary>
    /// Throws AtlantisException if validation fails
    /// </summary>
    /// <param name="val">value to validate</param>
    /// <param name="validator">Predicate function that returns true if value is valid, false if invalid</param>
    /// <param name="errMsg">Message to put in the AtlantisException should validation fail</param>
    private void ValidateString(string val, Predicate<string> validator, string errMsg)
    {
      const string source = "GSASearchRequestData.ValidateSearchQueryMap";
      if (!validator.Invoke(val))
      {
        throw new AtlantisException(this, source, errMsg, null);
      }
    }

    private void CorrectAndValidateOutputParam(NameValueCollection queryParms)
    {
      string output = queryParms[GSAQueryTerms.Output];
      switch (output) // based on the gsa docs, output has only two values
      {
        case "":
        case null:
          output = queryParms[GSAQueryTerms.Output] = "xml_no_dtd";
          break;
        case "xml":
        case "xml_no_dtd":
          break;
        default:
          throw new AtlantisException(this, "GSASearchRequestData.ValidateSearchQueryMap", "Output must equal 'xml' or 'xml_no_dtd'", output);
      }
    }

    private void CorrectAndValidateProxyStyleSheetParam(NameValueCollection queryParms)
    {
      string proxystylesheet = queryParms[GSAQueryTerms.ProxyStyleSheet];
      switch (proxystylesheet)
      {
        case "":
        case null:
          queryParms.Remove(GSAQueryTerms.ProxyStyleSheet);
          break;
        default:
          queryParms[GSAQueryTerms.ProxyStyleSheet] = queryParms[GSAQueryTerms.Client]; // make these match, anything else isn't correct
          break;
      }
    }

    /// <summary>
    /// Validates the following values supplied in the queryParms collection:
    /// 
    /// 1. GSAQueryTerms.Start
    /// 2. GSAQueryTerms.ResultsPerPage
    /// 3. GSAQueryTerms.Client / Front-End name
    /// 4. GSAQueryTerms.Site / Collections
    /// 5. GSAQueryTerms.Query
    /// 
    /// all other values supplied will not be validated.
    /// </summary>
    /// <param name="queryParms"></param>
    private void ValidateSearchQueryMap(NameValueCollection queryParms)
    {
      ValidateString(queryParms[GSAQueryTerms.Start], _validateStringGreaterThanOrEqualToZero, "StartIndex less than 0");
      ValidateString(queryParms[GSAQueryTerms.ResultsPerPage], _validateStringGreaterThanOrEqualToOne, "PageSize less than 1");
      ValidateString(queryParms[GSAQueryTerms.Client], _validateStringNotEmpty, "Client/Front-End name cannot be empty");
      ValidateString(queryParms[GSAQueryTerms.Site], _validateStringNotEmpty, "Site/Collection list cannot be empty");
      ValidateString(queryParms[GSAQueryTerms.Query], _validateStringNotEmpty, "SearchQuery cannot be empty");

      CorrectAndValidateOutputParam(queryParms);
      CorrectAndValidateProxyStyleSheetParam(queryParms);
    }

    #endregion

    /// <summary>
    /// Remove any existing partiton suffix from the SearchQueryMap's Partitioned Entities, and replace it 
    /// with the supplied partition's suffix.  An AtlantisException will be thrown if partition isn't a 
    /// valid partition name.
    /// </summary>
    /// <param name="partition">partition name that will be validated</param>
    private void _ApplyPartition(string partition)
    {
      string partitionSuffix = _ValidatePartition(partition);
      _RemovePartitionsAndApplyNew(partitionSuffix);
    }

    /// <summary>
    /// Validates the requested partition is defined in code
    /// </summary>
    /// <param name="partitionName"></param>
    /// <returns>the partition suffix for the Partitioned Entities</returns>
    private string _ValidatePartition(string partitionName)
    {
      var partition = PartitionList.Find((sp) =>
      {
        return sp.Name.Equals(partitionName);
      });
      if ( partition == null )
      {
        throw new AtlantisException(this, "GSASearchRequestData.GetSearchUrlForPartition", "Invalid Partition Name (check GSAPartition in atlantis.config)", partitionName);
      }
      return partition.Suffix;
    }

    private bool _IsPartitionApplied(string val, string existingPartitionSuffix)
    {
      int indexInto = val.LastIndexOf(existingPartitionSuffix);
      return indexInto > 0;
    }

    private string _RemovePartitionFromValueAndApplyNew(string val, string existingPartitionSuffix, string newPartitionSuffix)
    {
        int indexInto = val.LastIndexOf(existingPartitionSuffix);
        if (indexInto > 0)
        {
          var sb = new StringBuilder(val, 0, indexInto, indexInto + newPartitionSuffix.Length);
          return sb.Append(newPartitionSuffix).ToString();
        }

        throw new AtlantisException(this, "GSASearchRequestData._RemovePartitionFromValueAndApplyNew", "No partition found for the param. All partitioned entities must be partitioned. ", val);
    }

    /// <summary>
    /// Removes a partition suffix (if it has been applied at this point) from partitioned entities and adds 
    /// the supplied new suffix.
    /// </summary>
    /// <param name="newPartitionSuffix"></param>
    private void _RemovePartitionsAndApplyNew(string newPartitionSuffix)
    {
      string frontend = _searchQueryMap[GSAQueryTerms.Client];
      string proxystylesheet = _searchQueryMap[GSAQueryTerms.ProxyStyleSheet];
      string strCollections = _searchQueryMap[GSAQueryTerms.Site];
      // find the delimiter that will be used for manipulating the site collection(s)
      char[] siteDelimiters = { '|', '.' };
      string[] collections = strCollections.Split(siteDelimiters, StringSplitOptions.RemoveEmptyEntries);
      int indexJustPastFirstCollection = collections[0].Length;
      string delim = indexJustPastFirstCollection < strCollections.Length ? strCollections[indexJustPastFirstCollection].ToString() : String.Empty;

      // since all partitionable entities will be partitioned (not possible for one to be partitioned 
      // w/o the rest also being partitioned), let's search the easiest entity (Front-end) to find the partition
      Partition partition = PartitionList.Find((p) =>
      {
        return _IsPartitionApplied(frontend, p.Suffix);
      });

      if (partition != null) // we found that partitioning was applied, so remove it,
      {
        // remove and apply partition
        _searchQueryMap[GSAQueryTerms.Client] = _RemovePartitionFromValueAndApplyNew(frontend, partition.Suffix, newPartitionSuffix);

        // if the proxystylesheet is present, then remove and apply partition
        if (proxystylesheet != null)
        {
          _searchQueryMap[GSAQueryTerms.ProxyStyleSheet] = _RemovePartitionFromValueAndApplyNew(proxystylesheet, partition.Suffix, newPartitionSuffix);
        }

        // remove and apply partition for the collections
        for (int i = 0; i < collections.Length; i++)
        {
          collections[i] = _RemovePartitionFromValueAndApplyNew(collections[i], partition.Suffix, newPartitionSuffix);
        }
        _searchQueryMap[GSAQueryTerms.Site] = String.Join(delim, collections);
      }
      else // no partition present, just append the partition
      {
        _searchQueryMap[GSAQueryTerms.Client] = String.Concat(frontend, newPartitionSuffix);

        if (proxystylesheet != null)
        {
          _searchQueryMap[GSAQueryTerms.ProxyStyleSheet] = String.Concat(proxystylesheet, newPartitionSuffix);
        }

        for (int i = 0; i < collections.Length; i++)
        {
          collections[i] = String.Concat(collections[i], newPartitionSuffix);
        }
        _searchQueryMap[GSAQueryTerms.Site] = String.Join(delim, collections);

      }

    }

    /// <summary>
    /// Generates a fully-qualified GSA search URL with the following values:
    ///   1. Site
    ///   2. Client
    /// replaced with a partitioned name.
    /// </summary>
    /// <param name="partition"></param>
    /// <returns></returns>
    public string GetSearchUrlForPartition(string partition)
    {
      _ApplyPartition(partition);
      var sb = new StringBuilder(GSABaseURL, 500);
      AppendSearchQueryString(sb);
      return sb.ToString();
    }

    /// <summary>
    /// Computes the hash based on the inputs only (the partition is NOT included at the time this is called).
    /// Because the partition isn't in the MD5 hash, one should NEVER run the same site with diffent 
    /// partitions in the same process.
    /// </summary>
    /// <returns></returns>
    public override string GetCacheMD5()
    {
      var sb = new StringBuilder(_applianceKey, 500).Append("|");
      AppendSearchQueryString(sb);
      string key = sb.ToString();

      MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
      md5Provider.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
      byte[] md5Bytes = md5Provider.ComputeHash(stringBytes);
      return BitConverter.ToString(md5Bytes).Replace("-", string.Empty);
    }

    private void AppendSearchQueryString(StringBuilder sb)
    {
      int sbOriginalLength = sb.Length;
      foreach (string name in _searchQueryMap)
      {
        string val = _searchQueryMap[name];
        sb.Append('&').Append(name).Append('=').Append(ImprovedUrlEncode(val));
      }
      if (sb.Length > sbOriginalLength)
      {
        sb[sbOriginalLength] = '?';
      }
    }

    private static string ImprovedUrlEncode(string text)
    {
      string result = HttpUtility.UrlEncode(text);
      if (result != null)
      {
        result = result.Replace("'", "%27");
      }

      return result;
    }

  }
}
