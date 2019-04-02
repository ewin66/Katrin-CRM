using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects;
using System.Data.Services;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.ServiceModel;
using System.Web;
using Katrin.Services.Metadata;
using Katrin.Services.Notification;

namespace Katrin.Services
{
    public  class DynamicModelBuilder
    {
        protected static DbModelBuilder _builder;
        private static DbCompiledModel _cachedCompiledModel;
        private static List<Entity> _entities;

        static DynamicModelBuilder()
        {
            Database.SetInitializer<DbContext>(null);
            _builder = new DbModelBuilder(DbModelBuilderVersion.Latest);
            _builder.Conventions.Remove<PluralizingTableNameConvention>();
            _entities = GetEntityMetadataList();
            DynamicTypeBuilder.Instance.BuildDynamicType(_entities);
            PrepareBuilder();
        }

        public static DbContext CreateDataSource()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Katrin"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var compiledModel = GetCopiledModel();
            var context = new KatrinDbContext(connection, compiledModel, true);
            IObjectContextAdapter objectAdapter = context;
            objectAdapter.ObjectContext.SavingChanges += (sender, e) =>
                {
                    if (!(sender is ObjectContext)) return;
                    ObjectContext objectContext = (ObjectContext)sender;
                    var changes =
                        objectContext.ObjectStateManager.GetObjectStateEntries(
                            EntityState.Deleted | EntityState.Modified | EntityState.Added).Where(entry => entry.Entity != null);


                    if (!changes.Any())
                        return;
                    changes = changes.Where(stateEntry => _entities.Any(n => n.Name == stateEntry.EntitySet.ElementType.Name));

                    if (!changes.Any())
                        return;
                    Type auditType = DynamicTypeBuilder.Instance.GetDynamicType("Audit");

                    var dbContext = CreateDataSource();
                    List<string> excludeAttributeList = new List<string>() { "ModifiedOn", "ModifiedById", "VersionNumber" };
                    int languageId = 2052;
                    foreach (ObjectStateEntry objectStateEntry in changes)
                    {

                        Entity entity = _entities.First(en => en.Name == objectStateEntry.EntitySet.ElementType.Name);
                        if (!entity.IsAuditEnabled && entity.PhysicalName != "Note") continue;
                        string keyName = entity.Attributes.Where(c => c.IsPKAttribute == true).First().PhysicalName;
                        Dictionary<string, object> oldValue = new Dictionary<string, object>();
                        var entityId = (Guid)objectStateEntry.CurrentValues[keyName];
                        var trasactionId = Guid.NewGuid();
                        DateTime createdOn = DateTime.Now;

                        Guid? userId = null;
                        if (entity.Attributes.Any(c => c.PhysicalName == "ModifiedById"))
                        {
                            var userM = objectStateEntry.CurrentValues["ModifiedById"];
                            if (userM != null && !string.IsNullOrEmpty(userM.ToString()))
                                userId = Guid.Parse(userM.ToString());
                        }

                        if (objectStateEntry.State == EntityState.Modified)
                        {
                            foreach (var att in entity.Attributes)
                            {
                                var propertyName = att.PhysicalName;
                                var originalValue =
                                    objectStateEntry.OriginalValues[propertyName].ToString();

                                oldValue.Add(propertyName, originalValue);
                                if (excludeAttributeList.Contains(att.PhysicalName)) continue;
                                if (!(att.IsAuditEnabled && !objectStateEntry.CurrentValues[att.PhysicalName]
                                                        .Equals(objectStateEntry.OriginalValues[att.PhysicalName])))
                                    continue;
                                var audit = CreateAudit(entity, objectStateEntry, entityId,
                                                                                trasactionId, auditType, userId, createdOn);

                                SetPropertyValue(audit, "FieldName", propertyName);
                                var newValue =
                                    objectStateEntry.CurrentValues[propertyName].ToString();

                                SetPropertyValue(audit, "NewValue", newValue);
                                SetPropertyValue(audit, "OriginalValue", originalValue);
                                dbContext.Set(auditType).Add(audit);
                            }
                        }
                        Action action = new Action(() =>
                        {
                            if (userId == null) return;
                            string relationEntityName = string.Empty;
                            if (entity.PhysicalName == "Note")
                                relationEntityName = objectStateEntry.CurrentValues["ObjectType"].ToString();
                            Notification.CreateNotification.CreateCommonNotification(entityId, entity.PhysicalName,
                                relationEntityName, userId??Guid.Empty, oldValue, languageId);
                        });
                        context.NotificationAction = action;
                    }
                    dbContext.SaveChanges();
                };
            return context;
        }

        static void SetPropertyValue(object obj, string propertyName, object value)
        {
            System.Reflection.PropertyInfo info = obj.GetType().GetProperty(propertyName);
            if (info == null) return;
            info.SetValue(obj, value, null);
        }

        static object CreateAudit(Entity entity, ObjectStateEntry objectStateEntry, Guid entityId, Guid trasactionId, Type auditType, Guid? userId, DateTime createdOn)
        {
            var auditInfo = Activator.CreateInstance(auditType);
            SetPropertyValue(auditInfo, "AuditId", Guid.NewGuid());
            SetPropertyValue(auditInfo, "Action", objectStateEntry.State.ToString());
            SetPropertyValue(auditInfo, "ObjectId", entityId);
            SetPropertyValue(auditInfo, "ObjectType", entity.Name);
            SetPropertyValue(auditInfo, "TrasactionId", trasactionId);
            SetPropertyValue(auditInfo, "CreatedOn", createdOn);
            SetPropertyValue(auditInfo, "UserId", userId);
            return auditInfo;
        }

        private static DbCompiledModel GetCopiledModel()
        {
            if (_cachedCompiledModel == null)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Katrin"].ConnectionString;
                using (var connection = new SqlConnection(connectionString))
                {
                    _cachedCompiledModel = _builder.Build(connection).Compile();
                }
            }
            return _cachedCompiledModel;
        }

        private static List<Entity> GetEntityMetadataList()
        {
            using (var context = KatrinEntities.CreateInstance())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;
                var metadataQuery = context.Entities.Include("Attributes");
                metadataQuery = metadataQuery.Include("Attributes.AttributeType");
                metadataQuery = metadataQuery.Include("RelationshipRoles");
                metadataQuery = metadataQuery.Include("RelationshipRoles.EntityRelationship");
                metadataQuery = metadataQuery.Include("RelationshipRoles.EntityRelationship.EntityRelationshipRelationships");
                metadataQuery = metadataQuery.Include("RelationshipRoles.EntityRelationship.EntityRelationshipRelationships.Relationship");
                return metadataQuery.ToList();
            }
        }

        private static void PrepareBuilder()
        {
            foreach (var entityMetadata in _entities)
            {
                var type = DynamicTypeBuilder.Instance.DynamicTypes.First(t => t.Name == entityMetadata.PhysicalName);

                ConfigurateKey(entityMetadata, type);

                if (entityMetadata.Attributes.Any(a => a.PhysicalName == "VersionNumber"))
                    ConfigurateColumn(type, "VersionNumber", DatabaseGeneratedOption.Computed);

                ConfigurateNavigationProperty(entityMetadata, type);
            }
        }

        private static object GetEntityConfiguration(Type type)
        {
            var builderExpression = Expression.Constant(_builder);
            var entityExpression = Expression.Call(builderExpression, "Entity", new[] { type });
            var configurationInstance = Expression.Lambda(entityExpression).Compile().DynamicInvoke();
            return configurationInstance;
        }

        private static void ConfigurateKey(Entity entityMetadata, Type type)
        {
            var configurationInstance = GetEntityConfiguration(type);
            var keyFieldName = entityMetadata.Attributes.First(a => a.IsPKAttribute == true).PhysicalName;
            var entityParameter = Expression.Parameter(type);
            var keyPropertyExpression = Expression.Property(entityParameter, keyFieldName);
            var keyType = ((PropertyInfo)keyPropertyExpression.Member).PropertyType;
            var keyExpression = Expression.Lambda(keyPropertyExpression, entityParameter);

            var instanceExpression = Expression.Constant(configurationInstance);
            var hasKeyExpression = Expression.Call(instanceExpression, "HasKey", new[] { keyType }, keyExpression);
            Expression.Lambda(hasKeyExpression).Compile().DynamicInvoke();
        }

        private static void ConfigurateColumn(Type type, string columnName, DatabaseGeneratedOption? option)
        {
            var configurationInstance = GetEntityConfiguration(type);
            var entityParameter = Expression.Parameter(type);
            var columnPropertyExpression = Expression.Property(entityParameter, columnName);
            var columnExpression = Expression.Lambda(columnPropertyExpression, entityParameter);

            var instanceExpression = Expression.Constant(configurationInstance);
            var propertyExpression = Expression.Call(instanceExpression, "Property", null, columnExpression);
            var methodInfo = propertyExpression.Type.GetMethod("HasColumnName", new[] { typeof(string) });
            var columnParameter = Expression.Constant(columnName);
            var hasColumnExpression = Expression.Call(propertyExpression, methodInfo, columnParameter);
            if (option.HasValue)
            {
                var optionMethodInfo = hasColumnExpression.Type.GetMethod("HasDatabaseGeneratedOption");
                var hasGeneratedOption =
                    Expression.Call(hasColumnExpression, optionMethodInfo,
                                    Expression.Constant(option, typeof(DatabaseGeneratedOption?)));
                Expression.Lambda(hasGeneratedOption).Compile().DynamicInvoke();
            }

        }

        private static void ConfigurateNavigationProperty(Entity entityMetadata, Type type)
        {
            foreach (var role in entityMetadata.RelationshipRoles)
            {
                if (role.EntityRelationship.EntityRelationshipType == 0) // one to many
                {
                    var relationship = role.EntityRelationship.EntityRelationshipRelationships.Single().Relationship;
                    if (role.RelationshipRoleType == 1) // the many side
                    {
                        var hasExpression = GetHasDependentExpression(type, relationship);
                        var withManyExpression = Expression.Call(hasExpression, "WithMany", null);

                        var hasForeignKeyExpression = GetHasForeignKeyExpression(relationship, withManyExpression);
                        Expression.Lambda(hasForeignKeyExpression).Compile().DynamicInvoke();
                    }
                    else
                    {
                        var hasManyExpression = GetHasManyExpression(type, relationship);
                        var withManyExpression = GetWithDependentExpression(relationship, hasManyExpression);

                        var hasForeignKeyExpression = GetHasForeignKeyExpression(relationship, withManyExpression);
                        Expression.Lambda(hasForeignKeyExpression).Compile().DynamicInvoke();
                    }
                }
                else // many to many
                {
                    if (role.RelationshipRoleType == 3) // the relationship table of the manty-to-many
                    {
                        foreach (var relationshipRelationship in role.EntityRelationship.EntityRelationshipRelationships)
                        {
                            var relationship = relationshipRelationship.Relationship;
                            var propertyName = relationship.ReferencingAttribute.PhysicalName.Replace("Id", string.Empty);
                            var propertyInfo = (PropertyInfo)Expression.Property(Expression.Parameter(type), propertyName).Member;
                            var navigationPropertyName = type.Name.InflectTo().Pluralized;
                            var navigationParamenter = Expression.Parameter(propertyInfo.PropertyType, "");
                            Expression navigationPropertyExpression =
                                Expression.Property(navigationParamenter, navigationPropertyName);
                            navigationPropertyExpression = Expression.ConvertChecked(navigationPropertyExpression, typeof(ICollection<>).MakeGenericType(type));
                            navigationPropertyExpression = Expression.Quote(Expression.Lambda(navigationPropertyExpression, navigationParamenter));

                            var hasExpression = GetHasDependentExpression(type, relationship);

                            try
                            {
                                var withManyExpression = Expression.Call(hasExpression, "WithMany", null, navigationPropertyExpression);

                                var hasForeignKeyExpression = GetHasForeignKeyExpression(relationship, withManyExpression);
                                Expression.Lambda(hasForeignKeyExpression).Compile().DynamicInvoke();
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        private static MethodCallExpression GetHasForeignKeyExpression(Relationship relationship,
                                                                       MethodCallExpression withManyExpression)
        {
            string referencingEntityName = relationship.ReferencingEntity.PhysicalName;
            var referencingPropertyName = relationship.ReferencingAttribute.PhysicalName;
            var referencingEntityType =
                DynamicTypeBuilder.Instance.DynamicTypes.First(t => t.Name == referencingEntityName);
            var entityParameter = Expression.Parameter(referencingEntityType);
            var foreginKeyExpression = Expression.Property(entityParameter, referencingPropertyName);
            var foreginKeyType = ((PropertyInfo)foreginKeyExpression.Member).PropertyType;
            var foreginKeyLambdaExpression = Expression.Lambda(foreginKeyExpression, entityParameter);
            var hasForeignKeyExpression = Expression.Call(withManyExpression, "HasForeignKey",
                                                          new[] { foreginKeyType },
                                                          foreginKeyLambdaExpression);
            return hasForeignKeyExpression;
        }

        private static MethodCallExpression GetHasDependentExpression(Type type, Relationship relationship)
        {
            var referencingPropertyName = relationship.ReferencingAttribute.PhysicalName;
            var propertyName = referencingPropertyName.Replace("Id", string.Empty);
            string referencedEntityName = relationship.ReferencedEntity.PhysicalName;
            var referencedEntityType = DynamicTypeBuilder.Instance.DynamicTypes.First(t => t.Name == referencedEntityName);
            var entityParameter = Expression.Parameter(type);
            var propertyExpression = Expression.Property(entityParameter, propertyName);
            var propertyLambdaExpression = Expression.Lambda(propertyExpression, entityParameter);
            var methodName = "HasOptional";
            if (relationship.ReferencingAttribute.IsNullable == false) methodName = "HasRequired";

            var configurationInstance = GetEntityConfiguration(type);
            var instanceExpression = Expression.Constant(configurationInstance);
            var hasExpression = Expression.Call(instanceExpression, methodName, new[] { referencedEntityType },
                                                         propertyLambdaExpression);
            return hasExpression;
        }

        private static MethodCallExpression GetWithDependentExpression(Relationship relationship,
                                                                      MethodCallExpression hasManyExpression)
        {
            var referencingPropertyName = relationship.ReferencingAttribute.PhysicalName;
            var propertyName = referencingPropertyName.Replace("Id", string.Empty);
            string referencingEntityName = relationship.ReferencingEntity.PhysicalName;
            var referencingEntityType =
                DynamicTypeBuilder.Instance.DynamicTypes.First(t => t.Name == referencingEntityName);
            var entityParameter = Expression.Parameter(referencingEntityType);
            var propertyExpression = Expression.Property(entityParameter, propertyName);
            var propertyLambdaExpression = Expression.Lambda(propertyExpression, entityParameter);
            var methodName = "WithOptional";
            if (relationship.ReferencingAttribute.IsNullable == false) methodName = "WithRequired";
            var withOptionalExpression = Expression.Call(hasManyExpression, methodName, null,
                                                         propertyLambdaExpression);
            return withOptionalExpression;
        }

        private static MethodCallExpression GetHasManyExpression(Type type, Relationship relationship)
        {
            string referencingEntityName = relationship.ReferencingEntity.PhysicalName;
            var referencingEntityType =
                DynamicTypeBuilder.Instance.DynamicTypes.First(t => t.Name == referencingEntityName);
            var propertyName = referencingEntityName.InflectTo().Pluralized;
            var entityParameter = Expression.Parameter(type);
            var collectionType = typeof(ICollection<>).MakeGenericType(referencingEntityType);
            var propertyExpression = Expression.ConvertChecked(Expression.Property(entityParameter, propertyName),
                                                               collectionType);
            var propertyLambdaExpression = Expression.Lambda(propertyExpression, entityParameter);

            var configurationInstance = GetEntityConfiguration(type);
            var instanceExpression = Expression.Constant(configurationInstance);
            var hasManyExpression = Expression.Call(instanceExpression, "HasMany",
                                                    new[] { referencingEntityType },
                                                    propertyLambdaExpression);
            return hasManyExpression;
        }

    }
}
