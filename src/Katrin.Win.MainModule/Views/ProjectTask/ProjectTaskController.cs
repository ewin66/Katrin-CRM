using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using Katrin.Win.Common.Security;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using System.Collections;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Katrin.Win.Infrastructure;
using System.Reflection;
using DevExpress.Data.Filtering;
using Katrin.Win.Infrastructure.Services;
namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public class ProjectTaskController : EntityListController<ProjectTaskListView, ProjectTaskDetailView>
    {
        private IList _users;
        private bool _isShowChart;
        protected override string EntityName
        {
            get { return "ProjectTask"; }
        }

        private IProejctTaskFilter Filter
        {
            get
            {
                return GetStartView() as IProejctTaskFilter;
            }
        }

        protected override void InitController()
        {
            UserDataPersistenceService service = new UserDataPersistenceService("ProjectTask");
            _isShowChart = service["ActiveView"] == null ? false : service["ActiveView"].ToString() == "Diagram";

            base.InitController();

            Filter.BeginUpdate();
            var projectId = ParseGuid(service["ProjectId"]);
            var projectIterationId = ParseGuid(service["ProjectIterationId"]);
            var memberId = ParseGuid(service["MemberId"]);
            UpdateContextFilters(projectId, projectIterationId, memberId);
            Filter.InitFilters();
            Filter.EndUpdate();

            InitUser();

            RegisterCommandInvoker("EditTaskEffort", "EditEffort", "edit", "AddPageGroup", false, 0);
            RegisterCommandInvoker("NewProjectTaskEffort", "NewProjectTaskEffort", "add", "AddPageGroup", false, 0);
            RegisterCommandInvoker("GenerateDayReport", "GenerateDayReport", "", "AddPageGroup", false, 0);
            InitEvent();

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

        #region set filter


        private Guid? ParseGuid(object value)
        {
            if (value == null) return null;
            Guid id;
            Guid.TryParse(value.ToString(), out id);
            return id;
        }

        private void UpdateContextFilters(Guid? projectId, Guid? projectIterationId, Guid? memberId)
        {
            ProjectTaskListPresenter.UpdateContextFilters(Filter.Context, projectId, projectIterationId, memberId);
        }

        private void InitUser()
        {
            _users = DynamicDataServiceContext.GetObjects("User");
        }

        public void InitEvent()
        {
            //_entityListView.ProjectChanged += View_OnProjectChange;
        }
        
        #endregion

        protected override void UpdateCommandStatus()
        {
            base.UpdateCommandStatus();
            Commands["EditTaskEffort"].Status = _entityListView.SelectedEntity != null ? CommandStatus.Enabled
                                         : CommandStatus.Disabled;
            Commands["GenerateDayReport"].Status = _entityListView.SelectedEntity != null ? CommandStatus.Enabled
                                         : CommandStatus.Disabled;
            Commands["NewProjectTaskEffort"].Status = _entityListView.SelectedEntity != null ? CommandStatus.Enabled
                                         : CommandStatus.Disabled;
        }

        [CommandHandler("GenerateDayReport")]
        public void OnGenerateDayReport(object sender, EventArgs e)
        {
            LateBindingApi.Core.Factory.Initialize();
            Outlook.Application outlookApplication = new Outlook.Application();

            DateTime thisDay = DateTime.Today;
            DateTime nextDay = thisDay.AddDays(1);
            IEnumerable taskList = GetTasks(thisDay);
            var projectIdList = taskList.AsQueryable().Select("ProjectId").Cast<Guid>().Distinct<Guid>();
            if (projectIdList.ToList().Count <= 0)
            {
                XtraMessageBox.Show(Properties.Resources.NoTaskTip,
                       Properties.Resources.Katrin,
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information,
                       MessageBoxDefaultButton.Button1);
                return;
            }
            foreach (Guid projectId in projectIdList)
            {
                Outlook.MailItem KatrinEmal = outlookApplication.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;
                KatrinEmal.Subject = "";
                string emailTo = "";
                string sourceHtmlBody = KatrinEmal.HTMLBody;
                KatrinEmal.HTMLBody = InitEmailMessage(out emailTo, thisDay, nextDay, projectId, taskList);
                if (!string.IsNullOrEmpty(emailTo))
                    KatrinEmal.Recipients.Add(emailTo);
                KatrinEmal.Importance = OlImportance.olImportanceNormal;
                KatrinEmal.Display();
            }
        }

        private string GetDayTask(IEnumerable taskList, Guid projectId, bool isNextDay, DateTime date)
        {
            string result = "";
            var projectTaskList = taskList.AsQueryable().Where("ProjectId==@0", projectId).ToArrayList();
            foreach (var task in projectTaskList)
            {
                var dynamic = task.AsDyanmic();
                string rowItem = "<tr class='NormalLine'>";
                rowItem += "<td class='Left'>" + dynamic.Name + "</td>";
                if (isNextDay)
                {
                    rowItem += "<td class='LineMid'>" + date.ToShortDateString() + "</td>";
                }
                rowItem += "<td class='LineMid'>" + dynamic.ActualWorkHours + "</td>";
                if (!isNextDay)
                {
                    rowItem += "<td class='LineMid'>" + dynamic.ActualInput + "</td>";
                    IList taskhistory = dynamic.TaskTimeHistories;
                    DateTime nextDate = date.AddDays(1);
                    double actuallyProgress = taskhistory.AsQueryable().Where("RecordOn>=@0 && RecordOn<= @1", date, nextDate).Select("Effort").Cast<double?>().Sum() / dynamic.ActualWorkHours * 100;
                    rowItem += "<td class='LineMid'>" + actuallyProgress.ToString("0.00") + "%</td>";
                }
                rowItem += "<td class='Right'></td>";
                rowItem += "</tr>";
                result += rowItem;
            }
            return result;
        }



        private IEnumerable GetTasks(DateTime date)
        {
            var extraColumns = new Dictionary<string, string>
                                   {
                                       {"TaskTimeHistories", "TaskTimeHistories"}
                                   };

            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId);
            filter &= new BinaryOperator("StartDate", date, BinaryOperatorType.LessOrEqual);
            filter &= new GroupOperator(GroupOperatorType.Or, new UnaryOperator(UnaryOperatorType.IsNull, "EndDate"),
                new BinaryOperator("EndDate", date, BinaryOperatorType.GreaterOrEqual));

            return DynamicDataServiceContext.GetObjects("ProjectTask", filter, extraColumns);
        }

        private string GetWeekTask(DateTime date, Guid projectid)
        {
            DateTime startDate = Utils.Date.WeekBegin(date);
            DateTime endDate = Utils.Date.WeekEnd(date);
            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId);
            filter &= new BinaryOperator("StartDate", endDate, BinaryOperatorType.LessOrEqual);
            filter &= new GroupOperator(GroupOperatorType.Or, new UnaryOperator(UnaryOperatorType.IsNull, "EndDate"),
                new BinaryOperator("EndDate", startDate, BinaryOperatorType.GreaterOrEqual));
            filter &= new BinaryOperator("ProjectId", projectid);

            var weekTasks = DynamicDataServiceContext.GetObjects("ProjectTask", filter,null);
            string result = "";
            foreach (var weekTask in weekTasks)
            {
                var dynamic = weekTask.AsDyanmic();
                string rowItem = "<tr class='NormalLine'>";
                rowItem += "<td class='Left'>" + dynamic.Name + "</td>";
                rowItem += "<td class='LineMid'>" + ToShortDate(dynamic.StartDate) + "</td>";
                rowItem += "<td class='LineMid'>" + ToShortDate(dynamic.EndDate) + "</td>";
                rowItem += "<td class='LineMid'></td>";
                double status = dynamic.Effort * 100 / dynamic.ActualWorkHours;
                rowItem += "<td class='LineMid'>" + status.ToString("0.00") + "%</td>";
                rowItem += "<td class='Right'>" + dynamic.Description + "</td>";
                rowItem += "</tr>";
                result += rowItem;
            }
            return result;
        }

        private string ToShortDate(object date)
        {
            string result = "";
            if (date != null)
            {
                result = Convert.ToDateTime(date).ToShortDateString();
            }
            return result;
        }

        private string InitEmailMessage(out string emailTo, DateTime thisDay, DateTime nextDay, Guid projectId, IEnumerable taskList)
        {
            string dayReportTemplate = Properties.Resources.DayReportTemplate;

            //project 
            var project = DynamicDataServiceContext.GetOrNew("Project", projectId, "Customer");
            var customer = project.AsDyanmic().Customer;
            emailTo = customer == null ? string.Empty : customer.EMailAddress1;
            dayReportTemplate = dayReportTemplate.Replace("$CustomerName$", project.AsDyanmic().Contact);
            dayReportTemplate = dayReportTemplate.Replace("$ThisWeekTask$", GetWeekTask(thisDay, projectId));
            dayReportTemplate = dayReportTemplate.Replace("$TodayTask$", GetDayTask(taskList, projectId, false, thisDay));
            dayReportTemplate = dayReportTemplate.Replace("$NextDayTask$", GetDayTask(GetTasks(nextDay), projectId, true, nextDay));
            dayReportTemplate = dayReportTemplate.Replace("$ReportPeople$", AuthorizationManager.FullName);
            return dayReportTemplate;
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
            detailWorkItem.State["EntityId"] = Guid.Empty;
            detailWorkItem.State["WorkingMode"] = EntityDetailWorkingMode.Edit;
            detailWorkItem.Run();
        }

        [CommandHandler("EditTaskEffort")]
        public void OnEditTaskEffort(object sender, EventArgs e)
        {
            string key = Guid.Empty + ":DetailWorkItem";

            var detailWorkItem = Items.Get<RecordDetailController<TaskEffortDetailView>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = Items.AddNew<RecordDetailController<TaskEffortDetailView>>(key);
                detailWorkItem.EntityName = "ProjectTaskEffort";
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = GetSelectEntityId();
            detailWorkItem.State["WorkingMode"] = EntityDetailWorkingMode.Edit;
            detailWorkItem.Run();
        }

        [CommandHandler("NewProjectTaskEffort")]
        public void OnNewProjectTaskEffort(object sender, EventArgs e)
        {
            string key = Guid.Empty + ":DetailWorkItem";

            var detailWorkItem = Items.Get<RecordDetailController<NewTaskEffortDetailView>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = Items.AddNew<RecordDetailController<NewTaskEffortDetailView>>(key);
                detailWorkItem.EntityName = "NewProjectTaskEffort";
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = Guid.Empty;
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

        private void ViewChange(object sender, ItemClickEventArgs e)
        {
            var context = Filter.Context;
            var currentView = (IView)Filter;
            currentView.Lock();
            _isShowChart = !_isShowChart;
            SetButtonDown();
            IProejctTaskFilter actviewView = Filter;
            ((IView)actviewView).Unlock();
            actviewView.BeginUpdate();
            actviewView.InitFilters();
            actviewView.BindData();
            actviewView.EndUpdate();
            Workspaces[WorkspaceNames.ShellContentWorkspace].Show(actviewView);
        }

        protected override void OnTerminated()
        {
            base.OnTerminated();

            UserDataPersistenceService service = new UserDataPersistenceService("ProjectTask");
            service["ActiveView"] = _isShowChart ? "Diagram" : "List";

            service["ProjectId"] = Filter.ProjectId;
            service["ProjectIterationId"] = Filter.ProjectIterationId;
            service["MemberId"] = Filter.MemberId;

            service.Save();
        }

        protected override object GetStartView()
        {
            if (_isShowChart)
            {
                ProjectTaskChartView chartView = Items.Get<ProjectTaskChartView>("ChartView");
                if (chartView == null)
                {
                    chartView = Items.AddNew<ProjectTaskChartView>("ChartView");
                    chartView.Context = _entityListView.Context;
                }
                return chartView;
            }
            return base.GetStartView();
        }

        protected override void BindListData()
        {
            Filter.BindData();
        }
    }
}
