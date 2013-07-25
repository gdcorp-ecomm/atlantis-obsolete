using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;

namespace Atlantis.Framework.SearchDiscussions.Interface
{
  public class SearchDiscussionsRequestData : RequestData
  {

    private int _forumId;
    private string _searchWord;
    private int _maximumRows;
    private int _startRowIndex;
    private DateTime _newDate;
    private int _popularHours;

    public int ForumId
    {
      get { return _forumId; }
    }

    public string SearchWord
    {
      get { return _searchWord; }
    }

    public int MaximumRows
    {
      get { return _maximumRows; }
    }

    public int StartRowIndex
    {
      get { return _startRowIndex; }
    }

    public DateTime NewDate
    {
      get { return _newDate; }
    }

    public int PopularHours
    {
      get { return _popularHours; }
    }


    public SearchDiscussionsRequestData(
      string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
      int forumId, string searchWord, int maximumRows, int startRowIndex, DateTime newDate, int popularHours)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _forumId = forumId;
      _searchWord = searchWord;
      _maximumRows = maximumRows;
      _startRowIndex = startRowIndex;
      _newDate = newDate;
      _popularHours = popularHours;

    }

    public override string GetCacheMD5()
    {
      MD5 oMD5 = new MD5CryptoServiceProvider();
      oMD5.Initialize();
      byte[] stringBytes
        = System.Text.ASCIIEncoding.ASCII.GetBytes(_forumId.ToString() + ":" + _searchWord + ":" + _maximumRows.ToString() + ":" + _startRowIndex.ToString() + ":" +
                                                  _newDate.ToString() + ":" + _popularHours.ToString());
      byte[] md5Bytes = oMD5.ComputeHash(stringBytes);
      string sValue = BitConverter.ToString(md5Bytes, 0);
      return sValue.Replace("-", string.Empty);
    }
  }
}
