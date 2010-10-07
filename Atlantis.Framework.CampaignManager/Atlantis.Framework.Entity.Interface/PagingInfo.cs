using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.Entity.Interface
{
    [Serializable]
    public class PagingInfo
    {
        public bool ReturnAll { get; set; }

        public SortDirection SortDirection { get; set; }

        public string SortField { get; set; }

        public int CurrentPage { get; set; }

        public int RowsPerPage { get; set; }

        public int NumberOfRecords { get; set; }

        public int NumberOfPages { get; set; }  

        public PagingInfo()
        {
            this.ReturnAll = false;
            this.SortDirection = SortDirection.ASC;
            this.SortField = String.Empty;
            this.CurrentPage = 1;
            this.RowsPerPage = 20;
            this.NumberOfRecords = 0;
            this.NumberOfPages = 0;
        }
    }

    public enum SortDirection
    {
        ASC,
        DESC
    }
}
