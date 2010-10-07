using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Atlantis.Framework.Entity.Interface
{
    public class AtlantisQuery<T> : IQueryable<T>, IEnumerable<T>, IQueryable, IEnumerable, IOrderedQueryable<T>, IOrderedQueryable
        where T : class, new()
    {
        private AtlantisQueryProvider<T> _queryProvider = null;
        private Expression _expression = null;

        public delegate void Enumerating(AtlantisQueryEventArgs args);
        public delegate void CreatingQuery(AtlantisQueryEventArgs args);
        public delegate void Executing(AtlantisQueryEventArgs args);

        public event Enumerating OnEnumerating;
        public event CreatingQuery OnCreatingQuery;
        public event Executing OnExecuting;

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _queryProvider;
            }
        }

        public AtlantisQuery()
        {
            Init(new AtlantisQueryProvider<T>(), Expression.Constant(this));
        }

        internal AtlantisQuery(AtlantisQueryProvider<T> provider, Expression expression)
        {
            Init(provider, expression);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (OnEnumerating != null)
            {
                OnEnumerating(new AtlantisQueryEventArgs(AtlantisQueryEventTypes.Enumerating, this.Expression));
            }

            return (new List<T>()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        void _queryProvider_OnCreatingQuery(AtlantisQueryEventArgs args)
        {
            if (OnCreatingQuery != null)
            {
                OnCreatingQuery(args);
            }
        }

        void _queryProvider_OnExecuting(AtlantisQueryEventArgs args)
        {
            if (OnExecuting != null)
            {
                OnExecuting(args);
            }
        }

        private void Init(AtlantisQueryProvider<T> provider, Expression expression)
        {
            _queryProvider = provider;
            _expression = expression;
            _queryProvider.OnExecuting += new AtlantisQueryProvider<T>.Executing(_queryProvider_OnExecuting);
            _queryProvider.OnCreatingQuery += new AtlantisQueryProvider<T>.Executing(_queryProvider_OnCreatingQuery);
        }
    }

    public class AtlantisQueryProvider<T> : IQueryProvider
        where T : class, new()
    {
        public delegate void Executing(AtlantisQueryEventArgs args);
        public event Executing OnExecuting;

        public delegate void CreatingQuery(AtlantisQueryEventArgs args);
        public event Executing OnCreatingQuery;

        public AtlantisQueryProvider()
        {
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (OnCreatingQuery != null)
            {
                OnCreatingQuery(new AtlantisQueryEventArgs(AtlantisQueryEventTypes.CreatingQuery, expression));
            }

            var newQuery = new AtlantisQuery<T>(this, expression);

            return (IQueryable<TElement>)newQuery;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return this.CreateQuery<T>(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            if (OnExecuting != null)
            {
                OnExecuting(new AtlantisQueryEventArgs(AtlantisQueryEventTypes.Executing, expression));
            }

            return default(TResult);
        }

        public object Execute(Expression expression)
        {
            return this.Execute<T>(expression);
        }
    }

    public class AtlantisQueryEventArgs : EventArgs
    {
        public Expression Expression { get; private set; }
        public AtlantisQueryEventTypes EventType { get; private set; }

        public AtlantisQueryEventArgs(AtlantisQueryEventTypes eventType, Expression expression)
        {
            this.EventType = eventType;
            this.Expression = expression;
        }
    }

    public enum AtlantisQueryEventTypes
    {
        Enumerating,
        CreatingQuery,
        Executing
    }
}