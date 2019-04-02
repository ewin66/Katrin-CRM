using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Properties;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Constants;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Utility;
using Katrin.Win.Common.FormatCondition;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using System.IO;
using System.Xml.Linq;
using Antlr4.StringTemplate;
using DevExpress.XtraEditors;
using Katrin.Win.Common.FilterCondition;
using System.Drawing;
using Katrin.Win.Common.Security;
using CABDevExpress.Workspaces;
using Katrin.Win.Common.Notification;
using DevExpress.Data.Filtering;

namespace Katrin.Win.Common.Core
{
    public abstract class EntityListController<TListView, TDetailView> : RecordListController<TListView, TDetailView>
        where TListView : EntityListView
        where TDetailView : AbstractDetailView
    {
        #region init
        protected override void InitController()
        {
            base.InitController();

            //init page group
            InitPageGroup();

            //format
            string formatOperatePageGroup = "FormatOperatePageGroup";
            RegisterCommandInvoker("Format", "Format", null, formatOperatePageGroup, false, 84);

            //related
            RegisterRelatedEntityCommand();

            // init convert
            InitConvert();

            //flter
            var fastOperateGroup = UIExtensionSites["HomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Filters")));
            string fastOperatePageGroup = "FastOperatePageGroup";
            UIExtensionSites.RegisterSite(fastOperatePageGroup, fastOperateGroup);
            RibbonGalleryBar ribbonGallery = new RibbonGalleryBar(this,_entityListView,EntityName);
            UIExtensionSites[fastOperatePageGroup].Add(ribbonGallery);
            ribbonGallery.InitFilters();
            InitLoginUser(fastOperateGroup.Ribbon);
        }

        private void InitPageGroup()
        {
            var showGroup = UIExtensionSites["HomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Show")));
            string showPageGroup = "ShowPageGroup";
            UIExtensionSites.RegisterSite(showPageGroup, showGroup);

            var addGroup = UIExtensionSites["HomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Add")));
            string addPageGroup = "AddPageGroup";
            UIExtensionSites.RegisterSite(addPageGroup, addGroup);

            var foramtOperateGroup = UIExtensionSites["SkinPage"].Add(new RibbonPageGroup(GetLocalizedCaption("Format")));
            string formatOperatePageGroup = "FormatOperatePageGroup";
            UIExtensionSites.RegisterSite(formatOperatePageGroup, foramtOperateGroup);
        }

        protected override void InitViewList()
        {
            base.InitViewList();
            if (_entityListView != null)
            {
                Items.Add(new DockManagerWorkspace(_entityListView.DockManager), WorkspaceNames.DockManagerWorkspace);
            }
        }
        
        #endregion

        #region InitLoginUser
        private void InitLoginUser(RibbonControl Ribbon)
        {
            //??CLEAR SET
            if (RootWorkItem.State["hasAddBarStaticItem"] == null)
            {
                RootWorkItem.State["hasAddBarStaticItem"] = true;
                var clearSettingButton = new BarButtonItem();
                clearSettingButton.Caption = Resources.ClearSetting;
                clearSettingButton.Glyph = (Bitmap)Resources.ResourceManager.GetObject("ri_clear");
                clearSettingButton.ItemClick += delegate
                {
                    string message = Resources.ClearSettingConfirm;
                    var result = XtraMessageBox.Show(message, Properties.Resources.Katrin, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.OK)
                    {
                        var stateFiles = Directory.GetFiles(Application.StartupPath, "*.state");
                        foreach (var stateFile in stateFiles)
                        {
                            File.Delete(stateFile);
                        }
                    }
                };
                Ribbon.Items.Add(clearSettingButton);
                ApplicationMenu pmAppMain = Ribbon.ApplicationButtonDropDownControl as ApplicationMenu;
                if (pmAppMain != null)
                    pmAppMain.ItemLinks.Add(clearSettingButton);

                 //set logined user full name
                var _fullNameItem = new BarStaticItem();
                _fullNameItem.Caption = AuthorizationManager.FullName;
                Ribbon.Items.Add(_fullNameItem);
                _fullNameItem.ItemClick += (s, e) => ShowRelatedEntityDetail("User", AuthorizationManager.CurrentUserId);
                _fullNameItem.Glyph = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("userinfo");
                Ribbon.PageHeaderItemLinks.AddRange(new BarItem[] { _fullNameItem });

                var notificationItem = new BarStaticItem();
                notificationItem.Caption = Properties.Resources.Notification;
                Ribbon.Items.Add(notificationItem);
                notificationItem.ItemClick += (s, e) =>
                    {
                        string notificationKey = "NotificationListView";
                        var detailWorkItem = Items.Get<WorkItem>(notificationKey);
                        if (detailWorkItem == null)
                        {
                            detailWorkItem = Items.AddNew<WorkItem>(notificationKey);
                        }
                        detailWorkItem.Run();
                        var notificationListView = detailWorkItem.Items.Get<NotificationList>(notificationKey);
                        if (notificationListView != null) detailWorkItem.Items.Remove(notificationListView);
                        notificationListView = detailWorkItem.Items.AddNew<NotificationList>(notificationKey);
                        var info = new XtraWindowSmartPartInfo { Size = new Size(850, 400), StartPosition = FormStartPosition.CenterParent, Icon = Properties.Resources.ri_Katrin, Modal = true, Title = Properties.Resources.Notification + "   " };
                        detailWorkItem.Workspaces[WorkspaceNames.ModalWindows].Show(notificationListView, info);
                    };
                notificationItem.Glyph = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("notificationb");
                Ribbon.PageHeaderItemLinks.AddRange(new BarItem[] { notificationItem });

                //send sys msg
                var sysMsgItem = new BarStaticItem();
                sysMsgItem.Caption = Properties.Resources.SendSysMessage;
                Ribbon.Items.Add(sysMsgItem);
                sysMsgItem.ItemClick += (s, e) =>
                {
                    string sysMsgKey = "SendSysMsg";
                    var detailWorkItem = Items.Get<WorkItem>(sysMsgKey);
                    if (detailWorkItem == null)
                    {
                        detailWorkItem = Items.AddNew<WorkItem>(sysMsgKey);
                    }
                    detailWorkItem.Run();
                    var sysMsgView = detailWorkItem.Items.Get<SendSysNotification>(sysMsgKey);
                    if (sysMsgView != null) detailWorkItem.Items.Remove(sysMsgView);
                    sysMsgView = detailWorkItem.Items.AddNew<SendSysNotification>(sysMsgKey);
                    var info = new XtraWindowSmartPartInfo { StartPosition = FormStartPosition.CenterParent, Icon = Properties.Resources.ri_Katrin, Modal = true, Title = Properties.Resources.SendSysMessage};
                    detailWorkItem.Workspaces[WorkspaceNames.ModalWindows].Show(sysMsgView, info);
                };
                sysMsgItem.Glyph = (System.Drawing.Bitmap)Properties.Resources.ResourceManager.GetObject("sendsysmsg");
                Ribbon.PageHeaderItemLinks.AddRange(new BarItem[] { sysMsgItem });

            }
        }

       

        
        #endregion

        #region related
        private void RegisterRelatedEntityCommand()
        {
            var allRelationshipRoles = MetadataProvider.Instance.EntityRelationshipRoles;
            var relationshipRoles = allRelationshipRoles.Where(role => role.Entity.PhysicalName == EntityName && role.NavPanelDisplayOption == 1);
            if (relationshipRoles.Any())
            {
                var relatedEntityButtons = new List<BarButtonItemEx>();
                foreach (var relationshipRole in relationshipRoles)
                {
                    var entityRelation = relationshipRole.EntityRelationship;
                    var relatedRole = entityRelation.EntityRelationshipRoles
                        .FirstOrDefault(r => r != relationshipRole
                            && r.RelationshipRoleType != (int)RelationshipRoleType.Relationship);

                    if (relatedRole == null) continue;

                    var name = relatedRole.Entity.PhysicalName;
                    if (!AuthorizationManager.CheckAccess(name, "Read")) continue;
                    var localizedCaption = GetLocalizedCaption(name);
                    var buttonItem = new BarButtonItemEx(name, "Search") { Caption = localizedCaption };
                    if(relationshipRoles.Count() > 1)
                    buttonItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText | 
                        DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
                    buttonItem.ItemClick += (s, e) => {ShowRelatedView(entityRelation); };
                    relatedEntityButtons.Add(buttonItem);
                }
                if (relatedEntityButtons.Any())
                {
                    
                    var relatedGroup = UIExtensionSites["HomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Related")));
                    UIExtensionSites.RegisterSite("RelatedGroup", relatedGroup);
                    foreach (var button in relatedEntityButtons)
                    {
                        UIExtensionSites["RelatedGroup"].Add(button);
                    }
                }
            }
        }

        private void ShowRelatedView(EntityRelationship entityRelationship)
        {
            EntityRelationshipType relationshipType = (EntityRelationshipType)entityRelationship.EntityRelationshipType;

            var currentEntityRelationRole = entityRelationship.EntityRelationshipRoles.Single(r => r.Entity.PhysicalName == EntityName);
            string relationTitle = GetLocalizedCaption(currentEntityRelationRole.Entity.PhysicalName) + "-";
            if (relationshipType == EntityRelationshipType.OneToMany)
            {
                var roleType = (RelationshipRoleType)currentEntityRelationRole.RelationshipRoleType;
                var relationship = entityRelationship.EntityRelationshipRelationships.Single().Relationship;
                if (roleType == RelationshipRoleType.OneToMany)
                {
                    var desiredEntityName = relationship.ReferencingEntity.PhysicalName;
                    var entityId = GetId(_entityListView.SelectedEntity);
                    CriteriaOperator filter = new BinaryOperator(relationship.ReferencingAttribute.Name, entityId, BinaryOperatorType.Equal);
                    var result = DynamicDataServiceContext.GetObjects(desiredEntityName, filter, null);
                    if (result.ToArrayList().Count > 0)
                        ShowRelatedEntityList(desiredEntityName, relationTitle, filter);
                    else
                    {
                        XtraMessageBox.Show(Properties.Resources.NoRelatedData, Properties.Resources.Katrin,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    var entityName = relationship.ReferencedEntity.PhysicalName;
                    string desiredPropertyName = relationship.ReferencingAttribute.PhysicalName;
                    var propertyInfo = _entityListView.SelectedEntity.GetType().GetProperty(desiredPropertyName);
                    var id = propertyInfo.GetValue(_entityListView.SelectedEntity, null);
                    if (id != null)
                    {
                        ShowRelatedEntityDetail(entityName, (Guid)id);
                    }
                    else
                    {
                        XtraMessageBox.Show(_entityListView, Properties.Resources.NoRelatedData,
                        Properties.Resources.Katrin,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                var relationshipRole = entityRelationship.EntityRelationshipRoles
                    .Single(r => (RelationshipRoleType) r.RelationshipRoleType == RelationshipRoleType.Relationship);
                var desiredEntityRole = entityRelationship.EntityRelationshipRoles
                    .Single(r => r != relationshipRole && r != currentEntityRelationRole);
                var desiredEntityPropertyName =
                    entityRelationship.EntityRelationshipRelationships.Select(r => r.Relationship)
                        .Single(r => r.ReferencedEntity.EntityId == desiredEntityRole.Entity.EntityId).
                        ReferencedAttribute.PhysicalName;
                var knownPropertyName = entityRelationship.EntityRelationshipRelationships.Select(r => r.Relationship)
                    .Single(r => r.ReferencedEntity.EntityId == currentEntityRelationRole.Entity.EntityId).
                    ReferencedAttribute.PhysicalName;

                CriteriaOperator filter = new BinaryOperator(knownPropertyName, GetId(_entityListView.SelectedEntity));
                var relationships = DynamicDataServiceContext.GetObjects(relationshipRole.Entity.PhysicalName, filter, null);

                List<object> desiredEntityIds = new List<object>();
                CriteriaOperator relatedFilter = null;
                for (int index = 0; index < relationships.Count; index++)
                {
                    var relatedObject = relationships[index];
                    var propertyInfo = relatedObject.GetType().GetProperty(desiredEntityPropertyName);
                    var desiredEntityId = propertyInfo.GetValue(relatedObject, null);
                    desiredEntityIds.Add(desiredEntityId);
                    relatedFilter |= new BinaryOperator(desiredEntityPropertyName, desiredEntityId);
                }
                if (desiredEntityIds.Any())
                {
                    if (desiredEntityIds.Count == 1)
                        ShowRelatedEntityDetail(desiredEntityRole.Entity.PhysicalName, (Guid)desiredEntityIds[0]);
                    else
                        ShowRelatedEntityList(desiredEntityRole.Entity.PhysicalName, relationTitle, relatedFilter);
                }
                else
                {
                    XtraMessageBox.Show(_entityListView, Properties.Resources.NoRelatedData,
                    Properties.Resources.Katrin, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ShowRelatedEntityList(string name, string title, CriteriaOperator filter)
        {
            title += GetLocalizedCaption(name);
            var listViewType = FindLoadedType(name + "ListView");

            var addNewMethod =
                Items.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.IsGenericMethod && m.Name == "AddNew").MakeGenericMethod(listViewType);

            var objectView = addNewMethod.Invoke(Items,new object[]{});
            var entityListView = objectView as EntityListView;
            if (entityListView != null)
            {
                entityListView.FixedPredicate = filter;
                entityListView.InitEntityView(name);
                entityListView.Bind(name);
                var info = new XtraWindowSmartPartInfo { StartPosition = FormStartPosition.CenterParent, Icon = Properties.Resources.ri_Katrin, Modal = true, Title = title };
                Workspaces[WorkspaceNames.ModalWindows].Show(entityListView, info);
            }
        }

        private void ShowRelatedEntityDetail(string name, Guid id)
        {
            ShowRelatedEntityDetail(name, id, EntityDetailWorkingMode.View);
        }

        private void ShowRelatedEntityDetail(string name, Guid id,EntityDetailWorkingMode workMode)
        {
            var detailViewType = FindLoadedType(name + "DetailView");

            if (!typeof(AbstractDetailView).IsAssignableFrom(detailViewType))
            {
                throw new Exception("The detail view has to be derived from AbstractDetailView");
            }

            var showDetailMethod = this.GetType().GetMethod("ShowEntityDetails").MakeGenericMethod(detailViewType);
            showDetailMethod.Invoke(this, new object[] { workMode, name, id });
        }

        private static Type FindLoadedType(string typeName)
        {
            foreach (var assem in AppDomain.CurrentDomain.GetAssemblies().Where(asm => asm.FullName.StartsWith("Katrin")))
            {
                var query = assem.GetTypes().Where(t => t.Name == typeName);
                if (query.Any()) return query.Single();
            }
            return null;
        }
        #endregion


        #region common

        public Guid GetSelectEntityId()
        {
            return GetId(_entityListView.SelectedEntity);
        }

        protected override Guid GetId(object entity)
        {
            if (entity == null)
                return Guid.Empty;
            return DynamicDataServiceContext.GetObjectId(EntityName, entity);
        }

        [EventSubscription(EventTopicNames.FocusedRowChanged, Thread = ThreadOption.UserInterface)]
        public void OnFocusedRowChanged(object sender, EventArgs<object> e)
        {
            UpdateCommandStatus();
        }
        #endregion

        #region command
        [CommandHandler("Format")]
        public void OnFormat(object sender, EventArgs e)
        {
            string key = EntityName + ":FormatConditionList";
            var formatConditionListView = Items.Get<FormatConditionList>(key);
            if (formatConditionListView == null) formatConditionListView = Items.AddNew<FormatConditionList>(key);
            formatConditionListView.EntityTypeName = EntityName;
            formatConditionListView.SetGridView(_entityListView.EntityGridView);
            formatConditionListView.ShowDialog();
        }
        #endregion

        #region command status
        protected virtual void UpdateCommandStatus()
        {
            Commands["Add"].Status = AuthorizationManager.CheckAccess(EntityName, "Create")
                                         ? CommandStatus.Enabled
                                         : CommandStatus.Unavailable;
            SetCommandStatus("Edit", "Write");
            SetCommandStatus("View", "Read");
            SetCommandStatus("Delete", "Delete");

            if (!UIExtensionSites.Contains("RelatedGroup")) return;
            
            var relatedItems = UIExtensionSites["RelatedGroup"];
            if (relatedItems != null)
            {
                var buttons = relatedItems.OfType<BarButtonItemEx>();
                foreach (var button in buttons)
                {
                    button.Enabled = _entityListView.SelectedEntity != null && _entityListView.EntityGridView.RowCount != 0;
                }
            }
            var convertSiteName = UIExtensionSites.Where(c => c.ToString() == "ConvertGroup");
            if (convertSiteName.ToList().Count > 0)
            {
                var convertItems = UIExtensionSites["ConvertGroup"];
                var buttons = convertItems.OfType<BarButtonItemEx>();
                foreach (var button in buttons)
                {
                    button.Enabled = _entityListView.SelectedEntity != null && _entityListView.EntityGridView.RowCount != 0;
                }
            }
        }

        private void SetCommandStatus(string commandName, string priviledge)
        {
            if (AuthorizationManager.CheckAccess(EntityName, priviledge))
            {
                bool initSatus = _entityListView.EntityGridView.DataSource == null && _entityListView.Context.BindingSource.ToArrayList().Count > 0;
                initSatus = initSatus || (_entityListView.SelectedEntity != null && _entityListView.EntityGridView.RowCount != 0);
                Commands[commandName].Status =
                    initSatus ? CommandStatus.Enabled : CommandStatus.Disabled;
            }
            else
            {
                Commands[commandName].Status = CommandStatus.Unavailable;
            }
        }
        #endregion

        #region convert

        [EventSubscription(EventTopicNames.ConvertDetail, Thread = ThreadOption.UserInterface)]
        public void OnConvertDetail(object sender, EventArgs<string> e)
        {
            ShowRelatedEntityDetail(e.Data, Guid.Empty, EntityDetailWorkingMode.Convert);
        }

        private void InitConvert()
        {
            List<ColumnMapping> mappingList = MetadataProvider.Instance.MappingList
                .Where(c => c.SourceEntityName == EntityName).ToList();
            var toConverList = mappingList.Select(c => c.TargetEntityName).Distinct();
            if (toConverList.Any())
            {
                var convertEntityButtons = new List<BarButtonItemEx>();
                foreach (string commandName in toConverList)
                {
                    if (!AuthorizationManager.CheckAccess(commandName, "Write")) continue;
                    var localizedCaption = GetLocalizedCaption(commandName);
                    var buttonItem = new BarButtonItemEx(commandName, "convert") { Caption = localizedCaption };
                    buttonItem.Name = commandName;
                    if (toConverList.Count() > 1)
                        buttonItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText |
                            DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
                    buttonItem.ItemClick += (s, e) => { ShowRelatedEntityDetail(e.Item.Name, Guid.Empty, EntityDetailWorkingMode.Convert); };
                    convertEntityButtons.Add(buttonItem);
                }
                if (convertEntityButtons.Count > 0)
                {
                    var convertGroup = UIExtensionSites["HomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("ConvertTitle")));
                    UIExtensionSites.RegisterSite("ConvertGroup", convertGroup);
                    foreach (var button in convertEntityButtons)
                    {
                        UIExtensionSites["ConvertGroup"].Add(button);
                    }
                }
            }
        }
        #endregion
    }
}
