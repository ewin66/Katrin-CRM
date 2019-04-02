using System;
using System.Collections.Generic;
using System.Linq;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.MetadataServiceReference;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure.Services;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using DevExpress.XtraBars.Ribbon;
using System.Linq.Expressions;
using Microsoft.Practices.CompositeUI.Collections;
using System.Reflection;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.XtraBars;
using Katrin.Win.Infrastructure;
using DevExpress.Data.Filtering;

namespace Katrin.Win.Common.Core
{
    public class EnityDetailController<TView> : RecordDetailController<TView> where TView : AbstractDetailView
    {
        public override void Initialize()
        {
            base.Initialize();

            var showGroup = UIExtensionSites["DetailHomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Show")));
            UIExtensionSites.RegisterSite(ExtensionSiteNames.DetailShowRibbonPageGroup, showGroup);

            RegisterGenearlCommand("CopyAndNew", "Save", "Copy"); 
            RegisterShowCommand("ShowGeneral", EntityName, null, "General");

            var addGroup = UIExtensionSites["DetailHomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Add")));
            UIExtensionSites.RegisterSite(ExtensionSiteNames.DetailAddGroup, addGroup);
            InitConvert();
            RegisterRelatedEntityCommand();

            Workspaces[WorkspaceNames.DetailContentWorkspace].SmartPartActivated += (sender, e) =>
                {
                    PropertyInfo property = e.SmartPart.GetType().GetProperty("EntityName");
                    if (property == null) return;
                    if (property.GetValue(e.SmartPart, null) == null) return;
                    string smartEntityName = property.GetValue(e.SmartPart,null).ToString();
                    if (smartEntityName == EntityName)
                        smartEntityName = "ShowGeneral";
                    foreach (var site in UIExtensionSites["DetailHomePage"])
                    {
                        RibbonPageGroup pageGroup = site as RibbonPageGroup;
                        if (pageGroup == null) continue;
                        foreach (var itemLink in pageGroup.ItemLinks)
                        {
                            BarButtonItemLink barItemLink = itemLink as BarButtonItemLink;
                            if (barItemLink == null) continue;
                            BarButtonItemEx itemEx = barItemLink.Item as BarButtonItemEx;
                            if (itemEx == null && itemEx.ButtonStyle != BarButtonStyle.Check) continue;
                            if (itemEx.Name.Contains(smartEntityName)) itemEx.Down = true;
                            else itemEx.Down = false;
                        }
                    }
                };
        }

        protected override void UpdateCommandStatus()
        {
            base.UpdateCommandStatus();

            if (WorkingMode == EntityDetailWorkingMode.View)
            {
                Commands["CopyAndNew"].Status = CommandStatus.Unavailable;
            }
            else
            {
                Commands["CopyAndNew"].Status = !HasChanges && WorkingMode != EntityDetailWorkingMode.Add ? CommandStatus.Enabled : CommandStatus.Disabled;
            }

            bool status = WorkingMode != EntityDetailWorkingMode.Add ? true : false;
            var relatedSiteName = UIExtensionSites.Where(c => c.ToString() == "DetailRelatedGroup");
            if (relatedSiteName.ToList().Count > 0)
            {
                var relatedItems = UIExtensionSites["DetailRelatedGroup"];
                var buttons = relatedItems.OfType<BarButtonItemEx>();
                foreach (var button in buttons)
                {
                    button.Enabled = status;
                }
            }

            var convertSiteName = UIExtensionSites.Where(c => c.ToString() == "DetailConvertGroup");
            if (convertSiteName.ToList().Count > 0)
            {
                var convertItems = UIExtensionSites["DetailConvertGroup"];
                var buttons = convertItems.OfType<BarButtonItemEx>();
                foreach (var button in buttons)
                {
                    button.Enabled = status;
                }
                
            }
        }
        private void RegisterRelatedEntityCommand()
        {
            var allRelationshipRoles = MetadataProvider.Instance.EntityRelationshipRoles;
            var relationshipRoles =
                allRelationshipRoles.Where(
                    role => role.Entity.PhysicalName == EntityName && role.NavPanelDisplayOption == 1);
            if (relationshipRoles.Any())
            {
                var relatedEntityButtons = new List<BarButtonItemEx>();
                foreach (var relationshipRole in relationshipRoles)
                {
                    var entityRelation = relationshipRole.EntityRelationship;
                    var relatedRole = entityRelation.EntityRelationshipRoles
                        .FirstOrDefault(r => r != relationshipRole
                                             && r.RelationshipRoleType == (int)RelationshipRoleType.ManyToOne);

                    if (relatedRole == null) continue;

                    var name = relatedRole.Entity.PhysicalName;
                    if (!AuthorizationManager.CheckAccess(name, "Read")) continue;
                    var relationship = entityRelation.EntityRelationshipRelationships.First().Relationship;

                    var localizedCaption = Properties.Resources.ResourceManager.GetString(name);
                    var buttonItem = new BarButtonItemEx(name, "Search") { Caption = localizedCaption };
                    buttonItem.ItemClick += (s, e) => { ShowRelatedEntityList(relationship, name); };
                    buttonItem.Name = name;
                    if (relationshipRoles.Count() > 1)
                        buttonItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText |
                            DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText;
                    buttonItem.ButtonStyle = BarButtonStyle.Check;
                    relatedEntityButtons.Add(buttonItem);
                }
                if (relatedEntityButtons.Any())
                {
                    var generalGroup =
                        UIExtensionSites["DetailHomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("Related")));
                    UIExtensionSites.RegisterSite("DetailRelatedGroup", generalGroup);
                    foreach (var button in relatedEntityButtons)
                    {
                        UIExtensionSites["DetailRelatedGroup"].Add(button);
                    }
                }
            }
        }

        private void ShowRelatedEntityList(Relationship relationship, string name)
        {
            var listViewType = FindLoadedType(name + "ListView");

            var addNewMethod =
                Items.GetType().GetMethod("AddNew", new[] { typeof(string) }).MakeGenericMethod(listViewType);
            var getMethod = Items.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.IsGenericMethod && m.Name == "Get").MakeGenericMethod(listViewType);

            var key = EntityName + "_" + name + "_List";
            var objectView = getMethod.Invoke(Items, new object[] { key }) ??
                             addNewMethod.Invoke(Items, new object[] { key });
            var entityListView = objectView as EntityListView;
            if (entityListView != null)
            {
                var entityId = (Guid)State["EntityId"];
                CriteriaOperator filter = new BinaryOperator(relationship.ReferencingAttribute.Name, entityId, BinaryOperatorType.Equal);
                entityListView.FixedPredicate = filter;
                entityListView.InitEntityView(name);
                entityListView.Bind(name);
                var info = new XtraTabSmartPartInfo { Title = name };
                Workspaces[WorkspaceNames.DetailContentWorkspace].Show(entityListView, info);
            }
        }

        [EventSubscription(EventTopicNames.OpenDetail, Thread = ThreadOption.Publisher)]
        public void OpenDetailById(object sender, EventArgs<Guid, Type, String> e)
        {
            ShowRelatedEntityDetail(e.Data3, e.Data1, EntityDetailWorkingMode.View);
        }

        private void ShowRelatedEntityDetail(string entityName, Guid entityId, EntityDetailWorkingMode workMode)
        {
            var detailViewType = FindLoadedType(entityName + "DetailView");
            Type controlType = typeof(EnityDetailController<>).MakeGenericType(detailViewType);
            var addNewMethod =
                RootWorkItem.Items.GetType().GetMethod("AddNew", new[] { typeof(string) }).MakeGenericMethod(controlType);
            var getMethod = RootWorkItem.Items.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .First(m => m.IsGenericMethod && m.Name == "Get").MakeGenericMethod(controlType);

            string key = entityId + entityName+ ":DetailWorkItem";
            var detailWorkObject = getMethod.Invoke(RootWorkItem.Items, new object[] { key });
            var detailWorkItem = detailWorkObject as WorkItem;
            if (detailWorkItem == null)
            {
                detailWorkObject = addNewMethod.Invoke(RootWorkItem.Items, new object[] { key });
                detailWorkItem = detailWorkObject as WorkItem;
                var initializeMethod =
                detailWorkItem.GetType().GetMethod("Initialize");

                PropertyInfo entityProperty = detailWorkItem.GetType().GetProperty("EntityName");
                entityProperty.SetValue(detailWorkItem, entityName, null);
                initializeMethod.Invoke(detailWorkItem, new object[] { });
            }
            if (workMode == EntityDetailWorkingMode.Convert)
            {
                var _dynamicDataServiceContext = new DynamicDataServiceContext();
                detailWorkItem.State["ConvertEntiy"] = _dynamicDataServiceContext.GetOrNew(EntityName, (Guid)State["EntityId"]);
                detailWorkItem.State["ConvertName"] = EntityName;
            }
            detailWorkItem.State["EntityId"] = entityId;
            detailWorkItem.State["WorkingMode"] = workMode;
            detailWorkItem.Run();
        }

        #region convert
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
                    var convertGroup = UIExtensionSites["DetailHomePage"].Add(new RibbonPageGroup(GetLocalizedCaption("ConvertTitle")));
                    UIExtensionSites.RegisterSite("DetailConvertGroup", convertGroup);
                    foreach (var button in convertEntityButtons)
                    {
                        UIExtensionSites["DetailConvertGroup"].Add(button);
                    }
                }
            }
        }
        #endregion
    }
}
