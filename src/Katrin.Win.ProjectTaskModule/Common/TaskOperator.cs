using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Katrin.AppFramework;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.Security;
using Katrin.Domain.Impl;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using ICSharpCode.Core;

namespace Katrin.Win.ProjectTaskModule.Common
{
    public class TaskOperator
    {
        private static List<Katrin.Domain.Impl.User> _users;
        public static List<Katrin.Domain.Impl.User> Users
        {
            get
            {
                if (_users == null)
                {
                    IObjectSpace objectSpace = new ODataObjectSpace();
                    _users = (List<Katrin.Domain.Impl.User>)objectSpace.GetObjects("User");
                }
                return _users;
            }
        }

        public static string GetUserName(Guid userId)
        {
            var user = Users.Where(c => c.UserId == userId).FirstOrDefault();
            return user == null ? string.Empty : user.FullName;
        }

        public static bool HistoryData(IObjectSpace objectSpace, List<TaskTimeHistory> projectTaskList)
        {
            bool isManager = false;
            var projectList = (List<Katrin.Domain.Impl.Project>)objectSpace.GetObjects("Project", new BinaryOperator("ManagerId", AuthorizationManager.CurrentUserId), null);
            CriteriaOperator filter =null;
            if (projectList != null && projectList.Count > 0)
            {
                List<object> projectIds = new List<object>();
                foreach (var projectItem in projectList)
                {
                    projectIds.Add(projectItem.ProjectId);
                }
                filter = new InOperator("ProjectId", projectIds);
                isManager = true;
            }

            CriteriaOperator historyFilter = new BinaryOperator("CreatedById", AuthorizationManager.CurrentUserId, BinaryOperatorType.Equal);
            var taskTimeHistories = (List<Katrin.Domain.Impl.TaskTimeHistory>)objectSpace.GetObjects("TaskTimeHistory", historyFilter, null);
            if (taskTimeHistories.Count <= 0 && !isManager)
                return isManager;
            historyFilter = new InOperator("TaskId", taskTimeHistories.Select(c => c.TaskId).ToList());
            if (isManager)
            {
                filter |= historyFilter;
            }
            else
            {
                filter = historyFilter;
            }

            var managerExtraColumns = new Dictionary<string, string>
                                   {
                                       {"Project", "Project"},
                                       {"ProjectIteration", "ProjectIteration"},
                                       {"TaskTimeHistories","TaskTimeHistories"}
                                   };
            var projectTasks = objectSpace.GetBatchObjects("ProjectTask", filter, managerExtraColumns);
            foreach (var taskItem in projectTasks)
            {
                Katrin.Domain.Impl.ProjectTask task = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(taskItem);
                var historyList = task.TaskTimeHistories.ToList();
                if (!isManager) historyList = historyList.Where(c => c.CreatedById == AuthorizationManager.CurrentUserId).ToList();
                AddTaskItems(historyList, task, projectTaskList);
            }
            return isManager;
        }

        public static void AddTaskItems(List<Katrin.Domain.Impl.TaskTimeHistory> taskTimeHistoryList,
            Katrin.Domain.Impl.ProjectTask projectTask, List<TaskTimeHistory> projectTaskList)
        {
            taskTimeHistoryList = taskTimeHistoryList.Where(c => c.IsDeleted == false).OrderBy(c => c.RecordOn).ToList();
            foreach (var historyItemObject in taskTimeHistoryList)
            {
                TaskTimeHistory item = new TaskTimeHistory();
                item.TaskId = projectTask.TaskId;
                item.Name = projectTask.Name;
                item.ProjectName = projectTask.Project == null ? string.Empty : (projectTask.Project.Name ?? string.Empty);
                item.ActualWorkHours = projectTask.ActualWorkHours ?? 0;
                item.RecordOn = historyItemObject.RecordOn ?? DateTime.Today;
                item.ActualInput = historyItemObject.ActualInput ?? 0;
                item.Description = historyItemObject.Description;
                item.Effort = historyItemObject.Effort ?? 0;
                item.SourceEffort = item.Effort;
                item.Overtime = historyItemObject.Overtime ?? 0;
                item.RemainderTime = (projectTask.ActualWorkHours ?? 0) - (projectTask.Effort ?? 0);
                item.TaskTimeHistoryId = historyItemObject.TaskTimeHistoryId;
                item.RecordPerson = GetUserName(historyItemObject.CreatedById ?? Guid.Empty);
                projectTaskList.Add(item);
            }
        }


        public static bool CheckTaskEffort(IObjectSpace objectSpace, Dictionary<Guid, double> _taskList)
        {
            foreach (var taskId in _taskList.Keys)
            {
                var taskEntity = (Katrin.Domain.Impl.ProjectTask)objectSpace.GetOrNew("ProjectTask", taskId, null);
                double remainderTime = (taskEntity.ActualWorkHours ?? 0d) - (taskEntity.Effort ?? 0d);
                if (_taskList[taskId] > remainderTime)
                {
                    XtraMessageBox.Show(StringParser.Parse("OverEffortMessage"),
                        StringParser.Parse("Katrin"),
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            return true;
        }

        public static void UpdateTaskStatus(ProjectTask taskEntity)
        {
            if (taskEntity.ActualWorkHours - taskEntity.Effort <= 0)
            {
                taskEntity.StatusCode = 3;
                if (taskEntity.EndDate == null) taskEntity.EndDate = DateTime.Today;
                if (taskEntity.StartDate == null) taskEntity.StartDate = DateTime.Today;
            }
            else if (taskEntity.StatusCode == 1 || taskEntity.ActualWorkHours - taskEntity.Effort > 0)
            {
                taskEntity.StatusCode = 2;
                if (taskEntity.StartDate == null) taskEntity.StartDate = DateTime.Today;
                if (taskEntity.EndDate != null && taskEntity.EndDate < DateTime.Today)
                    taskEntity.EndDate = null;
            }
        }

    }
}
