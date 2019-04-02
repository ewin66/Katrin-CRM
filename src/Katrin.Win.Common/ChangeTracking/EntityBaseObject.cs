using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Services.Client;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using Katrin.Win.Common.Security;
using Microsoft.Data.Edm;

namespace Katrin.Win.Common.ChangeTracking
{
    public class EntityBaseObject : IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region ChangeTracking

        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
                SetFieldValue(this, "ModifiedOn", DateTime.Now);
                SetFieldValue(this, "ModifiedById", AuthorizationManager.CurrentUserId);
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged { add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;

        [DoNotSerializeAttribute]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }

        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }

        protected bool IsDeserializing { get; private set; }

        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }

        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }

        protected virtual void ClearNavigationProperties()
        {
        }

        #endregion

        private static void SetFieldValue(object entity, string fieldName, object fieldValue)
        {
            var fieldInfo = entity.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(entity, fieldValue);
            }
        }

        private void FixupOrder_Details(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }

            if (e.NewItems != null)
            {
                foreach (var newItem in e.NewItems)
                {
                    var newItemTypeName = newItem.GetType().Name;
                    //ServiceContext.AddRelatedObject(entity, property.Name, newItem);
                    //SetEntityId(newItemTypeName, newItem, Guid.NewGuid());

                    var roles = MetadataProvider.Instance.EntityRelationshipRoles
                        .Where(r => r.Entity.PhysicalName == newItemTypeName
                                    && r.EntityRelationship.EntityRelationshipRelationships
                                           .Exists(p => p.Relationship.ReferencedEntity.PhysicalName == this.GetType().Name));
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

            if (e.OldItems != null)
            {
                //foreach (Order_Detail item in e.OldItems)
                //{
                //    if (ReferenceEquals(item.Product, this))
                //    {
                //        item.Product = null;
                //    }
                //    if (ChangeTracker.ChangeTrackingEnabled)
                //    {
                //        ChangeTracker.RecordRemovalFromCollectionProperties("Order_Details", item);
                //        // Delete the dependent end of this identifying association. If the current state is Added,
                //        // allow the relationship to be changed without causing the dependent to be deleted.
                //        if (item.ChangeTracker.State != ObjectState.Added)
                //        {
                //            item.MarkAsDeleted();
                //        }
                //    }
                //    // This is the principal end in an association that performs cascade deletes.
                //    // Remove the previous dependent from the event listener.
                //    ChangeTracker.ObjectStateChanging -= item.HandleCascadeDelete;
                //}
            }
        }
    }
}
