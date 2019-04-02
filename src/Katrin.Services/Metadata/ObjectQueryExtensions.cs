using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Data.Metadata.Edm;

namespace Katrin.Services.Metadata
{
    public static class ObjectQueryExtensions
    {
        public static ObjectQuery<T> Include<T>(this ObjectQuery<T> query, Expression<Func<T, object>> selector)
        {
            string path = new PropertyPathVisitor().GetPropertyPath(selector);
            return query.Include(path);
        }

        public static ObjectQuery<TEntity> FetchMany<TEntity, TReleated>(this ObjectQuery<TEntity> query, Expression<Func<TEntity, IEnumerable<TReleated>>> selector) where TEntity : class
        {
            string path = new PropertyPathVisitor().GetPropertyPath(selector);
            return query.Include(path);
        }

        class PropertyPathVisitor : ExpressionVisitor
        {
            private Stack<string> _stack;
            public string GetPropertyPath(Expression expression)
            {
                _stack = new Stack<string>();
                Visit(expression);
                return _stack
                    .Aggregate(
                       new StringBuilder(),
                       (sb, name) =>
                           (sb.Length > 0 ? sb.Append(".") : sb).Append(name))
                   .ToString();
            }

            protected override Expression VisitMember(MemberExpression expression)
            {
                if (_stack != null)
                    _stack.Push(expression.Member.Name);
                return base.VisitMember(expression);
            }

            protected override Expression VisitMethodCall(MethodCallExpression expression)
            {
                if (IsLinqOperator(expression.Method))
                {
                    for (int i = 1; i < expression.Arguments.Count; i++)
                    {
                        Visit(expression.Arguments[i]);
                    }
                    Visit(expression.Arguments[0]);
                    return expression;
                }
                return base.VisitMethodCall(expression);
            }

            private static bool IsLinqOperator(MethodInfo method)
            {
                if (method.DeclaringType != typeof(Queryable) && method.DeclaringType != typeof(Enumerable))
                    return false;
                return Attribute.GetCustomAttribute(method, typeof(ExtensionAttribute)) != null;
            }
        }
    }

    public static class ObjectContextExtensions
    {
        private static IEnumerable<Type> GetAncestors(Type type)
        {
            Type current = type;
            do
            {
                yield return current;
                current = current.BaseType;
            } while (current != typeof(object));

        }


        public static string GetSingleEntitySetName(this ObjectContext context, EntityType entityType)
        {
            var workspace = context.MetadataWorkspace;
            var container = workspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);

            var entitySets = from set in container.BaseEntitySets.OfType<EntitySet>()
                             where set.ElementType.FullName == entityType.FullName
                             select set;
            var entitySet = entitySets.Single();
            return context.DefaultContainerName + "." + entitySet.Name;
        }

        public static string GetSingleEntitySetName(this ObjectContext context, Type entityType)
        {
            var ancestors = GetAncestors(entityType).ToList();
            var workspace = context.MetadataWorkspace;
            var container = workspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            var objectItems = (ObjectItemCollection)(workspace.GetItemCollection(DataSpace.OSpace));

            var entitySetNames =
                from set in container.BaseEntitySets.OfType<EntitySet>()
                let conceptualElementType = set.ElementType
                let objectElementType = workspace.GetObjectSpaceType(conceptualElementType)
                let clrElementType = objectItems.GetClrType(objectElementType)
                where ancestors.Any(type => type == clrElementType)
                select set.Name;

            return entitySetNames.Single();
        }
    }
}
