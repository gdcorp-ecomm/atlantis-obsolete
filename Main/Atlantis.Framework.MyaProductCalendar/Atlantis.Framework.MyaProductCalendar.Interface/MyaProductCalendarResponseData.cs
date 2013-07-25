using System;
using System.Collections.Generic;
using System.Reflection;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductCalendar.Interface
{
  public class MyaProductCalendarResponseData : IResponseData
  {
    private readonly AtlantisException _atlantisException;
    public IList<CalendarProduct> CalendarProducts { get; private set; }
    public IPagingResult PagingResult { get; private set; }
    public bool IsSuccess
    {
      get { return _atlantisException == null; }
    }

    public MyaProductCalendarResponseData(IList<CalendarProduct> calendarProducts, int totalRecords, int totalPages)
    {
      CalendarProducts = calendarProducts;
      PagingResult = new CalendarPagingResult(totalRecords, totalPages);
    }

     public MyaProductCalendarResponseData(AtlantisException atlantisException)
    {
      CalendarProducts = new List<CalendarProduct>(1);
      PagingResult = new CalendarPagingResult(0, 0);
      _atlantisException = atlantisException;
    }

    public MyaProductCalendarResponseData(RequestData requestData, Exception ex)
    {
      CalendarProducts = new List<CalendarProduct>(1);
      PagingResult = new CalendarPagingResult(0, 0);
      _atlantisException = new AtlantisException(requestData
        , MethodBase.GetCurrentMethod().DeclaringType.FullName
        , string.Format("MyaProductCalendar Error: {0}", ex.Message)
        , ex.Data.ToString()
        , ex);
    }

    #region IResponseData Members

    public string ToXML()
    {
      return string.Empty;
    }

    public AtlantisException GetException()
    {
      return _atlantisException;
    }

    #endregion

  }
}
