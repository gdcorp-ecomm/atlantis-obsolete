using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.Entity.Interface
{
    public abstract class AtlantisEntityRequestData<T> : RequestData, IAtlantisEntityRequestData<T>
        where T : class, IAtlantisEntity, new()
    {
        public AtlantisEntityRequestData()
            : base(String.Empty, String.Empty, String.Empty, String.Empty, -1)
        {

        }

        public AtlantisEntityRequestData(RepositoryAction repositoryAction, IList<T> entities, params IDataParameter[] parameters)
            : base(String.Empty, String.Empty, String.Empty, String.Empty, -1)
        {
            _repositoryAction = repositoryAction;
            _entities = entities;
            _parameters = parameters;
        }

        public AtlantisEntityRequestData(RepositoryAction repositoryAction, IList<T> entities, Func<T, bool> predicate)
            : base(String.Empty, String.Empty, String.Empty, String.Empty, -1)
        {
            _repositoryAction = repositoryAction;
            _entities = entities;
            _predicate = predicate;
        }

        public AtlantisEntityRequestData(
            RepositoryAction repositoryAction, 
            IList<T> entities, 
            IDataParameter[] parameters, 
            string shopperID, 
            string sourceURL, 
            string orderID, 
            string pathway, 
            int pageCount)
            : base(shopperID, sourceURL, orderID, pathway, pageCount) 
        {
            _repositoryAction = repositoryAction;
            _entities = entities;
            _parameters = parameters;
        }

        #region RequestData Members
        public override string GetCacheMD5()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IAtlantisEntityRequestData<T> Members
        public RepositoryAction RepositoryAction
        {
            get
            {
                return _repositoryAction;
            }
            set
            {
                _repositoryAction = value;
            }
        }
        private RepositoryAction _repositoryAction = RepositoryAction.Query;

        public TimeSpan RequestTimeout
        {
            get
            {
                return _requestTimeout;
            }
            set
            {
                _requestTimeout = value;
            }
        }
        private TimeSpan _requestTimeout = TimeSpan.FromSeconds(4);

        public PagingInfo PagingInfo
        {
            get
            {
                return _pagingInfo;
            }
            set
            {
                _pagingInfo = value;
            }
        }
        private PagingInfo _pagingInfo = null;

        public ICollection<T> Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }
        private ICollection<T> _entities = null;

        public IDataParameter[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }
        private IDataParameter[] _parameters = null;

        public Func<T, bool> WhereClause
        {
            get
            {
                return _predicate;
            }
            set
            {
                _predicate = value;
            }
        }
        private Func<T, bool> _predicate = null;

        public Expression Expression
        {
            get
            {
                return _expression;
            }
            set
            {
                _expression = value;
            }
        }
        private Expression _expression = null;
        #endregion
    }
}
