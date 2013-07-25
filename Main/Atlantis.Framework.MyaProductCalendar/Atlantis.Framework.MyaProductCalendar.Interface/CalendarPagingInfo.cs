﻿using Atlantis.Framework.MyaProduct.Interface;

namespace Atlantis.Framework.MyaProductCalendar.Interface
{
  public class CalendarPagingInfo : IPagingInfo
  {
    /// <summary>
    /// When set to true, will return all records.  Default is false.
    /// </summary>
    public bool ReturnAll { get; set; }

    /// <summary>
    /// The current page to return.  Default is 1.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// The number of rows to return per page.  Default is 20.
    /// </summary>
    public int RowsPerPage { get; set; }

    public CalendarPagingInfo()
    {
      ReturnAll = false;
      CurrentPage = 1;
      RowsPerPage = 20;
    }
  }
}
