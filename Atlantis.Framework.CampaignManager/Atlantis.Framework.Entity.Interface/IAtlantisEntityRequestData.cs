using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Atlantis.Framework.Entity.Interface
{
    public interface IAtlantisEntityRequestData<T>
        where T : class, IAtlantisEntity, new()
    {
        RepositoryAction RepositoryAction { get; set; }
        TimeSpan RequestTimeout { get; set; }
        PagingInfo PagingInfo { get; set; }
        ICollection<T> Entities { get; set; }
        Expression Expression { get; set; }
        IDataParameter[] Parameters { get; set; }
        Func<T, bool> WhereClause { get; set; }
    }
}