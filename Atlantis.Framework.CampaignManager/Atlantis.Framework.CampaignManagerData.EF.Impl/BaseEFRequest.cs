using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface;
using Atlantis.Framework.Entity.Interface.EF4;
using Atlantis.Framework.Entity.Interface.SelfTracking;
using Atlantis.Framework.Interface;
using System.Linq.Expressions;

namespace Atlantis.Framework.CampaignManagerData.EF.Impl
{
    public abstract class BaseEFRequest<T> : EF4EntityRequest<T>
        where T : class, IObjectWithChangeTracker, new()
    {
        public BaseEFRequest()
        {

        }

        public override IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
        {
            return this.ExecuteRepositoryAction(oRequestData, oConfig);
        }

        public override IResponseData ExecuteRepositoryAction(RequestData oRequestData, ConfigElement oConfig)
        {
            return base.ExecuteRepositoryAction(oRequestData, oConfig);
        }
        
        public override ICollection<T> Query()
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> Query(List<IDataParameter> parameters)
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> Query(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> Query(Expression expression)
        {
            throw new NotImplementedException();
        }

        public override T Single(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Insert(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public override void Update(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public override void Delete(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            // do nothing 
        }     

        protected void Update<MapEntityType>(ICollection<MapEntityType> currentList, ICollection<MapEntityType> oldList, Func<MapEntityType, MapEntityType, bool> matchSelector, Action<MapEntityType> addAction, Action<MapEntityType, MapEntityType> updateAction)
            where MapEntityType : class, IAtlantisEntity, new()
        {
            using (var ctx = new EFModelContext(this.GetConnectionString()))
            {
                ObjectStateManager stateManager = ctx.ObjectStateManager;

                var deletedItems = oldList
                    .Where(x => !currentList.Any(y => matchSelector(x, y)))
                    .ToList();

                foreach (var item in currentList)
                {
                    var oldItem = oldList.SingleOrDefault(x => matchSelector(x, item));
                    if (oldItem != null)
                    {
                        stateManager.ChangeObjectState(oldItem, EntityState.Detached);
                        updateAction(item, oldItem);
                        stateManager.ChangeObjectState(item, EntityState.Modified);
                    }
                    else
                    {
                        addAction(item);
                        stateManager.ChangeObjectState(item, EntityState.Added);
                    }
                }

                foreach (var item in deletedItems)
                {
                    stateManager.ChangeObjectState(item, EntityState.Deleted);
                }
            }
        }
    }
}
