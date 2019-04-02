using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Services.Client;
using Microsoft.Data.Edm;

namespace Katrin.AppFramework
{

    public interface IObjectSpace : IDisposable
    {
        //Object Owner { get; set; }
        //Boolean IsCommitting { get; }
        //Boolean IsModified { get; }
        //Boolean IsDeleting { get; }
        //Boolean IsDisposed { get; }
        //Boolean IsConnected { get; }
        //IObjectSpace CreateNestedObjectSpace();
        //Boolean CanInstantiate(Type type);
        //Object CreateObject(Type type);
        //ObjectType CreateObject<ObjectType>();
        //Object FindObject(Type objectType, CriteriaOperator criteria);
        //ObjectType FindObject<ObjectType>(CriteriaOperator criteria);
        //Object FindObject(Type objectType, CriteriaOperator criteria, Boolean inTransaction);
        //ObjectType FindObject<ObjectType>(CriteriaOperator criteria, Boolean inTransaction);
        //Object GetObject(Object objectFromDifferentObjectSpace);
        //ObjectType GetObject<ObjectType>(ObjectType objectFromDifferentObjectSpace);
        void LoadProperty(object entity, string propertyName);
        object GetOrNew(string entityName, Guid id, string path);
        Type ResolveType(string entityName);
        IList GetBatchObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties);
        void DeleteObject(string objectName, object obj);
        void UpdateObject(object entity);
        void AddObject(string entityName, object entity);
        void SaveChanges();
        Guid GetObjectId(string entityName, object entity);
        IEdmEntityType GetTypeDefinition(string objectName);
        IList GetObjects(string objectName);
        IList GetObjects(string entityName, CriteriaOperator filter, Dictionary<string, string> properties);
        DataServiceQuery GetObjectQuery(string objectName);
        DataServiceQuery GetObjectQuery(string objectName, string selector, CriteriaOperator criteria);
        DataServiceQuery GetObjectQuery(string objectName, string selector, CriteriaOperator criteria, bool includingDeleted);
        void SetEntityId(string entityName, object entity, Guid id);
        //DataServiceQuery GetObjectQuery(string objectName, string selector, System.Linq.Expressions.Expression criteria);
        //IList<T> GetObjects<T>();
        //IList GetObjects(Type type, CriteriaOperator criteria);
        //IList<T> GetObjects<T>(CriteriaOperator criteria);
        //IList GetObjects(Type type, CriteriaOperator criteria, Boolean inTransaction);
        //IList<T> GetObjects<T>(CriteriaOperator criteria, Boolean inTransaction);
        //IList CreateCollection(Type objectType);
        //IList CreateCollection(Type objectType, CriteriaOperator criteria);
        //Object CreateServerCollection(Type objectType, CriteriaOperator criteria);
        //void ReloadCollection(Object collection);
        //Boolean IsCollectionLoaded(Object collection);
        //Boolean Contains(Object obj);
        //Int32 GetObjectsCount(Type objectType, CriteriaOperator criteria);
        //IList ModifiedObjects { get; }
        //void SetModified(Object obj, System.Reflection.MemberInfo memberInfo);
        //void SetModified(Object obj);
        //void RemoveFromModifiedObjects(Object obj);
        //Object ReloadObject(Object obj);
        //ICollection GetObjectsToSave(Boolean includeParent);
        //ICollection GetObjectsToDelete(Boolean includeParent);
        //Boolean IsNewObject(Object obj);
        //Boolean IsObjectToSave(Object obj);
        //Boolean IsObjectToDelete(Object obj);
        //Boolean IsDeletedObject(Object obj);
        //Boolean IsDisposedObject(Object obj);
        //void Delete(Object obj);
        //void Delete(IList objects);
        //void CommitChanges();
        //Boolean Refresh();
        //Boolean Rollback();
        //String GetObjectHandle(Object obj);
        //Object GetObjectByHandle(String handle);
        //String GetKeyPropertyName(Type type);
        //Object GetKeyValue(Object obj);
        //Type GetKeyPropertyType(Type type);
        //String GetKeyValueAsString(Object obj);
        //Object GetObjectKey(Type objectType, String objectKeyString);
        //Object GetObjectByKey(Type type, Object key);
        //String GetDisplayableProperties(Object collection);
        //void SetDisplayableProperties(Object collection, String displayableProperties);
        //Boolean CanApplyCriteria(Type collectionType);
        //void ApplyCriteria(Object collection, CriteriaOperator criteria);
        //Boolean CanApplyFilter(Object collection);
        //void ApplyFilter(Object collection, CriteriaOperator filter);
        //CriteriaOperator GetFilter(Object collection);
        //CriteriaOperator GetCriteria(Object collection);
        //Boolean? IsObjectFitForCriteria(Type objectType, Object obj, CriteriaOperator criteria);
        //Boolean? IsObjectFitForCriteria(Object obj, CriteriaOperator criteria);
        //CriteriaOperator GetAssociatedCollectionCriteria(Object obj, System.Reflection.MemberInfo memberInfo);
        //CriteriaOperator ParseCriteria(String criteria);
        //IDisposable CreateParseCriteriaScope();
        //Int32 GetTopReturnedObjects(Object collection);
        //void SetTopReturnedObjects(Object collection, Int32 topReturnedObjects);
        //Boolean IsDeletionDefferedType(Type type);
        //event EventHandler Connected;
        //event EventHandler Reloaded;
        //event EventHandler ModifiedChanged;
        //event EventHandler<ConfirmationEventArgs> ConfirmationRequired;
        //event EventHandler<ObjectChangedEventArgs> ObjectChanged;
        //event EventHandler<ObjectManipulatingEventArgs> ObjectEndEdit;
        //event EventHandler<ObjectManipulatingEventArgs> ObjectReloaded;
        //event EventHandler<CancelEventArgs> Committing;
        //event EventHandler Committed;
        //event EventHandler<ObjectsManipulatingEventArgs> ObjectDeleting;
        //event EventHandler<ObjectsManipulatingEventArgs> ObjectDeleted;
        //event EventHandler<ObjectManipulatingEventArgs> ObjectSaving;
        //event EventHandler<ObjectManipulatingEventArgs> ObjectSaved;
        //event EventHandler<CancelEventArgs> Refreshing;
        //event EventHandler Disposed;
        //event EventHandler<CancelEventArgs> RollingBack;
        //event EventHandler<HandledEventArgs> CustomCommitChanges;
        //event EventHandler<CustomDeleteObjectsEventArgs> CustomDeleteObjects;
        //event EventHandler<HandledEventArgs> CustomRefresh;
        //event EventHandler<HandledEventArgs> CustomRollBack;
    }

}
