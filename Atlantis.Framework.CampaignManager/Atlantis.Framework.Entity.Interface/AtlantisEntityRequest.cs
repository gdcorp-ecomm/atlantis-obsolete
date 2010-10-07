using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using System.Data;
using System.Linq.Expressions;

namespace Atlantis.Framework.Entity.Interface
{
    public abstract class AtlantisEntityRequest<T> : IAtlantisEntityRequest<T>, IAtlantisRepository<T>
        where T : class, IAtlantisEntity, new()
    {
        public AtlantisEntityRequest()
        {

        }

        #region IRequest Members
        public abstract IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig);
        #endregion
        
        #region IAtlantisEntityRequest<T> Members
        public IAtlantisEntityRequestData<T> CurrentRequestData
        {
            get
            {
                return _currentRequestData;
            }
        }
        private IAtlantisEntityRequestData<T> _currentRequestData = null;

        public ConfigElement Config
        {
            get
            {
                return _config;
            }
        }
        private ConfigElement _config = null;

        public virtual IResponseData ExecuteRepositoryAction(RequestData oRequestData, ConfigElement oConfig)
        {
            IAtlantisEntityResponseData<T> responseData;
            
            _currentRequestData = oRequestData as IAtlantisEntityRequestData<T>;
            _config = oConfig;

            if (CurrentRequestData != null)
            {
                try
                {
                    responseData = new AtlantisEntityResponseData<T>();

                    switch (CurrentRequestData.RepositoryAction)
                    {
                        case RepositoryAction.Insert:
                            this.Insert(CurrentRequestData.Entities);
                            responseData.Entities = CurrentRequestData.Entities;
                            break;
                        case RepositoryAction.Update:
                            this.Update(CurrentRequestData.Entities);
                            responseData.Entities = CurrentRequestData.Entities;
                            break;
                        case RepositoryAction.Delete:
                            this.Delete(CurrentRequestData.Entities);
                            break;
                        case RepositoryAction.Single:
                            var singleItem = new List<T> { this.Single(CurrentRequestData.WhereClause) };
                            responseData.Entities = singleItem;
                            break;
                        default:
                            if (_currentRequestData.Parameters != null)
                            {
                                responseData.Entities = this.Query(CurrentRequestData.Parameters);
                            }
                            else if (_currentRequestData.WhereClause != null)
                            {
                                responseData.Entities = this.Query(CurrentRequestData.WhereClause);
                            }
                            else if (_currentRequestData.Expression != null)
                            {
                                responseData.Entities = this.Query(CurrentRequestData.Expression);
                            }
                            else
                            {
                                responseData.Entities = this.Query();
                            }
                            break;
                    }
                }
                catch (AtlantisException exAtlantis)
                {
                    responseData = new AtlantisEntityResponseData<T>(exAtlantis);
                }
                catch (Exception ex)
                {
                    responseData = new AtlantisEntityResponseData<T>(CurrentRequestData, ex);
                }

                return responseData;
            }

            return null;
        }
        #endregion

        #region IAtlantisRepository<T> Members
        public abstract ICollection<T> Query();

        public abstract ICollection<T> Query(params IDataParameter[] parameters);

        public abstract ICollection<T> Query(Func<T, bool> predicate);

        public abstract ICollection<T> Query(Expression expression);

        public abstract T Single(Func<T, bool> predicate);

        public abstract void Insert(ICollection<T> entities);

        public abstract void Update(ICollection<T> entities);

        public abstract void Delete(ICollection<T> entities); 
        #endregion

        public Type EntityType
        {
            get
            {
                return typeof(T);
            }
        }

        public abstract void Dispose();

        public static ICollection<TEntity> Query<TRequestData, TEntity>(int requestType)
            where TEntity : class, IAtlantisEntity, new() 
            where TRequestData : class, IAtlantisEntityRequestData<TEntity>, new() 
        {
            var requestData = new TRequestData()
            {
                RepositoryAction = RepositoryAction.Query
            };

            return ExecuteRequestReturnEntities<TEntity>(requestData, requestType);
        }

        public static ICollection<TEntity> ExecuteRequestReturnEntities<TEntity>(IAtlantisEntityRequestData<TEntity> requestData, int requestType)
            where TEntity : class, IAtlantisEntity, new() 
        {
            var responseData = ExecuteRequest(requestData, requestType);
            return responseData.Entities;
        }

        public static IAtlantisEntityResponseData<TEntity> ExecuteRequest<TEntity>(IAtlantisEntityRequestData<TEntity> requestData, int requestType)
            where TEntity : class, IAtlantisEntity, new() 
        {
            try
            {
                var responseData = Engine.Engine.ProcessRequest((AtlantisEntityRequestData<TEntity>)requestData, requestType) as IAtlantisEntityResponseData<TEntity>;
                return responseData;
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    throw new Exception(String.Format("There was an issue processing the atlantis request: {0}, {1}", requestData, ex.Message), ex);
                }
                else
                {
                    throw;
                }
            }
        } 
    }
}
