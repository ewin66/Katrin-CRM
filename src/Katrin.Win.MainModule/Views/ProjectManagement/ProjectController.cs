using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Infrastructure;
using Katrin.Win.Infrastructure.Services;
using Katrin.Win.MainModule.Constants;
using Katrin.Win.MainModule.Views.Opportunity;
using Katrin.Win.MainModule.Views.ProjectTask;
using DevExpress.XtraBars;
using Microsoft.Practices.CompositeUI.Commands;

namespace Katrin.Win.MainModule.Views.ProjectManagement
{
    public class ProjectController : EntityListController<ProjectListView, ProjectDetailView>
    {
        private bool _isShowChart;

        protected override string EntityName
        {
            get { return "Project"; }
        }

        protected override void InitController()
        {
            UserDataPersistenceService service = new UserDataPersistenceService("Project");
            _isShowChart = service["ActiveView"] == null ? false : service["ActiveView"].ToString() == "Diagram";

            base.InitController();

            RegisterCommandInvoker("EditEffort", "EditEffort", "", "ShowPageGroup", false, 0);


            string[] displayType = { "List", "Diagram" };
            for (int itemIndex = 0; itemIndex < displayType.Length; itemIndex++)
            {
                BarButtonItem barButton = new BarButtonItem();
                barButton.ButtonStyle = BarButtonStyle.Check;
                barButton.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
                barButton.ItemClick += ViewChange;
                barButton.Caption = GetLocalizedCaption(displayType[itemIndex]);
                barButton.Tag = displayType[itemIndex];
                UIExtensionSites[ExtensionSiteNames.RibbonStatusBar].Add(barButton);
            }
            SetButtonDown();

        }



        protected override void UpdateCommandStatus()
        {
            base.UpdateCommandStatus();
            Commands["EditEffort"].Status = _entityListView.SelectedEntity != null ? CommandStatus.Enabled
                                         : CommandStatus.Disabled;
        }

        [CommandHandler("EditEffort")]
        public void OnEditEffort(object sender, EventArgs e)
        {
            string key = Guid.Empty + ":DetailWorkItem";

            var detailWorkItem = Items.Get<RecordDetailController<ManageEffortDetailView>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = Items.AddNew<RecordDetailController<ManageEffortDetailView>>(key);
                detailWorkItem.EntityName = "EditEffort";
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = GetSelectEntityId();
            detailWorkItem.State["WorkingMode"] = EntityDetailWorkingMode.Edit;
            detailWorkItem.Run();
        }

        private void SetButtonDown()
        {
            var tag = _isShowChart ? "Diagram" : "List";
            IList buttons = UIExtensionSites[ExtensionSiteNames.RibbonStatusBar].ToArrayList();
            foreach (var item in buttons)
            {
                BarButtonItem button = item as BarButtonItem;
                if (button == null || button.Tag == null) continue;
                if (button.Tag.ToString() == tag) button.Down = true;
                else button.Down = false;
            }
        }

        protected override object GetStartView()
        {
            if (_isShowChart)
            {
                ProjectChartView chartView = Items.Get<ProjectChartView>("ChartView");
                if (chartView == null)
                {
                    chartView = Items.AddNew<ProjectChartView>("ChartView");
                    chartView.Context = _entityListView.Context;
                }
                return chartView;
            }
            return base.GetStartView();
        }

        private void ViewChange(object sender, ItemClickEventArgs e)
        {
            var currentView = GetStartView() as Katrin.Win.Common.Core.View;
            if(_isShowChart)
            currentView.Lock();
            _isShowChart = !_isShowChart;
            SetButtonDown();
            Katrin.Win.Common.Core.View actviewView = GetStartView() as Katrin.Win.Common.Core.View;
            if (actviewView == null) return;
            actviewView.Unlock();
            actviewView.OnCurrentChanged(null);
            Workspaces[WorkspaceNames.ShellContentWorkspace].Show(actviewView);
        }

        protected override void OnTerminated()
        {
            base.OnTerminated();
            UserDataPersistenceService service = new UserDataPersistenceService("Project");
            service["ActiveView"] = _isShowChart ? "Diagram" : "List";
            service.Save();
        }
    }
}
