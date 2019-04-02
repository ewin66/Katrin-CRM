using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using Katrin.Win.Common;
using Katrin.Win.Common.Constants;
using Katrin.Win.Common.Core;
using Katrin.Win.Common.Security;
using Katrin.Win.Infrastructure;
using DevExpress.Data.Filtering;
using Microsoft.Practices.CompositeUI.EventBroker;
using System.Windows.Forms;

namespace Katrin.Win.MainModule.Views.ProjectTask
{
    public interface IProejctTaskFilter
    {
        Guid? ProjectId { get; set; }
        Guid? ProjectIterationId { get; set; }
        Guid? MemberId { get; set; }
        void BeginUpdate();
        void EndUpdate();

        void BindData();
        IActionContext Context { get; set; }
        void InitFilters();
        void BindProjectLookUp(List<LookupListItem<Guid?>> projects);
        void BindIterationLookUp(List<LookupListItem<Guid?>> iterations);
        void BindMemberLookUp(List<LookupListItem<Guid?>> members);
    }

    public class ProjectTaskLookBoardData
    {
        public string ProjectName { get; set; }
        public string ProjectIterationName { get; set; }
        public string Description { get; set; }
        public Color BgColor { get; set; }
        public string Name { get; set; }
        public Guid? TaskId { get; set; }
        public int StatusCode { get; set; }
        public string OwnerFullName { get; set; }
        public double? ActualWorkHours { get; set; }
        public double? Effort { get; set; }
    }

    public class ProjectTaskChartPresenter : ProjectTaskFilterPresenter<IProjectTaskChartView>
    {
        private IList _users;
        Dictionary<string, Color> _bgColorList = new Dictionary<string, Color>();
        List<Color> _colorList = new List<Color>()
            {
                Color.FromArgb(231, 231, 231),Color.FromArgb(0xA1,0xA1,0xA1),Color.FromArgb(0xB0,0xE2,0xFF),Color.FromArgb(0xC2,0xC2,0xC2),
                Color.FromArgb(0xD1,0xEE,0xEE),Color.FromArgb(0xBF,0xEF,0xFF),Color.FromArgb(0x7B,0x68,0xEE),Color.FromArgb(0xAB,0x82,0xFF),
                Color.FromArgb(0xFF,0xE4,0xC4),Color.FromArgb(0xFF,0xA5,0x00),Color.FromArgb(0xEE,0x82,0xEE),Color.FromArgb(0xCD,0x91,0x9E),
                Color.FromArgb(0xC1,0xCD,0xCD),Color.FromArgb(0x9A,0xC0,0xCD),Color.FromArgb(0xCC,0xCC,0xCC),Color.FromArgb(0x77,0x88,0x99)
            };
        protected override void OnViewSet()
        {
            base.OnViewSet();
            _users = DynamicDataServiceContext.GetObjects("User");
            View.OnStatusCodeChange += OnStatusCodeChange;
            View.OnEditItem += OnEditItem;
            View.InitEditors();
        }


        private void OnEditItem(object sender, EventArgs<object> e)
        {
            EditTask<ProjectTaskDetailView>(e.Data, "ProjectTask");
        }

        private void EditTask<T>(object task,string entityName) where T:AbstractDetailView
        {
            Guid taskId = task.AsDyanmic().TaskId;
            string key = taskId + entityName + ":DetailWorkItem";

            var detailWorkItem = WorkItem.Items.Get<RecordDetailController<T>>(key);

            if (detailWorkItem == null)
            {
                detailWorkItem = WorkItem.Items.AddNew<RecordDetailController<T>>(key);
                detailWorkItem.EntityName = entityName;
                detailWorkItem.Initialize();
            }
            detailWorkItem.State["EntityId"] = taskId;
            detailWorkItem.State["WorkingMode"] = EntityDetailWorkingMode.Edit;
            detailWorkItem.Run();
        }

        private IDynamicDataServiceContext _dynamicDataServiceContext;

        protected IDynamicDataServiceContext DynamicDataServiceContext
        {
            get { return _dynamicDataServiceContext ?? (_dynamicDataServiceContext = new DynamicDataServiceContext()); }
        }

        public void BindData()
        {
            var filterCriteria = View.Context.GetFilters();
            var query = GridViewExtension.CreateQuery(EntityName, filterCriteria,null);
            var worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += (s, e) =>
            {
                e.Result = query.ToList();
            };
            worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
            worker.RunWorkerAsync();
        }

        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            View.Context.BindingSource.DataSource = e.Result;
            BindTaskData();
        }

        private void BindTaskData()
        {
            BindingList<object> taskList = new BindingList<object>();
            
            foreach (var item in View.Context.BindingSource)
            {
                ProjectTaskLookBoardData boardData = new ProjectTaskLookBoardData();

                boardData.Name = item.AsDyanmic().Name;
                boardData.TaskId = item.AsDyanmic().TaskId;
                boardData.StatusCode = item.AsDyanmic().StatusCode;
                boardData.OwnerFullName = item.AsDyanmic().OwnerFullName;
                boardData.ActualWorkHours = item.AsDyanmic().ActualWorkHours;
                boardData.Effort = item.AsDyanmic().Effort;
                if (item.AsDyanmic().PriorityCode != null)
                    boardData.ProjectName = GetLocalizedPickListValue(EntityName, "PriorityCode", item.AsDyanmic().PriorityCode);
                boardData.ProjectIterationName = Properties.Resources.colSumEffort + ":" + item.AsDyanmic().Effort;
                boardData.Description = Properties.Resources.colSumQuoteWorkHours + ":" + item.AsDyanmic().ActualWorkHours;
                SetBackColor(boardData);
                taskList.Add(boardData);
            }
            View.BindTaskData(taskList);
        }

        private void SetBackColor(ProjectTaskLookBoardData boardData)
        {
            if (string.IsNullOrEmpty(boardData.OwnerFullName)) return;
            if (_bgColorList.Keys.Contains(boardData.OwnerFullName))
            {
                boardData.BgColor = _bgColorList[boardData.OwnerFullName];
            }
            else
            {
                boardData.BgColor = _colorList[_bgColorList.Count % 16];
                _bgColorList.Add(boardData.OwnerFullName, boardData.BgColor);
            }
        }


        private string GetLocalizedPickListValue(string entityName, string attributeName, int value)
        {
            var entity = MetadataProvider.Instance.EntiyMetadata.First(e => e.PhysicalName == entityName);
            var attribute = entity.Attributes.First(a => a.PhysicalName == attributeName);
            if (attribute.OptionSet == null)
                return null;

            var pickListValue = attribute.OptionSet.AttributePicklistValues.FirstOrDefault(v => v.Value == value);
            if (pickListValue == null)
                return value.ToString(CultureInfo.InvariantCulture);
            //throw new ApplicationException(string.Format("The property {0} of {1} doesn't have the value: {2}", attributeName, entityName, value));
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var localizedLabels = MetadataProvider.Instance.LocalizedLabels
                .Where(l => l.ObjectId == pickListValue.AttributePicklistValueId);

            var localizedLabel = localizedLabels.FirstOrDefault(l => l.LanguageId == culture.LCID) ??
                                 localizedLabels.First();
            return localizedLabel.Label;
        }

        private string EntityName
        {
            get { return "ProjectTask"; }
        }

        private void OnStatusCodeChange(object sender,EventArgs<object,int,int> e)
        {
            var fromStatus = e.Data2;
            var newStatus = e.Data3;
            
            var isTaskCompleted = fromStatus ==3 || fromStatus == 4;
            var attemptingComplete  = newStatus ==3 || fromStatus == 4;
            var hasRemaininWorks = e.Data1.AsDyanmic().ActualWorkHours > e.Data1.AsDyanmic().Effort;

            if (!isTaskCompleted && attemptingComplete && hasRemaininWorks)
            {
                Cursor.Current = Cursors.WaitCursor;
                EditTask<TaskEffortDetailView>(e.Data1, "ProjectTaskEffort");
                Cursor.Current = Cursors.Default;
            }
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += (ws, we) =>
                {
                    var entity = DynamicDataServiceContext.GetOrNew(EntityName, e.Data1.AsDyanmic().TaskId);
                    entity.StatusCode = newStatus;
                    DynamicDataServiceContext.SaveChanges();
                };
            bgWorker.RunWorkerAsync();
           

        }
    }
}
