using System;
using System.Collections.Generic;
using System.Linq;
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
using Katrin.AppFramework.WinForms.Controller;
using Katrin.Win.ProjectTaskModule.Common;
using Katrin.AppFramework.Utils;
using ICSharpCode.Core;
using Katrin.AppFramework.Security;
using Katrin.AppFramework.WinForms.Workspaces;
using Katrin.AppFramework.WinForms.Messages;
using Katrin.AppFramework;

namespace Katrin.Win.ProjectTaskModule.EditEffort
{
    public class ManageEffortDetailController : ObjectDetailController
    {
        private IManageEffortDetailView _effortDetailView;
        private List<TaskTimeHistory> _projectTaskList = new List<TaskTimeHistory>();
        private List<TaskTimeHistory> _deleteTaskList = new List<TaskTimeHistory>();
        private bool _isManager = false;
        Dictionary<Guid, double> _taskList = new Dictionary<Guid, double>();
        private DateTime _filterBeginDate;
        private DateTime _filterEndDate;
        private string _filterprojectName = string.Empty;
        private string _filteriterationName = string.Empty;
        private string _filterrecordPerson = string.Empty;
        private RibbonControl _ribbon;
        public override string ObjectName
        {
            get
            {
                return "EditEffort";
            }
        }

        protected override string RibbonPath
        {
            get
            {
                return "/EditEffort/Detail/Ribbon";
            }
        }
        public ManageEffortDetailController()
        {
           
        }
        public override AppFramework.WinForms.MVC.IActionResult Execute(AppFramework.WinForms.MVC.ActionParameters parameters)
        {
            _ribbon = parameters.Get<RibbonControl>("ribbonControl");
            return base.Execute(parameters);
        }

        #region save data
        protected override bool OnSaving()
        {
            _taskList.Clear();
            DeleteTaskHistory();
            if (_projectTaskList != null)
            {
                foreach (var task in _projectTaskList)
                {
                    if (!_taskList.ContainsKey(task.TaskId)) _taskList.Add(task.TaskId, task.Effort - task.SourceEffort);
                    else _taskList[task.TaskId] += task.Effort - task.SourceEffort;
                    if (task.Overtime > task.Effort)
                    {
                        _effortDetailView.ValidateResult = false;
                        XtraMessageBox.Show(StringParser.Parse("${res:OverTimeTip}"),
                            StringParser.Parse("${res:Katrin}"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    if (task.ActualInput == 0)
                    {
                        _effortDetailView.ValidateResult = false;
                        XtraMessageBox.Show(StringParser.Parse("${res:ActualInputIsZero}"),
                            StringParser.Parse("${res:Katrin}"),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        return false;
                    }
                    SetHistory(task);
                }
            }
            if (!TaskOperator.CheckTaskEffort(_objectSpace, _taskList))
            {
                _effortDetailView.ValidateResult = false;
                return false;
            }
            _effortDetailView.ValidateResult = true;
            return true;
        }

        protected override void OnSaved()
        {
            UpdateTask();
            _objectSpace.SaveChanges();
            _deleteTaskList.Clear();
            FilterTaskList();
            _effortDetailView.Bind(_projectTaskList);
        }

        private void DeleteTaskHistory()
        {
            foreach (var task in _deleteTaskList)
            {
                var taskTimeHistory = (Katrin.Domain.Impl.TaskTimeHistory)_objectSpace.GetOrNew("TaskTimeHistory", task.TaskTimeHistoryId,null);
                taskTimeHistory.IsDeleted = true;
                if (!_taskList.ContainsKey(task.TaskId)) _taskList.Add(task.TaskId, -task.SourceEffort);
                else
                    _taskList[task.TaskId] -= task.SourceEffort;
            }
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

       

        private void UpdateTask()
        {
            foreach (var taskId in _taskList.Keys)
            {
                var taskEntity = (Katrin.Domain.Impl.ProjectTask)_objectSpace.GetOrNew("ProjectTask", taskId, "TaskTimeHistories");
                var historyList =  taskEntity.TaskTimeHistories.ToList();
                historyList = historyList.Where(c=>c.IsDeleted==false).ToList();
                taskEntity.ActualInput = historyList.Select(c=>c.ActualInput).Cast<double?>().Sum();
                taskEntity.Effort = historyList.Select(c=>c.Effort).Cast<double?>().Sum();
                taskEntity.Overtime = historyList.Select(c=>c.Overtime).Cast<double?>().Sum();
                TaskOperator.UpdateTaskStatus(taskEntity);
            }
        }
        #endregion

        #region filter
        private void InitFilter()
        {
            string groupName = "taskFilter";
            RibbonPageGroup ribbonGroup = new RibbonPageGroup(StringParser.Parse("${res:Filters}"));
            RibbonControl ribbon = this._ribbon;
            ribbon.Pages[0].Groups.Add(ribbonGroup);
            ribbonGroup.Ribbon.AutoSizeItems = true;
            ribbonGroup.Ribbon.ItemsVertAlign = DevExpress.Utils.VertAlignment.Center;
            InitDateFilter(groupName, ribbonGroup);
            InitPersonFilter(groupName, ribbonGroup);
            FilterTaskList();
        }


        private void InitDateFilter(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem beginDate = new BarEditItem();
            beginDate.Width = 100;
            beginDate.Caption = StringParser.Parse("${res:BeginDate}");
            beginDate.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            if (beginDate.EditValue == null)
            {
                beginDate.EditValue = DateTime.Now.Date;
                _filterBeginDate = Convert.ToDateTime(beginDate.EditValue);
            }


            beginDate.EditValueChanged += (sender, e) =>
            {
                _filterBeginDate = Convert.ToDateTime(beginDate.EditValue);
                FilterTaskList();
            };
            RepositoryItemDateEdit begindateValue = new RepositoryItemDateEdit();
            beginDate.Edit = begindateValue;
            ribbonGroup.ItemLinks.Add(beginDate, true);

            BarEditItem endDate = new BarEditItem();
            endDate.Width = 100;
            endDate.Caption = StringParser.Parse("${res:EndDate}");
            endDate.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            if (endDate.EditValue == null)
            {
                endDate.EditValue = DateTime.Now;
                _filterEndDate = Convert.ToDateTime(endDate.EditValue);
            }

            endDate.EditValueChanged += (sender, e) =>
            {
                _filterEndDate = Convert.ToDateTime(endDate.EditValue);
                FilterTaskList();
            };
            RepositoryItemDateEdit enddateValue = new RepositoryItemDateEdit();
            endDate.Edit = enddateValue;
            ribbonGroup.ItemLinks.Add(endDate);

        }

        RepositoryItemImageComboBox recordPersonItems = null;
        private void InitPersonFilter(string groupName, RibbonPageGroup ribbonGroup)
        {
            if (!_isManager) return;
            BarEditItem recordPersonDrop = new BarEditItem();
            recordPersonDrop.Width = 100;
            recordPersonDrop.Caption = StringParser.Parse("${res:RecordPerson}");
            recordPersonDrop.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            recordPersonDrop.EditValueChanged += (sender, e) =>
            {
                _filterrecordPerson = recordPersonDrop.EditValue.ToString();
                FilterTaskList();
            };
            recordPersonItems = new RepositoryItemImageComboBox();
            BindPersons();
            recordPersonDrop.Edit = recordPersonItems;
            ribbonGroup.ItemLinks.Add(recordPersonDrop, true);
            FilterTaskList();
        }

        private void BindPersons()
        {
            if (recordPersonItems == null) return;
            recordPersonItems.Items.Clear();
            var recordPersonList = _projectTaskList.Select(c => c.RecordPerson).Distinct<string>();
            recordPersonItems.Items.Add(new ImageComboBoxItem(StringParser.Parse("None"), string.Empty, -1));
            foreach (var recordPerson in recordPersonList)
            {
                recordPersonItems.Items.Add(new ImageComboBoxItem(recordPerson, recordPerson, -1));
            }
        }

        private void FilterTaskList()
        {
            InitData();
            if (!string.IsNullOrEmpty(_filterrecordPerson))
                _projectTaskList = _projectTaskList.Where(c => c.RecordPerson == _filterrecordPerson).ToList();
            if (_filterBeginDate != null && _filterBeginDate != DateTime.MinValue)
                _projectTaskList = _projectTaskList.Where(c => c.RecordOn >= _filterBeginDate).ToList();
            if (_filterEndDate != null && _filterEndDate != DateTime.MaxValue)
                _projectTaskList = _projectTaskList.Where(c => c.RecordOn <= _filterEndDate).ToList();
            _projectTaskList = _projectTaskList.OrderByDescending(c => c.RecordOn).ToList();
            _effortDetailView.Bind(_projectTaskList);
        }

        #endregion

        #region init data
        protected override void OnViewSet()
        {
            if (!(_detailView is IManageEffortDetailView)) return;
            _effortDetailView = (IManageEffortDetailView)_detailView;
            _effortDetailView.OnDeleteData += OnDeleteData;
            FilterTaskList();
            InitFilter();
            _effortDetailView.Bind(_projectTaskList);
            _effortDetailView.ObjectChanged += View_ObjectChanged;
            HasChanges = false;
            var message = new UpdateRibbonItemMessage(this.WorkSpaceID, this.ObjectName);
            EventAggregationManager.SendMessage(message);
        }

        private void InitData()
        {
            _projectTaskList.Clear();
            _isManager = TaskOperator.HistoryData(_objectSpace, _projectTaskList);
            _projectTaskList = _projectTaskList.Except(_deleteTaskList, new TaskTimeHistoryComparer()).ToList();
            BindPersons();
        }

        private void OnDeleteData(object sender, EventArgs<int> e)
        {
            if (_projectTaskList.Count <= e.Data) return;
            if (e.Data < 0) return;
            TaskTimeHistory task = _projectTaskList[e.Data];
            if (task == null) return;
            if (task.TaskTimeHistoryId != Guid.Empty)
            {
                _deleteTaskList.Add(task);
            }
            _projectTaskList.Remove(task);
            _effortDetailView.Bind(_projectTaskList);
        }
        #endregion

        public void Refresh()
        {
            if (!(_detailView is IManageEffortDetailView)) return;
            _effortDetailView = (IManageEffortDetailView)_detailView;
            _projectTaskList.Clear();
            _effortDetailView.Bind(_projectTaskList);
            FilterTaskList();
            _effortDetailView.Bind(_projectTaskList);
        }
    }
}
