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
using Katrin.AppFramework.WinForms.Extensions;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;
using Katrin.AppFramework.Data;
using Katrin.AppFramework.Security;
namespace Katrin.Win.ProjectTaskModule.BatchEffort
{
    public class NewTaskEffortDetailController : ObjectDetailController
    {
        //[EventPublication("RefreshNewTaskEffort", PublicationScope.WorkItem)]
        //public event EventHandler OnRefreshNewTaskEffort;
        private INewTaskEffortDetailView _newEffortView;
        private List<TaskTimeHistory> _projectTaskList = new List<TaskTimeHistory>();
        public override string ObjectName
        {
            get
            {
                return "NewProjectTaskEffort";
            }
        }

        protected override bool OnSaving()
        {
            taskList.Clear();
            if (_projectTaskList != null)
            {

                foreach (var task in _projectTaskList)
                {
                    if (task.Overtime > task.Effort)
                    {
                        _newEffortView.ValidateResult = false;
                        XtraMessageBox.Show(StringParser.Parse("OverTimeTip"),
                            StringParser.Parse("Katrin"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    if (task.ActualInput == 0 && task.Effort > 0)
                    {
                        _newEffortView.ValidateResult = false;
                        XtraMessageBox.Show(StringParser.Parse("${res:ActualInputIsZero}"),
                            StringParser.Parse("${res:Katrin}"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    if (task.ActualInput == 0 && task.Effort == 0) continue;
                    if (!UpdateTask(task)) return false;
                    SetHistory(task);
                }
            }
            _newEffortView.ValidateResult = true;
            return true;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            BindData();
            //if (OnRefreshNewTaskEffort != null)
            //    OnRefreshNewTaskEffort(this, new EventArgs());
        }

        private void SetHistory(TaskTimeHistory task)
        {
            var taskTimeHistory = (Katrin.Domain.Impl.TaskTimeHistory)_objectSpace.GetOrNew("TaskTimeHistory", task.TaskTimeHistoryId,null);
            if (taskTimeHistory == null) return;
            task.TaskTimeHistoryId = taskTimeHistory.TaskTimeHistoryId;
            taskTimeHistory.TaskId = task.TaskId;
            taskTimeHistory.ActualInput = task.ActualInput;
            taskTimeHistory.Effort = task.Effort;
            taskTimeHistory.Overtime = task.Overtime;
            taskTimeHistory.Description = task.Description;
            taskTimeHistory.RecordOn = task.RecordOn;
        }
        List<Katrin.Domain.Impl.ProjectTask> taskList = new List<Domain.Impl.ProjectTask>();
        private bool UpdateTask(TaskTimeHistory task)
        {
            var projectTask = new Katrin.Domain.Impl.ProjectTask();
            if (taskList.Select(c=>c.TaskId).Contains(task.TaskId))
            {
                projectTask = taskList.Where(c=>c.TaskId == task.TaskId).First();
            }
            else
            {
                projectTask = (Katrin.Domain.Impl.ProjectTask)_objectSpace.GetOrNew("ProjectTask", task.TaskId, null);
                taskList.Add(projectTask);
            }
            projectTask.ActualInput = Convert.ToDouble(projectTask.ActualInput ?? 0) + task.ActualInput;
            projectTask.Effort = Convert.ToDouble(projectTask.Effort ?? 0) + task.Effort;
            if (task.TaskTimeHistoryId != Guid.Empty)
            {
                projectTask.Effort -= task.SourceEffort;
            }
            task.SourceEffort = task.Effort;
            projectTask.Overtime = Convert.ToDouble(projectTask.Overtime ?? 0) + task.Overtime;
            if (task.TaskTimeHistoryId == Guid.Empty)
                projectTask.Description = projectTask.Description ?? " " + task.Description;

            TaskOperator.UpdateTaskStatus(projectTask);

            if (projectTask.Effort > projectTask.ActualWorkHours)
            {
                _newEffortView.ValidateResult = false;
                XtraMessageBox.Show(StringParser.Parse("OverEffortMessage"),
                    StringParser.Parse("Katrin"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private void SinglePersonData()
        {
            var extraColumns = new Dictionary<string, string>
                                   {
                                       {"Project", "Project"}
                                   };
            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId, BinaryOperatorType.Equal);
            filter &= new BinaryOperator("StartDate", DateTime.Today, BinaryOperatorType.LessOrEqual);
            filter &= new BinaryOperator(new OperandProperty("ActualWorkHours"), new OperandProperty("Effort"), BinaryOperatorType.Greater);
            if (ObjectId != Guid.Empty)
            {
                filter &= new BinaryOperator("TaskId", ObjectId, BinaryOperatorType.Equal);
            }
            var ownerProjectTasks = _objectSpace.GetObjects("ProjectTask", filter, extraColumns) as IList;
            List<Guid> exsitsTaskIdList = new List<Guid>();
            if (ownerProjectTasks != null && ownerProjectTasks.AsQueryable().Count() > 0)
            {
                foreach (var task in ownerProjectTasks)
                {
                    TaskTimeHistory item = new TaskTimeHistory();
                    var projectTask = ConvertData.Convert<Katrin.Domain.Impl.ProjectTask>(task);
                    exsitsTaskIdList.Add(projectTask.TaskId);
                    item.TaskId = projectTask.TaskId;
                    item.Name = projectTask.Name;
                    item.ActualWorkHours = projectTask.ActualWorkHours??0;
                    item.RecordOn = DateTime.Today;
                    item.StartDate = projectTask.StartDate;
                    item.EndDate = projectTask.EndDate;
                    item.RemainderTime = (projectTask.ActualWorkHours??0) - (projectTask.Effort??0);
                    var exsitsItems = _projectTaskList.Where(c => c.TaskId == item.TaskId).ToList();
                    foreach (var eitem in exsitsItems)
                    {
                        eitem.RemainderTime = item.RemainderTime;
                    }

                    item.TaskTimeHistoryId = Guid.Empty;
                    item.RecordPerson = TaskOperator.GetUserName(AuthorizationManager.CurrentUserId);
                    if (projectTask.Project != null)
                    {
                        item.ProjectName = projectTask.Project.Name;
                    }
                    if(_projectTaskList.Any(c=>c.Effort == 0 && c.TaskTimeHistoryId == Guid.Empty
                        && c.ActualInput == 0 && c.TaskId == item.TaskId))
                    {
                        continue;
                    }
                    _projectTaskList.Insert(0, item);
                }
            }
            var notExsitsList = _projectTaskList.Where(c => !exsitsTaskIdList.Contains(c.TaskId)).ToList();
            foreach (var notItem in notExsitsList)
            {
                notItem.RemainderTime = 0;
            }
        }

        private void BindData()
        {
            SinglePersonData();
            _newEffortView.Bind(_projectTaskList);
        }

        protected override void OnViewSet()
        {
            if (!(_detailView is INewTaskEffortDetailView)) return;
            _newEffortView = (INewTaskEffortDetailView)_detailView;
            BindData();
            _newEffortView.ObjectChanged += View_ObjectChanged;
            HasChanges = false;
            var message = new UpdateRibbonItemMessage(this.WorkSpaceID,this.ObjectName);
            EventAggregationManager.SendMessage(message);
        }
    }
}
