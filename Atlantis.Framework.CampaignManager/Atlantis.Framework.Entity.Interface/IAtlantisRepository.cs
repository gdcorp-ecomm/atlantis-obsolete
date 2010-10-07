using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;

namespace Atlantis.Framework.Entity.Interface
{
    public interface IAtlantisRepository<T> : IRepository, IDisposable 
        where T : class, IAtlantisEntity, new()
    {
        ICollection<T> Query();
        ICollection<T> Query(params IDataParameter[] parameters);
        ICollection<T> Query(Func<T, bool> predicate);
        ICollection<T> Query(Expression expression);
        T Single(Func<T, bool> predicate);
        void Insert(ICollection<T> entities);
        void Update(ICollection<T> entities);
        void Delete(ICollection<T> entities); 
    }

    public interface IRepository
    {
        Type EntityType { get; }
    }

    public enum RepositoryAction
    {
        Query = 1,
        Insert = 2, 
        Update = 3, 
        Delete = 4, 
        Single = 5 
    }
}
