using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Collections;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using Katrin.Win.Common.Controls;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.Data.Filtering;
using Katrin.Win.DetailViewModule;
using Katrin.Win.ProjectTaskModule.Common;
using ICSharpCode.Core;
using Katrin.AppFramework.Utils;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;
namespace Katrin.Win.ProjectTaskModule.AddEffort
{

    public class TaskEffortDetailController : ObjectDetailController
    {
        private ITaskEffortDetailView _taskEffortView;
        private List<TaskTimeHistory> _projectTaskList = new List<TaskTimeHistory>();
        private List<TaskTimeHistory> _deleteTaskList = new List<TaskTimeHistory>();
        private TaskTimeHistory _editTaskTimeHistory;
        private bool _isManager = false;
        List<Guid> _taskIdList = new List<Guid>();
        private DateTime _filterBeginDate;
        private DateTime _filterEndDate;
        private string _filterrecordPerson = string.Empty;
        public override string ObjectName
        {
            get
            {
                return "ProjectTaskEffort";
            }
        }

        #region save update
        protected override bool OnSaving()
        {
            if (_editTaskTimeHistory == null) return false;
            if (_editTaskTimeHistory.Overtime > _editTaskTimeHistory.Effort)
            {
                _taskEffortView.ValidateResult = false;
                XtraMessageBox.Show(StringParser.Parse("OverTimeTip"),
                    StringParser.Parse("Katrin"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            if (_editTaskTimeHistory.ActualInput ==0)
            {
                _taskEffortView.ValidateResult = false;
                XtraMessageBox.Show(StringParser.Parse("ActualInputIsZero"),
                    StringParser.Parse("Katrin"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return false;
            }

            dynamic taskEntity = _objectSpace.GetOrNew("ProjectTask", _editTaskTimeHistory.TaskId,null);
            if (!UpdateTask(taskEntity, _editTaskTimeHistory)) return false;
            SetHistory(_editTaskTimeHistory);
            _taskEffortView.ValidateResult = true;
            return true;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            InitData();
        }


        private void SetHistory(TaskTimeHistory task)
        {
            var taskTimeHistory = (Katrin.Domain.Impl.TaskTimeHistory)_objectSpace.GetOrNew("TaskTimeHistory", task.TaskTimeHistoryId,null);
            task.TaskTimeHistoryId = taskTimeHistory.TaskTimeHistoryId;
            taskTimeHistory.TaskId = task.TaskId;
            taskTimeHistory.ActualInput = task.ActualInput;
            taskTimeHistory.Effort = task.Effort;
            taskTimeHistory.Overtime = task.Overtime;
            taskTimeHistory.Description = task.Description;
            taskTimeHistory.RecordOn = task.RecordOn;
        }

        private bool UpdateTask(Katrin.Domain.Impl.ProjectTask taskEntity, TaskTimeHistory task)
        {
            if (taskEntity == null) return true;
            taskEntity.ActualInput = Convert.ToDouble(taskEntity.ActualInput ?? 0) + task.ActualInput;
            taskEntity.Effort = Convert.ToDouble(taskEntity.Effort ?? 0) + task.Effort;
            taskEntity.Overtime = Convert.ToDouble(taskEntity.Overtime ?? 0) + task.Overtime;

            TaskOperator.UpdateTaskStatus(taskEntity);

            if (taskEntity.Effort > taskEntity.ActualWorkHours)
            {
                _taskEffortView.ValidateResult = false;
                XtraMessageBox.Show(StringParser.Parse("OverEffortMessage"),
                    StringParser.Parse("Katrin"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }
        #endregion


        #region init task
        private void TaskData()
        {
            var taskExtraColumns = new Dictionary<string, string>
                                {
                                    {"Project", "Project"},
                                    {"ProjectIteration", "ProjectIteration"},
                                    {"TaskTimeHistories","TaskTimeHistories"}
                                };
            CriteriaOperator filter = new BinaryOperator("TaskId", ObjectId, BinaryOperatorType.Equal);
            var projectTasks = _objectSpace.GetObjects("ProjectTask", filter, taskExtraColumns);
            foreach (var taskItem in projectTasks)
            {
                var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(taskItem);
                var taskTimeHistoryList = projectTask.TaskTimeHistories.ToList();
                TaskOperator.AddTaskItems(taskTimeHistoryList, projectTask, _projectTaskList);
            }
            if (projectTasks.AsQueryable().Count() > 0 && _editTaskTimeHistory.TaskTimeHistoryId == Guid.Empty)
            {
                var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(projectTasks[0]);
                _editTaskTimeHistory.ProjectName = projectTask.Project == null ? string.Empty : projectTask.Project.Name;
                _editTaskTimeHistory.IterationName = projectTask.ProjectIteration == null?string.Empty:projectTask.ProjectIteration.Name;
                _editTaskTimeHistory.TaskId = projectTask.TaskId;
                _editTaskTimeHistory.Name = projectTask.Name;
                _editTaskTimeHistory.ActualWorkHours = projectTask.ActualWorkHours??0;
                _editTaskTimeHistory.RecordOn = DateTime.Today;
                _editTaskTimeHistory.RemainderTime = (projectTask.ActualWorkHours??0) - (projectTask.Effort??0);
                _editTaskTimeHistory.TaskTimeHistoryId = Guid.Empty;
                _editTaskTimeHistory.RecordPerson = TaskOperator.GetUserName(AuthorizationManager.CurrentUserId);
            }

        }
        #endregion


        #region init data
        protected override void OnViewSet()
        {
            if (!(_detailView is ITaskEffortDetailView)) return;
            _taskEffortView = (ITaskEffortDetailView)_detailView;
            _taskEffortView.OnCreateData += OnCreateData;
            _taskEffortView.OnDeleteData += OnDeleteData;
            _editTaskTimeHistory = new TaskTimeHistory();
            _editTaskTimeHistory.RecordOn = DateTime.Today;
            InitData();
            _taskEffortView.Bind(new List<TaskTimeHistory>() { _editTaskTimeHistory });
            _taskEffortView.ObjectChanged += View_ObjectChanged;
            HasChanges = false;
            var message = new UpdateRibbonItemMessage(this.WorkSpaceID, this.ObjectName);
            EventAggregationManager.SendMessage(message);
        }

        private void InitData()
        {
            _projectTaskList.Clear();
            TaskData();
            _projectTaskList = _projectTaskList.Except(_deleteTaskList, new TaskTimeHistoryComparer()).ToList();
            _taskEffortView.BindGrid(_projectTaskList);
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
            _taskEffortView.Bind(_projectTaskList);
        }

        private bool CheckSinglePersonData()
        {
            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId);
            filter &= new BinaryOperator("StartDate", DateTime.Today, BinaryOperatorType.LessOrEqual);
            filter &= new BinaryOperator(new OperandProperty("ActualWorkHours"), new OperandProperty("Effort"), BinaryOperatorType.Greater);
            if (ObjectId != Guid.Empty)
            {
                filter &= new BinaryOperator("TaskId", ObjectId);
            }
            var ownerProjectTasks = _objectSpace.GetObjects("ProjectTask", filter, null);

            if (ownerProjectTasks.AsQueryable().Count() <= 0)
            {
                XtraMessageBox.Show(StringParser.Parse("NoNewTaskMessage"), StringParser.Parse("Katrin"),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void OnCreateData(object sender, EventArgs e)
        {
            //if (!CheckSinglePersonData()) return;
            //string key = Guid.Empty + ":NewDetailWorkItem";

            //var detailWorkItem = WorkItem.RootWorkItem.Items.Get<RecordDetailController<NewTaskEffortDetailView>>(key);

            //if (detailWorkItem == null)
            //{
            //    detailWorkItem = WorkItem.RootWorkItem.Items.AddNew<RecordDetailController<NewTaskEffortDetailView>>(key);
            //    detailWorkItem.EntityName = "NewProjectTaskEffort";
            //    detailWorkItem.Initialize();
            //}
            //detailWorkItem.State["EntityId"] = EntityId;
            //detailWorkItem.State["WorkingMode"] = EntityDetailWorkingMode.Edit;
            //detailWorkItem.Run();
        }

        #endregion
    }
}
