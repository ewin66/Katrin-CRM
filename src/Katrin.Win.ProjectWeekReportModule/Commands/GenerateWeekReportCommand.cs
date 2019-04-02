using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.Core;
using Outlook = NetOffice.OutlookApi;
using NetOffice.OutlookApi.Enums;
using Katrin.Win.ProjectWeekReportModule.Detail;
using System.Collections;
using System.Globalization;
using DevExpress.Data.Filtering;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework;
using System.Linq.Dynamic;
using Katrin.AppFramework.Metadata;

namespace Katrin.Win.ProjectWeekReportModule.Commands
{
    public class GenerateWeekReportCommand : AbstractCommand
    {
        protected IObjectSpace _objectSpace = new ODataObjectSpace();
        public override void Run()
        {
            try
            {
                ProjectWeekReportDetailController projectWeekReportController = (ProjectWeekReportDetailController)this.Owner;
                if (!(this.Owner is ProjectWeekReportDetailController)) return;
                LateBindingApi.Core.Factory.Initialize();
                Outlook.Application outlookApplication = new Outlook.Application();
                Outlook.MailItem KatrinEmal = outlookApplication.CreateItem(OlItemType.olMailItem) as Outlook.MailItem;
                KatrinEmal.Subject = projectWeekReportController.ObjectName;
                string emailTo = "";
                KatrinEmal.Display();
                string sourceHtmlBody = KatrinEmal.HTMLBody;
                string emailBody = InitEmailMessage(out emailTo);
                emailBody += sourceHtmlBody;
                KatrinEmal.HTMLBody = emailBody;
                if (!string.IsNullOrEmpty(emailTo))
                    KatrinEmal.Recipients.Add(emailTo);
                KatrinEmal.Importance = OlImportance.olImportanceNormal;
            }
            catch (Exception ex)
            {
                MessageService.ShowException(ex, ResourceService.GetString("EmailExceptionTip"));
            }

        }
        private string InitEmailMessage(out string emailTo)
        {
            ProjectWeekReportDetailController projectWeekReportController = (ProjectWeekReportDetailController)this.Owner;
            var entity = (Katrin.Domain.Impl.ProjectWeekReport)projectWeekReportController.ObjectEntity;
            string weekReportTemplate = ResourceService.GetString("WeekReportTemplate");// Properties.Resources.WeekReportTemplate;
            //week info
            weekReportTemplate = weekReportTemplate.Replace("$CurrentProgress$",
                   GetLocalizedPickListValue("ProjectWeekReport", "CurrentProgressCode", entity.CurrentProgressCode));
            weekReportTemplate = weekReportTemplate.Replace("$OutlookProgress$",
                GetLocalizedPickListValue("ProjectWeekReport", "OutlookProgressCode", entity.OutlookProgressCode));
            weekReportTemplate = weekReportTemplate.Replace("$CurrentQuality$",
                GetLocalizedPickListValue("ProjectWeekReport", "CurrentQualityCode", entity.CurrentQualityCode));
            weekReportTemplate = weekReportTemplate.Replace("$OutlookQuality$",
                GetLocalizedPickListValue("ProjectWeekReport", "OutlookQualityCode", entity.OutlookQualityCode));
            weekReportTemplate = weekReportTemplate.Replace("$CriteriaProgress$", entity.CriteriaProgress);
            weekReportTemplate = weekReportTemplate.Replace("$CriteriaQuality$", entity.CriteriaQuality);
            weekReportTemplate = weekReportTemplate.Replace("$Suggestions$", entity.Suggestions);
            weekReportTemplate = weekReportTemplate.Replace("$Reviews$", entity.Reviews);

            // week Iteration
            var projectIteration = (Katrin.Domain.Impl.ProjectIteration)_objectSpace.GetOrNew("ProjectIteration", entity.ProjectIterationId, "ProjectTasks,ProjectVersion");
            weekReportTemplate = weekReportTemplate.Replace("$ShortTermGoal$", projectIteration.Objective);

            string startDate = "";
            if (projectIteration.StartDate != null)
            {
                DateTime sdt = Convert.ToDateTime(projectIteration.StartDate);
                startDate = "[" + sdt.ToShortDateString() + "]";
            }
            weekReportTemplate = weekReportTemplate.Replace("$StartDate$", startDate);
            string endDate = string.Empty;
            if (projectIteration.ProjectVersion != null)
                endDate = projectIteration.ProjectVersion.VersionName;
            if (projectIteration.Deadline != null)
            {
                DateTime edt = Convert.ToDateTime(projectIteration.Deadline);
                endDate = string.IsNullOrEmpty(endDate) ? "[" + edt.ToShortDateString() + "]" :
                    endDate + "[" + edt.ToShortDateString() + "]";
            }
            weekReportTemplate = weekReportTemplate.Replace("$DeadLine$", endDate);

            //week project 
            var project = (Katrin.Domain.Impl.Project)_objectSpace.GetOrNew("Project", entity.ProjectId, "Customer");
            if (project.Customer != null)
                emailTo = project.Customer.EMailAddress1;
            else
                emailTo = string.Empty;
            weekReportTemplate = weekReportTemplate.Replace("$CustomerName$", project.Contact);
            weekReportTemplate = weekReportTemplate.Replace("$ProjectName$", project.Name);
            weekReportTemplate = weekReportTemplate.Replace("$LongTermGoal$", project.Objective);

            //task info
            DateTime recordDate = DateTime.Today;
            if (entity.RecordOn != null)
                recordDate = Convert.ToDateTime(entity.RecordOn);
            IList projectTasks = projectIteration.ProjectTasks;
            projectTasks = projectTasks.AsQueryable().Where("IsDeleted = false").ToArrayList();
            IEnumerable taskHistoryList = GetTaskHistory(recordDate, projectTasks.AsQueryable().Select("TaskId").Cast<Guid>().ToList());
            double? remainingProgramming = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum() -
                (taskHistoryList == null ? 0d : taskHistoryList.AsQueryable().Select("Effort").Cast<double?>().Sum());
            double? availableProgramming = projectTasks.AsQueryable().Select("ActualWorkHours").Cast<double?>().Sum() -
                (taskHistoryList == null ? 0d : taskHistoryList.AsQueryable().Select("ActualInput").Cast<double?>().Sum());
            double? workAmountOfThisWeek = taskHistoryList == null ? 0d : taskHistoryList.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
            weekReportTemplate = weekReportTemplate.Replace("$RemainingProgramming$", remainingProgramming == null ? "" : remainingProgramming.ToString());
            weekReportTemplate = weekReportTemplate.Replace("$AvailableProgramming$", availableProgramming == null ? "" : availableProgramming.ToString());
            weekReportTemplate = weekReportTemplate.Replace("$WorkAmountOfThisWeek$", workAmountOfThisWeek == null ? "" : workAmountOfThisWeek.ToString());
            weekReportTemplate = weekReportTemplate.Replace("$ThisWeekTask$", GetThisWeekTask(recordDate, projectTasks));
            weekReportTemplate = weekReportTemplate.Replace("$NextWeekTask$", GetNextWeekTask(recordDate, projectTasks));
            return weekReportTemplate;
        }
        private string GetThisWeekTask(DateTime recordDate, IList projectTasks)
        {
            DateTime startDate = Katrin.AppFramework.Utils.Date.WeekBegin(recordDate);
            DateTime endDate = Katrin.AppFramework.Utils.Date.WeekEnd(recordDate);
            var thisWeekTask = projectTasks.AsQueryable().Where("StartDate<=@1 && (EndDate==null || EndDate>=@0)", startDate, endDate).ToArrayList();
            return GetWeekTask(startDate, endDate, thisWeekTask);
        }

        private string GetNextWeekTask(DateTime recordDate, IList projectTasks)
        {
            DateTime endDate = Katrin.AppFramework.Utils.Date.WeekEnd(recordDate);
            recordDate = endDate.AddDays(1);
            DateTime startDate = Katrin.AppFramework.Utils.Date.WeekBegin(recordDate);
            endDate = Katrin.AppFramework.Utils.Date.WeekEnd(recordDate);
            var nextWeekTask = projectTasks.AsQueryable().Where("StartDate<=@1 && (EndDate==null || EndDate>=@0)", startDate, endDate).ToArrayList();
            return GetWeekTask(startDate, endDate, nextWeekTask);
        }

        private string GetWeekTask(DateTime startDate, DateTime endDate, IList weekTask)
        {
            string result = "";
            int itemIndex = 1;
            foreach (var task in weekTask)
            {
                var taskData = (Katrin.Domain.Impl.ProjectTask)task;
                result += itemIndex.ToString() + "?" + taskData.Name + "<br/>";
                itemIndex++;
            }
            return result;
        }
        private IEnumerable GetTaskHistory(DateTime recordDate, List<Guid> taskListId)
        {
            DateTime startDate = Katrin.AppFramework.Utils.Date.WeekBegin(recordDate);
            DateTime endDate = Katrin.AppFramework.Utils.Date.WeekEnd(recordDate);
            if (taskListId.Count <= 0) return null;
            CriteriaOperator filter = new BinaryOperator("RecordOn", startDate, BinaryOperatorType.GreaterOrEqual);
            filter &= new BinaryOperator("RecordOn", endDate, BinaryOperatorType.LessOrEqual);
            if (taskListId.Count > 0) filter &= new InOperator("TaskId", taskListId);

            
            return _objectSpace.GetBatchObjects("TaskTimeHistory", filter, null);
        }

        private string GetLocalizedPickListValue(string entityName, string attributeName, object objectValue)
        {
            if (objectValue == null) return string.Empty;
            int value = int.Parse(objectValue.ToString());
            var entity = MetadataRepository.Entities.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.First(a => a.PhysicalName == attributeName);
            if (attribute.OptionSet == null)
                return null;

            var pickListValue = attribute.OptionSet.AttributePicklistValues.FirstOrDefault(v => v.Value == value);
            if (pickListValue == null)
                return value.ToString(CultureInfo.InvariantCulture);
            var localizedLabels = MetadataRepository.LocalizedLabels
                .Where(l => l.ObjectId == pickListValue.AttributePicklistValueId);

            var localizedLabel = localizedLabels.FirstOrDefault(l => l.LanguageId == 1033) ?? //culture.LCID
                                 localizedLabels.First();
            return localizedLabel.Label;
        }
    }
}
