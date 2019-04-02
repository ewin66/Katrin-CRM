using System;
using Katrin.Win.Common.Controls;
using Katrin.Win.Infrastructure;
using Katrin.Win.MainModule.Views.Opportunity;
using Microsoft.Practices.CompositeUI;
using Katrin.Win.Common.Core;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.Common.Constants;
using System.Windows.Forms;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.TimeTracking
{
    [WorkItemExtension(typeof(EnityDetailController<OpportunityDetailView>), "OpportunityDetailTimeTrackingExtension")]
    public class OpportunityDetailTimeTrackingExtension : WorkItemExtension
    {

        [EventPublication("ReloadTiming", PublicationScope.Global)]
        public event EventHandler OnReloadTiming;

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        public EntityDetailWorkingMode WorkingMode
        {
            get { return (EntityDetailWorkingMode)WorkItem.State["WorkingMode"]; }
        }

        protected override void OnRunStarted()
        {
            base.OnRunStarted();

            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowDetailTimeTracking", "TimeTracking", null,
                            "TimeTracking");

            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "AddDetailTimeTracking", "TimeTracking",
                            "add", "AddTimeTracking");
            UpdateCommandStatus();
        }

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            var status = WorkingMode != EntityDetailWorkingMode.Add ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["ShowDetailTimeTracking"].Status = status;
            WorkItem.Commands["AddDetailTimeTracking"].Status = status;
        }

        [CommandHandler("ShowDetailTimeTracking")]
        public void ShowDetailTimeTracking(object sender, EventArgs e)
        {
            ShowTimeTrackingListView();
        }

        [CommandHandler("AddDetailTimeTracking")]
        public void AddDetailTimeTracking(object sender, EventArgs e)
        {
            ShowTimeTrackingDetailView(Guid.Empty);
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
            if (OnReloadTiming != null)
                OnReloadTiming(this, new EventArgs());
        }

        private void ShowTimeTrackingDetailView(Guid timeTrackingId)
        {
            var presenter = WorkItem.Items.AddNew<TimeTrackingDetailPresenter>();
            var addTimeTrackingView = WorkItem.Items.AddNew<TimeTrackingDetailForm>();
            presenter.TimeTrackingId = timeTrackingId;
            presenter.WorkingMode = timeTrackingId == Guid.Empty
                                        ? EntityDetailWorkingMode.Add
                                        : EntityDetailWorkingMode.Edit;
            addTimeTrackingView.Presenter = presenter;
            if (addTimeTrackingView.ShowDialog() == DialogResult.OK)
            {
                ShowTimeTrackingListView();
                if (OnReloadTiming != null)
                    OnReloadTiming(this, new EventArgs());
            }
        }


        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            if (commandName == "ShowDetailTimeTracking")
            {
                buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        private void ShowTimeTrackingListView()
        {
            string key = "TimeTrackingDetailListView";
            var timetrackingListView = WorkItem.Items.Get<TimeTrackingListView>(key);
            if (timetrackingListView == null)
            {
                timetrackingListView = WorkItem.Items.AddNew<TimeTrackingListView>(key);
                var info = new XtraTabSmartPartInfo {Title = "Timetracking"};
                WorkItem.RegisterSmartPartInfo(timetrackingListView, info);
                timetrackingListView.InitEntityView("TimeTracking");
            }

            var entityId = (Guid)WorkItem.State["EntityId"];
            timetrackingListView.FixedPredicate = new BinaryOperator("OpportunityId", entityId);
            timetrackingListView.Bind("TimeTracking");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(timetrackingListView);
        }
    }
}
