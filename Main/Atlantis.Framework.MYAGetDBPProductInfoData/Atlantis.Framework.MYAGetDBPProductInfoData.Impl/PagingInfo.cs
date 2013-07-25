﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.MYAGetDBPProductInfoData.Impl
{
  #region Enums
  internal enum SortDirection
  {
    ASC,
    DESC
  }
  #endregion

  [Serializable]
  internal class PagingInfo
  {
    #region Properties

    private bool _returnAll;
    private SortDirection _sortDirection;
    private string _sortField;
    private int _currentPage;
    private int _rowsPerPage;
    private int _numberOfRecords;
    private int _numberOfPages;
    private bool _hasOutputParameters = true;
    private bool _hasPagingInfo = true;
    private bool _hasReturnAllFlag = true;

    internal string SortField
    {
      get { return _sortField; }
      set { _sortField = value; }
    }

    internal int NumberOfRecords
    {
      get { return _numberOfRecords; }
      set { _numberOfRecords = value; }
    }

    internal int NumberOfPages
    {
      get { return _numberOfPages; }
      set { _numberOfPages = value; }
    }

    internal bool HasOutputParameters
    {
      get { return _hasOutputParameters; }
      set { _hasOutputParameters = value; }
    }

    internal bool HasPagingInfo
    {
      get { return _hasPagingInfo; }
      set { _hasPagingInfo = value; }
    }

    internal bool HasReturnAllFlag
    {
      get { return _hasReturnAllFlag; }
      set { _hasReturnAllFlag = value; }
    }
    #endregion

    #region Constructor
    public PagingInfo(Atlantis.Framework.MYAGetDBPProductInfoData.Interface.PageHelper.PagingInfo pi)
    {
      _returnAll = pi.ReturnAll;
      _sortDirection = (SortDirection)pi.SortDirection;
      _sortField = pi.SortField;
      _currentPage = pi.CurrentPage;
      _rowsPerPage = pi.RowsPerPage;
    }
    #endregion

    #region Methods
    
    #endregion
  }
}