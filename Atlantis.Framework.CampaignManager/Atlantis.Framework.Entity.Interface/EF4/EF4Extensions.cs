using System;
using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Atlantis.Framework.Entity.Interface.EF4
{
    public static class EFEntityExtensions
    {
        public static string GetObjectSetName<TEntity>(this TEntity entity)
            where TEntity : class, IEntity, new()
        {
            PluralizationService ps = PluralizationService.CreateService(CultureInfo.CurrentCulture);

            string typeName = typeof(TEntity).Name;

            if (!ps.IsPlural(typeName))
                return ps.Pluralize(typeof(TEntity).Name);

            return typeName;
        }

        public static Expression<Func<TEntity, TProp>> Use<TEntity, TProp>(this TEntity entity, Expression<Func<TEntity, TProp>> exp)
            where TEntity : class, IEntity, new()
            where TProp : class
        {
            return exp;
        }

        public static ObjectSet<TEntity> GetObjectSet<TEntity>(this ObjectContext context)
            where TEntity : class, IEntity, new()
        {
            PropertyInfo[] props = context.GetType().GetProperties();

            ObjectSet<TEntity> set =
                (from p in props
                 let t = p.PropertyType
                 let v = p.GetValue(context, null)
                 let objectSet = v as ObjectSet<TEntity>
                 where v is ObjectSet<TEntity>
                 && objectSet != null
                 select objectSet).SingleOrDefault();

            return set;
        }

        public static ObjectStateEntry Attach<TEntity>(this ObjectContext context, TEntity entity)
            where TEntity : class, IEntity, new()
        {
            ObjectStateEntry state = null;
            if (entity != null)
            {
                ObjectSet<TEntity> set = context.GetObjectSet<TEntity>();
                if (set != null)
                {
                    ObjectStateManager stateManager = context.ObjectStateManager;
                    if (!stateManager.TryGetObjectStateEntry(entity, out state))
                    {
                        try
                        {
                            set.Attach(entity); // try to attach first (update)
                        }
                        catch
                        {
                            set.AddObject(entity); // otherwise try adding it (insert)
                        }
                        stateManager.TryGetObjectStateEntry(entity, out state);
                    }
                }
            }
            return state;
        }

        public static bool IsImplementationOf<T>(this Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        } 
    }
}
