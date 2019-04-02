using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Constants;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.MetadataServiceReference;
using CABDevExpress.SmartPartInfos;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using Katrin.Win.Infrastructure.Services;
using Microsoft.Practices.CompositeUI.SmartParts;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Utility;
using Katrin.Win.Common.Controls;

namespace Katrin.Win.MetadataManager
{
    public class MetadataDetailPresenter : Presenter<IMetadataDetailView>
    {
        private readonly MetadataServiceClient metadataServiceClient = MetadataProvider.CreateServiceClient();

        [EventPublication(EventTopicNames.EntitySaved, PublicationScope.WorkItem)]
        public event EventHandler EntitySaved;

        protected void OnEntitySaved(EventArgs e)
        {
            EventHandler handler = EntitySaved;
            if (handler != null) handler(this, e);
        }

        private Entity entity;

        public Guid EntityId
        {
            get { return (Guid) WorkItem.State["EntityId"]; }
            set { WorkItem.State["EntityId"] = value; }
        }

        public EntityDetailWorkingMode WorkingMode
        {
            get { return (EntityDetailWorkingMode) WorkItem.State["WorkingMode"]; }
            set { WorkItem.State["WorkingMode"] = value; }
        }

        [CommandHandler("Save")]
        public void OnView(object sender, EventArgs e)
        {
            SaveEntity();
            View.SetControlState(EntityId);
        }

        [CommandHandler("SaveAndClose")]
        public void SaveAndClose(object sender, EventArgs e)
        {
            if (SaveEntity())
                WorkItem.Commands["Close"].Execute();
        }

        [CommandHandler("Edit")]
        public void Edit(object sender, EventArgs e)
        {
            View.SetControlState(Guid.Empty);
        }

        private bool SaveEntity()
        {
            View.PostEditors();
            if (!View.ValidateData())
            {
                return false;
            }
            bool isAdd = false;
            if (EntityId == Guid.Empty)
            {
                isAdd = true;
                EntityId = Guid.NewGuid();
                entity.EntityId = EntityId;
            }
            metadataServiceClient.SaveEntity(entity, isAdd);
            if (WorkingMode == EntityDetailWorkingMode.Add) WorkingMode = EntityDetailWorkingMode.Edit;
            OnEntitySaved(EventArgs.Empty);
            WorkItem.Commands["Refresh"].Execute();
            BindList();
            return true;
        }


        protected override void OnViewSet()
        {
            base.OnViewSet();

            if (WorkingMode != EntityDetailWorkingMode.View)
                View.SelectTab(0);
            BindList();
        }

        private void BindList()
        {
            if (EntityId == Guid.Empty)
                entity = new Entity();
            else
                entity = metadataServiceClient.GetMetaEntityById(EntityId);
            if (WorkingMode == EntityDetailWorkingMode.Edit)
                View.SetControlState(Guid.Empty);
            else
                View.SetControlState(EntityId);

            View.Bind(new List<Entity>(new[] {entity}));
        }

        public void DeleteAttribute(Guid attributeId)
        {
            metadataServiceClient.DeleteEntityAttribute(attributeId);
            BindList();
        }

        public void DeleteView(Guid viewId)
        {
            metadataServiceClient.DeleteEntityView(viewId);
            BindList();
        }

        public void ShowAttributeDetail(Guid attributeId)
        {
            var attributeDetailView = WorkItem.Items.AddNew<AttributeDetailView>();
            var optionSetList = metadataServiceClient.GetOptionSet();
            var attributePickList = metadataServiceClient.GetAttributePicklistValue();
            FormatTypeDefind fd = new FormatTypeDefind();
            var formatTypeList = fd.GetFormatList();
            var entityList = metadataServiceClient.GetMetaEntities();
            var relationList = metadataServiceClient.GetEntityRelationshipRoles();
            attributeDetailView.InitOptionSetUpEdit(optionSetList, attributePickList, formatTypeList, entityList);
            EntityAttribute attribute = new EntityAttribute();
            attribute.IsNullable = true;
            if (attributeId != Guid.Empty)
                attribute = metadataServiceClient.GetEntityAttribute(attributeId);
            attributeDetailView.WorkItem = WorkItem;
            attributeDetailView.BindData(attribute, relationList);
            var info = new XtraWindowSmartPartInfo { StartPosition = FormStartPosition.CenterParent, Icon = Properties.Resources.ri_Katrin, Modal = true, Title = "Attrbute" };
            WorkItem.Workspaces[WorkspaceNames.ModalWindows].Show(attributeDetailView, info);
            if (attributeDetailView.IsSave)
            {
                // ??
                bool isAdd = true;
                
                if (attributeId != Guid.Empty) isAdd = false;
                SaveAttribute(attribute, attributeDetailView.RelationShip, isAdd);
            }
        }

        [EventSubscription("FreshOptionSet", Thread = ThreadOption.UserInterface)]
        public void FreshOptionSet(object sender, DataEventArgs<Guid> e)
        {
            AttributeDetailView attributeDetailView = sender as AttributeDetailView;
            if(attributeDetailView != null)
            {
                 var optionSetList = metadataServiceClient.GetOptionSet();
                var attributePickList = metadataServiceClient.GetAttributePicklistValue();
                attributeDetailView.FreshOptionSetLookUp(e.Data, optionSetList, attributePickList);
            }
        }


        [EventSubscription("CloseAttributeDetailView", Thread = ThreadOption.UserInterface)]
        public void CloseAttributeDetailView(object sender, EventArgs e)
        {
            IWorkspaceLocatorService locator = WorkItem.Services.Get<IWorkspaceLocatorService>();
            IWorkspace wks = locator.FindContainingWorkspace(WorkItem, sender);
            if (wks != null)
                wks.Close(sender);
        }

        public void SaveAttribute(EntityAttribute attribute, Relationship relationShip, bool isAdd)
        {
            attribute.EntityId = EntityId;
            attribute.LogicalName = attribute.Name;
            attribute.PhysicalName = attribute.TableColumnName;
            if (isAdd)
                attribute.AttributeId = Guid.NewGuid();
            if (relationShip != null)
            {
                relationShip.RelationshipId = Guid.NewGuid();
                relationShip.ReferencingEntityId = attribute.EntityId;
                relationShip.ReferencingAttributeId = attribute.AttributeId;
            }
            metadataServiceClient.SaveEntityAttribute(attribute, relationShip, isAdd);
            BindList();
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = GetLocalizedCaption(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            buttonItem.Name = commandName;
            buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        private string GetLocalizedCaption(string name)
        {
            return Properties.Resources.ResourceManager.GetString(name);
        }

        public void ShowSavedQueryDetail(SavedQuery savedQuery)
        {
            var savedQueryDetailView = WorkItem.Items.AddNew<SavedQueryDetailView>();
            savedQueryDetailView.Bind(savedQuery);
            var info = new XtraWindowSmartPartInfo { StartPosition = FormStartPosition.CenterParent, Icon = Properties.Resources.ri_Katrin, Modal = true, Title = "View Design" };
            WorkItem.Workspaces[WorkspaceNames.ModalWindows].Show(savedQueryDetailView, info);
            BindList();
            savedQueryDetailView.Dispose();
        }
    }
}
