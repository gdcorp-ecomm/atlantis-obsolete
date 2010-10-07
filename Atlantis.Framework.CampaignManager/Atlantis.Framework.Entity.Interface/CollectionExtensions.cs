using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.Entity.Interface
{
    public static class CollectionExtensions
    {
        public static void ForEach<TEntity>(this ICollection<TEntity> collection, Action<TEntity> action)
            where TEntity : class, IEntity, new()
        {
            if (collection != null && collection.Count > 0)
            {
                foreach (var entity in collection)
                {
                    action(entity);
                }
            }
        }
    }
}
