using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.SearchHelp.Interface
{  
  public class SearchHelpRequestData : RequestData
  {
    private string _site;
    private string _output;
    private string _oe;
    private string _ie;
    private string _client;
    private string _filter;
    
    private string _searchWords;
    private int _startIndex;
    private int _maxRecords;

    public string Site
    {
      get { return _site; }
    }
    
    public string Output
    {
      get { return _output; }
    }
    
    public string Oe
    {
      get { return _oe; }
    }
    
    public string Ie
    {
      get { return _ie; }
    }
    
    public string Client
    {
      get { return _client; }
    }

    public string Filter
    {
      get { return _filter; }
    }

    public string SearchWords
    {
      get { return _searchWords; }
    }

    public int StartIndex
    {
      get { return _startIndex; }
    }

    public int MaxRecords
    {
      get { return _maxRecords; }
    }       

    public SearchHelpRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string site, string output, string oe, string ie, string client, string filter,
      string searchWords, int startIndex, int maxRecords)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _site = site;
      _output = output;
      _oe = oe;
      _client = client;
      _filter = filter;
      _searchWords = searchWords;
      _startIndex = startIndex;
      _maxRecords = maxRecords;          
    }

    public SearchHelpRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      string searchWords, int startIndex, int maxRecords)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _site = "help_article_collection";
      _output = "xml_no_dtd";
      _oe = "UTF-8";
      _ie = "UTF-8";
      _client = "godaddy_frontend";
      _filter = "0";
      _searchWords = searchWords;
      _startIndex = startIndex;
      _maxRecords = maxRecords;   
    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_searchWords + ":" + _startIndex.ToString() + ":" + _maxRecords.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }
  }
}
