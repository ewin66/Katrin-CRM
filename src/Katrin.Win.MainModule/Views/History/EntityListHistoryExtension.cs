using System;
using System.Linq;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using CABDevExpress.SmartPartInfos;
using Katrin.Win.MainModule.Constants;
using Katrin.Win.Common.Controls;
using System.Reflection;
using Microsoft.Practices.CompositeUI.EventBroker;
using EventTopicNames = Katrin.Win.Common.Constants.EventTopicNames;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.History
{
    [WorkItemExtension(typeof(EntityListController<,>), "EntityListHistoryExtension")]
    public class EntityListHistoryExtension : WorkItemExtension
    {
        protected override void OnRunStarted()
        {
            base.OnRunStarted();
            RegisterCommand("ShowPageGroup", "ShowHistory", "History", null, "History");
            UpdateCommandStatus();
        }

        [EventSubscription(EventTopicNames.FocusedRowChanged, Thread = ThreadOption.UserInterface)]
        public void OnFocusedRowChanged(object sender, EventArgs<object> e)
        {
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            WorkItem.Commands["ShowHistory"].Status = SelectEntityId != Guid.Empty
                                                          ? CommandStatus.Enabled
                                                          : CommandStatus.Disabled;
        }

        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            if (SelectEntityId == Guid.Empty)
                buttonItem.Enabled = false;
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        [CommandHandler("ShowHistory")]
        public void OnView(object sender, EventArgs e)
        {
            ShowHistoryListView();
        }

        private Guid SelectEntityId
        {
            get
            {
                MethodInfo methodInfo = WorkItem.GetType().GetMethod("GetSelectEntityId");
                return (Guid) methodInfo.Invoke(WorkItem, null);
            }
        }

        private void ShowHistoryListView()
        {
            const string key = "HistoryListView";
            var historyView = WorkItem.Items.Get<HistroyListForm>(key) ?? WorkItem.Items.AddNew<HistroyListForm>(key);
            var info = new XtraTabSmartPartInfo {Title = "History"};

            var entityId = SelectEntityId;

            historyView.FormHistoryListView.FixedPredicate = new BinaryOperator("ObjectId",entityId);
            historyView.FormHistoryListView.InitEntityView("Audit");
            historyView.FormHistoryListView.Bind("Audit");
            historyView.ShowDialog();
        }
    }
}
