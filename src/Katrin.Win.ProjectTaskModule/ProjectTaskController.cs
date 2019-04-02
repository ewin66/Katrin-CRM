using Katrin.AppFramework.WinForms.MVC;
using Katrin.AppFramework.WinForms.MVC.Data;
using Katrin.AppFramework.WinForms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.AppFramework.WinForms.Controller;
using Katrin.AppFramework;
using Katrin.AppFramework.WinForms.Grid;
using Katrin.AppFramework.WinForms;
using ICSharpCode.Core;
using Outlook = NetOffice.OutlookApi;
using System.Collections;
using Katrin.AppFramework.WinForms.Extensions;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using NetOffice.OutlookApi.Enums;
using Katrin.AppFramework.Extensions;
using Katrin.AppFramework.Security;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.Win.ProjectTaskModule.Chart;
using Katrin.Win.MainModule.Views.ProjectTask;
using Katrin.Win.ProjectTaskModule.Common;
using Katrin.AppFramework.Data;
using Katrin.Win.ProjectTaskModule.Detail;
namespace Katrin.Win.ProjectTaskModule
{
    public class ProjectTaskController : TaskListController, IObjectWidget, IListener<SelectedObjectChangedMessage>, IListener<UpdateContextFilterMessage>
    {
        public override string ObjectName
        {
            get
            {
                return "ProjectTask";
            }
        }

        protected override  string RibbonPath
        {
            get { return "/ProjectTask/List/Ribbon"; }
        }

        public string ParentObjectName
        {
            get;
            set;
        }


        public override IActionResult Execute(ActionParameters parameters)
        {
            _listView = CreateListView("DefaultListView");
            _listView.ObjectName = ObjectName;
            var result = new PartialViewResult();
            result.View = _listView;
            return result;
        }

        void IListener<UpdateContextFilterMessage>.Handle(UpdateContextFilterMessage message)
        {
            FixedFilter = message.FixedFilter;
            BindListData();
        }

        void IListener<SelectedObjectChangedMessage>.Handle(SelectedObjectChangedMessage message)
        {
            if (message.ObjectName == ParentObjectName)
            {
                if (message.SelectedObject == null)
                {
                    _listView.ClearData();
                    return;
                }

                var id = _objectSpace.GetObjectId(message.ObjectName, message.SelectedObject);

                FixedFilter = new BinaryOperator("ProjectId", id);

                BindListData();
            }
        }

       


        #region day report
        public void GenerateDayReport()
        {
            try
            {
                LateBindingApi.Core.Factory.Initialize();
                Outlook.Application outlookApplication = new Outlook.Application();

                DateTime thisDay = DateTime.Today;
                DateTime nextDay = thisDay.AddDays(1);
                IEnumerable taskList = GetTasks(thisDay);
                var projectIdList = taskList.AsQueryable().Select("ProjectId").Cast<Guid>().Distinct<Guid>();
                if (projectIdList.ToList().Count <= 0)
                {
                    XtraMessageBox.Show(StringParser.Parse("NoTaskTip"),
                           StringParser.Parse("Katrin"),
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
                    KatrinEmal.Display();
                    string sourceHtmlBody = KatrinEmal.HTMLBody;
                    string emailBody = InitEmailMessage(out emailTo, thisDay, nextDay, projectId, taskList);
                    emailBody += sourceHtmlBody;
                    KatrinEmal.HTMLBody = emailBody;
                    if (!string.IsNullOrEmpty(emailTo))
                        KatrinEmal.Recipients.Add(emailTo);
                    KatrinEmal.Importance = OlImportance.olImportanceNormal;
                    
                }
            }
            catch(Exception ex)
            {
                MessageService.ShowException(ex, ResourceService.GetString("EmailExceptionTip"));
            }
        }


        private string InitEmailMessage(out string emailTo, DateTime thisDay, DateTime nextDay, Guid projectId, IEnumerable taskList)
        {
            string dayReportTemplate = StringParser.Parse("DayReportTemplate");

            //project 
            var project = (Katrin.Domain.Impl.Project)_objectSpace.GetOrNew("Project", projectId, "Customer");
            emailTo = project.Customer == null ? string.Empty : project.Customer.EMailAddress1;
            dayReportTemplate = dayReportTemplate.Replace("$CustomerName$", project.Contact);
            dayReportTemplate = dayReportTemplate.Replace("$ThisWeekTask$", GetWeekTask(thisDay, projectId));
            dayReportTemplate = dayReportTemplate.Replace("$TodayTask$", GetDayTask(taskList, projectId, false, thisDay));
            dayReportTemplate = dayReportTemplate.Replace("$NextDayTask$", GetDayTask(GetTasks(nextDay), projectId, true, nextDay));
            dayReportTemplate = dayReportTemplate.Replace("$ReportPeople$", AuthorizationManager.FullName);
            return dayReportTemplate;
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

            return _objectSpace.GetObjects("ProjectTask", filter, extraColumns);
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

        private string GetWeekTask(DateTime date, Guid projectid)
        {
            DateTime startDate = Date.WeekBegin(date);
            DateTime endDate = Date.WeekEnd(date);
            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId);
            filter &= new BinaryOperator("StartDate", endDate, BinaryOperatorType.LessOrEqual);
            filter &= new GroupOperator(GroupOperatorType.Or, new UnaryOperator(UnaryOperatorType.IsNull, "EndDate"),
                new BinaryOperator("EndDate", startDate, BinaryOperatorType.GreaterOrEqual));
            filter &= new BinaryOperator("ProjectId", projectid);

            var weekTasks = _objectSpace.GetObjects("ProjectTask", filter, null);
            string result = "";
            foreach (var weekTask in weekTasks)
            {
                var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(weekTask);
                string rowItem = "<tr class='NormalLine'>";
                rowItem += "<td class='Left'>" + projectTask.Name + "</td>";
                rowItem += "<td class='LineMid'>" + ToShortDate(projectTask.StartDate) + "</td>";
                rowItem += "<td class='LineMid'>" + ToShortDate(projectTask.EndDate) + "</td>";
                rowItem += "<td class='LineMid'></td>";
                double actualWorkHours = projectTask.ActualWorkHours ?? 0;
                double status = actualWorkHours==0 ?0:(projectTask.Effort ?? 0) * 100 / actualWorkHours;
                rowItem += "<td class='LineMid'>" + status.ToString("0.00") + "%</td>";
                rowItem += "<td class='Right'>" + projectTask.Description + "</td>";
                rowItem += "</tr>";
                result += rowItem;
            }
            return result;
        }

        private string GetDayTask(IEnumerable taskList, Guid projectId, bool isNextDay, DateTime date)
        {
            string result = "";
            var projectTaskList = taskList.AsQueryable().Where("ProjectId==@0", projectId);
            foreach (var task in projectTaskList)
            {
                var projectTask =  ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(task);
                string rowItem = "<tr class='NormalLine'>";
                rowItem += "<td class='Left'>" + projectTask.Name + "</td>";
                if (isNextDay)
                {
                    rowItem += "<td class='LineMid'>" + date.ToShortDateString() + "</td>";
                }
                rowItem += "<td class='LineMid'>" + projectTask.ActualWorkHours + "</td>";
                if (!isNextDay)
                {
                    rowItem += "<td class='LineMid'>" + projectTask.ActualInput + "</td>";
                    IList taskhistory = projectTask.TaskTimeHistories;
                    DateTime nextDate = date.AddDays(1);
                    double actualWorkHours = projectTask.ActualWorkHours ?? 0;
                    double sumEffort = taskhistory.AsQueryable().Where("RecordOn>=@0 && RecordOn<= @1", date, nextDate).Select("Effort").Cast<double?>().Sum()??0;
                    double actuallyProgress = actualWorkHours == 0 ? 0 : sumEffort / actualWorkHours * 100;
                    rowItem += "<td class='LineMid'>" + actuallyProgress.ToString("0.00") + "%</td>";
                }
                rowItem += "<td class='Right'></td>";
                rowItem += "</tr>";
                result += rowItem;
            }
            return result;
        }
        #endregion

        #region GiveTaskTo
        public void GiveTaskToMember(Guid? toMemberId)
        {
            Guid projectTaskId = this._objectSpace.GetObjectId(this.ObjectName, this.SelectedObject);
            object projectTask = this._objectSpace.GetOrNew(this.ObjectName, projectTaskId, null);
            Katrin.Domain.Impl.ProjectTask task = projectTask as Katrin.Domain.Impl.ProjectTask;
            task.OwnerId = toMemberId;
            this._objectSpace.SaveChanges();          
            this.BindListData();

            //update detail
            IList<ProjectTaskDetailController> controllers = 
                this.Context.AppContext.ControllerFinder.FinController<ProjectTaskDetailController>("ProjectTaskDetail");
            var detailControllers = controllers.Where(p => p.ObjectId == task.TaskId);
            foreach (var controller in detailControllers)
            {
                controller.UpdateOwerId(toMemberId);
            }


        }

        public void MoveTaskToIteration(Guid? iterationId)
        {
            IObjectSpace iobjectSpace = new ODataObjectSpace();
            Guid projectTaskId = this._objectSpace.GetObjectId(this.ObjectName, this.SelectedObject);
            object projectTask = iobjectSpace.GetOrNew(this.ObjectName, projectTaskId, null);
            Katrin.Domain.Impl.ProjectTask task = projectTask as Katrin.Domain.Impl.ProjectTask;
            task.ProjectIterationId = iterationId;
            iobjectSpace.SaveChanges();          
            this.BindListData();

            //update detail
            IList<ProjectTaskDetailController> controllers =
               this.Context.AppContext.ControllerFinder.FinController<ProjectTaskDetailController>("ProjectTaskDetail");
            var detailControllers = controllers.Where(p => p.ObjectId == task.TaskId);
            foreach (var controller in detailControllers)
            {
                controller.UpdateIteration(iterationId);
            }
        }


        #endregion


        
    }
}
