using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Atlantis.Framework.Entity.Interface;

namespace Atlantis.Framework.Entity.Interface.ADO
{
    public abstract class ADOEntityRequest<T> : AtlantisEntityRequest<T>
        where T : class, IAtlantisEntity, new()
    {
        public abstract T Materialize(DataRow row);

        protected ICollection<T> ExecuteProcedure(string procedureName)
        {
            return ExecuteProcedure<T>(procedureName, this.Materialize, null, null);
        }

        protected ICollection<T> ExecuteProcedure(string procedureName, Func<T, bool> predicate)
        {
            return ExecuteProcedure<T>(procedureName, this.Materialize, predicate, null);
        }

        protected ICollection<T> ExecuteProcedure(string procedureName, params IDataParameter[] parameters)
        {
            return ExecuteProcedure<T>(procedureName, this.Materialize, null, parameters);
        }

        protected ICollection<T> ExecuteProcedure(string procedureName, Func<T, bool> predicate, params IDataParameter[] parameters)
        {
            return ExecuteProcedure<T>(procedureName, this.Materialize, predicate, parameters);
        }

        protected ICollection<TEntity> ExecuteProcedure<TEntity>(string procedureName, Func<DataRow, TEntity> materializer, Func<TEntity, bool> predicate, params IDataParameter[] parameters)
            where TEntity : class, IAtlantisEntity, new()
        {
            List<TEntity> list = new List<TEntity>();

            using (var ado = new ADOHelper(this.Config))
            {
                if (parameters != null)
                {
                    foreach (var parm in parameters)
                    {
                        ado.Add(parm);
                    }
                }

                DataRowCollection rows = ado.ExecuteReturnRows(procedureName);

                if (rows != null)
                {
                    foreach (DataRow row in rows)
                    {
                        list.Add(materializer(row));
                    }
                } 
            }

            if (predicate != null)
            {
                return list.Where(predicate).ToList();
            }

            return list;
        }

        protected void UpdateMaps<TEntity>(ICollection<TEntity> updatedMaps, ICollection<TEntity> currentMaps, Func<TEntity, TEntity, bool> predicate, Action<ADOHelper, TEntity> insertAction, Action<TEntity> deleteAction)
            where TEntity : class, IAtlantisEntity, new()
        {
            // remove any that are not in the current map
            foreach (var map in currentMaps)
            {
                if (!updatedMaps.Any(x => { return predicate(x, map); }))
                {
                    deleteAction(map);
                }
            }

            // add any that are new 
            updatedMaps.ForEach(this.Config,
                (ado, e) =>
                {
                    if (!currentMaps.Any(x => { return predicate(x, e); }))
                    {
                        insertAction(ado, e);
                    }
                });
        }

        public bool HasItems<TCollection>(ICollection<TCollection> collection)
            where TCollection : class, new()
        {
            if (collection != null && collection.Count > 0)
                return true;

            return false;
        }

        public override void Dispose()
        {
             // do nothing
        }
    }
}
