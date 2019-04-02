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
    public class ManageEffortDetailPresenter : EntityDetailPresenter<IManageEffortDetailView>
    {
        private IList _users;
        private List<TaskTimeHistory> _projectTaskList = new List<TaskTimeHistory>();
        private List<TaskTimeHistory> _deleteTaskList = new List<TaskTimeHistory>();
        private bool _isManager = false;
        Dictionary<Guid, double> _taskList = new Dictionary<Guid, double>();
        private DateTime _filterBeginDate;
        private DateTime _filterEndDate;
        private string _filterprojectName = string.Empty;
        private string _filteriterationName = string.Empty;
        private string _filterrecordPerson = string.Empty;
        public ManageEffortDetailPresenter()
        {
            EntityName = "EditEffort";
        }

        #region save data
        protected override void OnSaving()
        {
            DeleteTaskHistory();
            if (_projectTaskList != null)
            {
                _taskList.Clear();
                foreach (var task in _projectTaskList)
                {
                    if (!_taskList.ContainsKey(task.TaskId)) _taskList.Add(task.TaskId, task.Effort - task.SourceEffort);
                    else _taskList[task.TaskId] += task.Effort - task.SourceEffort;
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
                    if (task.ActualInput == 0)
                    {
                        View.ValidateResult = false;
                        XtraMessageBox.Show(Properties.Resources.ActualInputIsZero,
                            Properties.Resources.Katrin,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        return;
                    }
                    SetHistory(task);
                }
            }
            if (!CheckTaskEffort()) return;
            View.ValidateResult = true;
        }

        protected override void OnSaved()
        {
            UpdateTask();
            DynamicDataServiceContext.SaveChanges();
        }

        private void DeleteTaskHistory()
        {
            foreach (var task in _deleteTaskList)
            {
                var taskTimeHistory = DynamicDataServiceContext.GetOrNew("TaskTimeHistory", task.TaskTimeHistoryId).AsDyanmic();
                taskTimeHistory.IsDeleted = true;
            }
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

        private bool CheckTaskEffort()
        {
            foreach (var taskId in _taskList.Keys)
            {
                var taskEntity = DynamicDataServiceContext.GetOrNew("ProjectTask", taskId);
                var taskDyanmic = taskEntity.AsDyanmic();
                double remainderTime = taskDyanmic.ActualWorkHours??0d - taskDyanmic.Effort??0d;
                if (_taskList[taskId] > remainderTime)
                {
                    View.ValidateResult = false;
                    XtraMessageBox.Show(Properties.Resources.OverEffortMessage,
                        Properties.Resources.Katrin,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            return true;
        }

        private void UpdateTask()
        {
            foreach (var taskId in _taskList.Keys)
            {
                var taskEntity = DynamicDataServiceContext.GetOrNew("ProjectTask", taskId, "TaskTimeHistories");
                var taskDyanmic = taskEntity.AsDyanmic();
                IList historyList = taskDyanmic.TaskTimeHistories as IList;
                historyList = historyList.AsQueryable().Where("IsDeleted=@0", false).ToArrayList();
                taskDyanmic.ActualInput = historyList.AsQueryable().Select("ActualInput").Cast<double?>().Sum();
                taskDyanmic.Effort = historyList.AsQueryable().Select("Effort").Cast<double?>().Sum();
                taskDyanmic.Overtime = historyList.AsQueryable().Select("Overtime").Cast<double?>().Sum();
                if (taskDyanmic.ActualWorkHours - taskDyanmic.Effort <= 0)
                {
                    taskDyanmic.StatusCode = 3;
                }
                else if (taskDyanmic.StatusCode == 1 || taskDyanmic.ActualWorkHours - taskDyanmic.Effort > 0)
                {
                    taskDyanmic.StatusCode = 2;
                }
            }
        }
        #endregion

        #region init history data
        private string GetUserName(Guid userId)
        {
            var user = _users.AsQueryable().Where("UserId = @0",userId)._First();
            return user.AsDyanmic().FullName;
        }

        private void HistoryData()
        {
            var projectList = DynamicDataServiceContext.GetObjects("Project", new BinaryOperator("ManagerId", AuthorizationManager.CurrentUserId), null);
            CriteriaOperator filter = new BinaryOperator("OwnerId", AuthorizationManager.CurrentUserId);
            if (projectList != null && projectList.Count > 0)
            {
                List<object> projectIds = new List<object>();
                foreach (var projectItem in projectList)
                {
                    projectIds.Add(projectItem.AsDyanmic().ProjectId);
                }
                filter = new InOperator("ProjectId", projectIds);
            }

            var managerExtraColumns = new Dictionary<string, string>
                                   {
                                       {"ProjectName", "Project == null?null:Project.Name"},
                                       {"IterationName", "ProjectIteration == null?null:ProjectIteration.Name"},
                                       {"TaskTimeHistories","TaskTimeHistories"}
                                   };
            var projectTasks = DynamicDataServiceContext.GetObjects("ProjectTask", filter, managerExtraColumns);
            foreach (var taskItem in projectTasks)
            {
                var taskDyanmic = taskItem.AsDyanmic();
                IList taskTimeHistoryList = taskDyanmic.TaskTimeHistories as IList;
                AddItems(taskTimeHistoryList, taskDyanmic);
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
                item.TaskId = taskDyanmic.TaskId;
                item.Name = taskDyanmic.Name;
                item.ProjectName = taskDyanmic.ProjectName;
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

        #region filter
        private void InitFilter()
        {
            string groupName = "taskFilter";
            RibbonPageGroup ribbonGroup = new RibbonPageGroup(GetLocalizedCaption("Filters"));
            var filterGroup = WorkItem.UIExtensionSites["DetailHomePage"].Add(ribbonGroup);
            ribbonGroup.Ribbon.AutoSizeItems = true;
            ribbonGroup.Ribbon.ItemsVertAlign = DevExpress.Utils.VertAlignment.Center;
            InitDateFilter(groupName, ribbonGroup);
            InitPersonFilter(groupName, ribbonGroup);
        }

      
        private void InitDateFilter(string groupName, RibbonPageGroup ribbonGroup)
        {
            BarEditItem beginDate = new BarEditItem();
            beginDate.Width = 100;
            beginDate.Caption = Properties.Resources.BeginDate;
            beginDate.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            if(beginDate.EditValue==null)
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
            ribbonGroup.ItemLinks.Add(beginDate,true);
            
            BarEditItem endDate = new BarEditItem();
            endDate.Width = 100;
            endDate.Caption = Properties.Resources.EndDate;
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

        private void InitPersonFilter(string groupName, RibbonPageGroup ribbonGroup)
        {
            if (!_isManager) return;
            BarEditItem recordPersonDrop = new BarEditItem();
            recordPersonDrop.Width = 100;
            recordPersonDrop.Caption = Properties.Resources.RecordPerson;
            recordPersonDrop.CaptionAlignment = DevExpress.Utils.HorzAlignment.Near;
            recordPersonDrop.EditValueChanged += (sender, e) =>
            {
                _filterrecordPerson = recordPersonDrop.EditValue.ToString();
                FilterTaskList();
            };
            RepositoryItemImageComboBox recordPersonItems = new RepositoryItemImageComboBox();
            var recordPersonList = _projectTaskList.Select(c => c.RecordPerson).Distinct<string>();
            recordPersonItems.Items.Add(new ImageComboBoxItem(Properties.Resources.None, string.Empty, -1));
            foreach (var recordPerson in recordPersonList)
            {
                recordPersonItems.Items.Add(new ImageComboBoxItem(recordPerson, recordPerson, -1));
            }
            recordPersonDrop.Edit = recordPersonItems;
            ribbonGroup.ItemLinks.Add(recordPersonDrop,true);
            FilterTaskList();
        }

        private void FilterTaskList()
        {
            InitData();
           if(!string.IsNullOrEmpty(_filterrecordPerson))
                _projectTaskList = _projectTaskList.Where(c => c.RecordPerson == _filterrecordPerson).ToList();
            if (_filterBeginDate != null && _filterEndDate != DateTime.MinValue)
                _projectTaskList = _projectTaskList.Where(c => c.RecordOn >= _filterBeginDate).ToList();
            if (_filterEndDate != null && _filterEndDate != DateTime.MinValue)
                _projectTaskList = _projectTaskList.Where(c => c.RecordOn <= _filterEndDate).ToList();
            View.Bind(_projectTaskList);
        }

        #endregion

        #region init data
        protected override void OnViewSet()
        {
            View.OnCreateData += OnCreateData;
            View.OnDeleteData += OnDeleteData;
            _users = DynamicDataServiceContext.GetObjects("User");
            InitData();
            InitFilter();
            View.Bind(_projectTaskList);
        }

        private void InitData()
        {
            _projectTaskList.Clear();
            HistoryData();
            _projectTaskList = _projectTaskList.Except(_deleteTaskList, new TaskTimeHistoryComparer()).ToList();
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

        [EventSubscription("RefreshNewTaskEffort", ThreadOption.UserInterface)]
        public void OnRefreshNewTaskEffort(object sender, EventArgs<Guid> e)
        {
            FilterTaskList();
        }
        #endregion
    }
}
