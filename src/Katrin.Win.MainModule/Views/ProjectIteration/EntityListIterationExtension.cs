using System;
using Katrin.Win.Common;
using Katrin.Win.Infrastructure;
using Katrin.Win.MainModule.Views.ProjectTask;
using Microsoft.Practices.CompositeUI;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.MainModule.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using System.Reflection;
using Katrin.Win.MainModule.Views.ProjectManagement;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.ProjectIteration
{
    [WorkItemExtension(typeof(ProjectController), "ProjectListIterationExtension", Dependency = "EntityListNoteExtension")]
    public class EntityListIterationExtension : WorkItemExtension
    {
        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            RegisterCommand("ShowPageGroup", "ShowIterationInList", "ProjectIteration", null, "ProjectIteration");
            RegisterCommand("AddPageGroup", "AddIterationInList", "ProjectIteration", "add", "AddIteration");
            ShowIterationListView();
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            var status = SelectEntityId != Guid.Empty ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["ShowIterationInList"].Status = status;
            WorkItem.Commands["AddIterationInList"].Status = status;
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;

            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);

        }

        [EventSubscription("EditProjectIteration", ThreadOption.UserInterface)]
        public void OnEditProjectIteration(object sender, EventArgs<Guid> e)
        {
            ShowEntityDetails<ProjectIterationDetailView>("ProjectIteration", SelectEntityId, e.Data, EntityDetailWorkingMode.Edit);
        }

        [EventSubscription("DeleteProjectIteration", ThreadOption.UserInterface)]
        public void DeleteProjectIteration(object sender, EventArgs<Guid> e)
        {
            var timeTracking = DynamicDataServiceContext.GetOrNew("ProjectIteration", e.Data);
            DynamicDataServiceContext.DeleteObject("ProjectIteration", timeTracking);
            DynamicDataServiceContext.SaveChanges();
            ShowIterationListView();
        }

        public void ShowEntityDetails<T>(string entityName, Guid projectId, Guid id, EntityDetailWorkingMode workMode) where T : AbstractDetailView
        {
            string key = id + ":DetailWorkItem";

            var rootItem = WorkItem.RootWorkItem;
            var detailWorkItem = rootItem.Items.Get<EnityDetailController<T>>(key);

            if (detailWorkItem == null)
            {

                detailWorkItem = rootItem.Items.AddNew<EnityDetailController<T>>(key);
                detailWorkItem.EntityName = entityName;
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = id;
            detailWorkItem.State["ProjectId"] = projectId;
            detailWorkItem.State["WorkingMode"] = workMode;
            detailWorkItem.Run();
        }

        private string GetEntityName()
        {
            var entityNamePropertyInfo = WorkItem.GetType().GetProperty("EntityName",
                                                                        BindingFlags.Instance | BindingFlags.NonPublic);
            if (entityNamePropertyInfo == null)
                throw new Exception("This extension have to work with a workitem that have Entity Name property");
            return (string)entityNamePropertyInfo.GetValue(WorkItem, null);
        }

        [CommandHandler("ShowIterationInList")]
        public void ShowNoteInList(object sender, EventArgs e)
        {
            var projectIterationListView = ProjectIterationListView;
            if (projectIterationListView != null)
            {
                if (projectIterationListView.Visible)
                    WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Hide(projectIterationListView);
                else
                    WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Show(projectIterationListView);
            }
        }

        [CommandHandler("AddIterationInList")]
        public void AddNote(object sender, EventArgs e)
        {
            ShowEntityDetails<ProjectIterationDetailView>("ProjectIteration", SelectEntityId, Guid.Empty, EntityDetailWorkingMode.Add);
        }

        [EventSubscription(EventTopicNames.FocusedRowChanged, Thread = ThreadOption.UserInterface)]
        public void OnFocusedRowChanged(object sender, EventArgs<object> e)
        {
            UpdateCommandStatus();
            var projectIterationListView = ProjectIterationListView;
            if (projectIterationListView != null)
            {
                BindProjectIterations(projectIterationListView);
            }
        }


        private void BindProjectIterations(ProjectIterationListView projectIterationListView)
        {
            projectIterationListView.FixedPredicate = new BinaryOperator("ProjectId", SelectEntityId); 
            projectIterationListView.Bind("ProjectIteration");
        }

        private Guid SelectEntityId
        {
            get
            {
                MethodInfo methodInfo = WorkItem.GetType().GetMethod("GetSelectEntityId");
                return (Guid)methodInfo.Invoke(WorkItem, null);
            }
        }

        private ProjectIterationListView ProjectIterationListView
        {
            get
            {
                string key = "ProjectIterationListView";
                var projectIterationListView = WorkItem.Items.Get<ProjectIterationListView>(key);
                return projectIterationListView;
            }
        }


        [EventSubscription(EventTopicNames.RefreshProjectIteration, Thread = ThreadOption.Publisher)]
        public void OnRefreshProjectIteration(object sender, EventArgs e)
        {
            var projectIterationListView = ProjectIterationListView;
            if (projectIterationListView != null)
            {
                BindProjectIterations(projectIterationListView);
            }
        }

        [EventSubscription(EventTopicNames.RefreshListProjectIteration, Thread = ThreadOption.Publisher)]
        public void OnRefreshListProjectIteration(object sender, EventArgs e)
        {
            var projectIterationListView = ProjectIterationListView;
            if (projectIterationListView != null)
            {
                BindProjectIterations(projectIterationListView);
            }
        }

        private void ShowIterationListView()
        {
            string key = "ProjectIterationListView";
            var projectIterationListView = WorkItem.Items.Get<ProjectIterationListView>(key);
            if (projectIterationListView == null)
            {
                projectIterationListView = WorkItem.Items.AddNew<ProjectIterationListView>(key);
                WorkItem.EventTopics[EventTopicNames.FocusedRowChanged]
                    .RemovePublication(projectIterationListView, EventTopicNames.FocusedRowChanged);
                var localizedCaption = Properties.Resources.ResourceManager.GetString("ProjectIteration");
                var info = new DockManagerSmartPartInfo
                               {
                                   ID = new Guid("AB4566B2-0B6A-485A-8796-0ECF9D2CA65C"),
                                   Title = localizedCaption,
                                   Name = "ProjectIteration",
                                   Dock = DockingStyle.Right,
                                   ParentPanelName = "Note",
                                   Index = 1
                               };
                WorkItem.RegisterSmartPartInfo(projectIterationListView, info);
                projectIterationListView.InitEntityView("ProjectIteration");
            }
            projectIterationListView.Dock = DockStyle.Fill;
            BindProjectIterations(projectIterationListView);
            WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Show(projectIterationListView);
        }
    }
}
