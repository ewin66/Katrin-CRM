using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Controls;
using Katrin.Win.Common.Constants;
using Katrin.Win.MainModule.Views.ProjectTask;
using Microsoft.Practices.CompositeUI.Commands;
using CABDevExpress.SmartPartInfos;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Collections;
using Katrin.Win.MainModule.Views.ProjectIteration;
using Katrin.Win.Infrastructure;
using Katrin.Win.Common;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using DevExpress.Data.Filtering; 

namespace Katrin.Win.MainModule.Views.ProjectWeekReport
{
    public class ProjectDetailPresenter : EntityDetailPresenter<IProjectWeekReportDetailView>
    {
        public ProjectDetailPresenter()
        {
            EntityName = "ProjectWeekReport";
        }

        protected override void OnViewSet()
        {
            base.OnViewSet();
            View.SetRichEdit();
            RegisterCommand(ExtensionSiteNames.DetailAddGroup, "GenerateWeekReport", "GenerateWeekReport", "", "GenerateWeekReport");
        }
        private void RegisterCommand(string groupName, string commandName, string imageName, string overlay, string caption)
        {
            var localizedCaption = Properties.Resources.ResourceManager.GetString(caption);
            var buttonItem = new BarButtonItemEx(imageName, overlay) { Caption = localizedCaption };
            if (WorkItem.Commands[commandName] != null)
            {
                WorkItem.Commands[commandName].AddInvoker(buttonItem, "ItemClick");
            }
            if (commandName == "ShowTask")
            {
                buttonItem.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
            }
            buttonItem.Name = commandName;
            WorkItem.UIExtensionSites[groupName].Add(buttonItem);
        }

        [CommandHandler("GenerateWeekReport")]
        public void OnGenerateWeekReport(object sender, EventArgs e)
        {
            try
            {
                LateBindingApi.Core.Factory.Initialize();
                Outlook.Application outlookApplication = new Outlook.Application();
                Outlook.MailItem KatrinEmal = outlookApplication.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;
                KatrinEmal.Subject = this.DynamicEntity.Name;
                string emailTo = "";
                KatrinEmal.HTMLBody = InitEmailMessage(out emailTo);
                if (!string.IsNullOrEmpty(emailTo))
                KatrinEmal.Recipients.Add(emailTo);
                KatrinEmal.Importance = OlImportance.olImportanceNormal;
                KatrinEmal.Display();
            }
            catch
            {

            }
        }

        private string InitEmailMessage(out string emailTo)
        {
            string weekReportTemplate = Properties.Resources.WeekReportTemplate;
            //week info
            weekReportTemplate = weekReportTemplate.Replace("$CurrentProgress$",
                   GetLocalizedPickListValue("ProjectWeekReport", "CurrentProgressCode", this.DynamicEntity.CurrentProgressCode));
            weekReportTemplate = weekReportTemplate.Replace("$OutlookProgress$",
                GetLocalizedPickListValue("ProjectWeekReport", "OutlookProgressCode", this.DynamicEntity.OutlookProgressCode));
            weekReportTemplate = weekReportTemplate.Replace("$CurrentQuality$",
                GetLocalizedPickListValue("ProjectWeekReport", "CurrentQualityCode", this.DynamicEntity.CurrentQualityCode));
            weekReportTemplate = weekReportTemplate.Replace("$OutlookQuality$",
                GetLocalizedPickListValue("ProjectWeekReport", "OutlookQualityCode", this.DynamicEntity.OutlookQualityCode));
            weekReportTemplate = weekReportTemplate.Replace("$CriteriaProgress$", this.DynamicEntity.CriteriaProgress);
            weekReportTemplate = weekReportTemplate.Replace("$CriteriaQuality$", this.DynamicEntity.CriteriaQuality);
            weekReportTemplate = weekReportTemplate.Replace("$Suggestions$", this.DynamicEntity.Suggestions);
            weekReportTemplate = weekReportTemplate.Replace("$Reviews$", this.DynamicEntity.Reviews);

            // week Iteration
            var projectIteration = DynamicDataServiceContext.GetOrNew("ProjectIteration", this.DynamicEntity.ProjectIterationId, "ProjectTasks,ProjectVersion");
            weekReportTemplate = weekReportTemplate.Replace("$ShortTermGoal$", projectIteration.Objective);

            string startDate = "";
            if (projectIteration.StartDate != null)
            {
                DateTime sdt = Convert.ToDateTime(projectIteration.StartDate);
                startDate = "[" + sdt.ToShortDateString() + "]";
            }
            weekReportTemplate = weekReportTemplate.Replace("$StartDate$", startDate);
            string endDate = string.Empty;
            if(projectIteration.ProjectVersion != null)
                endDate = projectIteration.ProjectVersion.VersionName;
            if (projectIteration.Deadline != null)
            {
                DateTime edt = Convert.ToDateTime(projectIteration.Deadline);
                endDate = string.IsNullOrEmpty(endDate) ? "[" + edt.ToShortDateString() + "]" :
                    endDate + "[" + edt.ToShortDateString() + "]";
            }
            weekReportTemplate = weekReportTemplate.Replace("$DeadLine$", endDate);

            //week project 
            var project = DynamicDataServiceContext.GetOrNew("Project", this.DynamicEntity.ProjectId, "Customer");
            if (project.Customer != null)
                emailTo = project.Customer.EMailAddress1;
            else
                emailTo = string.Empty;
            weekReportTemplate = weekReportTemplate.Replace("$CustomerName$", project.Contact);
            weekReportTemplate = weekReportTemplate.Replace("$ProjectName$", project.Name);
            weekReportTemplate = weekReportTemplate.Replace("$LongTermGoal$", project.Objective);

            //task info
            DateTime recordDate = DateTime.Today;
            if (this.DynamicEntity.RecordOn != null)
                recordDate = Convert.ToDateTime(this.DynamicEntity.RecordOn);
            IList projectTasks = projectIteration.ProjectTasks;
            projectTasks = projectTasks.AsQueryable().Where("IsDeleted = false").ToArrayList();
            IEnumerable taskHistoryList = GetTaskHistory(recordDate, projectTasks.AsQueryable().Select("TaskId").Cast<Guid>().ToList());
            double? remainingProgramming = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum()-
                (taskHistoryList==null?0d:taskHistoryList.AsQueryable().Select("Effort").Cast<double?>().Sum());
            double? availableProgramming = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum() -
                (taskHistoryList == null?0d:taskHistoryList.AsQueryable().Select("ActualInput").Cast<double?>().Sum());
            double? workAmountOfThisWeek = taskHistoryList == null?0d:taskHistoryList.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
            weekReportTemplate = weekReportTemplate.Replace("$RemainingProgramming$", remainingProgramming == null ? "" : remainingProgramming.ToString());
            weekReportTemplate = weekReportTemplate.Replace("$AvailableProgramming$", availableProgramming == null ? "" : availableProgramming.ToString());
            weekReportTemplate = weekReportTemplate.Replace("$WorkAmountOfThisWeek$", workAmountOfThisWeek == null ? "" : workAmountOfThisWeek.ToString());
            weekReportTemplate = weekReportTemplate.Replace("$ThisWeekTask$",GetThisWeekTask(recordDate,projectTasks));
            weekReportTemplate = weekReportTemplate.Replace("$NextWeekTask$", GetNextWeekTask(recordDate, projectTasks));
            return weekReportTemplate;
        }

        private string GetThisWeekTask(DateTime recordDate,IList projectTasks)
        {
            DateTime startDate = Utils.Date.WeekBegin(recordDate);
            DateTime endDate = Utils.Date.WeekEnd(recordDate);
            var thisWeekTask = projectTasks.AsQueryable().Where("StartDate<=@1 && (EndDate==null || EndDate>=@0)", startDate, endDate).ToArrayList();
            return GetWeekTask(startDate, endDate, thisWeekTask);
        }

        private string GetNextWeekTask(DateTime recordDate,IList projectTasks)
        {
            DateTime endDate = Utils.Date.WeekEnd(recordDate);
            recordDate = endDate.AddDays(1);
            DateTime startDate = Utils.Date.WeekBegin(recordDate);
            endDate = Utils.Date.WeekEnd(recordDate);
            var nextWeekTask = projectTasks.AsQueryable().Where("StartDate<=@1 && (EndDate==null || EndDate>=@0)", startDate, endDate).ToArrayList();
            return GetWeekTask(startDate, endDate, nextWeekTask);
        }

        private string GetWeekTask(DateTime startDate, DateTime endDate, IList weekTask)
        {
            string result = "";
            int itemIndex = 1;
            foreach (var task in weekTask)
            {
                result += itemIndex.ToString() + "?" + task.AsDyanmic().Name + "<br/>";
                itemIndex++;
            }
            return result;
        }

        private IEnumerable GetTaskHistory(DateTime recordDate, List<Guid> taskListId)
        {
            DateTime startDate = Utils.Date.WeekBegin(recordDate);
            DateTime endDate = Utils.Date.WeekEnd(recordDate);
            if (taskListId.Count <= 0) return null;
            CriteriaOperator filter = new BinaryOperator("RecordOn", startDate, BinaryOperatorType.GreaterOrEqual);
            filter &= new BinaryOperator("RecordOn", endDate, BinaryOperatorType.LessOrEqual);
            if (taskListId.Count > 0) filter &= new InOperator("TaskId", taskListId);

            return DynamicDataServiceContext.GetObjects("TaskTimeHistory", filter, null);
        }

        private string GetLocalizedPickListValue(string entityName, string attributeName, object objectValue)
        {
            if (objectValue == null) return string.Empty;
            int value = int.Parse(objectValue.ToString());
            var entity = MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.First(a => a.PhysicalName == attributeName);
            if (attribute.OptionSet == null)
                return null;

            var pickListValue = attribute.OptionSet.AttributePicklistValues.FirstOrDefault(v => v.Value == value);
            if (pickListValue == null)
                return value.ToString(CultureInfo.InvariantCulture);
            //throw new ApplicationException(string.Format("The property {0} of {1} doesn't have the value: {2}", attributeName, entityName, value));
            //var culture = System.Globalization.CultureInfo.CurrentCulture;
            var localizedLabels = MetadataProvider.Instance.LocalizedLabels
                .Where(l => l.ObjectId == pickListValue.AttributePicklistValueId);

            var localizedLabel = localizedLabels.FirstOrDefault(l => l.LanguageId == 1033) ?? //culture.LCID
                                 localizedLabels.First();
            return localizedLabel.Label;
        }

        [EventSubscription(EventTopicNames.RefreshCommandStatus, Thread = ThreadOption.UserInterface)]
        public void OnRefreshCommandStatus(object sender, EventArgs e)
        {
            UpdateCommandStatus();
        }

        private void UpdateCommandStatus()
        {
            var status = WorkingMode != EntityDetailWorkingMode.Add ? CommandStatus.Enabled : CommandStatus.Disabled;
            WorkItem.Commands["GenerateWeekReport"].Status = status;
        }
    }
}
