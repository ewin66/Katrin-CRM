using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Threading;
using System.Web.ClientServices;
using System.Xml.Linq;
using Katrin.Win.Common.ChangeTracking;
using Katrin.Win.Common.Security;
using DevExpress.Data;
using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Validation;
using Microsoft.Data.Edm.Csdl;
using System.Configuration;
using System.Data.Services.Client;
using System.Collections;
using System.IO;
using System.Net;
using System.Xml;
using System.Linq.Expressions;
using DevExpress.Data.Filtering;
using Katrin.Win.WcfServerMode;

namespace Katrin.Win.Common
{
    public class DynamicDataServiceContext : IDynamicDataServiceContext
    {
        private static IEdmModel _edmModel;
        private DataServiceContext _context;
        private static bool _changeTrackingEnabled;

        private static string ServerUrl
        {
            get { return ConfigurationManager.AppSettings["ServerUrl"] + "/EntityDataService.svc"; }
        }


        private DataServiceContext ServiceContext
        {
            get
            {
                if (_context == null)
                {
                    _context = new DataServiceContext(new Uri(ServerUrl))
                                   {
                                       MergeOption = MergeOption.OverwriteChanges
                                   };
                    _context.IgnoreResourceNotFoundException = true;
                    _context.SendingRequest += _context_SendingRequest;
                    _context.WritingEntity += _context_WritingEntity;
                    
                    
                }
                return _context;
            }
        }

        void _context_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            CookieContainer container = null;
            var clientFormsIdentity = Thread.CurrentPrincipal.Identity as ClientFormsIdentity;
            container = clientFormsIdentity != null
                            ? clientFormsIdentity.AuthenticationCookies
                            : ((CustomIdentity) Thread.CurrentPrincipal.Identity).AuthenticationCookies;
            ((HttpWebRequest) e.Request).CookieContainer = container;
        }

        void _context_WritingEntity(object sender, ReadingWritingEntityEventArgs e)
        {
            // e.Data gives you the XElement for the Serialization of the Entity 
            //Using XLinq  , you can  add/Remove properties to the element Payload  
            XName xnEntityProperties = XName.Get("properties", e.Data.GetNamespaceOfPrefix("m").NamespaceName);
            XElement xePayload = null;
            foreach (PropertyInfo property in e.Entity.GetType().GetProperties())
            {
                object[] doNotSerializeAttributes = property.GetCustomAttributes(typeof(DoNotSerializeAttribute), false);
                if (doNotSerializeAttributes.Length > 0)
                {
                    if (xePayload == null)
                    {
                        xePayload = e.Data.Descendants().Where<XElement>(xe => xe.Name == xnEntityProperties).First<XElement>();
                    }
                    //The XName of the property we are going to remove from the payload
                    XName xnProperty = XName.Get(property.Name, e.Data.GetNamespaceOfPrefix("d").NamespaceName);
                    //Get the Property of the entity  you don't want sent to the server
                    foreach (XElement xeRemoveThisProperty in xePayload.Descendants(xnProperty).ToList())
                    {
                        //Remove this property from the Payload sent to the server 
                        xeRemoveThisProperty.Remove();
                    }
                }
            }
        }

        private static IEdmModel EdmModel
        {
            get
            {
                if (_edmModel == null)
                {
                    //GET service metadata
                    string metadata = GetMetadata(new Uri(ServerUrl + "/$metadata"));

                    //Parse the metadata
                    IEnumerable<EdmError> errors;
                    XmlReader xmlReader = XmlReader.Create(new StringReader(metadata));
                    EdmxReader.TryParse(xmlReader, out _edmModel, out errors);
                    var types = _edmModel.SchemaElements
                        .Where(se => se.SchemaElementKind == EdmSchemaElementKind.TypeDefinition).Cast<IEdmEntityType>();
                    DynamicTypeBuilder.Instance.BuildDynamicType(types);
                }
                return _edmModel;
            }
        }

        public static IEnumerable<IEdmEntityType> GetTypeDefinitions()
        {
            return EdmModel.SchemaElements.OfType<IEdmEntityType>();
        }

        public static IEdmEntityType GetTypeDefinition(string entityName)
        {
            return GetTypeDefinitions().SingleOrDefault(t => t.Name == entityName);
        }

        private DataServiceQuery CreateQuery(string entityName)
        {
            var entitySetName = entityName.InflectTo().Pluralized;
            var entityClrtype = DynamicTypeBuilder.Instance.GetDynamicType(entityName);
            
            var query = ServiceContext.CreateQuery(entityClrtype, entitySetName);
            
            return query;
        }

        public object GetOrNew(string entityName, Guid id)
        {
            return GetOrNew(entityName, id, null);
        }

        public object GetOrNew(string entityName, Guid id, string path)
        {
            object entity = null;
            var entityType = GetTypeDefinition(entityName);
            var entityClrtype = DynamicTypeBuilder.Instance.GetDynamicType(entityType.Name);
            if (id == Guid.Empty)
            {
                entity = Activator.CreateInstance(entityClrtype);
                AddObject(entityName,entity);
                SetEntityId(entityName, entity, Guid.NewGuid());
                SetFieldValue(entity, "CreatedOn", DateTime.Now);
                SetFieldValue(entity, "CreatedById", AuthorizationManager.CurrentUserId);
                SetFieldValue(entity, "OwnerId", AuthorizationManager.CurrentUserId);
                SetFieldValue(entity, "ModifiedOn", DateTime.Now);
                SetFieldValue(entity, "ModifiedById", AuthorizationManager.CurrentUserId);
                _changeTrackingEnabled = true;
            }
            else
            {
                var primaryField = entityType.Key().First().Name;
                var query = CreateQuery(entityName);
                if (!string.IsNullOrEmpty(path))
                {
                    query = query.Expand(path);
                }
                query = query.Where(primaryField + " == @0", id) as DataServiceQuery;
                _changeTrackingEnabled = false;
                entity = query.Execute()._First();
                _changeTrackingEnabled = true;
            }
            ToggleChangeTracker(entity, true);
            return entity;
        }

        public object GetPropertyValue(string entityName, object keyValue,string propertyName)
        {
            DataServiceQuery query = CreateQuery(entityName);
            var entityMetadataType = GetTypeDefinition(entityName);
            var primaryField = entityMetadataType.Key().First().Name;
            var q = query.Where(primaryField + " = @0", keyValue).Select(propertyName);
            return q._First();
        }

        private void SetFieldValue(object entity, string fieldName,object fieldValue)
        {
            var fieldInfo = entity.GetType().GetField(fieldName,BindingFlags.NonPublic| BindingFlags.Instance);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(entity, fieldValue);
            }
        }

        private bool HasField(Type entityType, string fieldName)
        {
            var fieldInfo = entityType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                return true;
            }
            return false;
        }

        private void ToggleChangeTracker(object entity, bool turnOn)
        {
            var trackedObject = entity as INotifyPropertyChanged;
            if (trackedObject != null)
            {
                if (turnOn)
                    trackedObject.PropertyChanged += OnEntityPropertyChanged;
                else
                {
                    trackedObject.PropertyChanged -= OnEntityPropertyChanged;
                }
            }
            var entityMetadataType = GetTypeDefinition(entity.GetType().Name);
            var navigationProperties = entityMetadataType.NavigationProperties();
            foreach (var navigationProperty in navigationProperties)
            {
                IEdmNavigationProperty property = navigationProperty;
                var typeKind = property.Type.TypeKind();
                if (typeKind == EdmTypeKind.Collection)
                {
                    var propertyInfo = entity.GetType().GetProperty(property.Name);
                    var propertyValue = (INotifyCollectionChanged)propertyInfo.GetValue(entity, null);
                    propertyValue.CollectionChanged += (s, e) => OnEntityCollectionPropertyChanged(entity, property, e);
                }
            }
        }

        void OnEntityPropertyChanged(object entity, PropertyChangedEventArgs e)
        {
            if (!_changeTrackingEnabled) return;
            var descriptor = ServiceContext.GetEntityDescriptor(entity);
            if (descriptor != null && descriptor.State == EntityStates.Unchanged)
            {
                SetFieldValue(entity, "ModifiedOn", DateTime.Now);
                SetFieldValue(entity, "ModifiedById", AuthorizationManager.CurrentUserId);
                ServiceContext.UpdateObject(entity);
            }
        }

        void OnEntityCollectionPropertyChanged(object entity, IEdmNavigationProperty property, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (!_changeTrackingEnabled) return;
            var entityTypeName = entity.GetType().Name;
            if (eventArgs.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var newItem in eventArgs.NewItems)
                {
                    var newItemTypeName = newItem.GetType().Name;
                    ServiceContext.AddRelatedObject(entity, property.Name, newItem);
                    SetEntityId(newItemTypeName, newItem, Guid.NewGuid());

                    var roles = MetadataProvider.Instance.EntityRelationshipRoles
                        .Where(r => r.Entity.PhysicalName == newItemTypeName
                                    && r.EntityRelationship.EntityRelationshipRelationships
                                           .Exists(p => p.Relationship.ReferencedEntity.PhysicalName == entityTypeName));
                    foreach (var role in roles)
                    {
                        var rerferancingAttributeName = role.EntityRelationship.EntityRelationshipRelationships[0]
                            .Relationship.ReferencingAttribute.PhysicalName;
                        var entityPropertyInfo = newItem.GetType().GetProperty(rerferancingAttributeName);
                        if (entityPropertyInfo != null)
                        {
                            //var entityId = GetEntityId(entityTypeName, entity);
                            //entityPropertyInfo.SetValue(newItem, entityId, null);
                        }
                    }
                }
            }
            else if (eventArgs.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var oldItem in eventArgs.OldItems)
                {
                    bool isTracked = IsTracked(oldItem);
                    if (isTracked)
                    {
                        //if (!IsAdded(oldItem) && !IsAdded(entity)) ServiceContext.DeleteLink(entity, property.Name, oldItem);
                        ServiceContext.DeleteObject(oldItem);
                    }
                }
            }
        }

        public Guid GetObjectId(string entityName, object entity)
        {
            if (entity != null && entity is NotLoadedObject) return Guid.Empty;
            var entityType = entity.GetType();
            var entityMetadataType = GetTypeDefinition(entityName);
            if (entityMetadataType == null) return Guid.Empty;
            var primaryField = entityMetadataType.Key().First().Name;
            var idProperty = entityType.GetProperty(primaryField);
            return (Guid)idProperty.GetValue(entity, null);
        }

        private static void SetEntityId(string entityName, object entity, Guid id)
        {
            var entityType = entity.GetType();
            var entityMetadataType = GetTypeDefinition(entityName);
            var primaryField = entityMetadataType.Key().First().Name;
            var idProperty = entityType.GetProperty(primaryField);
            idProperty.SetValue(entity, id, null);
        }

        public void AddObject(string entityName, object entity)
        {
            var entitySets = EdmModel.EntityContainers().SelectMany(container => container.EntitySets());

            var entitySet = entitySets.First(es => es.Name == entityName.InflectTo().Pluralized);

            ServiceContext.AddObject(entitySet.Name, entity);
        }

        public void UpdateObject(object entity)
        {
            ServiceContext.UpdateObject(entity);
        }

        public void LoadProperty(object entity, string propertyName)
        {
            ServiceContext.LoadProperty(entity, propertyName);
        }

        private void Fixup(object entity)
        {
            var entityName = entity.GetType().Name;
            var entityMetadataType = GetTypeDefinition(entityName);
            var navigationProperties = entityMetadataType.NavigationProperties();
            foreach (var navigationProperty in navigationProperties)
            {
                IEdmNavigationProperty property = navigationProperty;
                var typeKind = property.Type.TypeKind();
                switch (typeKind)
                {
                    case EdmTypeKind.Entity:
                        break;
                    case EdmTypeKind.Collection:
                        {
                            var propertyInfo = entity.GetType().GetProperty(navigationProperty.Name);
                            var list = (IList) propertyInfo.GetValue(entity, null);
                            foreach (var relatedEntity in list)
                            {
                                bool isTracked = IsTracked(relatedEntity);
                                if (!isTracked) continue;
                                ServiceContext.UpdateObject(relatedEntity);
                            }
                        }
                        break;
                }
            }
        }

        private bool IsTracked(object entity)
        {
            if (ServiceContext.GetEntityDescriptor(entity) != null)
            {
                return true;
            }
            return false;
        }

        private bool IsAdded(object entity)
        {
            var descriptor = ServiceContext.GetEntityDescriptor(entity);
            if (descriptor != null)
            {
                return descriptor.State == EntityStates.Added;
            }
            return false;
        }

        public void DeleteObject(string entityName, object entity)
        {
            Uri editLink;
            var entityType = GetTypeDefinition(entityName);
            var entityClrtype = DynamicTypeBuilder.Instance.GetDynamicType(entityType.Name);
            bool hasIsDeletedProperty = HasField(entityClrtype, "IsDeleted");
            if (ServiceContext.TryGetUri(entity, out editLink))
            {
                if (hasIsDeletedProperty)
                {
                    ServiceContext.UpdateObject(entity);
                    SetFieldValue(entity, "IsDeleted", true);
                }
                else
                    ServiceContext.DeleteObject(entity);
                return;
            }
            var id = GetObjectId(entityName, entity);

            if (hasIsDeletedProperty)
            {
                var entityObject = GetOrNew(entityName, id);
                SetFieldValue(entityObject, "IsDeleted", true);
                ServiceContext.UpdateObject(entityObject);
            }
            else
            {
                var entityObject = Activator.CreateInstance(entityClrtype);
                SetEntityId(entityName, entityObject, id);
                var entitySetName = entityName.InflectTo().Pluralized;
                ServiceContext.AttachTo(entitySetName, entityObject);
                ServiceContext.DeleteObject(entityObject);
            }
        }

        public void SaveChanges()
        {
            ServiceContext.SaveChanges();
        }

        private static string GetMetadata(Uri metadataUri)
        {
            using (var client = new CookieAwareWebClient())
            {
                return client.DownloadString(metadataUri);
            }
        }

        

        private class CookieAwareWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                var identity = Thread.CurrentPrincipal.Identity as ClientFormsIdentity;
                WebRequest request = base.GetWebRequest(address);
                var webRequest = request as HttpWebRequest;
                if (webRequest != null && identity != null)
                {
                    webRequest.CookieContainer = identity.AuthenticationCookies;
                }
                return request;
            }
        }

        public IList GetObjects(string entityName)
        {
            return GetObjects(entityName, null, null);
        }

        public IList GetObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties)
        {
            DataServiceQuery query = CreateObjectQuery(entityName, filter, properties);
            var result = query.ToList();
            return result;
        }

        public IList GetBatchObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties)
        {
            DataServiceQuery query = CreateObjectQuery(entityName, filter, properties);
            DataServiceRequest[] batchRequests = new DataServiceRequest[] { query };
            DataServiceResponse  batchResponse = ServiceContext.ExecuteBatch(batchRequests);
            
            
            IList list = null;
            foreach (QueryOperationResponse response in batchResponse)
            {
                // Handle an error response.
                if (response.StatusCode > 299 || response.StatusCode < 200)
                {
                    Console.WriteLine("An error occurred.");
                    Console.WriteLine(response.Error.Message);
                }
                else
                {
                    foreach (var item in response)
                    {
                        if (list == null)
                        {
                            var listType = typeof(List<>).MakeGenericType(item.GetType());
                            list = Activator.CreateInstance(listType) as IList;
                        }
                        list.Add(item);
                    }
                }
            }

            return list;
        }

        public DataServiceQuery CreateObjectQuery(string entityName, CriteriaOperator filter, Dictionary<string, string> properties)
        {
            var entityType = GetTypeDefinition(entityName);


            DataServiceQuery query = CreateQuery(entityName);
            bool hasIsDeletedProperty = HasField(query.ElementType, "IsDeleted");
            if (hasIsDeletedProperty)
            {
                BinaryOperator deletedFilter = new BinaryOperator("IsDeleted", false);
                if ((object)filter == null) filter = deletedFilter;
                else filter = filter & deletedFilter;
            }

            if ((object)filter != null)
            {
                query = DataServiceQueryTranslator.Translate(query, filter);
            }

            if (properties != null)
            {
                var propertyNames = entityType.StructuralProperties().Where(p => !properties.ContainsKey(p.Name)).Select(p => p.Name).ToList();
                propertyNames.ForEach(p => properties.Add(p, p));

                var fetchingProperties = properties.Select(addition => addition.Value + " AS " + addition.Key);
                query = query.Select("new(" + string.Join(",", fetchingProperties) + ")") as DataServiceQuery;
            }

            return query;
        }
    }

}
