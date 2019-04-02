using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Constants;
using Katrin.Win.Infrastructure;
using Katrin.Win.Infrastructure.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Common.MetadataServiceReference;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.CompilerServices;
using System.Dynamic;

namespace Katrin.Win.Common.Core
{
    public class EntityDetailPresenter<TView> : Presenter<TView> where TView : IEntityDetailView
    {
        [EventPublication(EventTopicNames.EntitySaved, PublicationScope.WorkItem)]
        public event EventHandler<EventArgs<bool>> EntitySaved;

        protected void OnEntitySaved(EventArgs<bool> e)
        {
            EventHandler<EventArgs<bool>> handler = EntitySaved;
            if (handler != null) handler(this, e);
        }

        public object ConvertEntiy
        {
            get { return WorkItem.State["ConvertEntiy"]; }
            set { WorkItem.State["ConvertEntiy"] = value; }
        }

        public string ConvertName
        {
            get { return (string)WorkItem.State["ConvertName"]; }
            set { WorkItem.State["ConvertName"] = value; }
        }


        public Guid EntityId
        {
            get { return (Guid)WorkItem.State["EntityId"]; }
            set { WorkItem.State["EntityId"] = value; }
        }

        public Guid NewEntityId
        {
            get;
            set;
        }

        public string EntityName { get; set; }

        protected dynamic DynamicEntity { get; private set; }

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        public virtual EntityDetailWorkingMode WorkingMode
        {
            get { return (EntityDetailWorkingMode)WorkItem.State["WorkingMode"]; }
            set
            {
                WorkItem.State["WorkingMode"] = value;
                View.SetEditorStatus(WorkingMode == EntityDetailWorkingMode.View);
            }
        }

        [CommandHandler("Save")]
        public void OnSave(object sender, EventArgs e)
        {
            SaveEntity();
        }

        [CommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (SaveEntity())
                WorkItem.Commands["Close"].Execute();
        }

        [CommandHandler("CopyAndNew")]
        public void CopyAndNew(object sender, EventArgs e)
        {
            View.PostEditors();
            OnSaving();
            if (!View.ValidateData())
            {
                return;
            }
            if (NewEntityId == Guid.Empty)
            {
                _dynamicDataServiceContext = new DynamicDataServiceContext();
                EntityId = NewEntityId;
                var newEntity = GetEntity();
                var metaEntity = MetadataProvider.Instance.EntiyMetadata.Where(c => c.PhysicalName == EntityName).FirstOrDefault();
                foreach (var att in metaEntity.Attributes)
                {
                    if (att.IsCopyEnabled??false)
                    {
                        object targetValue = GetDynamicMember(DynamicEntity, att.TableColumnName);
                        newEntity.GetType().GetProperty(att.TableColumnName).SetValue(newEntity, targetValue, null);
                    }
                }
                DynamicEntity = new SysBits.DynamicProxies.DynamicProxy(newEntity);
                WorkingMode = EntityDetailWorkingMode.Add;
                RefreshEntityId(newEntity);
                NewEntityId = EntityId;
                Type entityType = newEntity.GetType();
                Type listGenericType = typeof(List<>);
                Type listType = listGenericType.MakeGenericType(entityType);
                var list = (IList)Activator.CreateInstance(listType);
                list.Add(newEntity);
                BindData(list);
            }
            OnEntitySaved(new EventArgs<bool>(true));
        }

        object GetDynamicMember(object obj, string memberName)
        {
            var binder = Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, memberName, obj.GetType(),
                new[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) });
            var callsite = CallSite<Func<CallSite, object, object>>.Create(binder);
            return callsite.Target(callsite, obj);
        }


        protected string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.BeginInit();
            View.UserDataPersistenceService = UserDataPersistenceService;
            View.EntityName = EntityName;
            var entity = GetEntity();
            DynamicEntity = new SysBits.DynamicProxies.DynamicProxy(entity);
            RefreshEntityId(entity);
            Type entityType = entity.GetType();
            Type listGenericType = typeof(List<>);
            Type listType = listGenericType.MakeGenericType(entityType);
            var list = (IList)Activator.CreateInstance(listType);
            list.Add(entity);

            var entityMetadata = MetadataProvider.Instance.EntiyMetadata.First(e => e.TableName == EntityName);


            BindData(list);
            View.InitEditors(entityMetadata);
            View.SetEditorStatus(WorkingMode == EntityDetailWorkingMode.View);
            View.EndInit();
        }

        protected virtual void RefreshEntityId(object entity)
        {

            ConvertEntity(entity);
            if (WorkingMode == EntityDetailWorkingMode.Add)
                EntityId = DynamicDataServiceContext.GetObjectId(EntityName, entity);
            
        }

        [ServiceDependency(Required = false)]
        public UserDataPersistenceService UserDataPersistenceService { get; set; }

        protected virtual void BindData(object data)
        {
            View.Bind(data);
        }

        protected virtual object GetEntity()
        {
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, EntityId, "CreatedBy,ModifiedBy");
            ConvertEntity(entity);
            return entity;
        }

        protected List<ColumnMapping> GetMappingList()
        {
            List<ColumnMapping> mappingList = MetadataProvider.Instance.MappingList.Where(c => c.SourceEntityName == ConvertName
                && c.TargetEntityName == EntityName).ToList();
            return mappingList;
        }

        protected virtual void ConvertEntity(object entity)
        {
            if (ConvertEntiy != null && WorkingMode == EntityDetailWorkingMode.Convert && ConvertName != "")
            {
                WorkingMode = EntityDetailWorkingMode.Add;
                var mappingList = GetMappingList();
                foreach (var mappingItem in mappingList)
                {
                    SetProperValue(ConvertEntiy, mappingItem.SourceAttributeName, entity, mappingItem.TargetAttributeName);
                }
            }
        }

        protected void SetProperValue(object sourceObject, string sourceAttributeName, object targetObject, string targetAttributeName)
        {
            PropertyInfo sourceProperty = sourceObject.GetType().GetProperty(sourceAttributeName);
            PropertyInfo targetProperty = targetObject.GetType().GetProperty(targetAttributeName);
            if (sourceProperty != null && targetProperty != null
                && targetProperty.PropertyType.FullName.Contains(sourceProperty.PropertyType.FullName))
            {
                targetProperty.SetValue(targetObject, sourceProperty.GetValue(sourceObject, null), null);
            }
        }

        protected virtual void OnSaving()
        {
        }

        protected virtual void OnSaved()
        {
            MetadataProvider.Instance.CreateCommonNotification(EntityId, EntityName, string.Empty);
        }

        private bool SaveEntity()
        {
            View.PostEditors();
            OnSaving();
            if (!View.ValidateData())
            {
                return false;
            }
            DynamicDataServiceContext.SaveChanges();
            NewEntityId = Guid.Empty;
            OnSaved();
            if (WorkingMode == EntityDetailWorkingMode.Add) WorkingMode = EntityDetailWorkingMode.Edit;
            OnEntitySaved(new EventArgs<bool>(false));
            WorkItem.Commands["Refresh"].Execute();
            return true;
        }
    }
}
