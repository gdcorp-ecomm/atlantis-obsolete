using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Atlantis.Framework.Entity.Interface;

namespace Atlantis.Framework.Entity.Interface.Mock
{
    public abstract class MockEntityRequest<T> : AtlantisEntityRequest<T>
        where T : class, IAtlantisEntity, new()
    {
        private static Dictionary<Type, List<T>> inMemoryTables = new Dictionary<Type, List<T>>();

        public List<T> Table
        {
            get
            {
                return inMemoryTables[typeof(T)];
            }
        }

        protected bool AddTable()
        {
            if (!inMemoryTables.ContainsKey(typeof(T)))
            {
                List<T> table = new List<T>();
                inMemoryTables.Add(typeof(T), table);
                return true;
            }

            return false;
        } 

        protected void Update(Predicate<T> match, T entity)
        {
            int index = this.Table.FindIndex(match);
            this.Table[index] = entity;
        }
                
        public override void Dispose()
        {
             // do nothing
        }
    }
}
