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
    public class NewTaskEffortDetailPresenter : EntityDetailPresenter<INewTaskEffortDetailView>
    {
        [EventPublication("RefreshNewTaskEffort", PublicationScope.WorkItem)]
        public event EventHandler OnRefreshNewTaskEffort;

        private IList _users;
        private List<TaskTimeHistory> _projectTaskList = new List<TaskTimeHistory>();
        public NewTaskEffortDetailPresenter()
        {
            EntityName = "NewProjectTaskEffort";
        }

        protected override void OnSaving()
        {
            if (_projectTaskList != null)
            {
                foreach (var task in _projectTaskList)
                {
                    if (task.Overtime > task.Effort)
                    {
                        View.ValidateResult = false;
                        XtraMessageBox.Show(Properties.Resources.OverTimeTip,
                            Properties.Resources.Katrin,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }
                    if (task.ActualInput != 0)
                    { SetHistory(task); }
                    if (!UpdateTask(task)) return;
                }
            }
            View.ValidateResult = true;
        }

        protected override void OnSaved()
        {
            base.OnSaved();
            if (OnRefreshNewTaskEffort != null)
                OnRefreshNewTaskEffort(this, new EventArgs());
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

        private bool UpdateTask(TaskTimeHistory task)
        {
            var entityOjbect = DynamicDataServiceContext.GetOrNew("ProjectTask", task.TaskId);
            var entity = entityOjbect.AsDyanmic();
            entity.ActualInput = Convert.ToDouble(entity.ActualInput ?? 0) + task.ActualInput;
            entity.Effort = Convert.ToDouble(entity.Effort ?? 0) + task.Effort;
            entity.Overtime = Convert.ToDouble(entity.Overtime ?? 0) + task.Overtime;
            if (task.TaskTimeHistoryId == Guid.Empty)
                entity.Description = entity.Description ?? " " + task.Description;
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

        private string GetUserName(Guid userId)
        {
            var user = _users.AsQueryable().Where("UserId = @0", userId)._First();
            return user.AsDyanmic().FullName;
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
            if (EntityId != Guid.Empty)
            {
                filter &= new BinaryOperator("TaskId", EntityId, BinaryOperatorType.Equal);
            }
            var ownerProjectTasks = DynamicDataServiceContext.GetObjects("ProjectTask", filter, extraColumns);
            if (ownerProjectTasks != null && ownerProjectTasks.ToArrayList().Count > 0)
            {
                foreach (var task in ownerProjectTasks)
                {
                    TaskTimeHistory item = new TaskTimeHistory();
                    var dyanmic = task.AsDyanmic();

                    item.TaskId = dyanmic.TaskId;
                    item.Name = dyanmic.Name;
                    item.ActualWorkHours = dyanmic.ActualWorkHours;
                    item.RecordOn = DateTime.Today;
                    item.RemainderTime = dyanmic.ActualWorkHours - dyanmic.Effort;
                    item.TaskTimeHistoryId = Guid.Empty;
                    item.RecordPerson = GetUserName(AuthorizationManager.CurrentUserId);
                    if (dyanmic.Project != null)
                    {
                        item.ProjectName = dyanmic.Project.Name;
                    }
                    _projectTaskList.Insert(0, item);
                }
            }
        }

        protected override void OnViewSet()
        {
            _users = DynamicDataServiceContext.GetObjects("User").ToArrayList();
            SinglePersonData();
            View.Bind(_projectTaskList);
        }
    }
}
