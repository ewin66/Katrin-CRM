using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using Katrin.Win.Common.Core;
using Microsoft.Practices.CompositeUI.EventBroker;
using Katrin.Win.Common.Constants;
using System.Collections;
using Katrin.Win.Common.Security;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using Katrin.Win.Infrastructure;
using DevExpress.XtraBars.Ribbon;
using Katrin.Win.Common.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Filtering;

namespace Katrin.Win.MainModule.Views.ProjectTask
{

    public class TaskTimeHistoryComparer : IEqualityComparer<TaskTimeHistory>
    {
        public bool Equals(TaskTimeHistory x, TaskTimeHistory y)
        {
            return x.TaskTimeHistoryId == y.TaskTimeHistoryId;
        }

        public int GetHashCode(TaskTimeHistory obj)
        {
            if (Object.ReferenceEquals(obj, null))
                return 0;
            return obj.TaskTimeHistoryId.GetHashCode();
        }
    }



    public class TaskTimeHistory
    {
        public Guid TaskTimeHistoryId { get; set; }
        public Guid TaskId { get; set; }
        public string RecordPerson { get; set; }
        public string IterationName { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
        public DateTime RecordOn { get; set; }
        public double ActualWorkHours { get; set; }
        public double ActualInput { get; set; }
        public double Effort { get; set; }
        public double SourceEffort { get; set; }
        public double Overtime { get; set; }
        public double RemainderTime { get; set; }
        public string Description { get; set; }
    }

    public class TaskEffortDetailPresenter : EntityDetailPresenter<ITaskEffortDetailView>
    {
        private IList _users;
        private List<TaskTimeHistory> _projectTaskList = new List<TaskTimeHistory>();
        private List<TaskTimeHistory> _deleteTaskList = new List<TaskTimeHistory>();
        private TaskTimeHistory _editTaskTimeHistory;
        private bool _isManager = false;
        List<Guid> _taskIdList = new List<Guid>();
        private DateTime _filterBeginDate;
        private DateTime _filterEndDate;
        private string _filterrecordPerson = string.Empty;
        public TaskEffortDetailPresenter()
        {
            EntityName = "ProjectTaskEffort";
        }

        #region save update
        protected override void OnSaving()
        {
            if (_editTaskTimeHistory == null) return;
            if (_editTaskTimeHistory.Overtime > _editTaskTimeHistory.Effort)
            {
                View.ValidateResult = false;
                XtraMessageBox.Show(Properties.Resources.OverTimeTip,
                    Properties.Resources.Katrin,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return;
            }
            if (_editTaskTimeHistory.ActualInput ==0)
            {
                View.ValidateResult = false;
                XtraMessageBox.Show(Properties.Resources.ActualInputIsZero,
                    Properties.Resources.Katrin,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return;
            }

            dynamic taskEntity = DynamicDataServiceContext.GetOrNew("ProjectTask", _editTaskTimeHistory.TaskId);
            if (!UpdateTask(taskEntity, _editTaskTimeHistory)) return;
            SetHistory(_editTaskTimeHistory);
            View.ValidateResult = true;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            InitData();
        }


        private void SetHistory(TaskTimeHistory task)
        {
            var taskTimeHistory = DynamicDataServiceContext.GetOrNew("TaskTimeHistory", task.TaskTimeHistoryId).AsDyanmic();
            task.TaskTimeHistoryId = taskTimeHistory.TaskTimeHistoryId;
            taskTimeHistory.TaskId = task.TaskId;
            taskTimeHistory.ActualInput = task.ActualInput;
            taskTimeHistory.Effort = task.Effort;
            taskTimeHistory.Overtime = task.Overtime;
            taskTimeHistory.Description = task.Description;
            taskTimeHistory.RecordOn = task.RecordOn;
        }

        private bool UpdateTask(dynamic entity, TaskTimeHistory task)
        {
            if (entity == null) return true;
            entity.ActualInput = Convert.ToDouble(entity.ActualInput ?? 0) + task.ActualInput;
            entity.Effort = Convert.ToDouble(entity.Effort ?? 0) + task.Effort;
            entity.Overtime = Convert.ToDouble(entity.Overtime ?? 0) + task.Overtime;
            if (entity.ActualWorkHours - entity.Effort <= 0)
            {
                entity.StatusCode = 3;
            }
            else if (entity.StatusCode == 1 || entity.ActualWorkHours - entity.Effort > 0)
            {
                entity.StatusCode = 2;
            }
            if (entity.Effort > entity.ActualWorkHours)
            {
                View.ValidateResult = false;
                XtraMessageBox.Show(Properties.Resources.OverEffortMessage,
                    Properties.Resources.Katrin,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }
        #endregion


        #region init task
        private string GetUserName(Guid userId)
        {
            var user = _users.AsQueryable().Where("UserId = @0", userId)._First();
            return user.AsDyanmic().FullName;
        }

        private void TaskData()
        {
            var taskExtraColumns = new Dictionary<string, string>
                                {
                                    {"ProjectName", "Project == null?null:Project.Name"},
                                    {"IterationName", "ProjectIteration == null?null:ProjectIteration.Name"},
                                    {"TaskTimeHistories","TaskTimeHistories"}
                                };
            CriteriaOperator filter = new BinaryOperator("TaskId", EntityId, BinaryOperatorType.Equal);
            var projectTasks = DynamicDataServiceContext.GetObjects("ProjectTask", filter, taskExtraColumns);
            foreach (var taskItem in projectTasks)
            {
                var taskDyanmic = taskItem.AsDyanmic();
                IList taskTimeHistoryList = taskDyanmic.TaskTimeHistories as IList;
                AddItems(taskTimeHistoryList, taskDyanmic);
            }
            if (projectTasks.AsQueryable().Count() > 0 && _editTaskTimeHistory.TaskTimeHistoryId == Guid.Empty)
            {
                var taskDyanmic = projectTasks.AsQueryable()._First().AsDyanmic();
                _editTaskTimeHistory.ProjectName = taskDyanmic.ProjectName;
                _editTaskTimeHistory.IterationName = taskDyanmic.IterationName;
                _editTaskTimeHistory.TaskId = taskDyanmic.TaskId;
                _editTaskTimeHistory.Name = taskDyanmic.Name;
                _editTaskTimeHistory.ActualWorkHours = taskDyanmic.ActualWorkHours;
                _editTaskTimeHistory.RecordOn = DateTime.Today;
                _editTaskTimeHistory.RemainderTime = taskDyanmic.ActualWorkHours - taskDyanmic.Effort;
                _editTaskTimeHistory.TaskTimeHistoryId = Guid.Empty;
                _editTaskTimeHistory.RecordPerson = GetUserName(AuthorizationManager.CurrentUserId);
            }

        }

        private void AddItems(IList taskTimeHistoryList, dynamic taskDyanmic)
        {
            taskTimeHistoryList = taskTimeHistoryList.AsQueryable().Where("IsDeleted=false").OrderBy("RecordOn desc").ToArrayList();
            foreach (var historyItemObject in taskTimeHistoryList)
            {
                _isManager = true;
                var historyItem = historyItemObject.AsDyanmic();
                TaskTimeHistory item = new TaskTimeHistory();
                item.ProjectName = taskDyanmic.ProjectName;
                item.IterationName = taskDyanmic.IterationName;
                item.TaskId = taskDyanmic.TaskId;
                item.Name = taskDyanmic.Name;
                item.ActualWorkHours = taskDyanmic.ActualWorkHours;
                item.RecordOn = historyItem.RecordOn;
                item.ActualInput = historyItem.ActualInput;
                item.Description = historyItem.Description;
                item.Effort = historyItem.Effort;
                item.SourceEffort = item.Effort;
                item.Overtime = historyItem.Overtime;
                item.RemainderTime = taskDyanmic.ActualWorkHours - taskDyanmic.Effort;
                item.TaskTimeHistoryId = historyItem.TaskTimeHistoryId;
                item.RecordPerson = GetUserName(historyItem.CreatedById);
                _projectTaskList.Add(item);
            }
        }
        #endregion


        #region init data
        protected override void OnViewSet()
        {
            View.OnCreateData += OnCreateData;
            View.OnDeleteData += OnDeleteData;
            _users = DynamicDataServiceContext.GetObjects("User");
            _editTaskTimeHistory = new TaskTimeHistory();
            _editTaskTimeHistory.RecordOn = DateTime.Today;
            InitData();
            View.Bind(new List<TaskTimeHistory>() { _editTaskTimeHistory });
        }

        private void InitData()
        {
            _projectTaskList.Clear();
            TaskData();
            _projectTaskList = _projectTaskList.Except(_deleteTaskList, new TaskTimeHistoryComparer()).ToList();
            View.BindGrid(_projectTaskList);
        }

        private void OnDeleteData(object sender, EventArgs<int> e)
        {
            if (_projectTaskList.Count <= e.Data) return;
            TaskTimeHistory task = _projectTaskList[e.Data];
            if (task == null) return;
            if (task.TaskTimeHistoryId != Guid.Empty)
            {
                _deleteTaskList.Add(task);
            }
            _projectTaskList.Remove(task);
            View.Bind(_projectTaskList);
        }

        private bool CheckSinglePersonData()
        {
            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId);
            filter &= new BinaryOperator("StartDate", DateTime.Today, BinaryOperatorType.LessOrEqual);
            filter &= new BinaryOperator(new OperandProperty("ActualWorkHours"), new OperandProperty("Effort"), BinaryOperatorType.Greater);
            if (EntityId != Guid.Empty)
            {
                filter &= new BinaryOperator("TaskId", EntityId);
            }
            var ownerProjectTasks = DynamicDataServiceContext.GetObjects("ProjectTask", filter, null);

            if (ownerProjectTasks.AsQueryable().Count() <= 0)
            {
                XtraMessageBox.Show(Properties.Resources.NoNewTaskMessage, Properties.Resources.Katrin,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void OnCreateData(object sender, EventArgs e)
        {
            if (!CheckSinglePersonData()) return;
            string key = Guid.Empty + ":NewDetailWorkItem";

            var detailWorkItem = WorkItem.RootWorkItem.Items.Get<RecordDetailController<NewTaskEffortDetailView>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = WorkItem.RootWorkItem.Items.AddNew<RecordDetailController<NewTaskEffortDetailView>>(key);
                detailWorkItem.EntityName = "NewProjectTaskEffort";
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = EntityId;
            detailWorkItem.State["WorkingMode"] = EntityDetailWorkingMode.Edit;
            detailWorkItem.Run();
        }

        #endregion
    }
}
