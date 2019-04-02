using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Controls;
using Katrin.Win.MainModule.Constants;
using Katrin.Win.MainModule.Views.ProjectTask;
using Katrin.Win.MainModule.Views.ProjectVersion;
using Microsoft.Practices.CompositeUI.Commands;
using CABDevExpress.SmartPartInfos;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Collections;
using Katrin.Win.MainModule.Views.ProjectIteration;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common;
using DevExpress.Data.Filtering;
using Katrin.Win.MainModule.Views.ProjectModule;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public class ProjectSummary
    {
        public string Name { get; set; }
        public string NameAndDate { get; set; }
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public double? SumQuoteWorkHours
        {
            get;
            set;
        }
        public double? SumActualWorkHours
        {
            get;
            set;
        }
        public double? SumActualInput
        {
            get;
            set;
        }
        public double? SumEffort
        {
            get;
            set;
        }
        public double? SumOvertime
        {
            get;
            set;
        }
        public double? SumRemainderTime
        {
            get;
            set;
        }

        public double SumInputEffortRate
        {
            get;
            set;
        }

        public double SumEvaluateExactlyRate
        {
            get;
            set;
        }

    }

    public class ProjectDetailPresenter : EntityDetailPresenter<IProjectDetailView>
    {
        private ProjectSummary _projectSummaryEntity;
        public ProjectDetailPresenter()
        {
            EntityName = "Project";
        }

        protected override void OnSaving()
        {
            base.OnSaving();
            SetProjectMember();
        }

        private void SetProjectMember()
        {
            if (View.SelectedProjectMember != null)
            {
                Type projectMemberType = DynamicTypeBuilder.Instance.GetDynamicType("ProjectMember");
                IList projectMembers = DynamicEntity.ProjectMembers;
                while (projectMembers.Count > 0)
                {
                    projectMembers.RemoveAt(0);
                }
                foreach (var selectedProjectMember in View.SelectedProjectMember)
                {
                    var projectMember = Activator.CreateInstance(projectMemberType);
                    dynamic dynamicProjectMember = new SysBits.DynamicProxies.DynamicProxy(projectMember);
                    dynamicProjectMember.ProjectMemberId = Guid.NewGuid();
                    dynamicProjectMember.ProjectId = EntityId;
                    dynamicProjectMember.MemberId = selectedProjectMember.AsDyanmic().UserId;
                    projectMembers.Add(projectMember);
                }
            }
        }

        protected override object GetEntity()
        {
            Dictionary<string, string> extraColumns = new Dictionary<string, string>();
            var entity = DynamicDataServiceContext.GetOrNew(EntityName, EntityId, "CreatedBy,ModifiedBy,ProjectTasks,ProjectMembers");
            _projectSummaryEntity = new ProjectSummary();
            IList projectTasks = entity.AsDyanmic().ProjectTasks;
            _projectSummaryEntity.SumQuoteWorkHours = projectTasks.AsQueryable().Select("QuoteWorkHours").Cast<double?>().Sum();
            _projectSummaryEntity.SumActualWorkHours = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum();
            _projectSummaryEntity.SumActualInput = projectTasks.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
            _projectSummaryEntity.SumEffort = projectTasks.AsQueryable().Select("Effort").Cast<double?>().Sum();
            _projectSummaryEntity.SumOvertime = projectTasks.AsQueryable().Select("Overtime").Cast<double?>().Sum();
            _projectSummaryEntity.SumRemainderTime = _projectSummaryEntity.SumActualWorkHours - _projectSummaryEntity.SumEffort;
            View.BindStatisticNumber(new List<ProjectSummary>() { _projectSummaryEntity });
            ConvertEntity(entity);
            return entity;
        }
        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.ContractEditValueChanged += OnContractEditValueChanged;
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "AddDetailIteration", "ProjectIteration", "add", "AddIteration");
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "AddDetailTask", "ProjectTask", "add", "AddTask");
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "AddDetailVersion", "ProjectVersion", "add", "AddVersion");
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "AddDetailModule", "ProjectModule", "add", "AddModule");
            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowProjectIteration", "ProjectIteration", "", "ProjectIteration");
            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowProjectTask", "ProjectTask", "", "ProjectTask");
            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowProjectVersion", "ProjectVersion", "", "ProjectVersion");
            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowProjectModule", "ProjectModule", "", "ProjectModule");
            IList projectMembers = DynamicEntity.ProjectMembers;
            var selectedProjectMember = new List<Guid>();
            foreach (var projectMember in projectMembers)
            {
                Guid memberId = projectMember.AsDyanmic().MemberId;
                selectedProjectMember.Add(memberId);
            }
            View.BindProjectMember(selectedProjectMember);
        }

        

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            if (commandName == "ShowProjectTask" || commandName == "ShowProjectIteration" || commandName == "ShowProjectVersion" || commandName == "ShowProjectModule")
            {
                buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            var status =
                WorkingMode == EntityDetailWorkingMode.Add ? CommandStatus.Disabled : CommandStatus.Enabled;
            WorkItem.Commands["ShowTask"].Status = status;
            WorkItem.Commands["AddDetailTask"].Status = status;
            WorkItem.Commands["ShowIteration"].Status = status;
            WorkItem.Commands["AddDetailIteration"].Status = status;
            WorkItem.Commands["AddDetailVersion"].Status = status;
            WorkItem.Commands["ShowVersion"].Status = status;
            WorkItem.Commands["AddDetailModule"].Status = status;
            WorkItem.Commands["ShowModule"].Status = status;
        }

        [CommandHandler("ShowProjectTask")]
        public void OnShowProjectTask(object sender, EventArgs e)
        {
            string key = "ProjectTaskListView";
            var taskListView = WorkItem.Items.Get<DProjectTaskListView>(key);
            if (taskListView == null)
            {
                taskListView = WorkItem.Items.AddNew<DProjectTaskListView>(key);
                var info = new XtraTabSmartPartInfo { Title = "Tasks" };
                WorkItem.RegisterSmartPartInfo(taskListView, info);
                taskListView.InitEntityView("ProjectTask");
            }

            taskListView.FixedPredicate = new BinaryOperator("ProjectId", EntityId);
            taskListView.Bind("ProjectTask");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(taskListView);
        }

        [CommandHandler("AddDetailTask")]
        public void OnAddDetailTask(object sender, EventArgs e)
        {
            ShowEntityDetails<ProjectTaskDetailView>("ProjectTask", EntityId,Guid.Empty, EntityDetailWorkingMode.Add);
        }

        [CommandHandler("ShowProjectIteration")]
        public void OnShowProjectIteration(object sender, EventArgs e)
        {
            string key = "ProjectIterationListView";
            var taskListView = WorkItem.Items.Get<ProjectIterationListView>(key);
            if (taskListView == null)
            {
                taskListView = WorkItem.Items.AddNew<ProjectIterationListView>(key);
                var info = new XtraTabSmartPartInfo { Title = "Iterations" };
                WorkItem.RegisterSmartPartInfo(taskListView, info);
                taskListView.InitEntityView("ProjectIteration");
            }
            taskListView.FixedPredicate = new BinaryOperator("ProjectId", EntityId);
            taskListView.Bind("ProjectIteration");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(taskListView);
        }
        [CommandHandler("ShowProjectVersion")]
        public void OnShowProjectVersion(object sender, EventArgs e)
        {
            string key = "ProjectVersionListView";
            var taskListView = WorkItem.Items.Get<ProjectVersionListView>(key);
            if (taskListView == null)
            {
                taskListView = WorkItem.Items.AddNew<ProjectVersionListView>(key);
                var info = new XtraTabSmartPartInfo { Title = "Versions" };
                WorkItem.RegisterSmartPartInfo(taskListView, info);
                taskListView.InitEntityView("ProjectVersion");
            }

            taskListView.FixedPredicate = new BinaryOperator("ProjectId", EntityId); ;
            taskListView.Bind("ProjectVersion");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(taskListView);
        }
        [CommandHandler("ShowProjectModule")]
        public void OnShowProjectModule(object sender, EventArgs e)
        {
            string key = "ProjectModuleListView";
            var taskListView = WorkItem.Items.Get<ProjectModuleListView>(key);
            if (taskListView == null)
            {
                taskListView = WorkItem.Items.AddNew<ProjectModuleListView>(key);
                var info = new XtraTabSmartPartInfo { Title = "Modules" };
                WorkItem.RegisterSmartPartInfo(taskListView, info);
                taskListView.InitEntityView("ProjectModule");
            }

            taskListView.FixedPredicate = new BinaryOperator("ProjectId", EntityId); ;
            taskListView.Bind("ProjectModule");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(taskListView);
        }
        [CommandHandler("AddDetailIteration")]
        public void OnAddDetailIIteration(object sender, EventArgs e)
        {
            ShowEntityDetails<ProjectIterationDetailView>("ProjectIteration", EntityId, Guid.Empty, EntityDetailWorkingMode.Add);
        }

        [EventSubscription("EditProjectIteration", ThreadOption.UserInterface)]
        public void OnEditProjectIteration(object sender, EventArgs<Guid> e)
        {
            ShowEntityDetails<ProjectIterationDetailView>("ProjectIteration", EntityId, e.Data, EntityDetailWorkingMode.Edit);
        }

        [CommandHandler("AddDetailVersion")]
        public void OnAddDetailVersion(object sender, EventArgs e)
        {
            ShowEntityDetails<ProjectVersionDetailView>("ProjectVersion", EntityId, Guid.Empty, EntityDetailWorkingMode.Add);
        }

        [EventSubscription("EditProjectVersion", ThreadOption.UserInterface)]
        public void OnEditProjectVersion(object sender, EventArgs<Guid> e)
        {
            ShowEntityDetails<ProjectVersionDetailView>("ProjectVersion", EntityId, e.Data, EntityDetailWorkingMode.Edit);
        }

        [CommandHandler("AddDetailModule")]
        public void OnAddDetailModule(object sender, EventArgs e)
        {
            ShowEntityDetails<ProjectModuleDetailView>("ProjectModule", EntityId, Guid.Empty, EntityDetailWorkingMode.Add);
        }

        [EventSubscription("EditProjectModule", ThreadOption.UserInterface)]
        public void OnEditProjectModule(object sender, EventArgs<Guid> e)
        {
            ShowEntityDetails<ProjectModuleDetailView>("ProjectModule", EntityId, e.Data, EntityDetailWorkingMode.Edit);
        }

        [EventPublication(EventTopicNames.RefreshListProjectIteration, PublicationScope.Global)]
        public event EventHandler OnRefreshListProjectVersion;
        public event EventHandler OnRefreshListProjectModule;

        [EventSubscription("DeleteProjectVersion", ThreadOption.UserInterface)]
        public void DeleteProjectVersion(object sender, EventArgs<Guid> e)
        {
            var timeTracking = DynamicDataServiceContext.GetOrNew("ProjectVersion", e.Data);
            DynamicDataServiceContext.DeleteObject("ProjectVersion", timeTracking);
            DynamicDataServiceContext.SaveChanges();
            EventHandler handler = OnRefreshListProjectIteration;
            if (handler != null) handler(sender, e);
            OnShowProjectVersion(sender, e);
        }

        [EventSubscription("DeleteProjectModule", ThreadOption.UserInterface)]
        public void DeleteProjectModule(object sender, EventArgs<Guid> e)
        {
            var timeTracking = DynamicDataServiceContext.GetOrNew("ProjectModule", e.Data);
            DynamicDataServiceContext.DeleteObject("ProjectModule", timeTracking);
            DynamicDataServiceContext.SaveChanges();
            EventHandler handler = OnRefreshListProjectIteration;
            if (handler != null) handler(sender, e);
            OnShowProjectModule(sender, e);
        }

        [EventPublication(EventTopicNames.RefreshListProjectIteration, PublicationScope.Global)]
        public event EventHandler OnRefreshListProjectIteration;

        [EventSubscription("DeleteProjectIteration", ThreadOption.UserInterface)]
        public void DeleteProjectIteration(object sender, EventArgs<Guid> e)
        {
            var timeTracking = DynamicDataServiceContext.GetOrNew("ProjectIteration", e.Data);
            DynamicDataServiceContext.DeleteObject("ProjectIteration", timeTracking);
            DynamicDataServiceContext.SaveChanges();
            EventHandler handler = OnRefreshListProjectIteration;
            if (handler != null) handler(sender, e);
            OnShowProjectIteration(sender, e);
        }

        [EventSubscription("EditProjectTask", ThreadOption.UserInterface)]
        public void OnEditProjectTask(object sender, EventArgs<Guid> e)
        {
            ShowEntityDetails<ProjectTaskDetailView>("ProjectTask", EntityId,e.Data, EntityDetailWorkingMode.Edit);
        }

        [EventSubscription("DeleteProjectTask", ThreadOption.UserInterface)]
        public void DeleteProjectTask(object sender, EventArgs<Guid> e)
        {
            var timeTracking = DynamicDataServiceContext.GetOrNew("ProjectTask", e.Data);
            DynamicDataServiceContext.DeleteObject("ProjectTask", timeTracking);
            DynamicDataServiceContext.SaveChanges();
            OnShowProjectTask(sender, e);
        }


        public void ShowEntityDetails<T>(string entityName, Guid projectId, Guid id, EntityDetailWorkingMode workMode) where T : AbstractDetailView
        {
            string key = id + ":" + entityName + "DetailWorkItem";

            var rootItem = WorkItem.RootWorkItem;
            var detailWorkItem = rootItem.Items.Get<EnityDetailController<T>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = rootItem.Items.AddNew<EnityDetailController<T>>(key);
                detailWorkItem.EntityName = entityName;
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = id;
            detailWorkItem.State["FromProject"] = "FromProject";
            detailWorkItem.State["ProjectId"] = projectId;
            detailWorkItem.State["WorkingMode"] = workMode;
            detailWorkItem.Run();
        }

        [EventSubscription(EventTopicNames.RefreshProjectTask, Thread = ThreadOption.Publisher)]
        public void OnRefreshProjectTask(object sender, EventArgs e)
        {
            OnShowProjectTask(sender, e);
        }

        [EventSubscription(EventTopicNames.RefreshProjectIteration, Thread = ThreadOption.Publisher)]
        public void OnRefreshProjectIteration(object sender, EventArgs e)
        {
            OnShowProjectIteration(sender, e);
        }

        [EventSubscription(EventTopicNames.RefreshProjectVersion, Thread = ThreadOption.Publisher)]
        public void OnRefreshProjectVersion(object sender, EventArgs e)
        {
            OnShowProjectVersion(sender, e);
        }

        [EventSubscription(EventTopicNames.RefreshProjectModule, Thread = ThreadOption.Publisher)]
        public void OnRefreshProjectModule(object sender, EventArgs e)
        {
            OnShowProjectModule(sender, e);
        }

        private void OnContractEditValueChanged(object sender,Katrin.Win.Infrastructure.EventArgs<Guid> e)
        {
            var entity = DynamicDataServiceContext.GetOrNew("Contract", e.Data, "Opportunity");
            bool isAdd = WorkingMode == EntityDetailWorkingMode.Add;
            var opportunity = entity.AsDyanmic().Opportunity;
            if (entity != null && opportunity != null)
            {
                DynamicEntity.ContractId = e.Data;
                DynamicEntity.CustomerId = isAdd ? opportunity.CustomerId : DynamicEntity.CustomerId ?? opportunity.CustomerId;
                DynamicEntity.ProjectTypeCode = isAdd ? opportunity.ProjectTypeCode : DynamicEntity.ProjectTypeCode ?? opportunity.ProjectTypeCode;
                DynamicEntity.TechnologyCode = isAdd ? opportunity.TechnologyCode : DynamicEntity.TechnologyCode ?? opportunity.TechnologyCode;
            }
        }

    }
}
