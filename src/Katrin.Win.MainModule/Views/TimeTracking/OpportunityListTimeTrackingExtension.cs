using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Katrin.Win.Common;
using Katrin.Win.Infrastructure;
using Katrin.Win.MainModule.Views.Opportunity;
using Microsoft.Practices.CompositeUI;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.Constants;
using System.Windows.Forms;
using DevExpress.XtraBars.Docking;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.Commands;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.Utility;
using Katrin.Win.Common.Core;
using System.Reflection;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.TimeTracking
{
    [WorkItemExtension(typeof(OpportunityController), "OpportunityListTimeTrackingExtension", Dependency = "EntityListNoteExtension")]
    public class OpportunityListTimeTrackingExtension : WorkItemExtension
    {
        private IDynamicDataServiceContext _dynamicDataServiceContext;
        private Guid _focusedEntityId;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            RegisterCommand("ShowPageGroup", "ShowTimeTracking", "TimeTracking", null, "TimeTracking");
            RegisterCommand("AddPageGroup", "AddTimeTracking", "TimeTracking", "add", "AddTimeTracking");
            ShowTimeTrackingListView();
        }

        private void UpdateCommandStatus()
        {
            var status = SelectEntityId != Guid.Empty ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["ShowTimeTracking"].Status = status;
            WorkItem.Commands["AddTimeTracking"].Status = status;
        }

        [CommandHandler("ShowTimeTracking")]
        public void ShowTimeTracking(object sender, EventArgs e)
        {
            var timeTrackingListView = TimeTrackingListView;
            if (timeTrackingListView != null)
            {
                if (timeTrackingListView.Visible)
                    WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Hide(timeTrackingListView);
                else
                    WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Show(timeTrackingListView);
            }
        }

        [CommandHandler("AddTimeTracking")]
        public void AddTimeTracking(object sender, EventArgs e)
        {
            ShowTimeTrackingDetailView(Guid.Empty);
        }

        private void ShowTimeTrackingDetailView(Guid timeTrackingId)
        {
            WorkItem.State["EntityId"] = SelectEntityId;
            var presenter = WorkItem.Items.AddNew<TimeTrackingDetailPresenter>();
            var addTimeTrackingView = WorkItem.Items.AddNew<TimeTrackingDetailForm>();
            presenter.TimeTrackingId = timeTrackingId;
            presenter.WorkingMode = timeTrackingId == Guid.Empty
                                        ? EntityDetailWorkingMode.Add
                                        : EntityDetailWorkingMode.Edit;
            addTimeTrackingView.Presenter = presenter;
            if (addTimeTrackingView.ShowDialog() == DialogResult.OK)
            {
                var timeTrackingListView = TimeTrackingListView;
                if (timeTrackingListView != null)
                {
                    BindList(timeTrackingListView);
                }
            }
        }

        private TimeTrackingListView TimeTrackingListView
        {
            get
            {
                string key = "TimeTrackingListView";
                var timeTrackingListView = WorkItem.Items.Get<TimeTrackingListView>(key);
                return timeTrackingListView;
            }
        }

        [EventSubscription(EventTopicNames.FocusedRowChanged, Thread = ThreadOption.UserInterface)]
        public void OnFocusedRowChanged(object sender, EventArgs<object> e)
        {
            UpdateCommandStatus();
            var timeTrackingListView = TimeTrackingListView;
            if (timeTrackingListView != null)
            {
                BindList(timeTrackingListView);
            }
        }

        [EventSubscription("ReloadTiming", ThreadOption.Publisher)]
        public void OnReloadTiming(object sender, EventArgs e)
        {
            var timeTrackingListView = TimeTrackingListView;
            if (timeTrackingListView != null)
            {
                BindList(timeTrackingListView);
            }
        }


        private void BindList(TimeTrackingListView timeTrackingListView)
        {
            timeTrackingListView.FixedPredicate = new BinaryOperator("OpportunityId", SelectEntityId);
            timeTrackingListView.Bind("TimeTracking");
        }

        private Guid SelectEntityId
        {
            get
            {
                MethodInfo methodInfo = WorkItem.GetType().GetMethod("GetSelectEntityId");
                return (Guid)methodInfo.Invoke(WorkItem, null);
            }
        }

        [EventSubscription("EditTimeTracking", ThreadOption.UserInterface)]
        public void OnEditTimeTracking(object sender, EventArgs<Guid> e)
        {
            ShowTimeTrackingDetailView(e.Data);
        }

        [EventSubscription("DeleteTimeTracking", ThreadOption.UserInterface)]
        public void DeleteTimeTracking(object sender, EventArgs<Guid> e)
        {
            var timeTracking = DynamicDataServiceContext.GetOrNew("TimeTracking", e.Data);
            DynamicDataServiceContext.DeleteObject("TimeTracking", timeTracking);
            DynamicDataServiceContext.SaveChanges();

            ShowTimeTrackingListView();
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

        private void ShowTimeTrackingListView()
        {
            string key = "TimeTrackingListView";
            var localizedCaption = Properties.Resources.ResourceManager.GetString("TimeTracking");
            var timeTrackingListView = WorkItem.Items.Get<TimeTrackingListView>(key);
            if (timeTrackingListView == null)
            {
                timeTrackingListView = WorkItem.Items.AddNew<TimeTrackingListView>(key);
                WorkItem.EventTopics[EventTopicNames.FocusedRowChanged].RemovePublication(timeTrackingListView, EventTopicNames.FocusedRowChanged);
                var info = new DockManagerSmartPartInfo
                               {
                                   ID= new Guid("AB4566B2-0B6A-485A-8796-0ECF9D2CA65B"),
                                   Title = localizedCaption,
                                   Name = "TimeTracking",
                                   Dock = DockingStyle.Right,
                                   ParentPanelName = "Note",
                                   Index = 1
                               };
                WorkItem.RegisterSmartPartInfo(timeTrackingListView, info);
                timeTrackingListView.InitEntityView("TimeTracking");
            }
            timeTrackingListView.Dock = DockStyle.Fill;
            BindList(timeTrackingListView);
            WorkItem.Workspaces[WorkspaceNames.DockManagerWorkspace].Show(timeTrackingListView);
        }
    }
}
