using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Data.Extensions;

namespace Atlantis.Framework.Entity.Interface.EF4
{
    public static class EFProcExtensions
    {
        // library of cached materializers
        static Dictionary<Type, object> _materializers = new Dictionary<Type, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Materializer<T> GetMaterializer<T>()
            where T : class, IAtlantisEntity, new()
        {
            Materializer<T> materializer = _materializers[typeof(T)] as Materializer<T>;

            // if a materializer wasn't registered, create one
            if (materializer == null)
            {
                // Default constructor. Instances of T are materialized by assigning field values to
                // writable properties on T having the same name. By default, allows fields
                // that do not have corresponding properties and properties that do not have corresponding
                // fields.
                materializer = new Materializer<T>();
            }

            return materializer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="shaper"></param>
        public static void AddMaterializer<T>(Expression<Func<IDataRecord, T>> shaper)
            where T : class, IAtlantisEntity, new()
        {
            if (!_materializers.ContainsKey(typeof(T)))
            {
                Materializer<T> materializer = new Materializer<T>(shaper);
                _materializers.Add(typeof(T), materializer);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="context"></param>
        /// <param name="procName"></param>
        /// <param name="postQueryAction"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IQueryable<TResult> ExecutProc<TResult>(ObjectContext context, string procName, Action<TResult> postQueryAction, params SqlParameter[] parameters)
            where TResult : class, IAtlantisEntity, new()
        {
            DbCommand dbCommand = context.CreateStoreCommand(
                procName,
                CommandType.StoredProcedure,
                parameters);

            Materializer<TResult> materializer = GetMaterializer<TResult>();

            List<TResult> results = materializer.Materialize(dbCommand).ToList<TResult>();

            if (postQueryAction != null)
            {
                results.ForEach(postQueryAction);
            }

            return results.AsQueryable<TResult>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="context"></param>
        /// <param name="postQueryAction"></param>
        /// <returns></returns>
        public static IQueryable<TResult> ExecuteSelectProc<TResult>(ObjectContext context, Action<TResult> postQueryAction)
            where TResult : class, IAtlantisEntity, new()
        {
            string procName = String.Format(
                "{0}SelectAll_sp",
                typeof(TResult).Name);

            return ExecutProc<TResult>(context, procName, postQueryAction, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TPrimeryKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="context"></param>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <param name="postQueryAction"></param>
        /// <returns></returns>
        public static IQueryable<TResult> ExecuteSelectProc<TSource, TPrimeryKey, TResult>(
            ObjectContext context,
            TSource source,
            Expression<Func<TSource, TPrimeryKey>> keySelector,
            Action<TResult> postQueryAction)
            where TSource : class, IAtlantisEntity, new()
            where TResult : class, IAtlantisEntity, new()
        {
            SqlParameter parm = BuildParameter(source, keySelector);

            string procName = String.Format(
                "{0}SelectBy{1}_sp",
                typeof(TResult).Name,
                parm.ParameterName);

            return ExecutProc<TResult>(
                context,
                procName,
                postQueryAction,
                parm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProp"></typeparam>
        /// <param name="source"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static SqlParameter BuildParameter<TSource, TProp>(this TSource source, Expression<Func<TSource, TProp>> propertySelector)
            where TSource : class, IAtlantisEntity, new() 
        {
            MemberExpression memberExpression = propertySelector.Body as MemberExpression;

            if (memberExpression == null)
            {
                throw new InvalidOperationException("Expression must be a member expression: " + propertySelector);
            }

            Type sourceType = typeof(TSource);
            MemberInfo memberInfo = memberExpression.Member;
            PropertyInfo parmInfo = sourceType.GetProperty(memberInfo.Name);

            SqlParameter parm = new SqlParameter
            {
                ParameterName = memberInfo.Name,
                Value = parmInfo.GetValue(source, null)
            };

            return parm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="postQueryAction"></param>
        /// <returns></returns>
        public static Action<TResult> PostQueryAction<TResult>(this IAtlantisEntity source, Action<TResult> postQueryAction)
        {
            return postQueryAction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TExpandMember"></typeparam>
        /// <typeparam name="TPrimaryKey"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="context"></param>
        /// <param name="expandMemberSelector"></param>
        /// <param name="primaryKeySelector"></param>
        /// <param name="postQueryAction"></param>
        /// <returns></returns>
        public static TSource Expand<TSource, TExpandMember, TPrimaryKey, TResult>(
            this TSource source,
            ObjectContext context,
            Expression<Func<TSource, TExpandMember>> expandMemberSelector,
            Expression<Func<TSource, TPrimaryKey>> primaryKeySelector,
            Action<TResult> postQueryAction)
            where TSource : class, IAtlantisEntity, new()
            where TResult : class, IAtlantisEntity, new()
        {
            MemberExpression memberExpression = expandMemberSelector.Body as MemberExpression;
            Type sourceType = typeof(TSource);

            if (memberExpression == null)
            {
                throw new InvalidOperationException("Expression must be a member expression: " + expandMemberSelector);
            }

            MemberInfo memberInfo = memberExpression.Member;
            Type propType = memberInfo.DeclaringType;
            PropertyInfo propertyInfo = sourceType.GetProperty(memberInfo.Name);

            IQueryable<TResult> results = ExecuteSelectProc(
                context,
                source,
                primaryKeySelector,
                postQueryAction);

            if (propType.IsAssignableFrom(typeof(IAtlantisEntity)))
            {
                if (results.Count() > 1)
                {
                    throw new InvalidOperationException("ExecuteSelectProc returned more than one entity.");
                }

                propertyInfo.SetValue(source, results.SingleOrDefault(), null);
            }
            else if (propType.IsAssignableFrom(typeof(Collection<TResult>)))
            {
                Collection<TResult> coll = propertyInfo.GetValue(source, null) as Collection<TResult>;
                if (coll != null)
                {
                    foreach (TResult item in coll)
                    {
                        coll.Add(item);
                    }
                }
            }

            return source;
        }
    }
}
