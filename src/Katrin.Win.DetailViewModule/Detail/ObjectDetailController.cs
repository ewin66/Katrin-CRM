using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.CSharp.RuntimeBinder;
using System.Runtime.CompilerServices;
using System.Dynamic;
using Katrin.AppFramework.WinForms.ViewInterface;
using ICSharpCode.Core;
using Katrin.AppFramework.MetadataServiceReference;
using Katrin.AppFramework.Metadata;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework.WinForms;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework.WinForms.Views;
using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.Workspaces;
using System.Windows.Forms;
namespace Katrin.Win.DetailViewModule
{
    public class ObjectDetailController : ObjectController, IObjectDetailController, IListener<UpdateDetailEntityMessage>
    {
        protected bool _hasChanges;
        public bool HasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                this._hasChanges = value;
            }
        }
        protected IObjectDetailView _detailView;
        


        public Guid ObjectId
        {
            get;
            set;
        }

        public Guid NewEntityId
        {
            get;
            set;
        }

        public object ObjectEntity { get; private set; }

        private EntityDetailWorkingMode _workingMode;
        public virtual EntityDetailWorkingMode WorkingMode
        {
            get
            {
                return _workingMode;
            }
            set
            {
                _workingMode = value;
            }
        }

        public ObjectDetailController()
        {
            EventAggregationManager.AddListener(this);
        }

        public bool OnSave()
        {
            return SaveEntity();
        }

        public bool SaveAndClose()
        {
            bool result = SaveEntity();
            if (result)
                _detailView.Close();
            return result;
        }

        public bool CopyAndNew()
        {
            _detailView.PostEditors();
            OnSaving();
            if (!_detailView.ValidateData())
            {
                return false;
            }
            if (NewEntityId == Guid.Empty)
            {
                _objectSpace = new ODataObjectSpace();
                ObjectId = NewEntityId;
                var newEntity = GetEntity();
                var metaEntity = MetadataRepository.Entities.Where(c => c.PhysicalName == ObjectName).FirstOrDefault();
                foreach (var att in metaEntity.Attributes)
                {
                    if (att.IsCopyEnabled ?? false)
                        SetProperValue(ObjectEntity, att.TableColumnName, newEntity, att.TableColumnName);
                }
                ObjectEntity = newEntity;
                WorkingMode = EntityDetailWorkingMode.Add;
                RefreshEntityId(newEntity);
                NewEntityId = ObjectId;
                BindData(ObjectEntity);
            }
            return true;
        }

        public override IActionResult Execute(ActionParameters parameters)
        {
            if (parameters.ContainsKey("ObjectEntity"))
                ObjectEntity = parameters.Get<object>("ObjectEntity");
            var objectId = parameters.ObjectId;
            var workMode = parameters.Get<EntityDetailWorkingMode>("WorkingMode");
            ObjectName = parameters.ObjectName;
            _detailView = ViewFactory.CreateView("Default" + ObjectName + "DetailView") as IObjectDetailView;
            this.ObjectId = objectId;
            this.WorkingMode = workMode;

            OnViewSet();
            var result = new PartialViewResult();
            result.View = _detailView;
            return result;
        }

        protected virtual void OnViewSet()
        {
            _detailView.BeginInit();
            if (ObjectEntity == null)
            {
                ObjectEntity = GetEntity();
            }
            else
            {
                _objectSpace.AddObject(ObjectName, ObjectEntity);
            }
            RefreshEntityId(ObjectEntity);
            BindData(ObjectEntity);
            InitEditors();
            SetEditorStatus();
            HasChanges = false;

            var message = new UpdateRibbonItemMessage(this.WorkSpaceID, this.ObjectName);
            EventAggregationManager.SendMessage(message);
            _detailView.ObjectChanged += View_ObjectChanged;
            _detailView.EndInit();
        }

        protected virtual void InitEditors()
        {
            var entityMetadata = MetadataRepository.Entities.First(e => e.TableName == ObjectName);
            _detailView.InitEditors(entityMetadata);
        }

        protected void View_ObjectChanged(object sender, EventArgs e)
        {
            if (!HasChanges)
            {
                HasChanges = true;
                var message = new UpdateRibbonItemMessage(this.WorkSpaceID, this.ObjectName);
                EventAggregationManager.SendMessage(message);
            }
        }

        public void SetEditorStatus()
        {
            _detailView.SetEditorStatus(WorkingMode == EntityDetailWorkingMode.View);
        }

        protected virtual void RefreshEntityId(object entity)
        {
            if (WorkingMode == EntityDetailWorkingMode.Add)
                ObjectId = _objectSpace.GetObjectId(ObjectName, entity);

        }



        protected virtual void BindData(object objectInfo)
        {
            if (objectInfo == null) return;
            Type entityType = objectInfo.GetType();
            Type listGenericType = typeof(List<>);
            Type listType = listGenericType.MakeGenericType(entityType);
            var list = (IList)Activator.CreateInstance(listType);
            list.Add(objectInfo);
            _detailView.Bind(list);
        }

        protected virtual object GetEntity()
        {
            var entity = _objectSpace.GetOrNew(ObjectName, ObjectId, "CreatedBy,ModifiedBy");
            return entity;
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

        protected void SetProperValue(object sourceValue, object targetObject, string targetAttributeName)
        {
            PropertyInfo targetProperty = targetObject.GetType().GetProperty(targetAttributeName);
            if (targetProperty != null)
            {
                targetProperty.SetValue(targetObject, sourceValue, null);
            }
        }

        protected virtual bool OnSaving()
        {
            return true;
        }

        protected virtual void OnSaved()
        {

        }

        private bool SaveEntity()
        {
            _detailView.PostEditors();
            if (!OnSaving()) return false;
            if (!_detailView.ValidateData())
            {
                return false;
            }
            _objectSpace.SaveChanges();
            NewEntityId = Guid.Empty;
            OnSaved();
            if (WorkingMode == EntityDetailWorkingMode.Add) WorkingMode = EntityDetailWorkingMode.Edit;
            HasChanges = false;
            EventAggregationManager.SendMessage(new ObjectSetChangedMessage { ObjectName = ObjectName });
            return true;
        }

        #region Fetch View Info
        public override object SelectedObject
        {
            get { return ObjectEntity; }
        }

        #endregion


        public void SetLoadedComplete()
        {
            this._hasChanges = false;
        }

        protected virtual void RefreshEntity(UpdateDetailEntityMessage message)
        {
            if (message.ObjectName != ObjectName)
            {
                return;
            }
            bool changed = HasChanges;
            ObjectEntity = GetEntity();
            HasChanges = false;
            Context.UpdateCommandState();
            if (changed)
            {
                Context.WorkSpace.ActiveWorkSpaceWindow();
                string showMessage = ResourceService.GetString("UpdateDetailEntity");
                MessageService.ShowMessage(showMessage);
            }
        }

        void IListener<UpdateDetailEntityMessage>.Handle(UpdateDetailEntityMessage message)
        {
            RefreshEntity(message);
        }
    }
}
