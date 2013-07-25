using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DCCCreateBlogRecord.Interface
{
  public class DCCCreateBlogRecordResponseData : IResponseData
  {

    protected AtlantisException _exception;

    public DCCCreateBlogRecordResponseData()
    {
      IsSuccess = true;
    }

    public  DCCCreateBlogRecordResponseData(int errorNum)
    {
      IsSuccess = false;
      ErrorNum = errorNum;
    }

    public DCCCreateBlogRecordResponseData(AtlantisException exception)
    {
      IsSuccess = false;
      _exception = exception;
    }

    public bool IsSuccess { get; protected set; }

    public int ErrorNum { get; protected set; }

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _exception;
    }
  }
}
