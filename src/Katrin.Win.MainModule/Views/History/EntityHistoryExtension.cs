using System;
using System.Linq;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.MainModule.Constants;
using Katrin.Win.Common.Controls;
using Microsoft.Practices.CompositeUI.EventBroker;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.History
{
    [WorkItemExtension(typeof(EnityDetailController<>), "EntityHistoryExtension")]
    public class EntityHistoryExtension: WorkItemExtension
    {

        public EntityDetailWorkingMode WorkingMode
        {
            get { return (EntityDetailWorkingMode)WorkItem.State["WorkingMode"]; }
        }

        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            RegisterCommand(ExtensionSiteNames.DetailShowRibbonPageGroup, "ShowDetailAudit", "History", null, "History");
            UpdateCommandStatus();
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

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            var status = WorkingMode != EntityDetailWorkingMode.Add ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["ShowDetailHistory"].Status = status;
        }

        [CommandHandler("ShowDetailAudit")]
        public void OnView(object sender, EventArgs e)
        {
            ShowHistoryListView();
        }

        private void ShowHistoryListView()
        {
            const string key = "HistoryDetailListView";
            var historyView = WorkItem.Items.Get<HistoryListView>(key) ?? WorkItem.Items.AddNew<HistoryListView>(key);
            var info = new XtraTabSmartPartInfo {Title = "History"};

            var entityId = (Guid)WorkItem.State["EntityId"];
            historyView.FixedPredicate = new BinaryOperator("ObjectId", entityId);
            historyView.InitEntityView("Audit");
            historyView.Bind("Audit");
            WorkItem.Workspaces[WorkspaceNames.DetailContentWorkspace].Show(historyView, info);
        }
    }
}
