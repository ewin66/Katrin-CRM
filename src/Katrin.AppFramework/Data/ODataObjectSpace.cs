using DevExpress.Data.Filtering;
using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Csdl;
using Microsoft.Data.Edm.Validation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using DevExpress.Data;
using System.ComponentModel;
using System.Collections.Specialized;
using Katrin.AppFramework.Metadata;
using Katrin.Domain.Impl;
using System.Collections;
using Katrin.AppFramework.Security;
using System.Linq.Expressions;

namespace Katrin.AppFramework
{
    public class ODataObjectSpace : IObjectSpace
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
                    _context = new CodeFirstContainer(new Uri(ServerUrl))
                    {
                        MergeOption = MergeOption.OverwriteChanges
                    };
                    //_context.IgnoreResourceNotFoundException = true;
                    _context.SendingRequest += _context_SendingRequest;
                    _context.WritingEntity += _context_WritingEntity;
                }
                return _context;
            }
        }

        void _context_SendingRequest(object sender, SendingRequestEventArgs e)
        {
            //CookieContainer container = null;
            //var clientFormsIdentity = Thread.CurrentPrincipal.Identity as ClientFormsIdentity;
            //container = clientFormsIdentity != null
            //                ? clientFormsIdentity.AuthenticationCookies
            //                : ((CustomIdentity)Thread.CurrentPrincipal.Identity).AuthenticationCookies;
            //((HttpWebRequest)e.Request).CookieContainer = container;
        }

        void _context_WritingEntity(object sender, ReadingWritingEntityEventArgs e)
        {
            // e.Data gives you the XElement for the Serialization of the Entity 
            //Using XLinq  , you can  add/Remove properties to the element Payload  
            XName xnEntityProperties = XName.Get("properties", e.Data.GetNamespaceOfPrefix("m").NamespaceName);
            XElement xePayload = null;
            foreach (PropertyInfo property in e.Entity.GetType().GetProperties())
            {
                //object[] doNotSerializeAttributes = property.GetCustomAttributes(typeof(DoNotSerializeAttribute), false);
                //if (doNotSerializeAttributes.Length > 0)
                //{
                //    if (xePayload == null)
                //    {
                //        xePayload = e.Data.Descendants().Where<XElement>(xe => xe.Name == xnEntityProperties).First<XElement>();
                //    }
                //    //The XName of the property we are going to remove from the payload
                //    XName xnProperty = XName.Get(property.Name, e.Data.GetNamespaceOfPrefix("d").NamespaceName);
                //    //Get the Property of the entity  you don't want sent to the server
                //    foreach (XElement xeRemoveThisProperty in xePayload.Descendants(xnProperty).ToList())
                //    {
                //        //Remove this property from the Payload sent to the server 
                //        xeRemoveThisProperty.Remove();
                //    }
                //}
            }
        }

        private static IEdmModel EdmModel
        {
            get
            {
                if (_edmModel == null)
                {
                    Initialize();
                }
                return _edmModel;
            }
        }

        public static void Initialize()
        {
            //GET service metadata
            string metadata = GetMetadata(new Uri(ServerUrl + "/$metadata"));

            //Parse the metadata
            IEnumerable<EdmError> errors;
            XmlReader xmlReader = XmlReader.Create(new StringReader(metadata));
            EdmxReader.TryParse(xmlReader, out _edmModel, out errors);
            var types = _edmModel.SchemaElements
                .Where(se => se.SchemaElementKind == EdmSchemaElementKind.TypeDefinition).Cast<IEdmEntityType>();
        }

        private static string GetMetadata(Uri metadataUri)
        {
            using (var client = new CookieAwareWebClient())
            {
                return client.DownloadString(metadataUri);
            }
        }


        private bool HasField(Type entityType, string fieldName)
        {
            var fieldInfo = entityType.GetField("_"+ fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                return true;
            }
            return false;
        }

        private void SetFieldValue(object entity, string fieldName, object fieldValue)
        {
            var fieldInfo = entity.GetType().GetField("_" + fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(entity, fieldValue);
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


        public  void SetEntityId(string entityName, object entity, Guid id)
        {
            var entityType = entity.GetType();
            var entityMetadataType = GetTypeDefinition(entityName);
            var primaryField = entityMetadataType.Key().First().Name;
            var idProperty = entityType.GetProperty(primaryField);
            idProperty.SetValue(entity, id, null);
        }

        public void UpdateObject(object entity)
        {
            ServiceContext.UpdateObject(entity);
        }

        public void AddObject(string entityName, object entity)
        {
            var entitySets = EdmModel.EntityContainers().SelectMany(container => container.EntitySets());

            var entitySet = entitySets.First(es => es.Name == entityName.InflectTo().Pluralized);

            ServiceContext.AddObject(entitySet.Name, entity);

            _changeTrackingEnabled = true;
            if (entity != null)
                ToggleChangeTracker(entity, true);
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

        public void LoadProperty(object entity, string propertyName)
        {
            ServiceContext.LoadProperty(entity, propertyName);
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
                    
                    var roles = MetadataRepository.EntityRelationshipRoles
                        .Where(r => r.Entity.PhysicalName == newItemTypeName
                                    && r.EntityRelationship.EntityRelationshipRelationships.ToList()
                                    .Exists(p => p.Relationship.ReferencedEntity.PhysicalName == entityTypeName));
                        
                    foreach (var role in roles)
                    {
                        var rerferancingAttributeName = role.EntityRelationship.EntityRelationshipRelationships[0]
                            .Relationship.ReferencingAttribute.PhysicalName;
                        var entityPropertyInfo = newItem.GetType().GetProperty(rerferancingAttributeName);
                        if (entityPropertyInfo != null)
                        {
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
                        ServiceContext.DeleteObject(oldItem);
                    }
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


        public Type ResolveType(string entityName)
        {
            string edmName = string.Concat("CodeFirstNamespace.", entityName);
            return ServiceContext.ResolveType(edmName); 
        }

        public object GetOrNew(string entityName, Guid id, string path)
        {
            object entity = null;
            var entityType = GetTypeDefinition(entityName);
            var entityClrtype = ResolveType(entityName); 
            if (id == Guid.Empty)
            {
                entity = Activator.CreateInstance(entityClrtype);
                AddObject(entityName, entity);
                SetEntityId(entityName, entity, Guid.NewGuid());
                SetFieldValue(entity, "CreatedOn", DateTime.Now);
                SetFieldValue(entity, "CreatedById", AuthorizationManager.CurrentUserId);
                SetFieldValue(entity, "OwnerId", AuthorizationManager.CurrentUserId);
                SetFieldValue(entity, "ModifiedOn", DateTime.Now);
                SetFieldValue(entity, "ModifiedById", AuthorizationManager.CurrentUserId);
            }
            else
            {
                var primaryField = entityType.Key().First().Name;
                var query = GetObjectQuery(entityName);
                if (!string.IsNullOrEmpty(path))
                {
                    query = query.Expand(path);
                }
                BinaryOperator binaryOperator = new BinaryOperator(primaryField, id);
                query = query.Where(binaryOperator) as DataServiceQuery;
                _changeTrackingEnabled = false;
                entity = query.Execute()._First();
                _changeTrackingEnabled = true;
                if (entity != null)
                    ToggleChangeTracker(entity, true);
            }
            
            return entity;
        }

        public void DeleteObject(string entityName, object entity)
        {
            Uri editLink;
            var entityType = GetTypeDefinition(entityName);
            var entityClrtype = ResolveType(entityType.Name);
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
                var entityObject = GetOrNew(entityName, id,null);
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


        private class CookieAwareWebClient : WebClient
        {
            protected override WebRequest GetWebRequest(Uri address)
            {
                //var identity = Thread.CurrentPrincipal.Identity as ClientFormsIdentity;
                WebRequest request = base.GetWebRequest(address);
                var webRequest = request as HttpWebRequest;
                //if (webRequest != null && identity != null)
                //{
                //    webRequest.CookieContainer = identity.AuthenticationCookies;
                //}
                return request;
            }
        }


        public IList GetBatchObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties)
        {
            DataServiceQuery query = CreateObjectQuery(entityName, filter, properties);
            var batchRequests = new DataServiceRequest[] { query };
            DataServiceResponse batchResponse = ServiceContext.ExecuteBatch(batchRequests);


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

        public System.Collections.IList GetObjects(string objectName)
        {
            var query = GetObjectQuery(objectName);
            return query.ToList();
        }

        public System.Collections.IList GetObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties)
        {
            DataServiceQuery query = CreateObjectQuery(entityName, filter, properties);
            var result = query.ToList();
            return result;
        }

        private DataServiceQuery CreateObjectQuery(string entityName, CriteriaOperator filter,
                                                   Dictionary<string, string> properties)
        {
            var entityType = GetTypeDefinition(entityName);
            string selector = null;
            if (properties != null)
            {
                var propertyNames =
                    entityType.StructuralProperties()
                              .Where(p => !properties.ContainsKey(p.Name))
                              .Select(p => p.Name)
                              .ToList();
                propertyNames.ForEach(p => properties.Add(p, p));

                var fetchingProperties = properties.Select(addition => addition.Value + " AS " + addition.Key);
                selector = "new(" + string.Join(",", fetchingProperties) + ")";
            }

            return GetObjectQuery(entityName, selector, filter);
        }

        public void Dispose()
        {
        }

        public DataServiceQuery GetObjectQuery(string objectName)
        {
            return GetObjectQuery(objectName, null, null);
        }

        public DataServiceQuery GetObjectQuery(string objectName, string selector, CriteriaOperator criteria)
        {
            return GetObjectQuery(objectName, selector, criteria, false);
        }

        public DataServiceQuery GetObjectQuery(string objectName, string selector, CriteriaOperator criteria,
                                               bool includingDeleted)
        {
            var entitySetName = objectName.InflectTo().Pluralized;
            var entityClrtype = ResolveType(objectName);

            var query = ServiceContext.CreateQuery(entityClrtype, entitySetName);
            if (!includingDeleted)
            {
                query = ExcludeDeletedObjects(query);
            }
            if ((object) criteria != null)
            {
                query = query.Where(criteria);
            }
            if (!string.IsNullOrEmpty(selector))
            {
                query = (DataServiceQuery) query.Select(selector);
            }
            return query;
        }

        private DataServiceQuery ExcludeDeletedObjects(DataServiceQuery query)
        {
            bool hasIsDeletedProperty = HasField(query.ElementType, "IsDeleted");
            if (hasIsDeletedProperty)
            {
                var deletedFilter = new BinaryOperator("IsDeleted", false);
                {
                    return query.Where(deletedFilter);
                }
            }
            return query;
        }

        public IEdmEntityType GetTypeDefinition(string objectName)
        {
            return EdmModel.SchemaElements.OfType<IEdmEntityType>()
                .SingleOrDefault(t => t.Name == objectName);
        }
    }
}
