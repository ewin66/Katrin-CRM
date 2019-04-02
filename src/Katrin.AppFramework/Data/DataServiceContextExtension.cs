using System;
using System.Linq;
using System.Data.Services.Client;
using System.Collections;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;
using Katrin.AppFramework.Data;
using DevExpress.Data.Filtering;

namespace Katrin.AppFramework
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

        public static IList ToList(this DataServiceQuery source)
        {
            Expression thisExpression = Expression.Constant(source);
            MethodCallExpression methodCallExpression =
                Expression.Call(typeof(Enumerable), "ToList",
                                new Type[1] { source.ElementType }, thisExpression);

            var result = Expression.Lambda(methodCallExpression).Compile().DynamicInvoke();
            return (IList)result;
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

        public static DataServiceQuery Where(this DataServiceQuery source, CriteriaOperator filter)
        {
            if ((object)filter == null) return source;
            var visitor = new DataServiceQueryExpressVisitor(filter);
            Expression reducibleExpression = GetReducibleExpression(source);
            Expression expression = visitor.Visit(reducibleExpression);
            return source.Provider.CreateQuery(expression) as DataServiceQuery;
        }

        public static int Count(this DataServiceQuery source)
        {
            var result = source.Execute();
            int count = 0;
            if (result == null) return count;
            var enumerator = result.GetEnumerator();
            while (enumerator.MoveNext())
            {
                count++;
            }
            return count;
        }

        private static Expression GetReducibleExpression(DataServiceQuery source)
        {
            if (source.Expression.CanReduce)
                return source.Expression;

            var elementType = source.ElementType;

            ParameterExpression thisExpression = Expression.Parameter(elementType, "");
            Expression predicate = Expression.Lambda(Expression.Constant(true), thisExpression);
            MethodCallExpression methodCallExpression =
                Expression.Call(typeof(Queryable), "Where",
                                new Type[1] { elementType }, new Expression[2]
                                                                       {
                                                                           source.Expression, predicate
                                                                       });
            return methodCallExpression;
        }
    }
}
