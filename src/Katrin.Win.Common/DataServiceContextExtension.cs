using System;
using System.Linq;
using System.Data.Services.Client;
using System.Collections;
using System.Reflection;
using System.Linq.Expressions;

namespace Katrin.Win
{
    public static class DataServiceContextExtension 
    {
        public static object _First(this IEnumerable source)
        {
            IList list = source as IList;
            if (list != null)
            {
                if (list.Count > 0)
                    return list[0];
            }
            else
            {
                IEnumerator enumerator = source.GetEnumerator();
                if (enumerator.MoveNext())
                    return enumerator.Current;
            }
            return null;
        }

        public static DataServiceQuery CreateQuery(this DataServiceContext context, Type elementType, string entitySetName)
        {
            MethodInfo method = context.GetType().GetMethod("CreateQuery");
            MethodInfo generic = method.MakeGenericMethod(elementType);
            DataServiceQuery query = generic.Invoke(context, new object[] { entitySetName }) as DataServiceQuery;
            return query;
        }

        public static DataServiceQuery Expand(this DataServiceQuery query, string path)
        {
            MethodInfo method = query.GetType().GetMethod("Expand", new[] { typeof(string) });
            return method.Invoke(query, new object[] { path }) as DataServiceQuery;
        }

        public static TEntity GetById<TEntity>(this IQueryable<TEntity> repository, string propertyName, object value)
        {
            ParameterExpression pe = Expression.Parameter(typeof(TEntity), "entity");

            Expression left = Expression.Property(pe, typeof(TEntity).GetProperty(propertyName));
            Expression right = Expression.Constant(value, value.GetType());
            Expression predicateBody = Expression.Equal(left, right);
            var predicate = Expression.Lambda<Func<TEntity, bool>>(predicateBody, new[] { pe });
            return repository.Where(predicate).Single();
        }
    }
}
